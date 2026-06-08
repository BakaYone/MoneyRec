using MoneyRec.Core.Context;

namespace MoneyRec.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            MonRecContext ctx = new MonRecContext();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapGet(@"/UserTransactions{id}", async (int id) =>
            {
                
            });

            app.Run();
        }
    }
}
