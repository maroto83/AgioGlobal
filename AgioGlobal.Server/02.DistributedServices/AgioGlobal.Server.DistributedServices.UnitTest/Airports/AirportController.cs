using AgioGlobal.Server.DistributedServices.Messages.Airport;
using AgioGlobal.Server.DistributedServices.UnitTest.Base;
using AgioGlobal.Server.DistributedServices.UnitTest.TestEnvironment.Contants;
using AgioGlobal.Server.DistributedServices.UnitTest.TestEnvironment.Managers;
using AgioGlobal.Server.DistributedServices.UnitTest.TestEnvironment.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgioGlobal.Server.DistributedServices.UnitTest.Airports
{
    /// <summary>
    /// Descripción resumida de AirportController
    /// </summary>
    [TestClass]
    public class AirportController : BaseUnitTest
    {
        #region Properties

        private AirportDTO airportDTO;
        private AirportDTO AirportDTO
        {
            get
            {
                return airportDTO ?? (airportDTO = DistributedServicesAutoMapper.Map<AirportDTO>(TestEnvironmentMapper.BuildAirportDTOFromData(TestEnvironmentConstant.TestAirportNameForCreateAirport)));
            }
        }

        #endregion

        [TestMethod]
        public void CreateAirport_WhenDataIsCorrect_CheckCreateOneAirport()
        {
            TestEnvironmentManager.DeleteAirportTest(AirportService, AirportDTO.Name);

            var response = AirportController.CreateAirport(AirportDTO);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Result.GetType().Name, "OkNegotiatedContentResult`1");

            TestEnvironmentManager.DeleteAirportTest(AirportService, AirportDTO.Name);
        }

        [TestMethod]
        public void CreateAirport_WhenDataIsIncorrect_CheckException()
        {
            AirportDTO.Name = null;

            var response = AirportController.CreateAirport(AirportDTO);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Result.GetType().Name, "ResponseMessageResult");

        }

        [TestMethod]
        public void Create_WhenDataIsIncorrect_CheckModelStateInvalid()
        {
            AirportDTO.Name = null;

            AirportController.Validate(AirportDTO);

            var result = AirportController.CreateAirport(AirportDTO);

            Assert.AreEqual(result.Result.GetType().Name, "InvalidModelStateResult");

        }
    }

}
