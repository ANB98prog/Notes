namespace Notes.Application.Notes.Queries.GetNoteList
{
    /// <summary>
    /// Note list view model
    /// </summary>
    public class NoteListVm
    {
        /// <summary>
        /// Note list
        /// </summary>
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
