using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Concrete
{
    public class MootableSubscriber : EntityBase<int>, IEntity
    {
        public int MootableId { get; set; }
        public int CategoryId { get; set; }//mootable hangi kategoriye ait.
        public int UserId { get; set; } // mootable masasını hangi user oluşturdu.
        public int ShareStatus { get; set; }// herkese açık, circle, özel.
        public string Description { get; set; }//mootable açıklaması

        public string getEntityName()
        {
            return "Mootable abonesi";
        }
    }
}
