using AutoMapper;
using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductsManager : IProductsService
    {
        private readonly IProductsDal _productsDal;
        private readonly IMapper _mapper;

        public ProductsManager(IProductsDal productsDal, IMapper mapper)
        {
            _productsDal = productsDal;
            _mapper = mapper;
        }

        public  IResult Add (ProductsDto product)
        {
            try
            {
                var products = _mapper.Map<Products>(product);
                 _productsDal.Add(products);
                return new SuccessResult("Başarı ile eklendi");

            }
            catch (Exception)
            {
                return new ErrorResult("Eklenemedi");
                throw;
            }
        }
        public IResult Delete (ProductsDto product)
        {
            product.IsDeleted = true;
            product.DeleteTime = DateTime.Now;
            return new SuccessResult("Başarı ile silindi");
        }
        public IResult Update (ProductsDto product)
        {
            var products = _mapper.Map<Products>(product);
            _productsDal.Update(products);
            return new SuccessResult("Başarı ile güncellendi");
        }
        public IDataResult <List<ProductsDto>> GetAll(Expression<Func<Products, bool>> filter = null)
        {
            var product = _productsDal.GetAll(filter);
            var products = _mapper.Map<List<ProductsDto>>(product);
            return new SuccessDataResult<List<ProductsDto>>(products);  
        }
        public IDataResult<ProductsDto> Get(Expression<Func<Products, bool>> filter = null)
        {
            var product = _productsDal.Get(filter);
            var products = _mapper.Map<ProductsDto>(product);
            if (product != null)
            {
                return new SuccessDataResult<ProductsDto>(products);
            }
            else
            {
                return new ErrorDataResult<ProductsDto>("Hata");
            }
        }

       
    }
}
