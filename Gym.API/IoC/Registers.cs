using Gym.API.Application.Auth.Handler;
using Gym.API.Application.Auth;
using Gym.API.Validators;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Gym.Domain.AggregateModels.Member;
using Gym.Infrastructure.Repository;
using AutoMapper;
using Gym.API.Application.Mappings;

namespace Gym.API.IoC
{
    public static class Registers
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappingProfiles());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(BasicAuthDefaults.AuthenticationScheme,
                    new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = BasicAuthDefaults.AuthenticationScheme,
                        In = ParameterLocation.Header,
                        Description = "Basic auth header"
                    });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = BasicAuthDefaults.AuthenticationScheme
                    }
                    },
                    new string[] {"Basic"}
                    }
                });
            });

            services.AddAuthentication()
                .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>(
                BasicAuthDefaults.AuthenticationScheme, null
                );

            return services;
        }
    }
}
