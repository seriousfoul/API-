using Microsoft.OpenApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API功能",
        Description = "使用API進行新增修改刪除查詢(CRUD)資料，測試網頁在 https://localhost:7045/home/index",
        TermsOfService = new Uri("https://example.com/terms"),  //服務條款
        Contact = new OpenApiContact   // (聯絡資訊)
        {
            Name = "網站維護者 - 簡文翊",    // 顯示維護者或團隊的名稱（如："Example Contact"）。
            Url = new Uri("https://https://github.com/seriousfoul/Wunyi-ASPNET-MVC-API-Swagger"),  // Url: 指向維護者的個人網站、專案頁面或聯絡表單的連結。
            Email = "john27306666@yahoo.com.tw" //Email(選填)：可以直接加入聯絡信箱。 
        },
        License = new OpenApiLicense     // (授權資訊)
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";          // 產生專案名稱的xml
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));    // 指定xml的路徑為剛剛產生的xml
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();   
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;   // swagger會取代index.html
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
