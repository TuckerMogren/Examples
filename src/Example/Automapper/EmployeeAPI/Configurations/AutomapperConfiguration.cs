using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Data.Models;
using Domain.DTOModels;
using Domain.Interfaces;

namespace EmployeeAPI.Configurations
{ 

	[ExcludeFromCodeCoverage]
	public static class AutomapperConfiguration
	{

		public static void ConfigureAutoMapper (this IServiceCollection services)
		{
			var mappingConfig = MappingConfig();

			IMapper mapper = mappingConfig.CreateMapper();

			services.AddSingleton(mapper);
		}


		public static MapperConfiguration MappingConfig()
		{
			return new MapperConfiguration(mc =>
            {
                mc.CreateMap<Int32, Employee>()
                .ForMember(x => x.ID, y => y.MapFrom(z => z));

                mc.CreateMap<Employee, EmployeeDTO>()
                    .ForMember(dto => dto.Dept, act => act
                        .MapFrom(src => src.Department))
                    .ForMember(dto => dto.FullName, act => act
                        .MapFrom(mapExpression: src => string.Concat(src.firstName, " ", src.lastName)))
                    .ReverseMap();

                mc.CreateMap<EmployeeDTO, Employee>()
                    .ForMember(emp => emp.ID, act => act.Ignore())
                    .ForMember(emp => emp.firstName, act => act.MapFrom(x => string.IsNullOrEmpty(x.FullName) ? "": x.FullName.Split()[0]))
                    .ForMember(emp => emp.lastName, act => act.MapFrom(x => string.IsNullOrEmpty(x.FullName) ? "" : x.FullName.Split()[1]))
                    .ForMember(emp => emp.Department, act => act.MapFrom(src => src.Dept))
                    .ReverseMap();

                mc.CreateMap<IEmployeeDTO, Employee>()
                    .ForMember(emp => emp.ID, act => act.Ignore())
                    .ForMember(emp => emp.firstName, act => act.MapFrom(x => string.IsNullOrEmpty(x.FullName) ? "" : x.FullName.Split()[0]))
                    .ForMember(emp => emp.lastName, act => act.MapFrom(x => string.IsNullOrEmpty(x.FullName) ? "" : x.FullName.Split()[1]))
                    .ForMember(emp => emp.Department, act => act.MapFrom(src => src.Dept))
                    .ReverseMap();

            });

        }
	}
}


