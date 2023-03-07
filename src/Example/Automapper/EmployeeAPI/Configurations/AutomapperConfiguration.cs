using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Data.Models;
using Domain.DTOModels;

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
				mc.CreateMap<Employee, EmployeeDto>()
					.ForMember(dto => dto.Dept, act => act
						.MapFrom(src => src.Department))
					.ForMember(dto => dto.FullName, act => act
						.MapFrom(mapExpression: src => string.Concat(src.FirstName, " ", src.LastName)))
					.ReverseMap();

				mc.CreateMap<EmployeeDto, Employee>()
					.ForMember(emp => emp.Id, act => act.Ignore())
					.ForMember(emp => emp.FirstName, act => act.MapFrom(x => x.FullName.Split()[0]))
                    .ForMember(emp => emp.LastName, act => act.MapFrom(x => x.FullName.Split()[1]))
                    .ForMember(emp => emp.Department, act => act.MapFrom(src => src.Dept))
                        .ReverseMap();

			});
		}
	}
}


