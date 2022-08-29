using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;
using System.ComponentModel.DataAnnotations;

namespace Notes.WebApi.Models
{
    /// <summary>
    /// Update note contract
    /// </summary>
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        /// <summary>
        /// Note id
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Note title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Note details
        /// </summary>
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
