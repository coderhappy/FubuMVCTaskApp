using FubuMVC.Core.Continuations;
using FubuMVCTaskApp.Core;

namespace FubuMVCTaskApp.Features.Tasks
{
	public class TaskDeleteEndpoint
	{
		private readonly IRepository _repository;

		public TaskDeleteEndpoint(IRepository repository)
		{
			_repository = repository;
		}

		public FubuContinuation post_task_delete_Id(TaskDeleteInput input)
		{
			_repository.Delete(_repository.Find<TaskEditModel>(input.Id));
			return FubuContinuation.RedirectTo("/");
		}

	}

	public class TaskDeleteInput:IEntity
	{
		public int Id { get; set; }
	}
}