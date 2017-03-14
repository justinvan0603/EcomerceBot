using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotDBService.Entities
{

    public class BOT_USER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int USERID { get; set; }
        [StringLength(50)]
        public string USERNAME { get; set; }
        [StringLength(100)]
        public string PASSWORD { get; set; }
        public Nullable<int> RECORD_STATUS { get; set; }
        public Nullable<int> DOMAIN_ID { get; set;}
        [StringLength(100)]
        public string DOMAIN_NAME { get; set; }
    }
}
