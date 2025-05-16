using Microsoft.AspNetCore.Mvc;
using financial.Api.Filters;
using financial.Application.Contracts.UseCases;
using financial.Model.DTOs.Client;
using financial.Model.DTOs.Sale;
using financial.Model.Entities;

namespace financial.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/sales")]
[ApiResponseFilter]
public class SaleController : Controller
{
    private readonly ISaleUseCase _saleUseCase;

    public SaleController(ISaleUseCase saleUseCase)
    {
        _saleUseCase = saleUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InputSaleDto sale)
    {
        var result = await _saleUseCase.CreateAsync(sale);
        return Ok(result);
    }
}
