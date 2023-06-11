using mootableProject.Shared.Entities.Dtos;
using mootableProject.Shared.Results.Abstract;
using mootableProject.Shared.Results.ComplexTypes;
using mootableProject.Shared.Results.Concrete;
using mootableProject.Shared.Utilities.Extensions;
using MootableSpace.Web.Helpers.Abstract;

namespace MootableSpace.Web.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string wwwroot;
        private readonly string imgFolder = "img";

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            wwwroot = _env.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> Delete(string pictureName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/", pictureName);
            if (File.Exists(fileToDelete))
            {
                //FileInfo'nun çalışabilmesi için dosyayı bulmak gerekiyor.
                var fileInfo = new FileInfo(fileToDelete);
                //o yüzden burada fileInfo'daki bilgileri yedekliyorum.
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = pictureName,
                    Extensions = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
            }
            return new DataResult<ImageDeletedDto>(ResultStatus.Error, $"Böyle bir resim bulunamadı.", null);
        }

        public async Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages")
        {
            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");
            }
            //~/img/username olarak kaydedeceğim.
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtensions = Path.GetExtension(pictureFile.FileName);
            var dateTime = DateTime.Now;
            string newFileName = $"{userName}_{dateTime.FullDateAndTimeStringWithUnderScore()}{fileExtensions}";
            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }
            ///<summary>
            ///dosyayı şu şekilde kaydedecek ahmetciftci_564_5_38_1_4_23.png
            /// </summary>
            return new DataResult<ImageUploadedDto>(ResultStatus.Success,
                $"{userName} adlı kullanıcının resmi başarıyla güncellenmiştir.", new ImageUploadedDto
                {
                    FullName = $"{folderName}/{newFileName}",
                    OldName = oldFileName,
                    Extension = fileExtensions,
                    FolderName = folderName,
                    Path = path,
                    Size = pictureFile.Length
                });

        }
    }
}
