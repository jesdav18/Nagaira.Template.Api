using AutoMapper;
using Nagaira.Template.Api.Features.Categories.Application.Dtos;
using Nagaira.Template.Api.Features.Categories.Domain.Entities;

namespace Nagaira.Template.Api.Features.Categories.Infraestructure.Mappers
{
    public class CategoryMapperDto : Profile
    {
        public CategoryMapperDto() : base("CategoryProfile")
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
