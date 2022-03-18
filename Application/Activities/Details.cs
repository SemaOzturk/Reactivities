using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Reactivities.Domain;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Activite>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query,Activite>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Activite> Handle(Query request, CancellationToken cancellationToken)
            {
                return (await _context.Activities.FindAsync(request.Id))!;
            }
        }
    }
}