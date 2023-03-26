using Data.Models;
using Domain.DTOModels;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries
{
	public class GetEmployeeQuery : IRequest<Unit>
	{

        //public int? _id { get; private set; }
        public Employee _emp { get; private set; }

        public GetEmployeeQuery(Employee emp)
        {
            _emp = emp ?? throw new ArgumentNullException(nameof(emp));
        }
        public class Handler : IRequestHandler<GetEmployeeQuery, Unit>
        {
            readonly IEmployeeRepository _employeeRepo;
            readonly ILogger _logger;


            public Handler(IEmployeeRepository employeeRepository, ILogger<Handler> logger)
            {
                _employeeRepo = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public async Task<Unit> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("Saving new Employee - Handle {EmployeeID}", request._emp.ID);


                    await _employeeRepo.GetEmployeeByID(request._emp.ID);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e.InnerException);
                }

                return Unit.Value;
            }


        }
    }
}

