﻿using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Family : ChildEntity
    {
        [IgnoreDataMember]
        public Business Business { get; private set; }

        public List<Offering> Offerings { get; private set; }

        public Family(string name, int businessId)
        {
            Name = name;
            ParentId = businessId;
            Offerings = new List<Offering>();
        }

        private Family()
        {
            
        }

    }
}
