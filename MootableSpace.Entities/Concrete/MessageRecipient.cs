using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Concrete
{
    public class MessageRecipient : EntityBase<int>, IEntity
    {
        public int MessageId { get; set; }// İlgili mesajın Id'si.
        public int RecipientId { get; set; }// İlgili mesajı alan User'ın Id'si.
        public bool IsShow { get; set; }// İlgili kullanıcı ilgili mesajı gördü mü?

        public string getEntityName()
        {
            return "Mesaj isteği";
        }
    }
}
