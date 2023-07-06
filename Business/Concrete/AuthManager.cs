using AutoMapper;
using Business.Abstract;
using Core.Dtos;
using Core.Utilities.Result.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    
    public class AuthManager : IAuthService
    {
        private readonly UsersLoginDto _usersLoginDto;
        private readonly IMapper _mapper;

        public AuthManager(UsersLoginDto usersLoginDto, IMapper mapper)
        {
            _usersLoginDto = usersLoginDto;
            _mapper = mapper;
        }

        public IDataResult<UsersLoginDto> Login (UsersLoginDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
