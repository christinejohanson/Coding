var builder = WebApplication.CreateBuilder(args);
//aktiverar MVC
builder.Services.AddControllersWithViews();
var app = builder.Build();
//för att använda statiska filer. hamnar i wwwroot
app.UseStaticFiles();
//routing
app.UseRouting();
//hur routing ska se ut 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
