namespace MishMashModels
{
	public class ChannelTag
	{
		public int Id { get; set; }
		public int ChannelId { get; set; }
		public Channel Channel { get; set; }
		public int TagId { get; set; }
		public Tag Tag { get; set; }
	}
}
