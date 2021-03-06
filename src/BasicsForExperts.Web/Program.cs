using BasicsForExperts.Web.Extensions;
using BasicsForExperts.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>()
                .AddCommandLine(args)
                .Build();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding dependencies
// Add an HttpClient that's available to any class requesting HttpClient - this will be managed by the HttpClientFactory
builder.Services.AddHttpClient();
builder.Services.AddSingleton<WaffleIngredientService>();
// We can add an implementation of an interface like this.
builder.Services.AddSingleton<IWaffleCreationService, WaffleCreationService>();

builder.Services.AddDatabases(Configuration);


// If there are a lot of dependencies, the program file will become unmanageable, so we can abstract it out into an extension
//builder.Services.AddDependencies();
//builder.Services.AddCustomSerializers();

// Add typed HttpClients and configure policies, circuit breaks and failovers
//builder.Services.AddClientsAndPolicies(); 

// Add service discovery for distributed systems
//builder.Services.AddServiceDiscovery();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// Minimal APIs architecture allows us to add lightweight api endpoints directly to the WebApplication without the need for a controller

   

app.MapGet("/GetWaffleToppings", (IWaffleCreationService waffleCreationService) =>
             {
                var response = await waffleCreationService.StartWaffleCreation();
                return new { ingredients = response.toppings, bases = response.bases });
             }
          );


// If we have a lot of apis, the program file could get messy, so just like everything else, we can pull it out into an extension method
//await app.AddApisAsync();

// The following extension method shows how to access Eureka to get registered apps.
//app.AddEurekaApi();

app.Run();

