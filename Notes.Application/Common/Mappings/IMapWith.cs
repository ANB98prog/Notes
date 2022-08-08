using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    /// <summary>
    /// Interface of mapping configuration
    /// </summary>
    /// <typeparam name="T">Mapper type</typeparam>
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
             profile.CreateMap(typeof(T), GetType());
    }
}
