using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AgioGlobal.Client.Presentation.Website.Airport.Models;
using AgioGlobal.Client.Presentation.Website.Flight.Models;
using AgioGlobal.Client.Presentation.Website.Helpers;
using Newtonsoft.Json;

namespace AgioGlobal.Client.Presentation.Website.Flight.Controllers
{
    public class FlightController : Controller
    {
        #region Actions

        #region Get actions

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var FlightModelList = await GetFlightModelList();

            //returning the employee list to view  
            return View(FlightModelList);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var FlightModelList = await GetFlightModelList();

            //returning the employee list to view  
            return View(FlightModelList.FirstOrDefault(x => x.FlightId.Equals(id)));
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var FlightModelList = await GetFlightModelList();

            //returning the employee list to view  
            return View(FlightModelList.FirstOrDefault(x => x.FlightId.Equals(id)));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var FlightModelList = await GetFlightModelList();

            //returning the employee list to view  
            return View(FlightModelList.FirstOrDefault(x => x.FlightId.Equals(id)));
        }

        #endregion

        #region Post actions

        public async Task<ActionResult> Create(FlightViewModel model)
        {
            var airportsList = await GetAirportModelList();
            
            if (!ModelState.IsValid)
            {
                model.AirportsList = new List<SelectListItem>();
                foreach (var airportModel in airportsList)
                {
                    model.AirportsList.Add(new SelectListItem { Text = airportModel.Name, Value = airportModel.AirportId.ToString() });
                }
                
                return View(model);
            }
            var flightModel = new FlightModel
            {
                Name = model.Name,
                DepartureAirport = airportsList.FirstOrDefault(airport => airport.AirportId.Equals(model.DepartureAirportId)),
                DestinationAirport = airportsList.FirstOrDefault(airport => airport.AirportId.Equals(model.DestinationAirportId))
            };
            ExecutePostAction(JsonConvert.SerializeObject(flightModel), Constants.CreateFlightActionName);
            return RedirectToAction("Index", "Flight/Index");

        }

        [HttpPost]
        public ActionResult Edit(FlightModel model)
        {
            if (!ModelState.IsValid) return View(model);

            ExecutePostAction(JsonConvert.SerializeObject(model), Constants.UpdateFlightActionName);
            return RedirectToAction("Index", "Flight/Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeletePost(int id)
        {
            var FlightModelList = await GetFlightModelList();

            ExecutePostAction(JsonConvert.SerializeObject(FlightModelList.FirstOrDefault(flight => flight.FlightId.Equals(id))), Constants.DeleteFlightActionName);
            return RedirectToAction("Index", "Flight/Index");
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
        /// Get the flights list
        /// </summary>
        /// <returns>A list with the flights</returns>
        private static async Task<List<FlightModel>> GetFlightModelList()
        {
            var FlightModelList = new List<FlightModel>();
            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
            var httpResponseMessage = await MyHelper.HttpClient.GetAsync(Constants.GetFlightsListActionName);

            //Checking the response is successful or not which is sent using HttpClient  
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var FlightResponse = httpResponseMessage.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                FlightModelList = JsonConvert.DeserializeObject<List<FlightModel>>(FlightResponse);
            }

            return FlightModelList;
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