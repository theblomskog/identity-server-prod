using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    var builtConfig = config.Build();

    string vaultUrl = builtConfig["Vault:Url"];
    string clientId = builtConfig["Vault:ClientId"];
    string secret = builtConfig["Vault:clientSecret"];
    string tenantId = builtConfig["Vault:TenantId"];

    var client = new ClientSecretCredential(tenantId, clientId, secret);

    config.AddAzureKeyVault(new Uri(vaultUrl), client);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
