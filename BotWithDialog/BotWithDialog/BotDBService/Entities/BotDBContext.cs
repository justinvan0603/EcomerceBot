using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDBService.Entities
{
    public class BotDBContext : DbContext
    {
        public BotDBContext() : base("BotDBConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Properties<string>().Configure(unicode => unicode.HasColumnType("NVARCHAR"));
            modelBuilder.Entity<BOT_ANSWER>().Property(answer => answer.CONTENT).HasMaxLength(500);
            modelBuilder.Entity<BOT_QUESTION>().Property(question => question.DOMAIN_NAME).IsOptional();
            modelBuilder.Entity<BOT_DOMAIN>().Property(domain => domain.DOMAIN).IsOptional();
            modelBuilder.Entity<BOT_FORMTYPE>().Property(form => form.DOMAIN_NAME).IsOptional();
            modelBuilder.Entity<BOT_CUSTOMERINFO>().Property(customer => customer.DOMAIN_NAME).IsOptional();
            modelBuilder.Entity<BOT_SCENARIO>().Property(customer => customer.DOMAIN_NAME).IsOptional();
            modelBuilder.Entity<BOT_USER>().Property(user => user.USERNAME).IsOptional();
            modelBuilder.Entity<BOT_USER>().Property(user => user.PASSWORD).IsOptional();
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
        public virtual DbSet<BOT_CUSTOMERREPLY> BOT_CUSTOMERREPLY { get; set; }
    }
}
