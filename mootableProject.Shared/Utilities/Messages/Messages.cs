using mootableProject.Shared.Entities.Abstract;
using mootableProject.Shared.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Messages
{
    public class Messages<TEntity> where TEntity : class, IEntity, new()
    {
        private static TEntity Entity { get; set; } = new TEntity();
        private static MessageStatus EntityStatus { get; set; }
        private static string EntityName { get; set; }
        private static string Verb { get; set; }
        private static string Decoration { get; set; }
        private static bool IsPositive { get; set; }

        public string Text { get; set; }
        public Messages(MessageStatus status, bool isPositive)
        {
            EntityName = Entity.getEntityName();
            EntityStatus = status;
            IsPositive = isPositive;
            Verb = GetVerbByStatus();
            Decoration = GetDecoration();
            Text = $"{EntityName} {Decoration} {Verb}!";
        }
        private string GetVerbByStatus()
        {
            if (EntityStatus == MessageStatus.Add && IsPositive) Verb = "eklendi";
            if (EntityStatus == MessageStatus.Add && !IsPositive) Verb = "eklenemedi";

            if (EntityStatus == MessageStatus.Update && IsPositive) Verb = "güncellendi";
            if (EntityStatus == MessageStatus.Update && !IsPositive) Verb = "güncellenemedi";

            if (EntityStatus == MessageStatus.Delete && IsPositive) Verb = "silindi";
            if (EntityStatus == MessageStatus.Delete && !IsPositive) Verb = "silinemedi";

            if (EntityStatus == MessageStatus.Send && IsPositive) Verb = "gönderildi";
            if (EntityStatus == MessageStatus.Send && !IsPositive) Verb = "gönderilemedi";

            if (EntityStatus == MessageStatus.Share && IsPositive) Verb = "paylaşıldı";
            if (EntityStatus == MessageStatus.Share && !IsPositive) Verb = "paylaşılamadı";

            if (EntityStatus == MessageStatus.Get && IsPositive) Verb = "bulundu";
            if (EntityStatus == MessageStatus.Get && !IsPositive) Verb = "bulunamadı";
            return Verb;
        }
        private string GetDecoration()
        {
            if (IsPositive)
            {
                Decoration = "başarıyla";
            }
            else
            {
                Decoration = "malesef";
            }
            return Decoration;
        }
    }
}
