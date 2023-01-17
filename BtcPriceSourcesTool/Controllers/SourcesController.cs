using BtcPriceSourcesTool.Contracts;
using BtcPriceSourcesTool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtcPriceSourcesTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {

        private readonly ISourceRepository _repo;

        public SourcesController(ISourceRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetAll")]
        public  Task<List<Source>> GetAllBtcSources() {

            return _repo.GetAll();
        }


        [HttpGet]
        [Route("GetById")]
        public  Task<Source> GetById(int SourceId)
        {

            return _repo.GetById(SourceId);
        }
    }
}
