using System.ComponentModel.DataAnnotations;

namespace Projeto_CriaBoletosParaBancos.Entidades;

public class Boleto
{
    [Required]
    public int Id { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	[MinLength(8, ErrorMessage = "Campo aceita no mínimo 8 dígitos")]
	[MaxLength(50, ErrorMessage = "Campo aceita no máximo 50 dígitos")]
	public string Nomepagador { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	[MinLength(11,ErrorMessage = "Campo aceita no mínimo 11 dígitos")]
	[MaxLength(14,ErrorMessage = "Campo aceita no máximo 14 dígitos")]
	public string Cpf_CnpjDoPagador { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	[MinLength(8, ErrorMessage = "Campo aceita no mínimo 8 dígitos")]
	[MaxLength(50, ErrorMessage = "Campo aceita no máximo 50 dígitos")]
	public string NomeBeneficiario { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	public Decimal Valor { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	public DateTime DataVencimento { get; set; }



	[MaxLength(200, ErrorMessage = "Campo aceita no máximo 200 dígitos")]
	public string Observacao { get; set; }


	[Required(ErrorMessage = "Campo obrigatório")]
	public int BancoId { get; set; }

}
