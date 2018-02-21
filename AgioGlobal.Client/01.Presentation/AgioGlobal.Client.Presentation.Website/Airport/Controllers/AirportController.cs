using System.Collections.Generic;
using System.Linq;
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
        #region Actions

        #region Get actions

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var AirportModelList = await GetAirportModelList();

            //returning the employee list to view  
            return View(AirportModelList);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var AirportModelList = await GetAirportModelList();

            //returning the employee list to view  
            return View(AirportModelList.FirstOrDefault(x => x.AirportId.Equals(id)));
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var AirportModelList = await GetAirportModelList();

            //returning the employee list to view  
            return View(AirportModelList.FirstOrDefault(x => x.AirportId.Equals(id)));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var AirportModelList = await GetAirportModelList();

            //returning the employee list to view  
            return View(AirportModelList.FirstOrDefault(x => x.AirportId.Equals(id)));
        }

        #endregion

        #region Post actions
        
        public ActionResult Create(AirportModel model)
        {
            if (!ModelState.IsValid) return View(model);

            ExecutePostAction(JsonConvert.SerializeObject(model), Constants.CreateAirportActionName);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(AirportModel model)
        {
            if (!ModelState.IsValid) return View(model);

            ExecutePostAction(JsonConvert.SerializeObject(model), Constants.UpdateAirportActionName);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeletePost(int id)
        {
            var AirportModelList = await GetAirportModelList();

            ExecutePostAction(JsonConvert.SerializeObject(AirportModelList.FirstOrDefault(airport => airport.AirportId.Equals(id))), Constants.DeleteAirportActionName);
            return RedirectToAction("Index");
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the airports list
        /// </summary>
        /// <returns>A list with the airports</returns>
        private static async Task<List<AirportModel>> GetAirportModelList()
        {
            var AirportModelList = new List<AirportModel>();
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            var httpResponseMessage = await MyHelper.HttpClient.GetAsync(Constants.GetAirportsListActionName);

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var AirportResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                AirportModelList = JsonConvert.DeserializeObject<List<AirportModel>>(AirportResponse);
            }

            return AirportModelList;
        }

        /// <summary>
        /// Execute an action Post in the Web Api
        /// </summary>
        /// <param name="requestApi">Request for the web api</param>
        /// <param name="actionName">Action name</param>
        private static void ExecutePostAction(string requestApi, string actionName)
        {
            // Build the message with the request
            var messagebyte = Encoding.UTF8.GetBytes(requestApi);

            // Build the request for the Web Api
            var WebRequest = System.Net.WebRequest.Create(MyHelper.BaseUrl + actionName);

            // Configurate the request for the Web Api
            WebRequest.Method = Constants.MethodPost;
            WebRequest.ContentType = Constants.ContentTypeJson;
            WebRequest.ContentLength = messagebyte.Length;

            // Send the request to the Web Api
            using (var stream = WebRequest.GetRequestStreamAsync().GetAwaiter().GetResult())
            {
                stream.Write(messagebyte, 0, messagebyte.Length);
            }
            
            System.Threading.Thread.Sleep(1000);
        }

        #endregion
    }
}