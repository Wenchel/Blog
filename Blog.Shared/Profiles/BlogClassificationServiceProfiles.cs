using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Blog.Shared.DataTransferObjects;
using Blog.Shared.Entities;
using Blog.Shared.Parameters;

namespace Blog.Shared.Profiles
{
    public class BlogClassificationServiceProfiles : Profile
    {
        public BlogClassificationServiceProfiles()
        {
            CreateMap<BlogClassificationService_AddPara, BlogClassification>();
            CreateMap<BlogClassificationService_UpdatePara, BlogClassification>();
            CreateMap<BlogClassification, BlogClassificationService_AddDto>();
            CreateMap<BlogClassification, BlogClassificationService_GetDto>();
            CreateMap<BlogClassification, BlogClassificationService_UpdateDto>();
        }
    }
}
