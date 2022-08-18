using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.API.DTOs;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Specifications;
using Talabat.DAL.Entities;

namespace Talabat.API.Controllers
{
    public class ProductsController : BaseAPIController
    {
        private readonly IGenaricRepository<Product> productsRepo;
        private readonly IGenaricRepository<ProductBrand> brandsRepo;
        private readonly IGenaricRepository<ProductType> typeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenaricRepository<Product> productsRepo ,
            IGenaricRepository<ProductBrand> brandsRepo,IGenaricRepository<ProductType> typeRepo,IMapper mapper)
        {
            this.productsRepo=productsRepo;
            this.brandsRepo=brandsRepo;
            this.typeRepo=typeRepo;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDtos>>> GetProducts()
        {

            var spec = new ProductsWithTypeAndBrandsSpecification();

            var products = await  productsRepo.GetAllWithSpecAsync(spec);

            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDtos>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDtos>> GetProduct(int id )
        {
            var spec = new ProductsWithTypeAndBrandsSpecification(id);
            var products = await productsRepo.GetEntityWithSpecAsync(spec);
            return Ok(mapper.Map<Product , ProductToReturnDtos>(products));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await brandsRepo.GetAllAsync();
            return Ok(brands);

        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes()
        {
            var types = await typeRepo.GetAllAsync();
            return Ok(types);

        }
    }
}
