﻿using AutoMapper;
using MediatR;
using System.Xml;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.All.AllUsers
{
    public class ListUsers
    {
        public List<UserDTO>? lstUsers { get; set; }
    }

    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ListUsers>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<ListUsers> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            ListUsers listUsers = new ListUsers();

            var userDB = await _crudService.GetAsync<User>();

            listUsers.lstUsers = _mapper.Map<List<UserDTO>>(userDB);

            return listUsers;
        }
    }
}
