using System;
using System.Collections.Generic;
using System.Text;

namespace PeakStats.Models
{
    public class User
    {
	    public int Id { get; set; }

	    public string Name { get; set; }

	    public string Password { get; set; }

	    public int PeakId { get; set; }

	    public ICollection<Peak> Peaks { get; set; }

    }
}
