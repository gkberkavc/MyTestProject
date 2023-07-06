using Core.Dtos;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductsService
    {
        IResult Add (ProductsDto product);
        IResult Update (ProductsDto product);
        IResult Delete (ProductsDto product);
        IDataResult<List<ProductsDto>> GetAll(Expression<Func<Products, bool>> filter = null);
        IDataResult<ProductsDto> Get(Expression<Func<Products, bool>> filter = null);
    }
}
