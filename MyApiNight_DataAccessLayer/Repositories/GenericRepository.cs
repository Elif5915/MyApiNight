using MyApiNight_DataAccessLayer.Abstract;

namespace MyApiNight_DataAccessLayer.Repositories;
public class GenericRepository<T> : IGenericDal<T> where T : class
{
	public void Delete(int id)
	{
		throw new NotImplementedException();
	}

	public List<T> GetAll()
	{
		throw new NotImplementedException();
	}

	public T GetById(int id)
	{
		throw new NotImplementedException();
	}

	public void Insert(T entity)
	{
		throw new NotImplementedException();
	}

	public void Update(T entity)
	{
		throw new NotImplementedException();
	}
}

