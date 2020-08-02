using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Taxas.Application.Interfaces.Services;

namespace Taxas.API.Controllers
{
    [Route("taxaJuros")]
    [Authorize()]
    public class TaxaDeJurosController : Controller
    {
        private readonly ITaxaDeJurosService _taxaDeJurosService;

        public TaxaDeJurosController(ITaxaDeJurosService taxaDeJurosService) =>
            _taxaDeJurosService = taxaDeJurosService;

        /// <summary>
        /// Recupera valor da taxa de juros.
        /// </summary>
        /// <param name="cancellationToken"></param>
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