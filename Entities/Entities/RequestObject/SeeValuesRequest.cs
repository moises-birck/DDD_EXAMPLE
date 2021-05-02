using System;

namespace Entities.Entities.RequestObject
{
    public class SeeValuesRequest
    {
        public int Origin { get; set; }

        public int Destiny { get; set; }

        public string Plan { get; set; }

        public int CallMinutes { get; set; }
        
    }
}
