using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductsSpecParams productParams)
        : base(x=>
            (!productParams.Brandid.HasValue|| x.ProductBrandId==productParams.Brandid)&&
            (!productParams.Typeid.HasValue|| x.ProductTypeId==productParams.Typeid)
        )
        {

        }
    }
}