﻿using Microsoft.AspNetCore.Mvc;
using financial.Application.Contracts.UseCases;
using financial.Application.UseCases;
using financial.Model.DTOs.Product;
using financial.Model.DTOs.User;

namespace financial.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
public class OauthController : Controller
{
    private readonly IOauthUseCase _userUseCase;

    public OauthController(IOauthUseCase userUseCase)
    {
        _userUseCase = userUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUser)
    {
        var result = await _userUseCase.CreateAsync(createUser);
        return Ok(result);
    }
}
