using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Turbo.Az.Entities;

namespace Turbo.Az.Models.Entities
{
    public class CarAnnouncement
    {


        public int Id { get; set; }
        public int ModelId { get; set; }
        public int March { get; set; }
        public double Price { get; set; }
        public BanType Banner { get; set; }
        public FuelType FuelType { get; set; }
        public GearBox GearBox { get; set; }
        public Transmission Transmission { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }
        public int? LastModifiedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public int? DeletedBy { get; set; }

        public DateTime? DeletedAt { get; set; }





    }
}
