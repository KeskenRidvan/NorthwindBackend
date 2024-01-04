using Northwind.Core.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework.Context;
using Northwind.Entities.Concrete;

namespace Northwind.DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, AppDbContext>, IProductDal
{
}
