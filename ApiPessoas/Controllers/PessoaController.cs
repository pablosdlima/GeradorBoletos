using ApiPessoas.Model;
using ApiPessoas.Model.ValueObjects;
using ApiPessoas.Services.Bussines.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ApiPessoas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa _pessoaServices;
        private readonly IMapper _mapper;
        public PessoaController(IPessoa pessoaServices, IMapper mapper)
        {
            _pessoaServices = pessoaServices;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaVo>> PorId(int id)
        {
            try
            {
                var pedido = await _pessoaServices.GetByIdAsync(id);
                if (pedido == null) return NotFound();

                return Ok(_mapper.Map<PessoaVo>(pedido));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PessoaVo>> Create([FromBody] PessoaVo vo)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                if (vo == null) return BadRequest();

                bool pedido = await _pessoaServices.InsertAsync(_mapper.Map<Pessoa>(vo));
                if (pedido == false) return BadRequest();

                var ultimo = await _pessoaServices.UltimoAsync(x => x.Id);
                if (ultimo != null)
                {
                    scope.Complete();
                    return Ok(_mapper.Map<PessoaVo>(ultimo));
                }
                return BadRequest();
            }
            catch (Exception err)
            {
                scope.Dispose();
                return BadRequest(err.Message);
            }
        }

    }
}
