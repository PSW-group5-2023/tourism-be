using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Blog.Core.Mappers;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<BlogDTO, BlogPage>().ReverseMap();
    }
}