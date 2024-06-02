using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Commands.UpdateCompany;
using Application.Features.Products.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductService
    {
        Task AddAsync(CreateProductCommand request);
    }
}
