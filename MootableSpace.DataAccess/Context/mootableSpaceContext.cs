using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mootableProject.Shared.Data.Concrete.Mappings;
using mootableProject.Shared.Entities.Concrete;
using MootableSpace.DataAccess.Mappings;
using MootableSpace.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.DataAccess.Context
{
    public class mootableSpaceContext:IdentityDbContext
        <User,Role,int,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {
        public mootableSpaceContext(DbContextOptions<mootableSpaceContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageRecipient> MessageRecipients { get; set; }
        public DbSet<Moot> Moots { get; set; }
        public DbSet<Mootable> Mootables { get; set; }
        public DbSet<MootableSubscriber> MootableSubscribers { get; set; }
        public DbSet<MootCircle> MootCircles { get; set; }
        public DbSet<MootCircleRequest> MootCircleRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CommentMap());
            builder.ApplyConfiguration(new MessageMap());
            builder.ApplyConfiguration(new MessageRecipientMap());
            builder.ApplyConfiguration(new MootableMap());
            builder.ApplyConfiguration(new MootableSubscriberMap());
            builder.ApplyConfiguration(new MootCircleMap());
            builder.ApplyConfiguration(new MootCircleRequestMap());
            builder.ApplyConfiguration(new MootMap());
            builder.ApplyConfiguration(new NotificationMap());
            builder.ApplyConfiguration(new RoleMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new RoleClaimMap());
            builder.ApplyConfiguration(new UserClaimMap());
            builder.ApplyConfiguration(new UserLoginMap());
            builder.ApplyConfiguration(new UserRoleMap());
            builder.ApplyConfiguration(new UserTokenMap());
            //builder.ApplyConfiguration(new LogMap());
        }

    }
}
