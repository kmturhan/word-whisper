using WordWhisper.Core.Models;
using AutoMapper;
using WordWhisper.Web.DTO;
namespace WordWhisper.Web.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDTO>();

            CreateMap<UserDTO, User>();
        }
    }
}
