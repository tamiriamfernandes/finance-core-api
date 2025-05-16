using financial.Model.DTOs.User;

namespace financial.Application.Contracts.UseCases;

public interface IOauthUseCase
{
    Task<long> CreateAsync(CreateUserDto createUser);
}
