using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace BaseWebApi.Controller
{
    [Authorize]
    [ApiController]
    [Route("Global/[controller]/[action]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BaseController<TDatabase, TController> : ControllerBase where TDatabase : DbContext
    {
        public BaseController(TDatabase database, ILogger<TController> logger)
        {
            Database = database;
            Logger = logger;
        }

        public TDatabase Database { get; }
        public ILogger<TController> Logger { get; }

    }
}