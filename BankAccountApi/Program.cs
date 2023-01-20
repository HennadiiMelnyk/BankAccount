using BankAccount.Shared.Infrastructure.Extensions;
using BankAccount.Transactions.Api;
using BankAccountApi.Accounts.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run();
builder.Services.AddSharedInfrastructure();
builder.Services.AddUsersModule();
builder.Services.AddTransactionsModule();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseUsersModule();
app.UseTransactionsModule();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", 
        context => context.Response.WriteAsync("BanAccount API"));
});

app.Run();