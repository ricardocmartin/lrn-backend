using Lrn.Infra.CrossCutting.Log;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Infra.CrossCutting.Configuration
{
    public static class AppSettingsManager
    {
        private static IConfiguration _config;

        public static void ConfigureSettings(IConfiguration config)
        {
            try
            {
                _config = config ?? throw new ArgumentNullException("config");
            }
            catch (Exception ex)
            {
                LogManager.Error(ex.Message);
            }
        }

    }
}
