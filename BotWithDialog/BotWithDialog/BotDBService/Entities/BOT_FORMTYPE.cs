using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDBService.Entities
{
    public class BOT_FORMTYPE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FORM_ID { get; set; }

        public string FROM_NAME { get; set; }

        public Nullable<int> DOMAIN_ID { get; set; }
        public string DOMAIN_NAME { get; set; }
    }
}
