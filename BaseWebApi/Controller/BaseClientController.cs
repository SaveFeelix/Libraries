using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BaseWebApi.Controller
{
    [Route("Client/[controller]/[action]")]
    public class BaseClientController<TDatabase, TController> : BaseController<TDatabase, TController> where TDatabase : DbContext
    {
        public BaseClientController(TDatabase database, ILogger<TController> logger) : base(database, logger)
        {
        }
    }
}
