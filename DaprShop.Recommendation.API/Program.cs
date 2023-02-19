namespace DaprShop.Recommendation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddDapr();
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


            app.UseCloudEvents();
            app.MapControllers();
            app.MapSubscribeHandler();

            app.Run();

            /*
             * To Start This App
             * dapr run --app-id recommendationapi --app-port 6000 -- dotnet run
             */
        }
    }
}