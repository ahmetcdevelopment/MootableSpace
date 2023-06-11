using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Dtos
{
    public class MootDto:IDto
    {
        public int Id { get; set; }
        //public int CategoryId { get; set; }//paylaşılan moot hangi kategoriye ait.
        public string CategoryName { get; set; }
        //public int UserId { get; set; }// paylaşılan moot hangi kullanıcıya ait.
        public string UserName { get; set; }
        public string Text { get; set; }// moot içeriğindeki yazı
        public string? Picture { get; set; }//moot içeriğindeki fotoğraf veya fotoğraflar.
        public DateTime ShareDate { get; set; } // moot hangi tarihte paylaşıldı.
        public int ShareStatus { get; set; } // herkes, circle, sadece ben
        public int ViewCount { get; set; }// moot'un görüntülenme sayısı.
        public int AgreeCount { get; set; }// kaç kişi katılıyor.
        public int CommentCount { get; set; }//moot'a kaç kişi yorum yaptı?
    }
}
