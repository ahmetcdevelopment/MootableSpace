using Microsoft.AspNetCore.Mvc.Rendering;

namespace MootableSpace.Web.Models
{
    public class MootEditViewModel
    {
        public SelectList Categories { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }//paylaşılan moot hangi kategoriye ait.
        public int UserId { get; set; }// paylaşılan moot hangi kullanıcıya ait.
        public string Text { get; set; }// moot içeriğindeki yazı
        public string? Picture { get; set; }//moot içeriğindeki fotoğraf veya fotoğraflar.
        public DateTime ShareDate { get; set; } // moot hangi tarihte paylaşıldı.
        public int ShareStatus { get; set; } // herkes, circle, sadece ben
        public int ViewCount { get; set; }// moot'un görüntülenme sayısı.
        public int AgreeCount { get; set; }// kaç kişi katılıyor.
        public int CommentCount { get; set; }//moot'a kaç kişi yorum yaptı?
    }
}
