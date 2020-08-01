using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Taxas.Application.Interfaces.Services;

namespace Taxas.API.Controllers
{
    [Route("taxaJuros")]
    public class TaxaDeJurosController : Controller
    {
        private readonly ITaxaDeJurosService _taxaDeJurosService;

        public TaxaDeJurosController(ITaxaDeJurosService taxaDeJurosService)
        {
            _taxaDeJurosService = taxaDeJurosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            try
            {
                var taxaDeJuros = await _taxaDeJurosService.GetAsync(cancellationToken);
                return Ok(taxaDeJuros.Percentual);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }
    }
}