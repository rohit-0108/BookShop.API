using AutoMapper;
using BookShop.API.DTOs;
using BookShop.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Mappers
{
    public class BookshopMapper : Profile
    {
        public BookshopMapper() { 
        CreateMap<Category,CategoryDTO>();
        CreateMap<CategoryCreationDTO,Category>();
        CreateMap<Author,AuthorDTO>();


        }

    }
}
