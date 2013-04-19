using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FubuMVCTaskApp.Core
{
	public class AjaxResponse
	{
		public bool Success { get; set; }
		public object Item { get; set; }
	}
}