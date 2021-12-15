using AutoMapper;
using Eccomerce.Domain.Entities;
using Eccomerce.Domain.Repositories;
using Eccomerce.Domain.UnitOfWork;
using Eccomerce.Domain.ValueObjects;
using Ecommerce.Api.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<Product> _validator;

        public ProductsController(
        IProductRepository productRepository,
        IMapper mapper, IUnitOfWork uow,
        IValidator<Product> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _uow = uow;
            _validator = validator;
        }


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IList<ProductDto>>> GetAll()
        {
            var products = await _productRepository.GetAll();

            var result =  _mapper.Map<IList<ProductDto>>(products);

            return Ok(result);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IList<ProductDto>>> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null) return NotFound();

            var result = _mapper.Map<ProductDto>(product);

            return Ok(result);
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Save([FromBody] ProductDto productDto)
        {
            try
            {

                var product = _mapper.Map<Product>(productDto);

                var resultValidation = await _validator.ValidateAsync(product);

                if (!resultValidation.IsValid) return UnprocessableEntity(resultValidation.Errors);

                product.EntityStatus = EntityStatus.Active;
                product.RegisterDate = DateTime.Now;
              

                await _productRepository.Save(product);

                await _uow.Commit();

                var result = _mapper.Map<ProductDto>(product);

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _uow.Rollback();
                return BadRequest();
            }

        }




    }
}
