using MyApiNight_DataAccessLayer.Abstract;
using MyApiNight_DataAccessLayer.Context;

namespace MyApiNight_DataAccessLayer.Repositories;
public class GenericRepository<T> : IGenericDal<T> where T : class
{
	private readonly ApiContext _context;

	public GenericRepository(ApiContext context)
	{
		_context = context;
	}

	public void Delete(int id)
	{
		var value = _context.Set<T>().Find(id);
		_context.Set<T>().Remove(value);
		_context.SaveChanges();
	}

	public List<T> GetAll()
	{
		return _context.Set<T>().ToList();
	}

	public T GetById(int id)
	{
		return _context.Set<T>().Find(id);
	}

	public void Insert(T entity)
	{
		_context.Set<T>().Add(entity);
		_context.SaveChanges();
	}

	public void Update(T entity)
	{
		_context.Set<T>().Update(entity);
		_context.SaveChanges();
	}
}

