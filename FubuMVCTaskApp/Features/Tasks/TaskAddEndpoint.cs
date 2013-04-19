using FubuMVC.Core.Continuations;
using FubuMVCTaskApp.Core;
using System;

namespace FubuMVCTaskApp.Features.Tasks
{
	public class TaskAddEndpoint
	{
		private readonly IRepository _repository;

		public TaskAddEndpoint(IRepository repository)
		{
			_repository = repository;
		}

		public TaskAddInput get_task_add(TaskAddInput input)
		{
			return input;
		}

		public FubuContinuation post_task_add(TaskAddInput input)
		{
			_repository.Save(
				new TaskEditModel
				{
					TaskText = input.TaskText,
					DateDue = input.DateDue
				}
			);

			return FubuContinuation.RedirectTo("/");
		}
	}

	public class TaskAddInput
	{
		public TaskAddInput()
		{
			DateDue = DateTime.Now;
		}

		public string TaskText { get; set; }
		public DateTime DateDue { get; set; }
	}
}