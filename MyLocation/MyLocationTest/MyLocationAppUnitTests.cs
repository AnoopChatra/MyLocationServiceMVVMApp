using NUnit.Framework;
using MyLocation.ViewModels;
using MyLocationTest.Services;

namespace MyLocationTest
{
   
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void Test_FirstView_To_SecondView_Push()
        {
            var testNavigationService = new TestNavigationService();
            var testLocationService = new TestLocationService();

            FirstVM  firstVM = new FirstVM(testLocationService,testNavigationService);
            firstVM.NextCommand.Execute(null);
            Assert.True(typeof(SecondVM) == testNavigationService.ViewModelNavigate.GetType());
        }

        [Test()]
        public void Test_SecondView_To_FirstView_Pop()
        {
            var testNavigationService = new TestNavigationService();
            var testLocationService = new TestLocationService();

            SecondVM secondVm = new SecondVM(testNavigationService,testLocationService);
            secondVm.BackCommand.Execute(null);
            Assert.True(testNavigationService.isMyPopExcuted);
        }

        [Test()]
        public void Test_Default_GPSValue_Is_Zero()
        {
            var testNavigationService = new TestNavigationService();
            var testLocationService = new TestLocationService();

            SecondVM secondVm = new SecondVM(testNavigationService, testLocationService);
            Assert.True(0 == secondVm.XCoordinate);
            Assert.True(0 == secondVm.YCoordinate);
        }

        [Test()]
        public void Test_Show_Location()
        {
            var testNavigationService = new TestNavigationService();
            var testLocationService = new TestLocationService();

            SecondVM secondVm = new SecondVM(testNavigationService, testLocationService);
            secondVm.ShowCommand.Execute(null);
            Assert.True(null != testLocationService.GetLocation());
        }

        [Test()]
        public void Test_Clear_Location()
        {
            var testNavigationService = new TestNavigationService();
            var testLocationService = new TestLocationService();

            SecondVM secondVm = new SecondVM(testNavigationService, testLocationService);
            secondVm.ClearCommand.Execute(null);
            Assert.True(0 == secondVm.XCoordinate);
            Assert.True(0 == secondVm.YCoordinate);
        }
    }
}
