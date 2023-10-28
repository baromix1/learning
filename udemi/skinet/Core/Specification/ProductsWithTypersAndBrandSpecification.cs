using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypersAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypersAndBrandSpecification(ProductsSpecParams productParams)
        : base(x=>
            (!productParams.Brandid.HasValue|| x.ProductBrandId==productParams.Brandid)&&
            (!productParams.Typeid.HasValue|| x.ProductTypeId==productParams.Typeid)
        )
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
            AddOrderBy(x=>x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1),productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort)){
                switch(productParams.Sort){
                    case "priceAsc":
                        AddOrderBy(p=>p.Price);
                    break;
                    case "priceDesc":
                        AddOrderByDescending(p=>p.Price);
                        break;
                    default:
                        AddOrderBy(n=>n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypersAndBrandSpecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}