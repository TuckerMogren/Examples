using Data.Models;
using AutoMapper;
using Data.Contexts;
using Domain.DTOModels;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeContext _db;
        private readonly IMapper _mapper;

		public EmployeeRepository(EmployeeContext db, IMapper mapper) 
		{
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task GetEmployeeByID(int? id)
        {

            var results = await _db.Employees.SingleOrDefaultAsync(x => x.ID == id);

            var data = _mapper.Map<EmployeeDto>(results);

            Console.WriteLine(data);
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

