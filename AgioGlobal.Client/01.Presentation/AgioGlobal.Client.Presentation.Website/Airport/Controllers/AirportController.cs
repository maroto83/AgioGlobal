using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AgioGlobal.Client.Presentation.Website.Airport.Models;
using AgioGlobal.Client.Presentation.Website.Helpers;
using Newtonsoft.Json;

namespace AgioGlobal.Client.Presentation.Website.Airport.Controllers
{
    public class AirportController : Controller
    {
        // GET: Airport
        public async Task<ActionResult> Index()
        {
            var AirportModelList = new List<AirportModel>();
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            var httpResponseMessage = await MyHelper.HttpClient.GetAsync("api/Airport/GetAirportsList");

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var AirportResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                AirportModelList = JsonConvert.DeserializeObject<List<AirportModel>>(AirportResponse);

            }
            //returning the employee list to view  
            return View(AirportModelList);
        }

        public async Task<ActionResult> Create(AirportModel model)
        {
            if (ModelState.IsValid)
            {
                var messagebyte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

                var WebRequest = System.Net.WebRequest.Create(MyHelper.BaseUrl + "api/Airport/Create");

                WebRequest.Method = "POST";
                WebRequest.ContentType = "application/json";
                WebRequest.ContentLength = messagebyte.Length;
                
                //Include request
                using (var stream = WebRequest.GetRequestStreamAsync().GetAwaiter().GetResult())
                {
                    stream.Write(messagebyte, 0, messagebyte.Length);
                }

                return RedirectToAction("Index");
            }

            return View(model);

        }

        public async Task<ActionResult> Edit(int id)
        {
            var AirportModelList = new List<AirportModel>();
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            var httpResponseMessage = await MyHelper.HttpClient.GetAsync("api/Airport/GetAirportsList");

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var AirportResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                AirportModelList = JsonConvert.DeserializeObject<List<AirportModel>>(AirportResponse);

            }
            //returning the employee list to view  
            return View(AirportModelList.FirstOrDefault(x => x.AirportId.Equals(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AirportModel model)
        {
            if (ModelState.IsValid)
            {
                var messagebyte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

                var WebRequest = System.Net.WebRequest.Create(MyHelper.BaseUrl + "api/Airport/Update");

                WebRequest.Method = "POST";
                WebRequest.ContentType = "application/json";
                WebRequest.ContentLength = messagebyte.Length;

                //Include request
                using (var stream = await WebRequest.GetRequestStreamAsync().ConfigureAwait(false))
                {
                    await stream.WriteAsync(messagebyte, 0, messagebyte.Length);
                    await stream.FlushAsync();
                }

                System.Threading.Thread.Sleep(1000);

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<ActionResult> Details(int id)
        {
            var AirportModelList = new List<AirportModel>();
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            var httpResponseMessage = await MyHelper.HttpClient.GetAsync("api/Airport/GetAirportsList");

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var AirportResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                AirportModelList = JsonConvert.DeserializeObject<List<AirportModel>>(AirportResponse);

            }
            //returning the employee list to view  
            return View(AirportModelList.FirstOrDefault(x => x.AirportId.Equals(id)));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var AirportModelList = new List<AirportModel>();
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            var httpResponseMessage = await MyHelper.HttpClient.GetAsync("api/Airport/GetAirportsList");

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var AirportResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                AirportModelList = JsonConvert.DeserializeObject<List<AirportModel>>(AirportResponse);

            }
            //returning the employee list to view  
            return View(AirportModelList.FirstOrDefault(x => x.AirportId.Equals(id)));
        }

        [HttpPost]
        public async Task<ActionResult> DeletePost(int id)
        {
            var AirportModelList = new List<AirportModel>();
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            var httpResponseMessage = await MyHelper.HttpClient.GetAsync("api/Airport/GetAirportsList");

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var AirportResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                AirportModelList = JsonConvert.DeserializeObject<List<AirportModel>>(AirportResponse);

            }

            var messagebyte = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(AirportModelList.FirstOrDefault(x => x.AirportId.Equals(id))));

            var WebRequest = System.Net.WebRequest.Create(MyHelper.BaseUrl + "api/Airport/Delete");

            WebRequest.Method = "POST";
            WebRequest.ContentType = "application/json";
            WebRequest.ContentLength = messagebyte.Length;

            //Include request
            using (var stream = await WebRequest.GetRequestStreamAsync().ConfigureAwait(false))
            {
                await stream.WriteAsync(messagebyte, 0, messagebyte.Length);
                await stream.FlushAsync();
            }

            System.Threading.Thread.Sleep(1000);

            return RedirectToAction("Index");
        }
    }
}