using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyFirstASP.net; // 引用 CustomHandlerMiddleware 的命名

var builder = WebApplication.CreateBuilder(args);

// 安裝配置
builder.Services.AddDirectoryBrowser();

var app = builder.Build();

// 自定義中間件
app.UseMiddleware<CustomHandlerMiddleware>();

// 使用靜態文件
app.UseStaticFiles();
app.UseDirectoryBrowser();
app.MapGet("/", () => "Hello World!");

app.Run();
