using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler
        : IRequestHandler<UpdateNoteCommand>
    {
        /// <summary>
        /// Db context
        /// </summary>
        private readonly INotesDbContext _dbContext;

        /// <summary>
        /// Initializes class instance of <see cref="UpdateNoteCommandHandler"/>
        /// </summary>
        /// <param name="dbContext">Db context</param>
        public UpdateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateNoteCommand request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.FirstOrDefaultAsync(note 
                    => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
