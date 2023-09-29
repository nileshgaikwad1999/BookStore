using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;

namespace BookStore.API.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();
            CreateMap<BooksDto, Book>()
                .ReverseMap()
                .ForMember(e => e.AuthorName, d => d.MapFrom(e => $"{e.Author.FirstName} {e.Author.LastName}"));

            CreateMap<BooksDto, BooksDetails>()
                 .ReverseMap()
                .ForMember(e => e.AuthorName, d => d.MapFrom(e => e.AuthorName));

            CreateMap<CreateAuthorAndBook, AuthorBook>()
                .ForMember(e => e.Id, d => d.MapFrom(x => x.AuthorCreateDto.id))
                .ForMember(e => e.FirstName, d => d.MapFrom(x => x.AuthorCreateDto.FirstName))
                .ForMember(e => e.LastName, d => d.MapFrom(x => x.AuthorCreateDto.LastName))
                .ForMember(e => e.Bio, d => d.MapFrom(x => x.AuthorCreateDto.Bio))
                  .ForMember(e => e.Books, d => d.MapFrom(x => x.BooksDto))
                  .ReverseMap()

                ;

        }
    }
}
