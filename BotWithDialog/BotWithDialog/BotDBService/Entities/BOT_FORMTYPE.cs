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
        [StringLength(100)]
        public string FORM_NAME { get; set; }
        [StringLength(100)]
        public string DESCRIPTION { get; set; }
        public Nullable<int> DOMAIN_ID { get; set; }
        [MaxLength(100)]
        public string DOMAIN_NAME { get; set; }
    }
}
