using LaboPabSoap.Service;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSoapEndpoint<IUserService>("/UserService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<IDepartmentService>("/DepartmentService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<IProjectService>("/ProjectService.asmx", new SoapEncoderOptions());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
