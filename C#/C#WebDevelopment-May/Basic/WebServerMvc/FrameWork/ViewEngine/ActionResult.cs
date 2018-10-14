using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.Interfaces;

namespace FrameWork.ViewEngine
{
    public class ActionResult:IActionResult
    {

	    public ActionResult(string viewFullQualifedName)
	    {
		    this.Action = (IRenderable)Activator.CreateInstance(Type.GetType(viewFullQualifedName));
	    }
	    public string Invoke()
	    {
		    return this.Action.Render();
	    }

	    public IRenderable Action { get; set; }
    }
}
