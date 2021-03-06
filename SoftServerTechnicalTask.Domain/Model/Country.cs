﻿using SoftServerTechnicalTask.Domain.BuildingBlocks;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SoftServerTechnicalTask.Domain.Model
{
    public class Country : ChildEntity
    {
        public string Code { get; set; }
        [IgnoreDataMember]
        public Organization Organization { get; private set; }
        public List<Business> Businesses { get; private set; }

        public Country(string name, string code, int organizationId)
        {
            Name = name;
            Code = code;
            ParentId = organizationId;
            Businesses = new List<Business>();
        }

        private Country()
        {
                
        }

    }
}
