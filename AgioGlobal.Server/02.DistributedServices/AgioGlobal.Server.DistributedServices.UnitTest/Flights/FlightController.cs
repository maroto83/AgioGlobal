using AgioGlobal.Server.DistributedServices.Messages.Flights;
using AgioGlobal.Server.DistributedServices.UnitTest.Base;
using AgioGlobal.Server.DistributedServices.UnitTest.TestEnvironment.Contants;
using AgioGlobal.Server.DistributedServices.UnitTest.TestEnvironment.Managers;
using AgioGlobal.Server.DistributedServices.UnitTest.TestEnvironment.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgioGlobal.Server.DistributedServices.UnitTest.Flights
{
    /// <summary>
    /// Descripción resumida de FlightController
    /// </summary>
    [TestClass]
    public class FlightController : BaseUnitTest
    {
        #region Properties

        private FlightDTO flightDTO;
        private FlightDTO FlightDTO
        {
            get
            {
                return flightDTO ?? (flightDTO = DistributedServicesAutoMapper.Map<FlightDTO>(TestEnvironmentMapper.BuildFlightDTOFromData(TestEnvironmentConstant.TestFlightNameForCreateFlight)));
            }
            set { flightDTO = value; }
        }

        #endregion

        #region Action Create

        [TestMethod]
        public void CreateFlight_WhenDataIsCorrect_CheckCreateOneFlight()
        {
            TestEnvironmentManager.DeleteFlightTest(FlightService, FlightDTO.Name);

            var response = FlightController.CreateFlight(FlightDTO);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Result.GetType().Name, "OkNegotiatedContentResult`1");

            TestEnvironmentManager.DeleteFlightTest(FlightService, FlightDTO.Name);
        }

        [TestMethod]
        public void CreateFlight_WhenDataIsIncorrect_CheckException()
        {
            FlightDTO.Name = null;

            var response = FlightController.CreateFlight(FlightDTO);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Result.GetType().Name, "ResponseMessageResult");

        }

        [TestMethod]
        public void Create_WhenDataIsIncorrect_CheckModelStateInvalid()
        {
            FlightDTO.Name = null;

            FlightController.Validate(FlightDTO);

            var result = FlightController.CreateFlight(FlightDTO);

            Assert.AreEqual(result.Result.GetType().Name, "InvalidModelStateResult");

        }

        #endregion

        #region Action Update

        [TestMethod]
        public void UpdateFlight_WhenDataIsCorrect_CheckResult()
        {
            TestEnvironmentManager.DeleteFlightTest(FlightService, FlightDTO.Name);
     
            if (FlightController.CreateFlight(FlightDTO).Result.GetType().Name.Equals("OkNegotiatedContentResult`1"))
            {
                FlightDTO = DistributedServicesAutoMapper.Map<FlightDTO>(FlightService.GetFlight(new Domain.BO.Flights.FlightDTO {Name = FlightDTO.Name}));

                FlightDTO.Name += "_Updated";
                var response = FlightController.UpdateFlight(FlightDTO);
                Assert.IsNotNull(response);

                TestEnvironmentManager.DeleteFlightTest(FlightService, FlightDTO.Name);
            }
            else
            {
                Assert.Fail();
            }
        }

        #endregion

        #region Action GetFlightsList

        [TestMethod]
        public void GetFlightsList_WhenDataIsCorrect_CheckResult()
        {
            if (FlightController.CreateFlight(FlightDTO).Result.GetType().Name.Equals("OkNegotiatedContentResult`1"))
            {
                var response = FlightController.GetFlightsList();
                Assert.IsNotNull(response);
            }
            else
            {
                Assert.Fail();
            }
        }

        #endregion
    }

}
