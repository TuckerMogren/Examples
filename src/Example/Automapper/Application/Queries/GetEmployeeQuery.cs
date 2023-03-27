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
        public EmployeeDto _emp { get; private set; }
        public int? _id { get; private set; }

        public GetEmployeeQuery(EmployeeDto emp, int? id)
        {
            _emp = emp ?? throw new ArgumentNullException(nameof(emp));
            _id = id ?? throw new ArgumentNullException(nameof(id));
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
                    _logger.LogInformation("Saving new Employee - Handle {EmployeeID}", request._id);


                    await _employeeRepo.GetEmployeeByID(request._id);
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

