public class Robot :IIdentifiable
{
	private string model;
	private string id;

	public Robot(string model,string id)
	{
		this.Model = model;
		this.Id = id;
	}
	public string Model { get; set; }
	public string Id { get; set; }
}

