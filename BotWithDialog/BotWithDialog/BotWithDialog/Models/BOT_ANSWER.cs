//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BotWithDialog.Models
{
    using System;
    using System.Collections.Generic;
    [Serializable]
    public partial class BOT_ANSWER
    {
        public int ANSWER_ID { get; set; }
        public string CONTENT { get; set; }
        public Nullable<int> QUESTION_ID { get; set; }
        public Nullable<int> NEXTANSWER_ID { get; set; }
        public Nullable<bool> IS_END { get; set; }
        public Nullable<int> RECORD_STATUS { get; set; }
    }
}
