using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BaseWebApi.Controller
{
    [Route("Admin/[controller]/[action]")]
    public class BaseAdminController<TDatabase, TController> : BaseController<TDatabase, TController> where TDatabase : DbContext
    {
        public BaseAdminController(TDatabase database, ILogger<TController> logger) : base(database, logger)
        {
        }
    }
}
