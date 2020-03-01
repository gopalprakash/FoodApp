using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAppEntities
{
    public class EntityFoodie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Contact { get; set; }
        public string Address { get; set; }
        public string CurrentAddress { get; set; }
        public int PlanId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }
}
