using financial.Model.DTOs.Sale;

namespace financial.Application.Contracts.UseCases;

public interface ISaleUseCase
{
    Task<long> CreateAsync(InputSaleDto sale);
}
