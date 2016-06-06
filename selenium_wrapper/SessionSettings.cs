using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_wrapper
{
    public class SessionSettingsConfigSection : ConfigurationSection
    {
        public SessionSettingsConfigSection()
        {
        }

        [ConfigurationProperty("Driver")]
        public DriverElement Driver
        {
            get
            {
                return (DriverElement)base["Driver"];
            }
        }
        /*
        [ConfigurationProperty("Folders")]
        public FoldersCollection FolderItems
        {
            get { return ((FoldersCollection)(base["Folders"])); }
        }*/
    }

    /*
    [ConfigurationCollection(typeof(FolderElement))]
    public class FoldersCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FolderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FolderElement)(element)).FolderType;
        }

        public FolderElement this[int idx]
        {
            get { return (FolderElement)BaseGet(idx); }
        }
    }
    */
    public class DriverElement : ConfigurationElement
    {

        [ConfigurationProperty("browser", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Browser
        {
            get
            {
                return ((string)(base["browser"]));
            }
            set { base["browser"] = value; }
        }

        [ConfigurationProperty("command_timeout", DefaultValue = "60", IsKey = true, IsRequired = false)]
        public int CommandTimeout
        {
            get
            {
                var timeout = base["command_timeout"].ToString();
                return int.Parse(timeout); 
            }
            set { base["browser"] = value; }
        }
    }
    
}
