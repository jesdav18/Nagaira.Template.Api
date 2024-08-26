using Nagaira.Core.Extentions.Responses;
using Nagaira.Template.Api.Features.Categories.Domain.Entities;
using Nagaira.Template.Api.Features.Categories.Domain.Repositories;
using Nagaira.Template.Api.Features.Categories.Domain.Services.Interfaces;

namespace Nagaira.Template.Api.Features.Categories.Domain.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDomainService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<bool>> CategoryExists(string description)
        {
            Category category = await _categoryRepository.GetCategoryByDescription(description);
            if (category != null) return Response<bool>.Exception("¡Esta categoría ya fue registrada!, por favor verifique e intente nuevamente.", true);

            return Response<bool>.Ok($"La categoría {description} aun no ha sido registrada.", false);
        }
    }
}
