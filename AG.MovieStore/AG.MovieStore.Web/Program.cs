using AG.MovieStore.Web.Data.Context;
using AG.MovieStore.Web.Data.Entities.User;
using AG.MovieStore.Web.Interfaces;
using AG.MovieStore.Web.Models.User;
using AG.MovieStore.Web.Repositories;
using AG.MovieStore.Web.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<UserContext>();
builder.Services.AddDbContext<UserContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});


builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.HttpOnly=true;
    opt.Cookie.Name = "MovieCookie";
    opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
});

builder.Services.AddTransient<IValidator<CreateUserModel>, CreateUserValidation>();
builder.Services.AddTransient<IValidator<SignInUserModel>, SignInValidation>();
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IMovie, MovieRepository>();

var app = builder.Build();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine
    (Directory.GetCurrentDirectory(), "node_modules"))
    ,
    RequestPath = "/node_modules"
});

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.Run();
