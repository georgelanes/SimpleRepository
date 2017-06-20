using AutoMapper;
using SimpleRepository.Persistence.Model;
using SimpleRepository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepository.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            //CreateMap<Product, ProductViewModel>()
            //    .ForMember(vm => vm.CategoryName, opt => opt.MapFrom(v => v.Category.Name));
            CreateMap<Product, ProductViewModel>();

            CreateMap<ProductViewModel, Product>();
        }
    }
}
