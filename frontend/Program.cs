using frontend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<ToDoTaskService>();
builder.Services.AddHttpClient<ToDoTaskService>(http =>
{
    string url = builder.Configuration["BackendUrl"] ?? throw new KeyNotFoundException("Backend url not found");
    http.BaseAddress = new Uri(url);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.UseRouting();

app.MapRazorPages();

app.Run();
