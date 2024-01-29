using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Domain.Entities;
using StoreAPI.Domain.Exceptions;
using StoreAPI.Infrastructure.DTO;
using StoreAPI.Service.Business;
using StoreAPI.Service.Interfaces;

namespace StoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {

            try
            {
                var product = await _orderService.GetById(id);

                return Ok(product);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderDTORequest orderDTORequest)
        {
            try 
            {
                var order = _mapper.Map<Order>(orderDTORequest);

                await _orderService.Create(order, orderDTORequest.Products);

                return Ok();

            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> IsReady(Guid id)
        {
            try
            {
                var order = await _orderService.IsReady(id);

                var response = _mapper.Map<Order>(order);

                return Ok(response);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> IsPaymented(Guid id)
        {
            try
            {
                var order = await _orderService.IsPaymented(id);

                var res = _mapper.Map<OrderDTOResponse>(order);

                return Ok(res);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Cancel(Guid id)
        {
            try
            {
                var order = await _orderService.Cancel(id);

                var res = _mapper.Map<OrderDTOResponse>(order);

                return Ok(res);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                await _orderService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
