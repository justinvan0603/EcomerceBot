using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BotDBService.Entities
{
    public class BOT_CUSTOMERINFO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CUSTOMER_ID { get; set; }

        public Nullable<int> DOMAIN_ID { get; set; }
        public string DOMAIN_NAME { get; set; }
        public string NAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }

        public Nullable<int> RECORD_STATUS { get; set; }
    }
}
