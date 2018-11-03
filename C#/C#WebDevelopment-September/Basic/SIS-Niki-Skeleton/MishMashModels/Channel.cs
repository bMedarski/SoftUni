namespace MishMashModels
{
	using System.Collections.Generic;

	public class Channel
	{
		public Channel()
		{
			this.Followers = new HashSet<UserChannel>();
			this.Tags = new HashSet<ChannelTag>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ChannelType Type { get; set; }
		public ICollection<ChannelTag> Tags { get; set; }
		public ICollection<UserChannel> Followers { get; set; }


	}
}
