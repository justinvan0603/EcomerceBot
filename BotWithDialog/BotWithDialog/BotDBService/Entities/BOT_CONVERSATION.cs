using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDBService.Entities
{
    [Serializable]
    public class BOT_CONVERSATION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public Nullable<int> DOMAIN_ID { get; set; }
        [StringLength(100)]
        public string DOMAIN_NAME { get; set; }
        public Nullable<int> CUSTOMER_ID { get; set; }
        [StringLength(100)]
        public string CUSTOMER_NAME { get; set; }

        public Nullable<DateTime> CREATE_DT { get; set; }
        public Nullable<int> RECORD_STATUS { get; set; }
    }
}
