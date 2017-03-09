using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BotWithDialog.Models;
using System.Threading;

using Microsoft.Bot.Builder.FormFlow;

namespace BotWithDialog.Dialog
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {

        private  BuildFormDelegate<Models.BOT_CUSTOMERINFO> MakeCustomerInfoForm;

        internal void CustomerInfoDialog(BuildFormDelegate<Models.BOT_CUSTOMERINFO> makeCustomerInfoForm)
        {
            
            this.MakeCustomerInfoForm = makeCustomerInfoForm;
            
        }

        public async Task StartAsync(IDialogContext context)
        {

            //   string Url = context.ConversationData.Get<string>("ServiceUrl");

            context.Wait(MessageReceiveAsync);
           // var message = await activity;
            //BotDBEntities DbContext = new BotDBEntities();
            //List<BOT_QUESTION> listFirstQuestion = DbContext.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == null && question.PREVANSWER_ID == null).ToList();

            //PromptDialog.Choice(context, this.ResumeAfterFirst, listFirstQuestion, "", "Không hợp lệ", 3, PromptStyle.Auto);
        }
        public async Task MessageReceiveAsync(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
           // await context.PostAsync("Chào mừng bạn đã đến với Website của chúng tôi");
            var message = await activity;

           // List<BotDBService.Entities.BOT_SCENARIO> listScenario = DAO_SCENARIO.BOT_SCENARIO_GetByDomain(null, message.ServiceUrl).ToList();



           // List<BotDBService.Entities.BOT_QUESTION> listFirstQuestion = DAO_QUESTION.BOT_QUESTION_GetListFirstQuestionByScenario(listScenario[0].SCENARIO_ID).ToList();


            BotDBEntities DbContext = new BotDBEntities();
            List<BOT_QUESTION> listFirstQuestion =  DbContext.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == null && question.PREVANSWER_ID == null).ToList();
            await this.ShowListQuestion(context,listFirstQuestion);
            //PromptDialog.Choice(context, this.ResumeAfterFirst, listFirstQuestion, "Click chuột để chọn:", "Không hợp lệ", 3, PromptStyle.Auto);
            // await context.PostAsync("You said " + message.Text);
            //   PromptDialog.Confirm(context, ResumeAfterConfirm, "Choose the one");

        }
        
        private async Task ShowListQuestion(IDialogContext context, List<BOT_QUESTION> listQuestion)
        {
            PromptDialog.Choice(context, this.ResumeAfterChooseQuestion, listQuestion, "Click chuột để chọn:", "Không hợp lệ", 3, PromptStyle.Auto);
        }

        private async Task ShowListAnswer(IDialogContext context, List<BOT_ANSWER> listAnswer)
        {

            //PromptDialog.Choice(context, this.ResumeAfterChooseAnswer, listAnswer, "Click chuột để chọn:", "Không hợp lệ", 3, PromptStyle.AutoText);
            if(listAnswer.All(answer => answer.IS_END.Value == true))
            {
                foreach(var item in listAnswer)
                {
                    await context.PostAsync(item.CONTENT);
                }
                BotDBEntities DbContext = new BotDBEntities();
                await context.PostAsync("Nếu bạn có thắc mắc gì mời bạn chọn tiếp các câu hỏi");
                List<BOT_QUESTION> listFirstQuestion = DbContext.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == null && question.PREVANSWER_ID == null).ToList();

                await this.ShowListQuestion(context, listFirstQuestion);
               // PromptDialog.Choice(context, this.ResumeAfterFirst, listFirstQuestion, "Click chuột để chọn:", "Không hợp lệ", 3, PromptStyle.Auto);

            }
            
        }
        public async Task ResumeAfterChooseQuestion(IDialogContext context, IAwaitable<BOT_QUESTION> result)
        {
            var value = await result;
            if(value != null)
            {
                BotDBEntities DbContext = new BotDBEntities();
                if(DbContext.BOT_ANSWER.Any(answer => answer.QUESTION_ID == value.QUESTION_ID))
                {
                    List<BOT_ANSWER> ListAnswer = DbContext.BOT_ANSWER.Where(answer => answer.QUESTION_ID == value.QUESTION_ID).ToList();
                    await ShowListAnswer(context, ListAnswer);
                    //PromptDialog.Choice(context, this.ResumeAfterChooseAnswer,ListAnswer, "Click để chọn:", "Không hợp lệ", 3, PromptStyle.Auto);
                }
                if(DbContext.BOT_QUESTION.Any(question => question.PREVQUESTION_ID == value.QUESTION_ID))
                {
                    List<BOT_QUESTION> ListQuestion = DbContext.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == value.QUESTION_ID).ToList();
                    await this.ShowListQuestion(context, ListQuestion);
                }
                if(value.QUESTION_TYPE.Value == 1)
                {
                    var customerInfoForm = new FormDialog<Models.BOT_CUSTOMERINFO>(new Models.BOT_CUSTOMERINFO(), MakeCustomerInfoForm, FormOptions.PromptInStart);
                    context.Call(customerInfoForm, CustomerInfoFormCompleted);

                }

            }
            else
            {

                context.Wait(this.MessageReceiveAsync);
            }

        }
        public async Task CustomerInfoFormCompleted(IDialogContext context,IAwaitable<Models.BOT_CUSTOMERINFO> result )
        {
            var value = await result;
            if(value != null)
            {
                await context.PostAsync($"Cảm ơn bạn {value.NAME} đã cung cấp thông tin. Chúng tội sẽ chủ động liên lạc với bạn");
                
                context.Wait(MessageReceiveAsync);
            }
            
        }
        public async Task ResumeAfterChooseAnswer(IDialogContext context, IAwaitable<BOT_ANSWER> result)
        {
            var value = await result;
            if(value != null)
            {
                BotDBEntities DbContext = new BotDBEntities();
                if(DbContext.BOT_ANSWER.Any(answer => answer.ANSWER_ID == value.NEXTANSWER_ID))
                {
                    List<BOT_ANSWER> ListAnswer = DbContext.BOT_ANSWER.Where(answer => answer.ANSWER_ID == value.NEXTANSWER_ID).ToList();
                    await ShowListAnswer(context, ListAnswer);
                 
                }
                if(DbContext.BOT_QUESTION.Any(question=> question.PREVANSWER_ID == value.ANSWER_ID))
                {
                    List<BOT_QUESTION> ListQuestion = DbContext.BOT_QUESTION.Where(question => question.PREVANSWER_ID == value.ANSWER_ID).ToList();
                    await ShowListQuestion(context, ListQuestion);
                }
                
            }

        }
        //public async Task ResumeAfterFirst(IDialogContext context ,IAwaitable<BOT_QUESTION> result )
        //{
        //    var value = await result;
        //    if (value != null)
        //    {
        //        BotDBEntities DbContext = new BotDBEntities();

        //        if (DbContext.BOT_QUESTION.Any(question => question.PREVQUESTION_ID == value.QUESTION_ID))
        //        {
        //            List<BOT_QUESTION> listQuestion = DbContext.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == value.QUESTION_ID).ToList();
        //           await ShowListQuestion(context, listQuestion);

        //        }
        //        if (value.QUESTION_TYPE.Value == 1)
        //        {
        //            var customerInfoForm = new FormDialog<Models.FormDialog_Models.CustomerInfoFormModel>(new Models.FormDialog_Models.CustomerInfoFormModel(), MakeCustomerInfoForm, FormOptions.PromptInStart);
                    
        //            context.Call(customerInfoForm, CustomerInfoFormCompleted);
        //        }

        //    }
        //    else
        //    {

        //        context.Wait(this.MessageReceiveAsync);
        //    }

        //}
        //public async Task ResumeAfterChoose(IDialogContext context, IAwaitable<object> result)
        //{
        //    context.Wait(this.MessageReceiveAsync);
        //}
        //private void ShowOptions(IDialogContext context)
        //{
        //    List<Option> ListOptions = Option.CreateListOption();

        //    PromptDialog.Choice(context, this.OnOptionSelected, ListOptions, "Are you looking for a flight or a hotel?", "Not a valid option", 3,PromptStyle.Auto);
        //}
        //private async Task OnOptionSelected(IDialogContext context, IAwaitable<Option> result)
        //{
        //    try
        //    {

        //        Option optionSelected = await result;

        //        switch (optionSelected.Text )
        //        {
        //            case "A":
        //                {
        //                    await context.PostAsync($"You've choose {optionSelected.ID}");
        //                    context.Call(new RootDialog(), this.ResumeAfterChoose);
        //                    break;
        //                }
        //            default: { context.Wait(MessageReceiveAsync); break; }
        //        }
        //    }
        //    catch (TooManyAttemptsException ex)
        //    {
        //        await context.PostAsync($"Ooops! Too many attemps :(. But don't worry, I'm handling that exception and you can try again!");

        //        context.Wait(this.MessageReceiveAsync);
        //    }
        //}


    }
}