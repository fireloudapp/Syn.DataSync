using Newtonsoft.Json;
using RestSharp;
using Sun.DataFetcher.App.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sun.DataFetcher.App.HTTPUtility
{
    public class WebAPIHelper
    {
        string _hostURL = null;
        string _queue = null;
        public WebAPIHelper()
        {
            _hostURL = ConfigurationManager.AppSettings["APIURL"];
            _queue = ConfigurationManager.AppSettings["Queue"]; 
        }
        
        public async Task<string> GetAuthenticationAsync()
        {
            string token = string.Empty;
            await Task.Run(() =>
            {
               token =  GetAuthenticate();
            });
            return token;
        }

        public string GetAuthenticate()
        {
            string token = string.Empty;
            try
            {
                string userName = ConfigurationManager.AppSettings["UserName"];
                string pwd = ConfigurationManager.AppSettings["Password"];
                
                var client = new RestClient(_hostURL + APIConstant.AUTHENTICATE);//Url is subject is change.
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                User usr = new User()
                {
                    username = userName,
                    password = pwd
                };
                string usrJson = JsonConvert.SerializeObject(usr);
                request.AddParameter("application/json", usrJson, ParameterType.RequestBody);//Subject to change for download
                IRestResponse response = client.Execute(request);
                AuthenticateUser user = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    user = JsonConvert.DeserializeObject<AuthenticateUser>(response.Content);
                    token = user.token;
                }
                else
                {
                    token = response.Content;
                }
                Console.WriteLine(response.Content);
               
            }
            catch (Exception ex)
            {
                //TODO:Log
                token = "An Error Occured while generating token: " + ex.Message;

            }
            return token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="getURL">eg."api/getinventory"</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string GetData(string getURL, string token)
        {           
            try
            {
                //This is the skeliton, debug and test properly and run the code.
                var client = new RestClient(_hostURL + getURL);//Url is subject is change. URL Exammple "api/getinventory"
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddHeader("Content-Type", "application/json");
                
                string usrJson = JsonConvert.SerializeObject("our model/Input date appeares here");
                request.AddParameter("application/json", usrJson, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                AuthenticateUser user = null;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    user = JsonConvert.DeserializeObject<AuthenticateUser>(response.Content);
                    token = user.token;
                }
                else
                {
                    token = response.Content;
                }
                Console.WriteLine(response.Content);

            }
            catch (Exception ex)
            {
                //TODO:Log
                token = "An Error Occured while generating token: " + ex.Message;

            }
            return token;
        }

        public HttpStatusCode PostData(string token, string jsonData, string sendURL)
        {
            bool result = false;
            
            var client = new RestClient(_hostURL + sendURL);//APIConstant.SEND_TRANS
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("QueueName", _queue);
            request.AddHeader("RoutingKey", _queue);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", jsonData, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            //Todo: Return HTTP Status
            return response.StatusCode;
        }
        
    }
}
