using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FubuMVCTaskApp.Core
{
	/// <summary>
	/// Stores Entities in the .Net Session State
	/// </summary>
	public class Repository:IRepository
	{
		private static readonly HashSet<object> _items = new HashSet<object>();
		private static int _nextId;

		public T Find<T>(int id) where T:IEntity
		{
			return _items.OfType<T>().FirstOrDefault(item => item.Id == id);
		}

		public IQueryable<T> Query<T>()
		{
			return _items.OfType<T>().AsQueryable();
		}

		/// <summary>
		/// Create entity and add it to a HashSet of items. 
		/// Assign it the next available Id.
		/// </summary>
		/// <param name="item">Entity to create</param>
		public void Save(object item)
		{
			var entity = item as IEntity;
			if(entity != null && entity.Id == 0)
			{
				entity.Id = Interlocked.Increment(ref _nextId);
			}
			_items.Add(item);
		}

		/// <summary>
		/// Delete an Entity
		/// </summary>
		/// <param name="item">Entity to delete</param>
		public void Delete(object item)
		{
			_items.Remove(item);
		}
	}
}