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
    public interface IUsersService
    {
        IResult Add(UsersDto user);
        IResult Update(UsersDto user);
        IResult Delete(UsersDto user);
        IDataResult<List<UsersDto>> GetAll(Expression<Func<Users, bool>> filter = null);
        IDataResult<UsersDto> Get(Expression<Func<Users, bool>> filter = null);
    }
}
