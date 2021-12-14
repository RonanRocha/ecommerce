using Eccomerce.Domain.ValueObjects;
using System;


namespace Eccomerce.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public User User { get; set; }

    }
}
