using Domain.DTOModels;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Queries
{
	public class GetEmployeeQuery : IRequest<EmployeeDto>
	{

        public int? _id { get; private set; }

        public GetEmployeeQuery(int? id)
        {
            _id = id ?? throw new ArgumentNullException(nameof(id));
        }
        public class Handler : IRequestHandler<GetEmployeeQuery, EmployeeDto>
        {
            readonly IEmployeeRepository _employeeRepo;
            readonly ILogger _logger;


            public Handler(IEmployeeRepository employeeRepository, ILogger<Handler> logger)
            {
                _employeeRepo = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public Task<EmployeeDto> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("Saving new Employee - Handle {EmployeeID}", request._id);


                    var results =  _employeeRepo.GetEmployeeByID(request._id);
                    return results;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e.InnerException);
                }
            }


        }
    }
}

