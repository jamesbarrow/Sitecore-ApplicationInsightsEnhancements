using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Malian.Foundation.AzureExtensions.TelemetryInitialisers
{
    public class CloudRoleNameInitialiser : ITelemetryInitializer
    {
        private readonly string roleName;

        public CloudRoleNameInitialiser(string roleName)
        {
            this.roleName = roleName ?? throw new ArgumentNullException(nameof(roleName));
        }

        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Cloud.RoleName = this.roleName;
        }
    }
}