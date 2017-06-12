namespace IntegrationTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OMSZ.App;

    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void ActualDataCheck_idojaras3File_NormalFile()
        {
            // Arrange
            var fileName = "idojaras.htm";
            var fakeRepository = new FakeRepository(fileName);
            var appMain = new AppMain(fakeRepository);

            var expected_time = "12:00";
            var expected_temp = 19;
            var expected_pressure = 1016; 

            //Act
            var viewModel = appMain.GetViewModel();

            //Assert
            Assert.AreEqual(expected_time, viewModel.Time);
            Assert.AreEqual(expected_temp, viewModel.Temperature);
            Assert.AreEqual(expected_pressure, viewModel.Pressure);
        }


    }
}
