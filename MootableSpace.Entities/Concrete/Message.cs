using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Concrete
{
    public class Message : EntityBase<int>, IEntity
    {
        public int SenderId { get; set; }//Mesajı gönderen User'ın Id'si.
        public string Text { get; set; }//Mesaj içeriği(text).
        public string? Picture { get; set; }//Mesaj içeriği(fotoğraf).

        public string getEntityName()
        {
            return "Mesaj";
        }
    }
}
