﻿namespace StoreAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
