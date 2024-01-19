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

	public void VerificaVencimento(Boleto boleto)
	{
		Decimal valorComJuros;

		if (boleto.DataVencimento < DateTime.Now)
		{

			Decimal juros = RetornaPercentualJuros(boleto.BancoId);


			valorComJuros = CalculaJuros(boleto.Valor, juros);
			

			var boletoDbo = _contextoDb.Boletos.FirstOrDefault(b => b.Id == boleto.Id);

			boletoDbo.Valor = Math.Round(valorComJuros, 2);

			_contextoDb.Boletos.Update(boletoDbo);
			_contextoDb.SaveChanges();

		}


	}

	public Decimal CalculaJuros(Decimal valor, Decimal Percentual)
	{
		var juros = valor * Percentual;
		Decimal valorAPagar = valor + juros;

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
