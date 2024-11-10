using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
  public ProductSpecification(ProductSpecificationParams specParams) : base(x =>
    (string.IsNullOrWhiteSpace(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
    (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand)) &&
    (specParams.Types.Count == 0 || specParams.Types.Contains(x.Type))
  )
  {
    //for the first page, we skip 0, then take 5
    //for the second page, we skip 5, then take 5
    // etc...
    ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

    //adding ordering functionality
    switch (specParams.Sort)
    {
      case "priceAsc":
        AddOrderBy(x => x.Price);
        break;
      case "priceDesc":
        AddOrderByDescending(x => x.Price);
        break;
      default:
        AddOrderBy(x => x.Name);
        break;
    }
  }
}
