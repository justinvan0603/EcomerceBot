using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotWithDialog.Models.FormDialog_Models
{
    [Serializable]
    public class CustomerInfoFormModel
    {
        [Prompt("Cho chúng tôi biết tên của bạn:")]
        public string NAME { get; set; }
        [Prompt("Cho chúng tôi biết E-mail của bạn:")]
        [Pattern(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
+ "@"
+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")]
        public string EMAIL { get; set; }
        [Prompt("Cho chúng tôi biết số điện thoại của bạn:")]
        public string PHONE { get; set; }
        public int ID { get; set; }
        public static IForm<CustomerInfoFormModel> BuildForm()
        {

            return new FormBuilder<CustomerInfoFormModel>()
                .Message("Lets create a New Lead")
                .Field(new FieldReflector<CustomerInfoFormModel>(nameof(ID)).SetActive((state)=>false))
                .Field(nameof(NAME))
                .Field(nameof(EMAIL))
                .Field(nameof(PHONE))
                .Field(nameof(EMAIL))
                
                .Build();

        }
    }
}