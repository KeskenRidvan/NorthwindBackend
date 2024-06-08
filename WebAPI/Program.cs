using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace WebAPI;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
		builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
		{
			builder.RegisterModule(new AutofacBusinessModule());
		});

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		#region Jwt Configuration
		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowOrigin", builder =>
				builder.WithOrigins("https://localhost:3000"));
		});

		TokenOptions? tokenOptions =
			builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

		builder.Services
			.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(options =>
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
			app.UseSwaggerUI(opt =>
			{
				opt.DocExpansion(DocExpansion.None);
			});
		}

		app.UseHttpsRedirection();

		app.UseAuthentication(); // -> Jwt Configuration
		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
