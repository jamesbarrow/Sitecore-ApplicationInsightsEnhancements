using Malian.Foundation.AzureExtensions.TelemetryInitialisers;
using Microsoft.ApplicationInsights.Extensibility;
using Sitecore.Configuration;
using Sitecore.Pipelines;
using System;

namespace Malian.Foundation.AzureExtensions.Pipelines
{
    public class InjectAdditionalTelemetryInitialisers
    {
        public virtual void Process(PipelineArgs args)
        {
            string roleName = Settings.GetSetting("ApplicationInsights.RoleName", string.Empty);

            if (string.IsNullOrEmpty(roleName))
            {
                roleName = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME");
            }

            if (string.IsNullOrEmpty(roleName))
            {
                return;
            }

            TelemetryConfiguration.Active.TelemetryInitializers.Add(new CloudRoleNameInitialiser(roleName));
        }
    }
}