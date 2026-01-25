using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentFront.Infrastructure.WebCommon.Helpers
{
    public static class UrlExtention
    {

        public static string PathAndQuery(this HttpRequest httpRequest)
        {
            var queryString = httpRequest.QueryString.HasValue ? $"{httpRequest.Path}{httpRequest.QueryString}" : httpRequest.Path.ToString();

            return queryString;
        }
    }
}
