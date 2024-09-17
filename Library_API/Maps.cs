using AutoMapper;
using Library_API.Models;
using Library_API.Models.DTOs;

namespace Library_API
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Book, CreatedAndUpdatedBookDTO>().ReverseMap();
        }
    }
}
