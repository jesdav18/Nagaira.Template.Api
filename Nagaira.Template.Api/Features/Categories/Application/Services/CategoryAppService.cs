﻿using AutoMapper;
using Nagaira.Core.Extentions.Exceptions;
using Nagaira.Core.Extentions.Responses;
using Nagaira.Template.Api.Features.Categories.Application.Dtos;
using Nagaira.Template.Api.Features.Categories.Application.Services.Interfaces;
using Nagaira.Template.Api.Features.Categories.Domain.Entities;
using Nagaira.Template.Api.Features.Categories.Domain.Repositories;
using Nagaira.Template.Api.Features.Categories.Domain.Services.Interfaces;

namespace Nagaira.Template.Api.Features.Categories.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryDomainService _categoryDomainService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryAppService(ICategoryDomainService categoryDomainService, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryDomainService = categoryDomainService;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<Response<CategoryDto>> Add(CategoryDto categoryDto)
        {
            try
            {
                Category category = _mapper.Map<Category>(categoryDto);


                var existeLaversionEnBdResponse = await _categoryDomainService.CategoryExists(categoryDto.Description!);
                if (existeLaversionEnBdResponse.Type != TypeResponse.Ok) return new Response<CategoryDto> { Type = existeLaversionEnBdResponse.Type, Message = existeLaversionEnBdResponse.Message };

                category.UserRegister = "1";
                category.Active = true;
                category.DateRegister = DateTime.Now;

                await _categoryRepository.AddAsync(category)!;
                await _categoryRepository.SaveChangesAsync()!;

                categoryDto.Id = category.Id;

                return Response<CategoryDto>.Ok("¡La categoría se registró exitosamente!", categoryDto);
            }
            catch (Exception ex)
            {
                return Response<CategoryDto>.Exception(MessageException.ShowException(ex));
            }
        }

        public async Task<Response> Delete(int id)
        {
            try
            {
                var categoryBd = await _categoryRepository.GetCategoryById(id);
                if (categoryBd == null) return Response.Exception($"¡La categoria con Id {id} no fue encontrada en el almacén de datos!. Por favor verifique, e intente nuevamente.");

                categoryBd.Active = false;

                await _categoryRepository.SaveChangesAsync();

                return Response.Ok("¡La categoría se eliminó exitosamente!");
            }
            catch (Exception ex)
            {
                return Response.Exception(MessageException.ShowException(ex));
            }
        }

        public async Task<Response<List<CategoryDto>>> GetAll()
        {
            try
            {
                var categories = await _categoryRepository.GetActiveCategories();
                return Response<List<CategoryDto>>.Ok("Ok", _mapper.Map<List<CategoryDto>>(categories));
            }
            catch (Exception ex)
            {

                return Response<List<CategoryDto>>.Exception(MessageException.ShowException(ex));
            }
        }

        public async Task<Response<CategoryDto>> Update(CategoryDto cateogryDto)
        {
            try
            {
                var categoryBd = await _categoryRepository.GetCategoryById(cateogryDto.Id ?? 0);
                if (categoryBd == null) return Response<CategoryDto>.Exception($"¡La categoría con Id {cateogryDto.Id} no fue encontrada en el almacén de datos!. Por favor verifique, e intente nuevamente.");

                categoryBd.Description = cateogryDto.Description;

                await _categoryRepository.SaveChangesAsync();

                return Response<CategoryDto>.Ok("¡La categoría se actualizó exitosamente!", cateogryDto);
            }
            catch (Exception ex)
            {
                return Response<CategoryDto>.Exception(MessageException.ShowException(ex));
            }
        }
    }
}
