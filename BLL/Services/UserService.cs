﻿using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork uow, IUserRepository repository)
        {
            _uow = uow;
            _userRepository = repository;
        }

        public UserEntity GetUserEntity(int id)
        {
            return _userRepository.GetById(id).ToBllUser();
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return _userRepository.GetAll().Select(user => user.ToBllUser());
        }

        public void CreateUser(UserEntity user)
        {
            _userRepository.Create(user.ToDalUser());
            _uow.Commit();
        }

        public UserEntity GetUserByEmail(string email)
        {
            return _userRepository.GetByEmail(email).ToBllUser();
        }

        public IEnumerable<UserEntity> GetUsersExceptCurrent(string currentUserEmail)
        {
            return _userRepository.GetAll().Where(user => user.Email != currentUserEmail).
            Select(user => user.ToBllUser());
        }
    }
}