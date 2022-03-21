using BasicsForExperts.Web.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BasicsForExperts.Tests
{

    //https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
    [TestFixture]
    public class Tests
    {
        private WaffleDbContext _context;
        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<WaffleDbContext>();
            builder.UseInMemoryDatabase("WaffleDBMemory");
            var options = builder.Options;
            _context = new WaffleDbContext(options);
            _context.Database.EnsureCreated();

        }

        [Test]
        public async Task Test1()
        {
            var users = await _context.Users.ToListAsync();
            Assert.Pass();
            
        }
       
    }
}