using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BotDBService.Entities
{
    public class BOT_CONVERSATIONCONTENT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public Nullable<int> CONVERSATION_ID { get; set; }
        public Nullable<int> QUESTION_ID { get; set; }
        [StringLength(500)]
        public string QUESTION { get; set; }
        public Nullable<int> ANSWER_ID { get; set; }
        [StringLength(500)]
        public string ANSWER { get; set; }
        public Nullable<DateTime> CREATE_DT { get; set; }
        public Nullable<int> RECORD_STATUS { get; set; }
    }
}
