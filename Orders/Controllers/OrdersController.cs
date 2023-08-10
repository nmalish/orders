using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Dto;

namespace Orders.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly OrdersContext _context;

    public OrdersController(ILogger<OrdersController> logger, OrdersContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Orders.ToListAsync());
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _context.Orders.FirstOrDefaultAsync(i => i.Id == id));
    }
    
    [HttpGet]
    [Route("GetStatuses")]
    public async Task<IActionResult> GetStatusList()
    {
        return Ok(await _context.Statuses.ToListAsync());
    } 
    
        
    [HttpGet]
    [Route("GetCustomers")]
    public async Task<IActionResult> GetCustomers()
    {
        return Ok(await _context.Customers.ToListAsync());
    } 
    
    [HttpPost]
    [Route("Add")]
    public async Task<IActionResult> Add(OrderDto orderDto)
    {
        var order = _context.Orders.Add(new Order
        {
            CustomerId = orderDto.CustomerId,
            OrderDate = orderDto.OrderDate,
            StatusId = orderDto.StatusId,
            TotalAmount = orderDto.TotalAmount
        });
        await _context.SaveChangesAsync();
        
        orderDto.Id = order.Entity.Id;
        
        return Ok(orderDto);
    }
    
    [HttpPost]
    [Route("EditOrder")]
    public async Task<IActionResult> EditOrder(OrderDto order)
    {
        _context.Orders.Update(new Order
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            StatusId = order.StatusId,
            TotalAmount = order.TotalAmount
        });
        await _context.SaveChangesAsync();
        return Ok(order);
    }
    
    [HttpPost]
    [Route("DeleteOrder")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(i => i.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return Ok(order);
    }
}