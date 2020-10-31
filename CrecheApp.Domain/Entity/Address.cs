﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public Guid GlobalId { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}
