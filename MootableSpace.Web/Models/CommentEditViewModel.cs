namespace MootableSpace.Web.Models
{
    public class CommentEditViewModel
    {
        public int Id { get; set; }
        public int MootId { get; set; }//yorum yapılan ilgili moot veya mootable Id'si.
        /// <summary>
        /// Herhangi bir yorumun altına yapıldıysa Parent yorumun Id'si
        /// Direkt Moot veya Mootable altına yapıldıysa Parent Id'si yorumun kendi Id'sidir.
        /// </summary>
        public int? ParentId { get; set; }
        public int UserId { get; set; }//yorumu yapan user.
        public string Text { get; set; }//yorum içeriği
        public int ViewCount { get; set; }//yorumun görüntülenme sayısı.
        public int AgreeCount { get; set; }// yoruma katılanların sayısı.
    }
}
