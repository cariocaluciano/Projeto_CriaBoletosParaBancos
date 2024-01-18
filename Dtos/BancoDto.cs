using System.ComponentModel.DataAnnotations;

namespace Projeto_CriaBoletosParaBancos.Dtos;

public class BancoDto
{
	[Required(ErrorMessage = "Campo obrigatório")]
	public string NomeBanco { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	public int CodigoBanco { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	public Decimal PercentualJuros { get; set; }
}
