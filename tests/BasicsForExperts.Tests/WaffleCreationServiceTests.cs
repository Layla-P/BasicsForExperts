using BasicsForExperts.Web.Data;
using BasicsForExperts.Web.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BasicsForExperts.Tests
{

    //https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
    [TestFixture]
    public class WaffleCreationServiceTests
    {
        private Mock<WaffleIngredientService> _mockedIngredientService;
        private Mock<IWaffleCreationService> _mockedWaffleCreationService;
        private WaffleCreationService _sut;
        private IWaffleCreationService _isut;
        [SetUp]
        public void Setup()
        {
            //_mockedIngredientService = new Mock<WaffleIngredientService>(MockBehavior.Strict);
            //_mockedWaffleCreationService = new Mock<IWaffleCreationService>(MockBehavior.Strict);
            //_sut = new WaffleCreationService(_mockedIngredientService.Object);
            //_isut = new WaffleCreationService(_mockedIngredientService.Object);
        }

        [Test]
        public async Task Test1()
        {
            
            Assert.Pass();
            
        }
       
    }
}