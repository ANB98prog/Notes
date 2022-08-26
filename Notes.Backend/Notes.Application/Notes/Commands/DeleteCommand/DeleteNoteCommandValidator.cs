using FluentValidation;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    /// <summary>
    /// Validation rules for <see cref="DeleteNoteCommand"/>
    /// </summary>
    public class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
    {
        public DeleteNoteCommandValidator()
        {
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteNoteCommand =>
                deleteNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
