using System.ComponentModel.DataAnnotations;

namespace Projeto_CriaBoletosParaBancos.Entidades;

public class Banco
{
	[Required]
	public int Id { get; set; }

	[Required(ErrorMessage = "Campo obrigatório")]
	public string NomeBanco { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	public int CodigoBanco { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	public Decimal PercentualJuros { get; set; }

}
