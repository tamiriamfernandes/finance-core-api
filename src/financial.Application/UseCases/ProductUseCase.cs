using AutoMapper;
using financial.Application.Contracts.Repositories;
using financial.Application.Contracts.UseCases;
using financial.Model.DTOs.Product;
using financial.Model.Entities;

namespace financial.Application.UseCases;

public class ProductUseCase : IProductUseCase
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductUseCase(IMapper mapper, IRepository<Product> productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<long> CreateAsync(CreateProductDto createProduct)
    {
        var entity = _mapper.Map<Product>(createProduct);
        _productRepository.Add(entity);

        await _productRepository.SaveChangesAsync();

        return entity.Id;
    }

    public IEnumerable<DetailProductDto> GetAll()
    {
        var products = _productRepository.GetAll().ToList();
        var productsDto = _mapper.Map<IEnumerable<DetailProductDto>>(products);

        return productsDto;
    }
}
