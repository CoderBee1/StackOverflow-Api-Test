using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplicationTask.Models;

namespace WebApplicationTask.Controllers
{
    public class StackOverflowApiController : Controller
    {
        private const string ApiKey = "api??";
        private const string BaseUrl = "https://api.stackexchange.com/2.3/";

        public async Task<ActionResult> Index()
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("questions", (Method)DataFormat.Json);

            //request.AddParameter("order", "desc");
            //request.AddParameter("sort", "activity");
            request.AddParameter("site", "stackoverflow");
            request.AddParameter("pagesize", "50");
            request.AddParameter("key", ApiKey);

            var response = await client.GetAsync<QuestionListModel>(request);

            return View(response.Questions);
        }

        public async Task<ActionResult> Details(int id)
        {
            var client = new RestClient(BaseUrl);
            var request = new RestRequest($"questions/{id}", (Method)DataFormat.Json);

            request.AddParameter("site", "stackoverflow");
            request.AddParameter("key", ApiKey);

            var response = await client.GetAsync<QuestionDetailModel>(request);

            return View(response);
        }
    }

}
