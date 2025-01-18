using Microsoft.EntityFrameworkCore;
using ToDoListApp.AppLogic;
using ToDoListApp.Infrastructure;

namespace ToDoListApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            builder.Services.AddDbContext<ToDoListContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoListDBConnection")
    , sqlOptions => sqlOptions.EnableRetryOnFailure()));

            
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            builder.Services.AddScoped<IToDoListRepository, ToDoListRepositoryImpl>();

            builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepositoryImpl>();

            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                
                app.UseSwagger();                      
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllers();
            
            app.MapDefaultControllerRoute();
    //            (
    //name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

    
}