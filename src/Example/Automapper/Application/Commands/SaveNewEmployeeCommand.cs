using Domain.DTOModels;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using MediatR;
using AutoMapper;

namespace Application.Commands
{
	public class SaveNewEmployeeCommand : IRequest
    {
        public EmployeeDTO employeeDto { get; private set; }

		public SaveNewEmployeeCommand(EmployeeDTO dto) 
		{
            employeeDto = dto ?? throw new ArgumentNullException(nameof(dto));
		}

        public class Handler : IRequestHandler<SaveNewEmployeeCommand, Unit>
        {
            readonly IEmployeeRepository _employeeRepo;
            readonly ILogger _logger;
            readonly IMapper _mapper;


            public Handler(IEmployeeRepository employeeRepository, ILogger<SaveNewEmployeeCommand.Handler> logger, IMapper mapper)
            {
                _employeeRepo = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<Unit> Handle(SaveNewEmployeeCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation("Saving new Employee - Handle {EmployeeFullName} - {EmployeeDepartment}", request.employeeDto.FullName, request.employeeDto.Dept);

             
                    await _employeeRepo.SaveEmployeeAsync(request.employeeDto);
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message, e.InnerException);
                }

                

                return Unit.Value;
            }


        }
    }
}

