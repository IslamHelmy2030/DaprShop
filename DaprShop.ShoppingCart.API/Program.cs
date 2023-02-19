using Dapr.Client;
using DaprShop.ShoppingCart.API.Services;

namespace DaprShop.ShoppingCart.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDaprClient();
            builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            /*
             * To Start This App
             * dapr run --app-id shoppingcartapi --app-port 5000 -- dotnet run
             */
        }
    }
}