using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Domain.Entities;
using StoreAPI.Domain.Exceptions;
using StoreAPI.Domain.Interfaces.Repositories;
using StoreAPI.Domain.Validators;
using StoreAPI.Infrastructure.DTO;
using StoreAPI.Infrastructure.UnitOfWork.Repositories;
using StoreAPI.Service.Interfaces;
using System;

namespace StoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private IValidator<Product> _validator;
        private readonly IMapper _mapper;
         
        public ProductController(IProductService productService, IMapper mapper, IValidator<Product> validator)
        {
            _productService = productService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await _productService.GetById(id);

                var response = _mapper.Map<ProductDTOResponse>(product);

                return Ok(response);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTORequest productDTORequest)
        {
            try
            {
                var product = _mapper.Map<ProductDTORequest, Product>(productDTORequest);
                ValidationResult result = await _validator.ValidateAsync(product);

                if(!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                var createdProdcut = await _productService.Create(product);

                return Ok(createdProdcut);
            }
            catch (UniqueException ex)
            {
                return Conflict(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, ProductDTORequest productDTORequest)
        {
            try
            {
                await _productService.Update(id, productDTORequest.Name, productDTORequest.Price);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _productService.DeleteById(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
