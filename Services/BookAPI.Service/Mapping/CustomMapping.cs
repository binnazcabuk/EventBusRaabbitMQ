using AutoMapper;
using BookAPI.Service.Commands;
using BookAPI.Service.Dto;
using BookAPI.Service.Models;
using BookAPI.Service.Queries;

namespace BookAPI.Service.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Book,BookCreateDto>().ReverseMap();
            CreateMap<Book,BookViewDto>().ReverseMap();
            CreateMap<Book,CreateBookCommand>().ReverseMap();
            CreateMap<BookViewDto, GetAllBookQuery>().ReverseMap();
           
        }
    }
}
