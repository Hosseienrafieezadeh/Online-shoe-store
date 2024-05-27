using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoeses.Contracts.Interface;
using Shoeses.Entitis.Addresses;
using Shoeses.Services.Addresses.Contracts;
using Shoeses.Services.Addresses.Contracts.Dtos;
using Shoeses.Services.Addresses.Contracts.Exeptions;
using Shoeses.Services.Users.Contracts.Exeptions;

namespace Shoeses.Services.Addresses
{
    public class AddressAppService:addressService
    {
        private readonly AdressRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public AddressAppService(AdressRepository repository,UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(AddAdressDto dto)
        {
            //if (!_repository.IsExistUser(dto.UserId))
            //{
            //    throw new UsersIsNotExistException();
            //}
            var addreess = new Address()
            {
                Street=dto.Street,
                City = dto.City,
                Country = dto.Country,
                IsBillingAddress = dto.IsBillingAddress,
                PostalCode = dto.PostalCode,
                IsShippingAddress = dto.IsShippingAddress,
                State = dto.State
            };
            _repository.Add(addreess);
            await _unitOfWork.Complete();

        }

        public async Task Update(int id, UpdateAdressDto dto)
        {
            var address = _repository.Find(id);
            if (address == null)
            {
                throw new AddressIsNotExistToUpadateException();
            }

            address.State = dto.State;
            address.Country = dto.Country;
            address.IsBillingAddress= dto.IsBillingAddress;
            address.City = dto.City;
            address.IsShippingAddress= dto.IsShippingAddress;
            address.State = dto.State;
            address.PostalCode = dto.PostalCode;
            _repository.Update(address);
           await _unitOfWork.Complete();
        }

        public async Task Delete(int id)
        {
            var address= _repository.Find(id);
            if (address==null)
            {
                throw new AddressIsNotExistException();
            }

            _repository.Delete(address);
             await  _unitOfWork.Complete();
        }

        public async Task<List<GetAdressDto>> GetAll()
        {
            return await _repository.GetAll(); 
        }
    }
}
