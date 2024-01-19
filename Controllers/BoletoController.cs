using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto_CriaBoletosParaBancos.Ajustes;
using Projeto_CriaBoletosParaBancos.Dados;
using Projeto_CriaBoletosParaBancos.Dtos;
using Projeto_CriaBoletosParaBancos.Entidades;

namespace Projeto_CriaBoletosParaBancos.Controllers;

[Route("Api/Boleto")]
public class BoletoController : Controller
{
	private ContextoBancoDeDados _contextoDb;
	private IMapper _mapper;

	public BoletoController(ContextoBancoDeDados contextoDb, IMapper mapper)
	{
		_contextoDb = contextoDb;
		_mapper = mapper;
	}


	[HttpPost("Adicionar")]
	public IActionResult AdicionaBoleto([FromBody] BoletoDto boletoDto)
	{
		try
		{
		     if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{ 
				Boleto boleto = _mapper.Map<Boleto>(boletoDto);



                _contextoDb.Boletos.Add(boleto);
				_contextoDb.SaveChanges();

				return CreatedAtAction(nameof(RecuperaBoletoPorId),
					new { id = boleto.Id }, boleto);
			}
		}catch (Exception ex) 
		{
			return StatusCode(500, new { error = ex.Message });
		}
	}

	[HttpGet("Id")]
	public IActionResult RecuperaBoletoPorId(int Id)
	{
		try
		{
			var boleto = _contextoDb.Boletos.FirstOrDefault(boleto => boleto.Id == Id);
			if (boleto == null) return NotFound("Código não localizado.");


			AjustesBoleto ajuste = new AjustesBoleto(_contextoDb);
			ajuste.VerificaVencimento(boleto);


			return Ok(boleto);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { error = ex.Message });
		}
	}



}
