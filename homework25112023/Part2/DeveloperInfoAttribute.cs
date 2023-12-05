using System;

namespace Part2
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class DeveloperInfoAttribute : Attribute
    {
        private string developerName;
        private DateTime dateOfClassCreation;

        public DeveloperInfoAttribute(string developerName, string dateOfClassCreation)
        {
            this.developerName = developerName;
            this.dateOfClassCreation = DateTime.Parse(dateOfClassCreation);
        }
        public string DeveloperName
        {
            get
            {
                return developerName;
            }
        }
        public DateTime Date
        {
            get
            {
                return dateOfClassCreation;
            }
        }
    }
}
