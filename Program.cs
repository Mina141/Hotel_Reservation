using Hotel_Reservation.Irepository;
using Hotel_Reservation.Models;
using Hotel_Reservation.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string ConnectionStrings = builder.Configuration.GetConnectionString("CS");

            builder.Services.AddDbContext<Hotel_Entity>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(ConnectionStrings);
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Registeration
            builder.Services.AddScoped<IRoom, RoomRepository>();
            builder.Services.AddScoped<IRoomType, RoomTypeRepository>();
            builder.Services.AddScoped<IMealPlan, MealPlanRepository>();
            builder.Services.AddScoped<ISeasons, SeasonsRepository>();
            builder.Services.AddScoped<IReservation, ReservationRepository>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}