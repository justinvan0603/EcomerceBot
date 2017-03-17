using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BotDBService.Entities;
using BotDBService.DAO;
using System.Threading;
using Microsoft.Bot.Builder.FormFlow;
using BotWithDialog.Models.FormDialog_Models;

namespace BotWithDialog.Dialog
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {

        //private  BuildFormDelegate<Models.FormDialog_Models.CustomerInfoFormModel> MakeCustomerInfoForm;

        //internal void CustomerInfoDialog(BuildFormDelegate<Models.FormDialog_Models.CustomerInfoFormModel> makeCustomerInfoForm)
        //{
            
        //    this.MakeCustomerInfoForm = makeCustomerInfoForm;
            
        //}

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceiveAsync);
            
           
        }
        public async Task MessageReceiveAsync(IDialogContext context, IAwaitable<IMessageActivity> activity)
        {
            // await context.PostAsync("Chào mừng bạn đã đến với Website của chúng tôi");
            var message = await activity;
            
            
            //<--**--Bao gio chay thuc te thi mo dong nay ra--**-->
            //BOT_DOMAIN domain = DAO_DOMAIN.GetById(null, message.ServiceUrl);
            //context.PrivateConversationData.SetValue<int>("DOMAIN_ID", domain.DOMAIN_ID);
            //context.PrivateConversationData.SetValue<string>("DOMAIN_NAME", message.ServiceUrl);
            //  List<BotDBService.Entities.BOT_SCENARIO> listScenario = DAO_SCENARIO.BOT_SCENARIO_GetByDomain(null, message.ServiceUrl).ToList();

            

            List<BotDBService.Entities.BOT_QUESTION> listFirstQuestion = DAO_QUESTION.BOT_QUESTION_GetListFirstQuestionByScenario(1).ToList();
            await this.ShowListQuestion(context,listFirstQuestion);


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
                if (listAnswer.Any(answer => answer.ANSWER_ID == -1))
                {
                    var target = listAnswer.Single(answers => answers.ANSWER_ID == -1);
                    listAnswer.Remove(target);
                }
                foreach (var item in listAnswer)
                {
                    await context.PostAsync(item.CONTENT);
                }
          
                //BotDBEntities DbContext = new BotDBEntities();
                await context.PostAsync("***Cảm ơn bạn đã trò chuyện. Nếu bạn có thắc mắc mời bạn chọn tiếp các câu hỏi***");
                List<BOT_QUESTION> listFirstQuestion = DAO_QUESTION.BOT_QUESTION_GetListFirstQuestionByScenario(1).ToList();
                //List<BOT_QUESTION> listFirstQuestion = DbContext.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == null && question.PREVANSWER_ID == null).ToList();
                context.PrivateConversationData.Clear();

                await this.ShowListQuestion(context, listFirstQuestion);
               //PromptDialog.Choice(context, this.ResumeAfterFirst, listFirstQuestion, "Click chuột để chọn:", "Không hợp lệ", 3, PromptStyle.Auto);

            }
            else
            {
                
                PromptDialog.Choice(context, this.ResumeAfterChooseAnswer, listAnswer, "Click chuột để chọn:", "Không hợp lệ", 3, PromptStyle.Auto);
            }
            
        }
        public async Task ShowPreviousSelectionFromCurrentQuestion(IDialogContext context, BOT_QUESTION currentQuestion)
        {
            if(currentQuestion.PREVQUESTION_ID != null)
            {
                //List<BOT_QUESTION> listPrevQuestion = DAO_QUESTION.BOT_QUESTION_GetByPrevQuestionId(currentQuestion.PREVQUESTION_ID.Value).ToList();
                //await ShowListQuestion(context, listPrevQuestion);
                    List<BOT_QUESTION> listPrevQuestions = DAO_QUESTION.BOT_QUESTION_GetPreviousSelectQuestions(currentQuestion.PREVQUESTION_ID.Value).ToList();
                    await ShowListQuestion(context, listPrevQuestions);
            }
            else
            {
                if(currentQuestion.LEVEL == 1)
                {
                    List<BOT_QUESTION> listPrevQuestions = DAO_QUESTION.BOT_QUESTION_GetByLevel(currentQuestion.LEVEL.Value).ToList();
                    await ShowListQuestion(context, listPrevQuestions);
                }
            }
            if(currentQuestion.PREVANSWER_ID != null)
            {
                List<BOT_ANSWER> listPrevAnswers = DAO_ANSWER.BOT_ANSWER_GetByPreviousSelectAnswers(currentQuestion.PREVANSWER_ID.Value).ToList();
                await ShowListAnswer(context, listPrevAnswers);
                // List<BOT_ANSWER> listPrevAnswer
            }
        }
        public async Task ShowPreviousSelectionFromCurrentAnswer(IDialogContext context, BOT_ANSWER currentAnswer)
        {
            if(currentAnswer.QUESTION_ID != null && currentAnswer.QUESTION_ID != -1)
            {
                List<BOT_QUESTION> listPrevQuestions = DAO_QUESTION.BOT_QUESTION_GetPreviousSelectQuestions(currentAnswer.QUESTION_ID.Value).ToList();
                if (listPrevQuestions.All(question => question.LEVEL != 1))
                {
                    BOT_QUESTION backQuestion = new BOT_QUESTION();
                    backQuestion.QUESTION_ID = -1;
                    backQuestion.CONTENT = "<-Quay lại";
                    backQuestion.DOMAIN_ID = -1;
                    backQuestion.FORM_ID = -1;
                    backQuestion.IS_END = true;
                    backQuestion.PREVANSWER_ID = -1;
                    backQuestion.PREVQUESTION_ID = listPrevQuestions[0].PREVQUESTION_ID;
                    backQuestion.QUESTION_TYPE = -1;
                    backQuestion.RECORD_STATUS = -1;
                    backQuestion.SCENARIO_ID = -1;
                    backQuestion.LEVEL = -1;

                    
                    listPrevQuestions.Add(backQuestion);
                }
                await ShowListQuestion(context, listPrevQuestions);
            }
            if(currentAnswer.PREVANSWER_ID != null && currentAnswer.PREVANSWER_ID != -1)
            {
                
                List<BOT_ANSWER> listPrevAnswers = DAO_ANSWER.BOT_ANSWER_GetByPreviousSelectAnswers(currentAnswer.PREVANSWER_ID.Value).ToList();

                BOT_ANSWER backAnswer = new BOT_ANSWER();
                backAnswer.ANSWER_ID = -1;
                if (listPrevAnswers[0].QUESTION_ID != null)
                    backAnswer.QUESTION_ID = listPrevAnswers[0].QUESTION_ID;
                else
                    backAnswer.QUESTION_ID = -1;
                if (listPrevAnswers[0].PREVANSWER_ID != null)
                    backAnswer.PREVANSWER_ID = listPrevAnswers[0].PREVANSWER_ID;
                else
                    backAnswer.PREVANSWER_ID = -1;
                backAnswer.IS_END = true;
                backAnswer.LEVEL = -1;
                backAnswer.RECORD_STATUS = -1;
                backAnswer.CONTENT = "<-Quay lại";
                
                backAnswer.RECORD_STATUS = -1;

                listPrevAnswers.Add(backAnswer);
                await ShowListAnswer(context, listPrevAnswers);
            }
        }
        public async Task ResumeAfterChooseQuestion(IDialogContext context, IAwaitable<BOT_QUESTION> result)
        {

            var value = await result;
            if(value != null)
            {
                //string a = "";
                //context.PrivateConversationData.TryGetValue<string>("A", out a);
                if (value.QUESTION_ID == -1)
                {
                    BOT_QUESTION prevQuestion = DAO_QUESTION.BOT_QUESTION_GetById(value.PREVQUESTION_ID.Value);
                    await ShowPreviousSelectionFromCurrentQuestion(context, prevQuestion);
                }
                if (DAO_QUESTIONTYPE.BOT_QUESTIONTYPE_IsGetInfoQuestion(value.QUESTION_TYPE.Value))
                {
                    if (value.FORM_NAME.Equals(typeof(CustomerInfoFormModel).Name))
                    {
                        var customerInfoForm = new FormDialog<Models.FormDialog_Models.CustomerInfoFormModel>(new Models.FormDialog_Models.CustomerInfoFormModel(value), CustomerInfoFormModel.BuildForm, FormOptions.PromptInStart);
                        context.Call(customerInfoForm, CustomerInfoFormCompleted);
                    }
                    else if (value.FORM_NAME.Equals(typeof(CustomerReplyFormModel).Name))
                    {

                        var customerReplyForm = new FormDialog<Models.FormDialog_Models.CustomerReplyFormModel>(new Models.FormDialog_Models.CustomerReplyFormModel(), CustomerReplyFormModel.BuildForm, FormOptions.PromptInStart);
                        context.Call(customerReplyForm, CustomerReplyFormCompleted);
                    }
                    return;
                }
                //BotDBEntities DbContext = new BotDBEntities();
                BotDBService.Entities.BotDBContext DbContext = new BotDBContext();
                if(DbContext.BOT_ANSWER.Any(answer => answer.QUESTION_ID == value.QUESTION_ID))
                {
                    List<BOT_ANSWER> ListAnswer = DbContext.BOT_ANSWER.Where(answer => answer.QUESTION_ID == value.QUESTION_ID).ToList();
                    if (!ListAnswer.All(answer => answer.IS_END == true))
                    {
                        BOT_ANSWER backAnswer = new BOT_ANSWER();
                        backAnswer.ANSWER_ID = -1;
                        backAnswer.QUESTION_ID = value.QUESTION_ID;
                        backAnswer.IS_END = true;
                        backAnswer.LEVEL = -1;
                        backAnswer.RECORD_STATUS = -1;
                        backAnswer.CONTENT = "<-Quay lại";
                        backAnswer.PREVANSWER_ID = -1;
                        backAnswer.RECORD_STATUS = -1;
                        ListAnswer.Add(backAnswer);
                    }
                    await ShowListAnswer(context, ListAnswer);
                    //PromptDialog.Choice(context, this.ResumeAfterChooseAnswer,ListAnswer, "Click để chọn:", "Không hợp lệ", 3, PromptStyle.Auto);
                }
                if(DbContext.BOT_QUESTION.Any(question => question.PREVQUESTION_ID == value.QUESTION_ID))
                {
                    List<BOT_QUESTION> ListQuestion = DbContext.BOT_QUESTION.Where(question => question.PREVQUESTION_ID == value.QUESTION_ID).ToList();

                  //  if(value.LEVEL  1)
                 ///   {
                    BOT_QUESTION backQuestion = new BOT_QUESTION();
                    backQuestion.QUESTION_ID = -1;
                    backQuestion.CONTENT = "<-Quay lại";
                    backQuestion.DOMAIN_ID = -1;
                    backQuestion.FORM_ID = -1;
                    backQuestion.IS_END = true;
                    backQuestion.PREVANSWER_ID = -1;
                    backQuestion.PREVQUESTION_ID = value.QUESTION_ID;
                    backQuestion.QUESTION_TYPE = -1;
                    backQuestion.RECORD_STATUS = -1;
                    backQuestion.SCENARIO_ID = -1;
                    backQuestion.LEVEL = -1;
                    backQuestion.QUESTION_ID = -1;
                    ListQuestion.Add(backQuestion);
                  // }

                    await this.ShowListQuestion(context, ListQuestion);
                }
                
                

            }
            else
            {

                context.Wait(this.MessageReceiveAsync);
            }

        }
        public async Task CustomerReplyFormCompleted(IDialogContext context , IAwaitable<Models.FormDialog_Models.CustomerReplyFormModel> result)
        {
            var value = await result;
            if(value != null)
            {
                
            }
        }
        public async Task CustomerInfoFormCompleted(IDialogContext context,IAwaitable<Models.FormDialog_Models.CustomerInfoFormModel> result )
        {
            var value = await result;
            if(value != null)
            {
                //int domain_id = context.PrivateConversationData.Get<int>("DOMAIN_ID");
               // string domain = context.PrivateConversationData.Get<string>("DOMAIN_NAME");
                
                BOT_CUSTOMERINFO customerInfo = new BOT_CUSTOMERINFO();
                customerInfo.DOMAIN_ID = 1;
                customerInfo.DOMAIN_NAME = "http://google.com.vn";
                customerInfo.CUSTOMER_ID = 0;
                customerInfo.NAME = value.NAME;
                customerInfo.PHONE = value.PHONE;
                customerInfo.EMAIL = value.EMAIL;
                customerInfo.RECORD_STATUS = 1;
                DAO_CUSTOMERINFO.BOT_CUSTOMERINFO_Ins(customerInfo);
                context.PrivateConversationData.SetValue<int>("CUSTOMER_ID", customerInfo.CUSTOMER_ID);
                //context.PrivateConversationData.RemoveValue("DOMAIN_ID");
                //context.PrivateConversationData.RemoveValue("DOMAIN_NAME");
                if (value.GetQuestion().IS_END == true)
                {
                    await context.PostAsync($"Cảm ơn bạn {value.NAME} đã cung cấp thông tin. Chúng tôi sẽ chủ động liên lạc với bạn");
                    await context.PostAsync($"Nếu {value.NAME} có vấn đề gì thắc mắc xin mời chọn câu hỏi");
                    context.Wait(MessageReceiveAsync);
                }
                else
                {
                    await context.PostAsync($"Cảm ơn bạn {value.NAME} đã cung cấp thông tin.");
                    if (DAO_QUESTION.BOT_QUESTION_IsHaveNextQuestions(value.GetQuestion().QUESTION_ID))
                    {
                        List<BOT_QUESTION> listQuestion = DAO_QUESTION.BOT_QUESTION_GetNextQuestions(value.GetQuestion().QUESTION_ID).ToList();
                        await this.ShowListQuestion(context, listQuestion);
                    }
                    if(DAO_ANSWER.BOT_ANSWER_IsHasAnswer(value.GetQuestion().QUESTION_ID))
                    {
                        List<BOT_ANSWER> listAnswer = DAO_ANSWER.BOT_ANSWER_GetByQuestionId(value.GetQuestion().QUESTION_ID).ToList();
                        await this.ShowListAnswer(context, listAnswer);
                    }
                }
            }
            
        }
        public async Task ResumeAfterChooseAnswer(IDialogContext context, IAwaitable<BOT_ANSWER> result)
        {
            var value = await result;
            if(value != null)
            {
                BotDBService.Entities.BotDBContext DbContext = new BotDBContext();
                if(value.ANSWER_ID == -1)
                {
                    await ShowPreviousSelectionFromCurrentAnswer(context,value);
                    //if (value.QUESTION_ID != -1)
                    //{
                    //    BOT_QUESTION prevQuestion = DAO_QUESTION.BOT_QUESTION_GetById(value.QUESTION_ID.Value);
                    //    await ShowPreviousSelectionFromCurrentQuestion(context,prevQuestion);
                    //}
                    //else
                    //{
                    //    if(value.PREVANSWER_ID != -1)
                    //    {
                    //        BOT_ANSWER prevAnswer = DAO_ANSWER.BOT_ANSWER_GetById(value.PREVANSWER_ID.Value);
                    //        await ShowPreviousSelectionFromCurrentAnswer(context, prevAnswer);
                    //    }
                    //}
                    
                }
                //BotDBEntities DbContext = new BotDBEntities();
                if(DbContext.BOT_ANSWER.Any(answer => answer.PREVANSWER_ID == value.ANSWER_ID))
                {

                    List<BOT_ANSWER> ListAnswer = DbContext.BOT_ANSWER.Where(answer => answer.PREVANSWER_ID == value.ANSWER_ID).ToList();
                    BOT_ANSWER backAnswer = new BOT_ANSWER();
                    backAnswer.ANSWER_ID = -1;
                    backAnswer.QUESTION_ID = value.QUESTION_ID;
                    backAnswer.IS_END = true;
                    backAnswer.LEVEL = -1;
                    backAnswer.RECORD_STATUS = -1;
                    backAnswer.CONTENT = "<-Quay lại";
                    backAnswer.PREVANSWER_ID = -1;
                    backAnswer.RECORD_STATUS = -1;
                    ListAnswer.Add(backAnswer);
                    await ShowListAnswer(context, ListAnswer);
                 
                }
                if(DbContext.BOT_QUESTION.Any(question=> question.PREVANSWER_ID == value.ANSWER_ID))
                {
                    List<BOT_QUESTION> ListQuestion = DbContext.BOT_QUESTION.Where(question => question.PREVANSWER_ID == value.ANSWER_ID).ToList();
                    BOT_QUESTION backQuestion = new BOT_QUESTION();
                    backQuestion.QUESTION_ID = -1;
                    backQuestion.CONTENT = "<-Quay lại";
                    backQuestion.DOMAIN_ID = -1;
                    backQuestion.FORM_ID = -1;
                    backQuestion.IS_END = true;
                    backQuestion.PREVANSWER_ID = -1;
                    backQuestion.PREVQUESTION_ID = value.QUESTION_ID;
                    backQuestion.QUESTION_TYPE = -1;
                    backQuestion.RECORD_STATUS = -1;
                    backQuestion.SCENARIO_ID = -1;
                    backQuestion.LEVEL = -1;
                    backQuestion.QUESTION_ID = -1;
                    ListQuestion.Add(backQuestion);
                    await ShowListQuestion(context, ListQuestion);
                }
                if(value.IS_END.Value == true && value.ANSWER_ID != -1)
                {
                    await context.PostAsync("Cảm ơn bạn đã trò chuyện. Nếu bạn có thắc mắc gì mời bạn chọn tiếp các câu hỏi");
                    
                    List<BOT_QUESTION> listFirstQuestion = DAO_QUESTION.BOT_QUESTION_GetListFirstQuestionByScenario(1).ToList();


                    await this.ShowListQuestion(context, listFirstQuestion);
                }
                
            }

        }
    }
}