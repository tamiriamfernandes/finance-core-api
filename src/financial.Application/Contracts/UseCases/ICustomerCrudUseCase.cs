using financial.Model.Entities;
using financial.Model.DTOs.Client;

namespace financial.Application.Contracts.UseCases;

public interface ICustomerCrudUseCase
{
    IEnumerable<Customer> GetAll();
    Task<long> CreateAsync(InputCustomerDto inputClient);
}
