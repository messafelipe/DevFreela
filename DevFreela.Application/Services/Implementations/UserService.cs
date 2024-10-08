﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _dbContext;

        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return new UserViewModel();
            }

            var userViewModel = new UserViewModel( 
                user.FullName,
                user.Email
            );

            return userViewModel;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, 
                                            inputModel.Password,
                                            inputModel.BirthDate);


            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user.Id;
        }
    }
}
