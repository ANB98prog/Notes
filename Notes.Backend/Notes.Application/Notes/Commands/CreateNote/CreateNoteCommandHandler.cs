using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote
{
    /// <summary>
    /// Note creation command handler
    /// </summary>
    public class CreateNoteCommandHandler
        : IRequestHandler<CreateNoteCommand, Guid>
    {
        /// <summary>
        /// Db context
        /// </summary>
        private readonly INotesDbContext _dbContext;

        /// <summary>
        /// Initializes class instance of <see cref="CreateNoteCommandHandler"/>
        /// </summary>
        /// <param name="dbContext">Db context</param>
        public CreateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;


        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
