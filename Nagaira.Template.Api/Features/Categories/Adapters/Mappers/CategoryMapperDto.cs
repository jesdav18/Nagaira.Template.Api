using AutoMapper;
using Nagaira.Template.Api.Features.Categories.Adapters.Dtos;
using Nagaira.Template.Api.Features.Categories.Domain.Entities;

namespace Nagaira.Template.Api.Features.Categories.Adapters.Mappers
{
    public class CategoryMapperDto : Profile
    {
        public CategoryMapperDto() : base("CategoryProfile")
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
