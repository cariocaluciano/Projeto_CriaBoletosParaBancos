using AutoMapper;
using Projeto_CriaBoletosParaBancos.Dtos;
using Projeto_CriaBoletosParaBancos.Entidades;

namespace Projeto_CriaBoletosParaBancos.Perfis;

public class BoletoPerfil : Profile
{
    public BoletoPerfil()
    {
        CreateMap<BoletoDto, Boleto>();
    }


}
