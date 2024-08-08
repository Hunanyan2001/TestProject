using TestProject.Models;

namespace TestProject.Mapping.Profiles
{
    public class AuthProfile : AutoMapper.Profile
    {
        public AuthProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<LoginModel, User>();
            CreateMap<RegisterModel, User>();
        }
    }
}
