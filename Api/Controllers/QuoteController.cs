using BusinessApi.Factories;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{
    private readonly IQuoteFactory _quoteFactory;

    public QuoteController(IQuoteFactory quoteFactory)
    {
        _quoteFactory = quoteFactory;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Quote>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var quotes = _quoteFactory.GetAll();
        return Ok(quotes);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Quote), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var quote = _quoteFactory.GetById(id);
        return quote is null ? NotFound($"Quote {id} not found.") : Ok(quote);
    }
}
