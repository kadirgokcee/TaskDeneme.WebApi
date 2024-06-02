using Domain.Entities;
using Domain.Repositories.ProductRepositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Application.Features.Products.Commands.CreateProduct;

namespace Persistance.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductCommandRepository _commandRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductCommandRepository commandRepository
    , IUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(CreateProductCommand request)
        {
            Product product = new()
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = request.CompanyId,
                CreatedDate = DateTime.Now,
                ProductName = request.ProductName,
                Price = request.Price,
                Stock = request.Stock,
            };

            await _commandRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
