using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Blog.Shared.Parameters;

namespace Blog.Shared.Profiles
{
    public class UnionProfiles : Profile
    {
        public UnionProfiles()
        {
            CreateMap<VerificationService_GetVerificationCodePara, UserService_IsExistPara>().ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.EmailAddress));
        }
    }
}
