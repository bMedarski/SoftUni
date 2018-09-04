using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork
{
    public class MvcContext
    {
	    private static MvcContext Instance;

		private MvcContext(){}

	    public static MvcContext Get => Instance == null ? (Instance = new MvcContext()) : Instance;

		public string AssemblyName { get; set; }
	    public string ControllersFolder { get; set; } = "Cotrollers";
	    public string ControllersSuffix { get; set; } = "Cotroller";
	    public string ViewsFolder { get; set; } = "Views";
	    public string ModelsFolder { get; set; } = "Models";
    }
}
