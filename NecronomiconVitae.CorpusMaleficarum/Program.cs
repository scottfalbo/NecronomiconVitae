using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using NecronomiconVitae.CorpusMaleficarum;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var azureCredential = new DefaultAzureCredential();

var keyVaultUrl = configuration["KeyVaultUri"];
var secretClient = new SecretClient(new Uri(keyVaultUrl!), azureCredential);

var storageConnectionString = secretClient.GetSecret("BlobConnectionString").Value.Value;

builder.Services.AddTransient<IBlobStorageService, BlobStorageService>();
builder.Services.AddTransient<IProcessor, Processor>();
builder.Services.AddSingleton(new BlobServiceClient(storageConnectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();