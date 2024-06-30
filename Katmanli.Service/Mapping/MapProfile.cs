using AutoMapper;
using Katmanli.DataAccess.DTOs;
using Katmanli.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katmanli.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserQuery>().ReverseMap();
            CreateMap<User, UserCreate>().ReverseMap();
            CreateMap<User, UserUpdate>().ReverseMap();

            CreateMap<AboutMe, AboutMeQuery>().ReverseMap();
            CreateMap<Article, ArticleQuery>().ReverseMap();
            CreateMap<Article, ArticleCreate>().ReverseMap();
            CreateMap<Article, ArticleUpdate>().ReverseMap();

            CreateMap<Project, ProjectQuery>().ReverseMap();
            CreateMap<Project, ProjectCreate>().ReverseMap();
            CreateMap<Project, ProjectUpdate>().ReverseMap();
        }
    }
}
