using System.Text;
using Microsoft.IdentityModel.Tokens;
using SignalRSample.Backend.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddScoped<Chathub>();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opts => opts.TokenValidationParameters = new()
{
    ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
    ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
    IssuerSigningKey =
        new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Authentication:SecretKey"))),
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateIssuerSigningKey = true,
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseCors(opt => { opt.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader(); });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<Chathub>("/hub/chat");

app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Run();