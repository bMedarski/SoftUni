using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.Interfaces.Generic;

namespace FrameWork.ViewEngine.Generic
{
    public class ActionResult<T>:IActionResult<T>
    {

	    public ActionResult(string viewFullQuilifiedName,T model)
	    {
		    this.Action = (IRenderable<T>) Activator.CreateInstance(Type.GetType(viewFullQuilifiedName));
		    this.Action.Model = model;
	    }
	    public string Invoke()
	    {
		    return this.Action.Render();
	    }

	    public IRenderable<T> Action { get; set; }
    }
}
