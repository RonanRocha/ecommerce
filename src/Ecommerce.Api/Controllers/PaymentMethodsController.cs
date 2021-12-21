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
    [Route("api/paymentmethods")]
    public class PaymentMethodsController : Controller
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<PaymentMethod> _validator;

        public PaymentMethodsController(
                IPaymentMethodRepository paymentMethodRepository,
                IMapper mapper,
                IUnitOfWork uow,
                IValidator<PaymentMethod> validator
            )
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
            _uow = uow;
            _validator = validator;
        }



        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IList<PaymentMethodDto>>> GetAll()
        {
            var paymentMethods = await _paymentMethodRepository.GetAll();

            var result = _mapper.Map<IList<PaymentMethodDto>>(paymentMethods);

            return Ok(result);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IList<PaymentMethodDto>>> GetById(Guid id)
        {
            var paymentMethod = await _paymentMethodRepository.GetById(id);

            if (paymentMethod == null) return NotFound();

            var result = _mapper.Map<PaymentMethod>(paymentMethod);

            return Ok(result);
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Save([FromBody] PaymentMethodDto paymentMethodDto)
        {
            try
            {

                var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodDto);

                var resultValidation = await _validator.ValidateAsync(paymentMethod);

                if (!resultValidation.IsValid) return UnprocessableEntity(resultValidation.Errors);

                paymentMethod.EntityStatus = EntityStatus.Active;
                paymentMethod.RegisterDate = DateTime.Now;


                await _paymentMethodRepository.Save(paymentMethod);

                await _uow.Commit();

                var result = _mapper.Map<PaymentMethodDto>(paymentMethod);

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _uow.Rollback();
                return BadRequest();
            }

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update([FromBody] PaymentMethodDto paymentMethodDto, Guid id)
        {
            try
            {

                var paymentMethod = await _paymentMethodRepository.GetById(id);

                if (paymentMethod == null) return NotFound();

                paymentMethod.Description = paymentMethodDto.Description;
                paymentMethod.UpdateDate = DateTime.Now;

                var resultValidation = await _validator.ValidateAsync(paymentMethod);

                if (!resultValidation.IsValid) return UnprocessableEntity(resultValidation.Errors);

                await _paymentMethodRepository.Update(paymentMethod);

                await _uow.Commit();

                var result = _mapper.Map<PaymentMethodDto>(paymentMethod);

                return Ok(result);
            }
            catch (Exception ex)
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
                var paymentMethod = await _paymentMethodRepository.GetById(id);

                if (paymentMethod == null) return NotFound();

                paymentMethod.DeleteDate = DateTime.Now;
                paymentMethod.EntityStatus = EntityStatus.Inactive;

                await _paymentMethodRepository.Update(paymentMethod);

                await _uow.Commit();

                return Ok(paymentMethod);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


    }
}
