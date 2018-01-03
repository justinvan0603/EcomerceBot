using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BotWithDialog.Controllers
{

    [Route("api/WebChat")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WebChatController : ApiController
    {
        //[HttpGet]
        //public async Task<string> Get()
        //{

        //   // Obj a = new Obj();
        //   // a.ID = 1;
        //   // a.Name = "hello";
        //    return @"alert('Hello World!')";
        //}
        //[HttpGet]
        //[Route("{userid}")]
        public async Task<HttpResponseMessage> Get(string domain)
        {
            //int a = 5;
            string webChatSecrect = "w3VHr6c9kug.cwA.dgY.NbwFCdsdfTVJUQqtD8I-KGahmhbYvx7GLlDmEn4A2cc";
            var request = new HttpRequestMessage(HttpMethod.Get, "https://webchat.botframework.com/api/tokens");
            request.Headers.Add("Authorization", "BotConnector " +webChatSecrect);

            HttpResponseMessage response = await new HttpClient().SendAsync(request);
            string token = await response.Content.ReadAsStringAsync();
            token = token.Replace("\"", "");
            //int a = 5;
            return new HttpResponseMessage()
            {
                Content = new StringContent(
            @"(function () {
    
                
                var div = document.createElement('div');
                document.getElementsByTagName('body')[0].appendChild(div);
                
                div.outerHTML = '<div id=""botDiv"" style="" border:none;width:100%; max-width:380px;height: 38px; position: fixed;bottom:0; z-index: 9999; background-color: #fff""><div id=""botTitleBar"" style=""border:none;height: 38px;width:100%; max-width: 380px; position:fixed; cursor: pointer;""></div><iframe style=""height: 400px;width:100%; max-width:380px;"" src=""https://webchat.botframework.com/embed/WordpressChatBot?s=" + webChatSecrect + "&userid="+ domain + @"""></iframe></div>';

                document.querySelector('body').addEventListener('click', function(e) {
                    e.target.matches = e.target.matches || e.target.msMatchesSelector;
                    if (e.target.matches('#botTitleBar'))
                    {
                        var botDiv = document.querySelector('#botDiv');
                        botDiv.style.height = botDiv.style.height == '400px' ? '38px' : '400px';
                    };
                });
               }());",
        Encoding.UTF8,
        "text/html"
    )
            };
        }
    }

}
