using Nagaira.Core.Extentions.Responses;
using Nagaira.Template.Api.Features.Categories.Adapters.Dtos;

namespace Nagaira.Template.Api.Features.Categories.Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task<Response<List<CategoryDto>>> GetAll();
        Task<Response<CategoryDto>> Add(CategoryDto categoryDto);
        Task<Response<CategoryDto>> Update(CategoryDto categoryDto);
        Task<Response> Delete(int id);
    }
}
