﻿using Nagaira.DataLayer.Core.Repositories;
using Nagaira.DataLayer.Core.Standard;
using Nagaira.Template.Api.Features.Categories.Domain.Entities;
using Nagaira.Template.Api.Features.Categories.Domain.Repositories;
using Nagaira.Template.Api.Infraestructure.DbContexts;

namespace Nagaira.Template.Api.Features.Categories.Infraestructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _categoryRepository;

        public CategoryRepository(IUnitOfWorkBuilder<UnitOfWorkType> unitOfWorkBuilder)
        {
            _unitOfWork = unitOfWorkBuilder.Build(UnitOfWorkType.Example);
            _categoryRepository = _unitOfWork.Repository<Category>();
        }

        public async Task AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
        }

        public async Task<List<Category>> GetActiveCategories()
        {
            return await _categoryRepository.WhereAsync(x => x.Active);
        }

        public async Task<Category> GetCategoryByDescription(string description)
        {
            return await _categoryRepository.FirstOrDefaultAsync(x => x.Active && x.Description.Equals(description));
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _categoryRepository.FirstOrDefaultAsync(x => x.Active && x.Id == categoryId);
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
