using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Persistence;
using Reactivities.Domain;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activite Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
               _mapper.Map(request.Activity, activity);
               await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value; 
            }
        }
    }
}