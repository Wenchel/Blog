using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Blog.Shared.Entities;
using Blog.Shared.Parameters;
using NETCore.Encrypt;

namespace Blog.Shared.Profiles
{
    public class UserServiceProfiles : Profile
    {
        public UserServiceProfiles()
        {
            CreateMap<UserService_IsExistPara, User>();
            CreateMap<UserService_SignUpPara, User>().ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => EncryptProvider.Sha256(src.UserPassword)));
            CreateMap<UserService_SignUpPara, UserService_IsExistPara>();
        }
    }
}
