using MyApiNight_BusinessLayer.Abstract;
using MyApiNight_DataAccessLayer.Abstract;
using MyApiNight_EntityLayer.Concrete;

namespace MyApiNight_BusinessLayer.Concrete;
public class ProductManager : IProductService
{
	private readonly IProductDal _productDal;

	public ProductManager(IProductDal productDal)
	{
		_productDal = productDal;
	}

	public void TDelete(int id)
	{
		_productDal.Delete(id);
	}

	public List<Product> TGetAll()
	{
		return _productDal.GetAll();
	}

	public Product TGetById(int id)
	{
		return _productDal.GetById(id);
	}

	public int TGetProductCount()
	{
		return _productDal.GetProductCount();
	}

	public void TInsert(Product entity)
	{
		_productDal.Insert(entity);
	}

	public void TUpdate(Product entity)
	{
		_productDal.Update(entity);
	}
}

