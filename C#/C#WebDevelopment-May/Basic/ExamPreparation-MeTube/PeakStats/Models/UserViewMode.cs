using System;
using System.Collections.Generic;
using System.Text;

namespace PeakStats.Models
{
    public class UserViewMode
    {
	    public int Id { get; set; }
	    public string Name { get; set; }
	    public ICollection<Peak> Tubes { get; set; }
	}
}
