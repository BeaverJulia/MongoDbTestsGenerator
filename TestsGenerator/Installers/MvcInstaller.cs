﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

namespace TestsGenerator.Installers
{
    public class MvcInstaller: IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
           

            services.AddMvc(options=> { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
           
        }
    }

}

