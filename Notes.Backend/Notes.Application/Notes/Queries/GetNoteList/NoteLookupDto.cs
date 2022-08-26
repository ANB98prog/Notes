using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        /// <summary>
        /// Note id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Note title
        /// </summary>
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title,
                    opt => opt.MapFrom(note => note.Title));
        }

    }
}
