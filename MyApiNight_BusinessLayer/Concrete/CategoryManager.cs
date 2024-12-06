using MyApiNight_BusinessLayer.Abstract;
using MyApiNight_DataAccessLayer.Abstract;
using MyApiNight_EntityLayer.Concrete;

namespace MyApiNight_BusinessLayer.Concrete;
public class CategoryManager : ICategoryService
{
	private readonly ICategoryDal _categoryDal;

	public CategoryManager(ICategoryDal categoryDal)
	{
		_categoryDal = categoryDal;
	}

	public void TDelete(int id)
	{
		_categoryDal.Delete(id);
	}

	public List<Category> TGetAll()
	{
		return _categoryDal.GetAll();
	}

	public Category TGetById(int id)
	{
		return _categoryDal.GetById(id);
	}

	public void TInsert(Category entity)
	{
		_categoryDal.Insert(entity);
	}

	public void TUpdate(Category entity)
	{
		_categoryDal.Update(entity);
	}
}

