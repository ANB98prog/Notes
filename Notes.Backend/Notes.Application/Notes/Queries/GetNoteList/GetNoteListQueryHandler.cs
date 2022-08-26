using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryHandler
        : IRequestHandler<GetNoteListQuery, NoteListVm>
    {

        /// <summary>
        /// Db context
        /// </summary>
        private readonly INotesDbContext _dbContext;

        /// <summary>
        /// Contract mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes class instance of <see cref="GetNoteDetailsQueryHandler"/>
        /// </summary>
        /// <param name="dbContext">Db context</param>
        public GetNoteListQueryHandler(INotesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoteListVm> Handle(GetNoteListQuery request,
            CancellationToken cancellationToken)
        {
            var notesQuery = await _dbContext.Notes
                                .Where(note => note.UserId == request.UserId)
                                .ProjectTo<NoteLookupDto>(_mapper.ConfigurationProvider)
                                .ToListAsync(cancellationToken);

            return new NoteListVm { Notes = notesQuery };

        }
    }
}
