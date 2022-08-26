using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    /// <summary>
    /// Get note details query handler
    /// </summary>
    public class GetNoteDetailsQueryHandler
        : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
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
        public GetNoteDetailsQueryHandler(INotesDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                            .FirstOrDefaultAsync(note =>
                                note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);

        }
    }
}
