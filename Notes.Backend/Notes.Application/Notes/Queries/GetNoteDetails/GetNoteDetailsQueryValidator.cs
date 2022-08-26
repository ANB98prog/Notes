using FluentValidation;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    /// <summary>
    /// Validation rules for <see cref="GetNoteDetailsQuery"/>
    /// </summary>
    public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
    {
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(note => note.Id).NotEqual(Guid.Empty);
            RuleFor(note => note.UserId).NotEqual(Guid.Empty);
        }
    }
}
