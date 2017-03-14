using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDBService.Entities
{
    public class BOT_CUSTOMERREPLY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int REPID { get; set; }
        public Nullable<int> CUSTOMER_ID { get; set; }
        public Nullable<int> QUESTION_ID { get; set; }
        public Nullable<int> DOMAIN_ID { get; set; }
        [StringLength(100)]
        public string DOMAIN_NAME { get; set; }
        [StringLength(500)]
        public string CONTENT { get; set; }
        public DateTime? REPLY_TIME { get; set; }
    }
}
