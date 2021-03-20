using BLL;
using BLL.Enums;
using Moq;
using NUnit.Framework;
using UIL;

namespace NUnitTestShopMultilayerArchitecture
{
    public class Tests
    {
        private MainController controller = new MainController(new BLL.DTO.UserDto());
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void CountUser_True()
        {
            int expected=controller.GetUsers().Count;
            Assert.AreEqual(expected, 4);
        }

        [Test]
        public void AddUser_NotExist()
        {
            var mock = new Mock<MainController>();
            mock.Setup(x=>x.Signup("Kate", "poiuyt098765"));
            var exist = mock.Object.GetUsers().Exists(x => x.Name == "Kate" && x.Password == "poiuyt098765");
            Menu menu=new Menu()
            
            Assert.IsTrue(exist);
        }
    }
}