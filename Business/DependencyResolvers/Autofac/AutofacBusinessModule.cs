using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;


namespace Business.DependencyResolvers.Autofac;
public class AutofacBusinessModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterType<EfProductDal>().As<IProductDal>();
		builder.RegisterType<ProductManager>().As<IProductService>();

		builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
		builder.RegisterType<CategoryManager>().As<ICategoryService>();

		builder.RegisterType<UserManager>().As<IUserService>();
		builder.RegisterType<EfUserDal>().As<IUserDal>();

		builder.RegisterType<AuthManager>().As<IAuthService>();
		builder.RegisterType<JwtHelper>().As<ITokenHelper>();

		var assembly = Assembly.GetExecutingAssembly();
		builder
			.RegisterAssemblyTypes(assembly)
			.AsImplementedInterfaces()
			.EnableInterfaceInterceptors(new ProxyGenerationOptions()
			{
				Selector = new AspectInterceptorSelector()
			}).SingleInstance();
	}
}