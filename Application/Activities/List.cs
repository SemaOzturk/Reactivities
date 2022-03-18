using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Reactivities.Domain;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activite>>
        {
            
        }
        
        public class Handler : IRequestHandler<Query,List<Activite>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activite>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Activities.ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}