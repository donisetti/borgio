using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Telerik.Reporting.Cache.Interfaces;
using Telerik.Reporting.Services.Engine;
using Telerik.Reporting.Services.WebApi;


namespace SuperBorgio.GestorWeb.Controllers
{
    [Authorize]
    public class ReportsController : ReportsControllerBase
    {
        protected override IReportResolver CreateReportResolver()
        {
            var reportsPath = HttpContext.Current.Server.MapPath("~/Reports");

            return new ReportFileResolver(reportsPath)
                .AddFallbackResolver(new ReportTypeResolver());
        }

        protected override ICache CreateCache()
        {
            return Telerik.Reporting.Services.Engine.CacheFactory.CreateFileCache();
        }
    }
}

