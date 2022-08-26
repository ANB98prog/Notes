using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
        /// <summary>
        /// Note id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Note title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Note details
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Note creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Note edit date
        /// </summary>
        public DateTime? EditDate { get; set; }

        public void Mapping(AssemblyMappingProfile profile)
        {
            profile.CreateMap<Note, NoteDetailsVm>()
                .ForMember(noteVm => noteVm.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Title,
                    opt => opt.MapFrom(note => note.Title))
                .ForMember(noteVm => noteVm.Details,
                    opt => opt.MapFrom(note => note.Details))
                .ForMember(noteVm => noteVm.CreationDate,
                    opt => opt.MapFrom(note => note.CreationDate))
                .ForMember(noteVm => noteVm.EditDate,
                    opt => opt.MapFrom(note => note.EditDate));
        }

    }
}
