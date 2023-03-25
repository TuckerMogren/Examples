using Domain.DTOModels;
namespace Domain.Interfaces.Repositories
{
	public interface IEmployeeRepository
	{

        Task SaveEmployeeAsync(IEmployeeDTO data);
        Task<EmployeeDto> GetEmployeeByID(int? id);

		
	}
}

