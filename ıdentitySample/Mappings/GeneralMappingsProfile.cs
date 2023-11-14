using AutoMapper;
using ıdentitySample.Context;
using ıdentitySample.Models;
using ıdentitySample.ViewModels;

namespace ıdentitySample.Mappings
{
    public class GeneralMappingsProfile:Profile
    {

        public GeneralMappingsProfile()
        {
            CreateMap<AppUser, AppUserListVM>();
            CreateMap<AppUser, SignUpViewModel>();
            CreateMap<SignUpViewModel, AppUser>();
            

        }
    }
}
