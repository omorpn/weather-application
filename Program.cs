var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "wwwoot"  
});
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
