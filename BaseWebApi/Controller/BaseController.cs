using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Mime;

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

        protected TDatabase Database { get; }
        protected ILogger<TController> Logger { get; }

    }
}