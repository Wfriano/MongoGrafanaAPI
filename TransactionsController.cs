using Microsoft.AspNetCore.Mvc;
using MongoGrafanaAPI.Services;
using MongoGrafanaAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoGrafanaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        public TransactionsController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet("filtered")]
        public async Task<List<TransactionLog>> GetFiltered(
            [FromQuery] string transactionId,
            [FromQuery] string type,
            [FromQuery] DateTime start,
            [FromQuery] DateTime end)
        {
            return await _mongoDBService.GetFilteredAsync(transactionId, type, start, end);
        }
    }
}
