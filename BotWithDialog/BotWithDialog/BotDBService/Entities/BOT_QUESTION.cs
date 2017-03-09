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
    public class BOT_QUESTION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QUESTION_ID { get; set; }
        public string CONTENT { get; set; }
        public Nullable<int> QUESTION_TYPE { get; set; }
        public Nullable<int> SCENARIO_ID { get; set; }
        public Nullable<int> DOMAIN_ID { get; set; }
        public string DOMAIN_NAME { get; set; }
        public Nullable<int> PREVQUESTION_ID { get; set; }
        public Nullable<bool> IS_END { get; set; }
        public Nullable<int> RECORD_STATUS { get; set; }
        public Nullable<int> PREVANSWER_ID { get; set; }
        public override string ToString()
        {
            return CONTENT;
        }
    }
}
