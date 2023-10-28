using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using API.Dtos;
using AutoMapper;
using API.Errors;
using API.Helpers;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        public readonly IGenericRepository<Product> _productRepo;
        public readonly IGenericRepository<ProductBrand> _productBrandRepo;
        public readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product>productRepo,
        IGenericRepository<ProductBrand>productBrandRepo, IGenericRepository<ProductType>productTypeRepo,IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductsSpecParams productParams){
            var spec=new ProductsWithTypersAndBrandSpecification(productParams);
            var countSpec= new ProductWithFiltersForCountSpecification(productParams);
            var totalItems=await _productRepo.CountAsync(countSpec);
            var products=await _productRepo.ListAsync(spec);
            var data= _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,productParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id){
            var spec=new ProductsWithTypersAndBrandSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if(product==null){
                return NotFound(new ApiResponse(404));
            }
            return _mapper.Map<Product,ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes(){
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}