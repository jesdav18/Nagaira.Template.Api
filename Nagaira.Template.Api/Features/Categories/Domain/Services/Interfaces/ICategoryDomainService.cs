using Nagaira.Core.Extentions.Responses;

namespace Nagaira.Template.Api.Features.Categories.Domain.Services.Interfaces
{
    public interface ICategoryDomainService
    {
        Task<Response<bool>> CategoryExists(string description);
    }
}
