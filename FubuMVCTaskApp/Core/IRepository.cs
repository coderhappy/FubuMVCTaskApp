using System.Linq;

namespace FubuMVCTaskApp.Core
{
	public interface IRepository
	{
		T Find<T>(int id) where T:IEntity;
		IQueryable<T> Query<T>();

		/* Basic operations on an Entity */

		/// <summary>
		/// Create an Entity
		/// </summary>
		/// <param name="item">Item to be created</param>
		void Save(object item);

		/// <summary>
		/// Delete an Entity
		/// </summary>
		/// <param name="item">Item to delete</param>
		void Delete(object item);
	}
}
