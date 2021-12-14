using AutoMapper;
using Eccomerce.Domain.Entities;
using Eccomerce.Domain.Repositories;
using Eccomerce.Domain.UnitOfWork;
using Ecommerce.Api.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<Category> _validator;

        public CategoriesController(
            ICategoryRepository  categoryRepository,
            IMapper mapper, IUnitOfWork uow,
            IValidator<Category> validator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _uow = uow;
            _validator = validator;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IList<CategoryDto>>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();
            var result = _mapper.Map<IList<CategoryDto>>(categories);
            return Ok(result);
           
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(Guid id)
        {

            var category = await _categoryRepository.GetById(id);
          
            if (category == null) return NotFound();

            var result = _mapper.Map<CategoryDto>(category);

            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Save([FromBody]CategoryDto categoryDto)
        {
            try
            {

               
                var category = _mapper.Map<Category>(categoryDto);

                var resultValidation = await _validator.ValidateAsync(category);

                if (!resultValidation.IsValid) return UnprocessableEntity(resultValidation.Errors);

                await _categoryRepository.Save(category);

                await _uow.Commit();

                return Ok(category);
            }
            catch(Exception ex)
            {
                await _uow.Rollback();
                return BadRequest();
            }
            
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromBody] CategoryDto categoryDto, Guid id)
        {
            try
            {
               
                var category = await _categoryRepository.GetById(id);

                if (category == null) return NotFound();

                category.Name = categoryDto.Name;

                var resultValidation = await _validator.ValidateAsync(category);

                if (!resultValidation.IsValid) return UnprocessableEntity(resultValidation.Errors);

                _categoryRepository.Update(category);

                await _uow.Commit();

                var result = _mapper.Map<CategoryDto>(category);

                return Ok(result);
            }
            catch(Exception ex)
            {
                await _uow.Rollback();
                return BadRequest();
            }

         
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            try
            {
                var category = await _categoryRepository.GetById(id);

                if (category == null) return NotFound();

                await _categoryRepository.Remove(category.Id);

                await _uow.Commit();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
