using BusinessApi.Factories;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderFactory _orderFactory;

    public OrderController(IOrderFactory orderFactory)
    {
        _orderFactory = orderFactory;
    }

    /// <summary>Get all orders</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Order>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var orders = _orderFactory.GetAll();
        return Ok(orders);
    }

    /// <summary>Get an order by ID</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var order = _orderFactory.GetById(id);
        return order is null ? NotFound($"Order {id} not found.") : Ok(order);
    }
}
