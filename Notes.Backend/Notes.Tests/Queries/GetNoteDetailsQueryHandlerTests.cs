using AutoMapper;
using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Persistence;
using Notes.Tests.Common;
using Shouldly;

namespace Notes.Tests.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly NotesDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async void GetNoteDetailsQueryHandler_Success()
        {
            //Arrange
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(new GetNoteDetailsQuery
            {
                UserId = NotesContextFactory.UserBId,
                Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
            }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }

        [Fact]
        public async void GetNoteDetailsQueryHandler_IfNotFound()
        {
            //Arrange
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>( async () => 
                await handler.Handle(new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F252124")
                }, CancellationToken.None));
        }
    }
}
