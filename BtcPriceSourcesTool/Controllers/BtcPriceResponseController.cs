using BtcPriceSourcesTool.Contracts;
using BtcPriceSourcesTool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BtcPriceSourcesTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BtcPriceResponseController : ControllerBase
    {

        private readonly IBtcPriceResponseRepository _repo;

        public BtcPriceResponseController(IBtcPriceResponseRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        [Route("GetAll")]
        public Task<List<BtcPriceResponse>> GetBtcHistoryBySourceId(int sourceId)
        {

            return _repo.GetBtcHistoryBySourceId(sourceId);
        }


        [HttpGet]
        [Route("GetBtcPriceBySourceId")]
        public Task<BtcPriceResponse> GetBtcPriceBySourceId(int SourceID)
        {

            return _repo.GetBtcPriceBySourceId(SourceID);
        }




    }
}
