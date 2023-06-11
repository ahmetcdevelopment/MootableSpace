using mootableProject.Shared.Entities.Dtos;
using mootableProject.Shared.Results.Abstract;

namespace MootableSpace.Web.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> UploadUserImage
            (string userName, IFormFile pictureFile, string folderName = "userImages");
        /// <summary>
        /// Kullanacağım methodlar senkron olacağı için metodun asenkron olmasına gerek yok.
        /// </summary>
        /// <param name="pictureName"></param>
        /// <returns></returns>
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
