using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Reactivities.Domain;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activite Activite { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _dataContext.Activities.Add(request.Activite);
                await _dataContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}