using FoodAppEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodAppDAL.Interface
{
    public interface IFoodieDAL
    {
        List<EntityFoodie> GetProfiles();
    }
}
