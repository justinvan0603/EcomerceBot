using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BotDBService.Entities;
namespace BotWithDialog.Models.FormDialog_Models
{
    [Serializable]
    public class CustomerInfoFormModel
    {
        
        [Prompt("Tên của bạn:")]
        
        public string NAME { get; set; }
        [Prompt("E-mail của bạn:")]
        [Pattern(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
+ "@"
+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")]
        public string EMAIL { get; set; }
        [Prompt("Số điện thoại của bạn:")]

        public string PHONE { get; set; }

        private BotDBService.Entities.BOT_QUESTION _question;
        public BotDBService.Entities.BOT_QUESTION GetQuestion()
        {
            return _question;
        }
        public CustomerInfoFormModel()
        {
            
        }
        public CustomerInfoFormModel(BotDBService.Entities.BOT_QUESTION question)
        {
            _question = question;
        }
        public static IForm<CustomerInfoFormModel> BuildForm()
        {

            return new FormBuilder<CustomerInfoFormModel>()
              
                .Field(nameof(NAME))

                .Field(nameof(EMAIL))
         
                .Field(nameof(PHONE))
         
                .Build();

        }
    }
}