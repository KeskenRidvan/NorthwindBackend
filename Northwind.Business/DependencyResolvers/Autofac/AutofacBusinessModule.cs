﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Core.Utilities.Interceptors.Autofac.Concrete;
using Northwind.Core.Utilities.Security.JWT.Abstract;
using Northwind.Core.Utilities.Security.JWT.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;

namespace Northwind.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		builder.RegisterType<ProductManager>().As<IProductService>();
		builder.RegisterType<EfProductDal>().As<IProductDal>();

		builder.RegisterType<CategoryManager>().As<ICategoryService>();
		builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

		builder.RegisterType<UserManager>().As<IUserService>();
		builder.RegisterType<EfUserDal>().As<IUserDal>();

		builder.RegisterType<AuthManager>().As<IAuthService>();
		builder.RegisterType<JwtHelper>().As<ITokenHelper>();

		var assembly = Assembly.GetExecutingAssembly();
		builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
		{
			Selector = new AspectInterceptorSelector()
		}).SingleInstance();

	}
}