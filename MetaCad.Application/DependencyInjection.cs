using FluentValidation;
using MetaCad.Application.Validators.Auth;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                                       Assembly.GetExecutingAssembly(),                 // Current API assembly
                                       typeof(AssemblyReference).Assembly              // Application assembly

                                       ));
            //TODO: this registered but not wxcuted till implement mediatorR Validation Behavior  
            services.AddValidatorsFromAssemblyContaining<RegisterModelValidator>();  
            return services;
        }
    }
}
