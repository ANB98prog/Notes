using MediatR;

namespace Notes.Application.Notes.Commands.CreateNote
{
    /// <summary>
    /// Note creation command
    /// </summary>
    public class CreateNoteCommand : IRequest<Guid>
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Note title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Note details
        /// </summary>
        public string Details { get; set; }
    }
}
