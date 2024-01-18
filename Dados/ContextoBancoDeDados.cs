using Microsoft.EntityFrameworkCore;
using Projeto_CriaBoletosParaBancos.Entidades;

namespace Projeto_CriaBoletosParaBancos.Dados;

public class ContextoBancoDeDados : DbContext
{
	public ContextoBancoDeDados(DbContextOptions<ContextoBancoDeDados> opts) : base(opts)
	{

	}

	public DbSet<Boleto> Boletos { get; set; }
	public DbSet<Banco> Bancos { get; set; }

}
