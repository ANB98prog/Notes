using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteCommand;
using Notes.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Tests.Notes
{
    public class DeleteNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteNoteCommandHandler(Context);

            //Act
            await handler.Handle(
                new DeleteNoteCommand
                {
                    Id = NotesContextFactory.NoteIdForDelete,
                    UserId = NotesContextFactory.UserAId
                }, CancellationToken.None);

            //Assert
            Assert.Null(Context.Notes.SingleOrDefault(note => 
                note.Id == NotesContextFactory.NoteIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailWithWrongId()
        {
            //Arrange
            var handler = new DeleteNoteCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(
                new DeleteNoteCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = NotesContextFactory.UserAId
                }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailWithWrongUserId()
        {
            //Arrange
            var deleteHandler = new DeleteNoteCommandHandler(Context);
            var createHandler = new CreateNoteCommandHandler(Context);
            var noteId = await createHandler.Handle(new CreateNoteCommand
            {
                Title = "some title",
                Details = "some details",
                UserId = NotesContextFactory.UserAId
            }, CancellationToken.None);


            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await deleteHandler.Handle(
                new DeleteNoteCommand
                {
                    Id = noteId,
                    UserId = NotesContextFactory.UserBId
                }, CancellationToken.None));
        }
    }
}
