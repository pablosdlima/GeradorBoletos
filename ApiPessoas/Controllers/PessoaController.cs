using ApiPessoas.Model;
using ApiPessoas.Model.ValueObjects;
using ApiPessoas.Services.Bussines.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaVo>>> Todos()
        {
            try
            {
                var products = await _pessoaServices.Get().ToListAsync();
                return Ok(products);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaVo>> PorId(long id)
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

        [HttpPut]
        public async Task<ActionResult<PessoaVo>> Update([FromBody] PessoaVo vo)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                if (vo == null)
                    return BadRequest();

                var pedido = await _pessoaServices.UpdateAsync(_mapper.Map<Pessoa>(vo));
                if (pedido == false) return BadRequest();

                scope.Complete();
                return Ok(vo);
            }
            catch (Exception err)
            {
                scope.Dispose();
                return BadRequest(err.Message);
            }
        }
    }
}
