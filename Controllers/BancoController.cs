﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_CriaBoletosParaBancos.Dados;
using Projeto_CriaBoletosParaBancos.Dtos;
using Projeto_CriaBoletosParaBancos.Entidades;

namespace Projeto_CriaBoletosParaBancos.Controllers;

[Route("Api/Banco")]
public class BancoController : Controller
{
	private ContextoBancoDeDados _contextoDb;
	private IMapper _mapper;
	public BancoController(ContextoBancoDeDados contextoDb, IMapper mapper)
	{
		_contextoDb = contextoDb;
		_mapper = mapper;
	}


	[HttpPost("Cadastro")]
	public IActionResult AdicionaBanco([FromBody] BancoDto bancoDto)
	{
		try
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			else
			{
				Banco banco = _mapper.Map<Banco>(bancoDto);

				_contextoDb.Bancos.Add(banco);
				_contextoDb.SaveChanges();

				return CreatedAtAction(nameof(RecuperaBancoPorId),
							new { codigoBanco = banco.CodigoBanco }, banco);
			}

		}
		catch (Exception ex)
		{
			return StatusCode(500, new { error = ex.Message });
		}
	}

	[HttpGet("CodigoBanco")]
	public IActionResult RecuperaBancoPorId(int CodigoBanco)
	{
		try
		{
			var banco = _contextoDb.Bancos.FirstOrDefault(banco => banco.CodigoBanco == CodigoBanco);
			if (banco == null) return NotFound("Codigo não Localizado.");
			return Ok(banco);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { error = ex.Message });
		}
	}

	[HttpGet("Todos")]
	public IActionResult RecuperaTodosOsBancos()
	{
		try
		{
			List<Banco> BancosList = new List<Banco>();
			BancosList = _contextoDb.Bancos.ToList();

			if (BancosList == null) return NotFound("Não existem bancos cadastrados.");

			return Ok(BancosList);
		}
		catch (Exception ex)
		{
			return StatusCode(500, new { error = ex.Message });
		}
	}

}
