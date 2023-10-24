using Business.Tenant;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public class TenantMiddleware
    {
        readonly RequestDelegate Delagado;

        public TenantMiddleware(RequestDelegate delagado)
        {
            Delagado = delagado;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            if (!(string.IsNullOrEmpty(context.Request.Path.Value)))
            {
                string path = context.Request.Path.Value;

                string pathSplit = path.Split('/', StringSplitOptions.RemoveEmptyEntries)[0];


                if (pathSplit.Length > 0)
                    context.Items["Tenant"] = pathSplit;

                await Delagado(context);
            }
        }
    }
}
