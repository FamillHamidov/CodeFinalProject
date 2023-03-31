﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Services.Order.Domain.Core;

namespace Travel.Services.Order.Domain.OrderAggregate
{
    public class Address : ValueObject
    {
        public Address(string province, string district, string street, string zipCode, string line)
        {
            Province = province;
            District = district;
            Street = street;
            ZipCode = zipCode;
            Line = line;
        }

        public string Province { get; private set; } = null!;
        public string District { get; private set; } = null!;
        public string Street { get; private set; } = null!;
        public string ZipCode { get; private set; } = null!;
        public string Line { get; private set; } = null!;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Province;
            yield return District;
            yield return Street;
            yield return ZipCode;
            yield return Line;
        }
    }
}
