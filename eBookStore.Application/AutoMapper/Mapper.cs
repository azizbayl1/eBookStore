using AutoMapper;
using eBookStore.Domain.Entities;
using eBookStore.DTOs.Authentication;

namespace eBookStore.AutoMapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<RegistrationDTO, BookStoreUser>();
    }
}
