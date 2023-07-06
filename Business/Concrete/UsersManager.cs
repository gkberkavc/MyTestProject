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
    public class UsersManager : IUsersService
    {
        private readonly IUsersDal _usersDal;
        private readonly IMapper _mapper;

        public UsersManager(IUsersDal usersDal, IMapper mapper)
        {
            _usersDal = usersDal;
            _mapper = mapper;
        }

        public IResult Add (UsersDto user)
        {
            try
            {
                var users = _mapper.Map<Users>(user);
                _usersDal.Add(users);
                return new SuccessResult("Başarı ile eklendi");

            }
            catch (Exception)
            {
                return new ErrorResult("Eklenemedi");
                throw;
            }
        }
        public IResult Delete (UsersDto user)
        {
            var users = _mapper.Map<Users>(user);
            user.IsDeleted = true;
            user.DeleteTime = DateTime.Now;
            return new SuccessResult("Başarı ile silindi");
        }
        public IResult Update (UsersDto user)
        {
            var users =_mapper.Map<Users>(user);
            _usersDal.Update(users);
            return new SuccessResult("Başarı ile güncellendi");
        }
        public IDataResult<List<UsersDto>> GetAll(Expression<Func<Users, bool>> filter = null)
        {
            var user = _usersDal.GetAll(filter);
            var users = _mapper.Map<List<UsersDto>>(user);
            return new SuccessDataResult<List<UsersDto>>(users);
        }
        public IDataResult<UsersDto> Get(Expression<Func<Users, bool>> filter = null)
        {
            var user = _usersDal.Get(filter);
            var users = _mapper.Map<UsersDto>(user);
            if (user != null)
            {
                return new SuccessDataResult<UsersDto>(users);
            }
            else
            {
                return new ErrorDataResult<UsersDto>("Hata");
            }
        }
    }
}
