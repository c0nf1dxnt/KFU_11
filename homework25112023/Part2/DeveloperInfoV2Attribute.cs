using System;

namespace Part2
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class DeveloperInfoV2Attribute : Attribute
    {
        private string developerName;
        private string organization;

        public DeveloperInfoV2Attribute(string developerName, string organization)
        {
            this.developerName = developerName;
            this.organization = organization;
        }
        public string DeveloperName
        {
            get
            {
                return developerName;
            }
        }
        public string Organization
        {
            get
            {
                return organization;
            }
        }
    }
}
