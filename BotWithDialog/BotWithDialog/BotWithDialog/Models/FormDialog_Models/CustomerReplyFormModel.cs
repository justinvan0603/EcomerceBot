using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotWithDialog.Models.FormDialog_Models
{
    [Serializable]
    public class CustomerReplyFormModel
    {
        public Nullable<int> CUSTOMER_ID { get; set; }
        public Nullable<int> QUESTION_ID { get; set; }
        public Nullable<int> DOMAIN_ID { get; set; }

        public string DOMAIN_NAME { get; set; }
        [Prompt("Câu trả lời của bạn:")]
        public string CONTENT { get; set; }

        public DateTime? REPLY_TIME { get; set; }

        public static IForm<CustomerReplyFormModel> BuildForm()
        {

            return new FormBuilder<CustomerReplyFormModel>()

                .Field(nameof(CONTENT))

                .Build();

        }

    }
}