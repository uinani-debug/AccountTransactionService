using AutoMapper;
using AccountLibrary.API.Models;
using AccountLibrary.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountLibrary.API.Controllers
{
    [ApiController]
  
    public class AccountController : ControllerBase
    {
        private readonly IAccountLibraryRepository _AccountLibraryRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountLibraryRepository AccountLibraryRepository,
            IMapper mapper)
        {
            _AccountLibraryRepository = AccountLibraryRepository ??
                throw new ArgumentNullException(nameof(AccountLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


        [Route("api/v1/AccountTransaction")]
        [HttpGet]
        public ActionResult<Transaction> AccountTransaction(string AccountNumber)
        {
            var accpuntsFromRepo = _AccountLibraryRepository.GetAccountTransactionsByID(AccountNumber);

            if (accpuntsFromRepo == null)
            {
                return NotFound();
            }
            var accountrepo = accpuntsFromRepo.ToList().Count > 5 ? accpuntsFromRepo.Take(5): accpuntsFromRepo.ToList();
            return Ok((_mapper.Map<IEnumerable<Entities.AccountTransaction>, IEnumerable<Transaction>>(accountrepo)));
        }

        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}