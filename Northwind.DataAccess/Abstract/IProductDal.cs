﻿using Northwind.Core.DataAccess.Abstract;
using Northwind.Entities.Concrete;

namespace Northwind.DataAccess.Abstract;

public interface IProductDal : IEntityRepositoryBase<Product>
{

}
