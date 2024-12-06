using MyApiNight_DataAccessLayer.Abstract;
using MyApiNight_DataAccessLayer.Context;
using MyApiNight_DataAccessLayer.Repositories;
using MyApiNight_EntityLayer.Concrete;

namespace MyApiNight_DataAccessLayer.EntityFramework;
public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
{
	public EfCategoryDal(ApiContext context) : base(context)
	{
	}
}

