using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Contracts.Interface;
using Shoeses.Entitis.Addresses;
using Shoeses.Entitis.Users;
using Shoeses.Services.Addresses.Contracts;
using Shoeses.Services.Users.Contracts;
using Shoeses.Services.Users.Contracts.Dtos;
using Shoeses.Services.Users.Contracts.Exeptions;

namespace Shoeses.Services.Users
{
    public class UserAppService:UserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly userRepository _repository;
        private readonly AdressRepository _adressRepository;

        public UserAppService(UnitOfWork unitOfWork,userRepository repository,AdressRepository adressRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _adressRepository = adressRepository;
        } 
        public async Task Add(AddUserDto dto)
            {
                if (_repository.IsExistUser(dto.Email))
                {
                    throw new UsersIsNotExistException();
                }

                var user = new User
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email
                };

                _repository.Add(user);
                await _unitOfWork.Complete();

                // Update user with addresses
                user.Addresses = dto.Addresses.Select(a => new Address
                {
                    UserId = user.Id,
                    Street = a.Street,
                    City = a.City,
                    State = a.State,
                    PostalCode = a.PostalCode,
                    Country = a.Country,
                    IsBillingAddress = a.IsBillingAddress,
                    IsShippingAddress = a.IsShippingAddress
                }).ToList();

                _repository.Update(user);
                await _unitOfWork.Complete();
            
        }

        public async Task Update(string id, UpdateUserDto dto)
        {
            var user = _repository.Find(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;

            var existingAddresses = user.Addresses.ToList();
            var newAddresses = dto.Addresses.Select(a => new Address
            {
                UserId = user.Id,
                Street = a.Street,
                City = a.City,
                State = a.State,
                PostalCode = a.PostalCode,
                Country = a.Country,
                IsBillingAddress = a.IsBillingAddress,
                IsShippingAddress = a.IsShippingAddress
            }).ToList();

            foreach (var address in existingAddresses)
            {
                _adressRepository.Delete(address);
            }

            user.Addresses = newAddresses;

            _repository.Update(user);
            await _unitOfWork.Complete();
        }

 

        public async Task Delete(string id)
        {
            var user = _repository.Find(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var addresses = user.Addresses.ToList();

            foreach (var address in addresses)
            {
                _adressRepository.Delete(address);
            }

            _repository.Delete(user);
            await _unitOfWork.Complete();
        }

        public async Task<List<GetUserDto>> GetAll()
        {
            var users = await _repository.GetAll();
            return users;
        }

    }
}
