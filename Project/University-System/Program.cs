using Microsoft.EntityFrameworkCore;
using SysUniPro.Context;
using SysUniPro.Factory;
using SysUniPro.Repostory;


var builder = WebApplication.CreateBuilder(args);

// إضافة الخدمات هنا قبل استدعاء builder.Build()
builder.Services.AddControllersWithViews();

// إضافة DbContext
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection"))
);

builder.Services.AddTransient<IStudentRepostory, StudentRepostory>();

builder.Services.AddTransient<ICourseRepostory, CourseRepostory>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<RepositoryFactory>();

// إضافة الخدمات الأخرى (مثل Controllers أو Authentication)
builder.Services.AddControllers();

var app = builder.Build(); // تأكدي من أن app.Build() يحدث بعد الإعدادات.

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

