namespace Eventures.WebApp.ViewModels.Events
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using ValidationAttributes;

	public class CreateEventViewModel
	{
		[Required]
		[MinLength(10)]
		public string Name { get; set; }
		
		[Required]
		[MinLength(1)]
		public string Place { get; set; }
		
		[Required(ErrorMessage="The start date is required")]
		[Display(Name="Start Date")]
		[DataType(DataType.DateTime)]
		[FutureDateValidation(ErrorMessage = "Date cannot be in the past")]
		public DateTime Start { get; set; }
		
		[Required(ErrorMessage="The end date is required")]
		[Display(Name="End Date")]
		[DataType(DataType.DateTime)]
		[DateGreaterThan("Start",ErrorMessage = "End date must be later then start date")]
		public DateTime End { get; set; }
		
		[Required]
		[Range(1,int.MaxValue)]
		public int TotalTickets { get; set; }

		[Required]
		[Range(1,double.MaxValue)]
		public decimal PricePerTicket { get; set; }
	}
}
