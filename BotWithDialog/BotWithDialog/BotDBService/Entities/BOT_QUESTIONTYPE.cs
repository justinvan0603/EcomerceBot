using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDBService.Entities
{
    public class BOT_QUESTIONTYPE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QUESTIONTYPE_ID { get; set; }
        [StringLength(100)]
        public string QUESTION_TYPE { get; set; }
        public Nullable<int> RECORD_STATUS { get; set; }
    }
}
