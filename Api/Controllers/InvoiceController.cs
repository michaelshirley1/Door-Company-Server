using BusinessApi.Interfaces;
using BusinessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApi.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceFactory _invoiceFactory;

    public InvoiceController(IInvoiceFactory invoiceFactory)
    {
        _invoiceFactory = invoiceFactory;
    }

    /// <summary>Get all invoices</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Invoice>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var invoices = _invoiceFactory.GetAll();
        return Ok(invoices);
    }

    /// <summary>Get an invoice by ID</summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Invoice), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var invoice = _invoiceFactory.GetById(id);
        return invoice is null ? NotFound($"Invoice {id} not found.") : Ok(invoice);
    }
}
