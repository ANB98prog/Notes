namespace Notes.Identity.Data
{
    /// <summary>
    /// Database initializer
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Initializes database
        /// </summary>
        /// <param name="context">Db context</param>
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
