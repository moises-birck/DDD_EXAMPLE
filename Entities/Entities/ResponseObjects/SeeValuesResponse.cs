using Entities.Entities.RequestObject;
using Entities.Notifications;
using System;
using System.Collections.Generic;

namespace Entities.Entities.ResponseObjects
{
    public class SeeValuesResponse 
    {
        public SeeValuesRequest request { get; set; }

        public string WithPlan { get; set; }
        
        public string NoPlan { get; set; }


    }
}
