using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        /// <summary>
        /// Note user id
        /// </summary>
        public Guid UserId { get; set; }
    }
}
