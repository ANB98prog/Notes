using FluentValidation;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    /// <summary>
    /// Validation rules for <see cref="UpdateNoteCommand"/>
    /// </summary>
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommand =>
                updateNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand =>
                updateNoteCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}
