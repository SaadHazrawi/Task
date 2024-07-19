using Application.Common.Dtos.Author;
using Application.Common.Dtos.Book;
using Application.Common.Dtos.Category;
using Application.Common.Dtos.SubCategory;
using AutoMapper;
using Core.Model;

namespace Application.Common.Helper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region BookMapper
            CreateMap<BookAddDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();
            CreateMap<Book, BookResponseDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src => src.Subcategory.SubcategoryName));
            #endregion
            #region CategoryMapper
            CreateMap<Category,CategoreyAddDto>().ReverseMap();
            CreateMap<Category, CategoryResponseDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName)).ReverseMap();
            #endregion
            #region SubCategorey
            CreateMap<SubCategory, SubCategoryAddDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoryResponseDTO>().ReverseMap();
            #endregion
            #region Author
            CreateMap<Author, AuthorAddDto>().ReverseMap();
            #endregion
        }
    }
}
