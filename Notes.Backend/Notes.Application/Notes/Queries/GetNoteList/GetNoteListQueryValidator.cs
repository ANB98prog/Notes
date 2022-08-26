using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    /// <summary>
    /// Validation rules for <see cref="GetNoteListQuery"/>
    /// </summary>
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(note => note.UserId).NotEqual(Guid.Empty);
        }
    }
}
