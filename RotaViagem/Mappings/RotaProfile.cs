using AutoMapper;
using RotaViagem.DTOs;
using RotaViagem.Models;

namespace RotaViagem.Mappings
{
    public class RotaProfile : Profile
    {
        public RotaProfile()
        {
            CreateMap<Rota, RotaResponse>();
            CreateMap<RotaCreateRequest, Rota>();
        }
    }
}
