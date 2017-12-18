using AutoMapper;
using Instagraph.DataProcessor.DtoModels;
using Instagraph.Models;

namespace Instagraph.App
{
    public class InstagraphProfile : Profile
    {
        public InstagraphProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(u => u.ProfilePicture, pp => pp.UseValue<Picture>(null));

            CreateMap<Post, UncommentedPostDto>()
                .ForMember(dto => dto.Picture, pp => pp.MapFrom(p => p.Picture.Path))
                .ForMember(dto => dto.User, u => u.MapFrom(p => p.User.Username));

            CreateMap<User, PopularUserDto>()
                .ForMember(dto => dto.Followers, f => f.MapFrom(u => u.Followers.Count));
        }
    }
}
