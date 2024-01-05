using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Northwind.Business.DependencyResolvers.Autofac;
using Northwind.Core.DependencyResolvers;
using Northwind.Core.Extensions;
using Northwind.Core.Utilities.IoC.Abstract;
using Northwind.Core.Utilities.Security.Encyption;
using Northwind.Core.Utilities.Security.JWT.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
	builder.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddDependencyResolvers(new ICoreModule[]
{
	new CoreModule(),
});


#region Jwt Configuration
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("https://localhost:7056")); // Canliya alindiginda buraya domain adresi yazilacak.
});

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidIssuer = tokenOptions.Issuer,
		ValidAudience = tokenOptions.Audience,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
	};
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // -> Jwt Configuration
app.UseAuthorization();

app.MapControllers();

app.Run();
