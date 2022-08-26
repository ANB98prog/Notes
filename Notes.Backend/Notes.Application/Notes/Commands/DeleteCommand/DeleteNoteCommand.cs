using MediatR;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    /// <summary>
    /// Delete note command
    /// </summary>
    public class DeleteNoteCommand : IRequest
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Note id
        /// </summary>
        public Guid Id { get; set; }
    }
}
