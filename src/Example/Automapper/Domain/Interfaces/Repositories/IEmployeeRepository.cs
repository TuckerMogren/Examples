using Domain.DTOModels;
namespace Domain.Interfaces.Repositories
{
	public interface IEmployeeRepository
	{

		Task<EmployeeDto> GetEmployeeByID(int id);

		Task SaveEmployeeAsync(IEmployeeDTO data);
	}
}

