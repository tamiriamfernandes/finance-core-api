using Microsoft.AspNetCore.Mvc;
using financial.Api.Filters;
using financial.Application.Contracts.UseCases;
using financial.Model.DTOs.Client;

namespace financial.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/customers")]
[ApiResponseFilter]
public class CustomerController : Controller
{
    private readonly ICustomerCrudUseCase _customerUseCase;

    public CustomerController(ICustomerCrudUseCase customerUseCase)
    {
        _customerUseCase = customerUseCase;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _customerUseCase.GetAll();

        if (!result.Any()) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InputCustomerDto inputCustomer)
    {
        var result = await _customerUseCase.CreateAsync(inputCustomer);
        return Ok(result);
    }
}
