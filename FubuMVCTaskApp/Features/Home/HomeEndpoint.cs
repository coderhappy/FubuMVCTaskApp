using FubuMVCTaskApp.Core;
using System.Linq;
using FubuMVCTaskApp.Features.Tasks;
using HtmlTags;

namespace FubuMVCTaskApp.Features.Home
{
	public class HomeModel
	{
		public TagList Tasks { get; set; }
	}

	// Fubu's default policies look for classes suffixed with "Endpoint" or "Endpoints"
	public class HomeEndpoint
	{
		private readonly IRepository _repository;

		public HomeEndpoint(IRepository repository)
		{
			_repository = repository;
		}

		// Fubu will use HomeEndpoint.Index as the default "home" route
		public HomeModel Index()
		{
			/* Create a list item for each task
			 * Using HTMLTags - http://htmltags.fubu-project.org/
			 * Example Format: <li><a href="/task/1">Task To Do</a></li> 
			 */
			var newTasks = new TagList(
				_repository.Query<TaskEditModel>()
					.Select(t => new HtmlTag("li")
						.Append(new LinkTag(t.TaskText, "/task/" + t.Id)
							.Append(new HtmlTag("i")
								.AddClass("icon-pencil")
							)
						)
					)
			);
			return new HomeModel { Tasks = newTasks };

			/* This accomplishes the same thing as above - there are many ways to use HtmlTag 
			 */
			//var tasks = _repository.Query<Task>().Select(t => new HtmlTag("li").Append(new HtmlTag("a").Attr("href", "/task/" + t.Id).Text(t.TaskText)));
			//return new HomeModel { Tasks = tasks.ToTagList() };
		}
	}
}