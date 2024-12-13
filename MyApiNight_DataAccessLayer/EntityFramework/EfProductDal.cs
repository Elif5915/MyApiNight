using MyApiNight_DataAccessLayer.Abstract;
using MyApiNight_DataAccessLayer.Context;
using MyApiNight_DataAccessLayer.Repositories;
using MyApiNight_EntityLayer.Concrete;

namespace MyApiNight_DataAccessLayer.EntityFramework;
public class EfProductDal : GenericRepository<Product>, IProductDal
{
	public EfProductDal(ApiContext context) : base(context)
	{
	}

	public int GetProductCount()
	{
		var context = new ApiContext();
		int value = context.Products.Count();
		return value;
	}
}

