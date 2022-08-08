using MediatR;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Note id
        /// </summary>
        public Guid Id { get; set; }

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
