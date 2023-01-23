using ExoAPI.Contexts;
using ExoAPI.Interfaces;
using ExoAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using ExoAPI.ViewModel;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ChapterContext, ChapterContext>(); 
builder.Services.AddTransient<IProjetos, ProjetoRepository>(); 
builder.Services.AddTransient<IUsuario, UsuarioRepository>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:7205")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });

});

builder.Services.AddAuthentication(opitons =>
{
    opitons.DefaultChallengeScheme = "JwtBearer";
    opitons.DefaultAuthenticateScheme = "JwtBearer";
})

    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
           
            ValidateIssuer = true,
      
            ValidateAudience = true,
            
            ValidateLifetime = true,
            
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chave-autentificacao")),
            ClockSkew = TimeSpan.FromMinutes(15),
            
            ValidIssuer = "ExoAPI",
            
            ValidAudience = "ExoAPI"


        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
