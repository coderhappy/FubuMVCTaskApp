using System;
using FubuMVC.Core.Continuations;
using FubuMVCTaskApp.Core;

namespace FubuMVCTaskApp.Features.Tasks
{
	public class TaskEditEndpoint
	{
		private readonly IRepository _repository;

		public TaskEditEndpoint(IRepository repository)
		{
			_repository = repository;
		}

		public TaskEditModel get_task_Id(TaskEditModel model)
		{
			var t = _repository.Find<TaskEditModel>(model.Id);
			return t;
		}

		public FubuContinuation post_task_edit(TaskEditModel model)
		{
			var task = new TaskEditModel
			{
				Id = model.Id,
				TaskText = model.TaskText,
				DateCreated = model.DateCreated,
				DateDue = model.DateDue
			};

			_repository.Delete(_repository.Find<TaskEditModel>(model.Id));
			_repository.Save(task);

			return FubuContinuation.RedirectTo("/");
		}
	}

	public class TaskEditModel:IEntity
	{
		public TaskEditModel()
		{
			DateCreated = DateTime.Now;
			DateDue = DateTime.Now;
		}

		public int Id { get; set; }
		public string TaskText { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateDue { get; set; }
	}
}