using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.DevTools;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tflpro.Support
{
     
        public static class AppSettings 
    {
        public static class Properties
        {
            
            public static class RetryFunctions
            {
                public static readonly ConfigurationProperty RetryInterval = new ConfigurationProperty("RetryFunctions:RetryInterval", typeof(int), 1000);
                public static readonly ConfigurationProperty RetryLimit = new ConfigurationProperty("RetryFunctions:RetryLimit", typeof(int), 10);
            }
            public static class ServiceVirtualization
            {
                public static readonly ConfigurationProperty Endpoint = new ConfigurationProperty("ServiceVirtualization:Endpoint", typeof(string), null);
                public static readonly ConfigurationProperty Environment = new ConfigurationProperty("ServiceVirtualization:Environment", typeof(string), null); 
                public static readonly ConfigurationProperty Services = new ConfigurationProperty("ServiceVirtualization:Services", typeof(IList<string>), null);
            }
            public static class WebBrowser 
            {
                public static readonly ConfigurationProperty Arguments = new ConfigurationProperty("WebBrowser:Arguments", typeof(string), null);
                public static readonly ConfigurationProperty DefaultDriverDirectory = new ConfigurationProperty("WebBrowser:DefaultDriverDirectory", typeof(string), Environment.CurrentDirectory); 
                public static readonly ConfigurationProperty InternalFindElementRetryLimit = new ConfigurationProperty("WebBrowser:InternalFindElementRetryLimit", typeof(int), 0);
                public static readonly ConfigurationProperty PollingInterval = new ConfigurationProperty("WebBrowser:PollingInterval", typeof(int), 100); 
                public static readonly ConfigurationProperty RemoteUri = new ConfigurationProperty("WebBrowser:RemoteUri", typeof(string), null);
                public static readonly ConfigurationProperty Timeout = new ConfigurationProperty("WebBrowser:Timeout", typeof(int), 10000); 
                public static readonly ConfigurationProperty UseJavascriptInteractions = new ConfigurationProperty("WebBrowser:UseJavascriptInteractions", typeof(bool), false);
            }
        }
        
        public static readonly string DefaultAppSettingsFile = "appsettings.json"; 
        private static IConfigurationRoot appSettings; 
        private static string environment = null; 
        public static void Load(string environment = null) 
        {
            try
            {
                ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile(DefaultAppSettingsFile); 
                appSettings = ((IConfigurationBuilder)configurationBuilder).Build();
               
            }
            catch 
            (Exception ex) 
            {
                  throw;
            }
        }
        public static string GetEnvironment() 
        {
            return environment;

        } 
      
        public static IConfigurationRoot GetAppSettings()
        {
            return appSettings;
        }
        public static string GetString(string property) 
        {
            return Get<string>(property);
        }
        public static bool GetBool(string property) 
        {
            return Get<bool>(property);
        }
        public static int GetInt(string property)
        {
            return Get<int>(property);
        }
        public static double GetDouble(string property) 
        {
            return Get<double>(property);
        }
        public static T Get<T>(string property)
        {
            return appSettings.GetValue<T>(property) ?? throw new ConfigurationErrorsException("AppSettings, property not found: " + property); 
        }
        public static IList<T> GetList<T>(string property)
        {
            IConfigurationSection section = appSettings.GetSection(property);
            if
                (!section.Exists()) 
            {
                throw new ConfigurationErrorsException("AppSettings, property not found or is an empty list: " + property); 
            }
            return section.Get<IList<T>>();
        } 
        public static T GetConfigurationProperty<T>(ConfigurationProperty property)
        {
            T? value = appSettings.GetValue<T>(property.Name);
            if
                (value == null && property.DefaultValue == null)
            {
                throw new ConfigurationErrorsException("AppSettings, property not found: " + property.Name);
            }
            T val = value; 
            if 
                (val == null) 
            {
                return (T)property.DefaultValue;
            }
            return val;
        }
        public static IList<T> GetConfigurationPropertyList<T>(ConfigurationProperty property)
        {
            IConfigurationSection section = appSettings.GetSection(property.Name);
            if
                (!section.Exists())
            {
                if
                    (property.DefaultValue != null) 
                {
                    throw new ConfigurationErrorsException("AppSettings, property not found or is an empty list: " + property.Name); 
                }
                return (IList<T>)property.DefaultValue;
            } 
            return section.Get<IList<T>>();
        }
    }
}



  

