﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Travel.Services.Catalog.Models;

namespace Travel.Services.Catalog.Dtos
{
    public class TourDto
    {
        public string? Id { get; set; } 
        public string? Name { get; set; }
       
        public decimal Price { get; set; }
        public string? Luggage { get; set; }
        public string? AirTicket { get; set; }
        public string? Picture { get; set; }
        public string? UsserId { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public FeatureDto? Feature{ get; set; }
        public Category? Category { get; set; }
    }
}
