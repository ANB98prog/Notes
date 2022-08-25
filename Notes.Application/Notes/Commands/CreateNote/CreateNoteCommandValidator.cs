using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNote
{
    /// <summary>
    /// Validation rules for <see cref="CreateNoteCommand"/>
    /// </summary>
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand => 
                createNoteCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
                createNoteCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
