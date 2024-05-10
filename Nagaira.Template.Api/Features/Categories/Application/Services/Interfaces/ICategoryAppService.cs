using Nagaira.Core.Extentions.Responses;
using Nagaira.Template.Api.Features.Categories.Application.Dtos;

namespace Nagaira.Template.Api.Features.Categories.Application.Services.Interfaces
{
    public interface ICategoryAppService
    {
        Task<Response<List<CategoryDto>>> GetAll();
        Task<Response<CategoryDto>> Add(CategoryDto categoryDto);
        Task<Response<CategoryDto>> Update(CategoryDto categoryDto);
        Task<Response> Delete(int id);
    }
}
