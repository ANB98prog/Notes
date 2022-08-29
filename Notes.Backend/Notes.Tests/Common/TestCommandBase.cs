using Notes.Persistence;

namespace Notes.Tests.Common
{
    /// <summary>
    /// Base class for testing commands
    /// </summary>
    public class TestCommandBase : IDisposable
    {
        /// <summary>
        /// Db context
        /// </summary>
        protected readonly NotesDbContext Context;

        /// <summary>
        /// Initializes test context
        /// </summary>
        public TestCommandBase()
        {
            Context = NotesContextFactory.Create();
        }

        /// <summary>
        /// Disposes test context
        /// </summary>
        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }
}
