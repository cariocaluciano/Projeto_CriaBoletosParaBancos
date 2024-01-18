using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Projeto_CriaBoletosParaBancos.Dados;
using Projeto_CriaBoletosParaBancos.Entidades;
using System.Linq;
namespace Projeto_CriaBoletosParaBancos.Ajustes;

public class AjustesBoleto
{
	private ContextoBancoDeDados _contextoDb;

	public AjustesBoleto(ContextoBancoDeDados contextoDb)
	{
		_contextoDb = contextoDb;
	}

	public Boleto VerificaVencimento(Boleto boleto)
	{
		Decimal valorComJuros;

		if (boleto.DataVencimento > DateTime.Now)
		{
			Decimal juros = RetornaPercentualJuros(boleto.BancoId);

			valorComJuros = CalculaJuros(boleto.Valor, juros);

			Boleto boletoAjustado = new Boleto { 
			Nomepagador = 
			};
			
		}


	}

	public Decimal CalculaJuros(Decimal valor , Decimal Percentual) 
	{
		var juros = valor * Percentual;
		Decimal valorAPagar = valor * juros;

		return valorAPagar;
	}

	public Decimal RetornaPercentualJuros(int IdBanco)
	{
		var percentualJuros = _contextoDb.Bancos
			.Where(b => b.Id == IdBanco)
			.Select(b => b.PercentualJuros)
			.FirstOrDefault();

		return percentualJuros;

	}

}
