using Autofac;
using HelloTask.Infrastructure.EF;
using HelloTask.Infrastructure.Extensions;
using HelloTask.Infrastructure.Mongo;
using HelloTask.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace HelloTask.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                    .SingleInstance(); 
            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
                .SingleInstance(); 
        }
    }
}
