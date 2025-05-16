using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using financial.Application.Contracts.Repositories;
using financial.Application.Contracts.UseCases;
using financial.Model.DTOs.Client;
using financial.Model.Entities;
using System;

namespace financial.Application.UseCases;

public class CustomerCrudUseCase : ICustomerCrudUseCase
{
    private readonly IRepository<Customer> _customerRepository;
    private IValidator<InputCustomerDto> _validator;
    private readonly IMapper _mapper;

    public CustomerCrudUseCase(IMapper mapper, IRepository<Customer> customerRepository, IValidator<InputCustomerDto> validator)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _validator = validator;
    }

    public IEnumerable<Customer> GetAll()
    {
        var clients = _customerRepository.GetAll();
        return clients.ToList();
    }

    public async Task<long> CreateAsync(InputCustomerDto inputCustomer)
    {
        ValidationResult result = _validator.Validate(inputCustomer);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var entity = _mapper.Map<Customer>(inputCustomer);
        _customerRepository.Add(entity);

        await _customerRepository.SaveChangesAsync();

            return entity.Id;
    }
}
