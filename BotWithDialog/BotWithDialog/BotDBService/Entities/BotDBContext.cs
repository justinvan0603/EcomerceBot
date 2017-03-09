using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDBService.Entities
{
    class BotDBContext : DbContext
    {
        public BotDBContext() : base("BotDBConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<BOT_ANSWER> BOT_ANSWER { get; set; }
        public virtual DbSet<BOT_CUSTOMERINFO> BOT_CUSTOMERINFO { get; set; }
        public virtual DbSet<BOT_DOMAIN> BOT_DOMAIN { get; set; }
        public virtual DbSet<BOT_QUESTIONTYPE> BOT_QUESTIONTYPE { get; set; }
        public virtual DbSet<BOT_SCENARIO> BOT_SCENARIO { get; set; }
        public virtual DbSet<BOT_USER> BOT_USER { get; set; }
        public virtual DbSet<BOT_QUESTION> BOT_QUESTION { get; set; }
        public virtual DbSet<BOT_FORMTYPE> BOT_FORMTYPE { get; set; }
    }
}
