using Merino.config;
using Merino.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Merino.Controller
{

    [CustomExceptionFilter]
    [TypeFilter(typeof(AccessLogFilter))]
    public class MerinoController : Microsoft.AspNetCore.Mvc.Controller
    {

        public MerinoController()
        {

        }

    }
}
