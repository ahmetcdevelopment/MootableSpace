using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Concrete
{
    public class Moot : EntityBase<int>, IEntity
    {
        public int CategoryId { get; set; }//paylaşılan moot hangi kategoriye ait.
        public int UserId { get; set; }// paylaşılan moot hangi kullanıcıya ait.
        public string Text { get; set; }// moot içeriğindeki yazı
        public string? Picture { get; set; }//moot içeriğindeki fotoğraf veya fotoğraflar.
        public DateTime ShareDate { get; set; } // moot hangi tarihte paylaşıldı.
        public int ShareStatus { get; set; } // herkes, circle, sadece ben
        public int ViewCount { get; set; }// moot'un görüntülenme sayısı.
        public int AgreeCount { get; set; }// kaç kişi katılıyor.
        public int CommentCount { get; set; }//moot'a kaç kişi yorum yaptı?

        public string getEntityName()
        {
            return "Moot";
        }
    }
}
