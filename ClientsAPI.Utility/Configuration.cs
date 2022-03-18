﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsAPI.Utility
{
    public class Configuration
    {
        private IConfiguration appSettings;

        public IConfiguration AppSettings
        {
            get { return this.appSettings; }
        }

        internal Configuration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrWhiteSpace(env))
                throw new Exception("A variável de ambiente ASPNETCORE_ENVIRONMENT não está configuarada");

            try
            {
                var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: true, reloadOnChange: false).AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false).AddEnvironmentVariables();
                this.appSettings = builder.Build();
            }
            catch (FormatException e)
            {
                throw new Exception("Arquivos de configuração não configurados corretamente! Verifique o formato do arquivo .json", e);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar arquivos de configuração", e);
            }
        }
    }
}
