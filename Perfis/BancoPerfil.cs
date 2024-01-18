using AutoMapper;
using Projeto_CriaBoletosParaBancos.Dtos;
using Projeto_CriaBoletosParaBancos.Entidades;

namespace Projeto_CriaBoletosParaBancos.Perfis;

public class BancoPerfil : Profile
{
	public BancoPerfil()
	{
		CreateMap<BancoDto, Banco>();
	}
}

