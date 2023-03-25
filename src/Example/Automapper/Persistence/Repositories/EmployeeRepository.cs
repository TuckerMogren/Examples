using Data.Models;
using AutoMapper;
using Data.Contexts;
using Domain.DTOModels;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Persistence.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

		public EmployeeRepository(EmployeeContext db, ILogger logger, IMapper mapper) 
		{
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<EmployeeDto> GetEmployeeByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveEmployeeAsync(IEmployeeDTO data)
        {
            try
            {
                //automapper to employeedto to employee DB entity
                var employee = _mapper.Map<Employee>(data);
                //write to db.

                _db.Employees.Add(employee);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }


        }
    }
}

