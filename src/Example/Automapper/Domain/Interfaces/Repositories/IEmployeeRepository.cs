using Domain.DTOModels;
namespace Domain.Interfaces.Repositories
{
	public interface IEmployeeRepository
	{

        public Task SaveEmployeeAsync(IEmployeeDTO data);
    	public Task<EmployeeDTO?> GetEmployeeByIDAsync (int? id);

		
	}
}

