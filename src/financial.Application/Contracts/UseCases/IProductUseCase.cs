using financial.Model.DTOs.Product;
using financial.Model.Entities;

namespace financial.Application.Contracts.UseCases;

public interface IProductUseCase
{
    IEnumerable<DetailProductDto> GetAll();
    Task<long> CreateAsync(CreateProductDto createProduct);
}
