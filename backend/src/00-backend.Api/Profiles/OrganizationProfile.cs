using AutoMapper;
using backend.Api.Configurations;
using backend.Api.Models;
using backend.Domain.Entities;

namespace backend.Api.Profiles
{
    public class OrganizationProfile : Profile
    {
        protected HashConfiguration _hash;
        public OrganizationProfile()
        {
            _hash = new HashConfiguration();
            
            CreateMap<UserModel, User>()       
                .AfterMap((model, entity)=>{
                    entity.Password = _hash.Encrypt(model.Password);
                });
            CreateMap<UserCreateModel, User>()
                .AfterMap((model, entity)=>{
                    entity.Password = _hash.Encrypt(model.Password);
                });
            CreateMap<User, UserModel>();
        }   
    }
}