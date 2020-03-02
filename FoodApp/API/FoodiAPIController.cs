using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApp.Models;
using FoodAppDAL.Interface;
using FoodAppEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodApp.API
{
    [ApiController]
    [Route("api/Foodies")]
    public class FoodiAPIController : Controller
    {
        public IFoodieDAL _foodieDal;
        public FoodiAPIController(IFoodieDAL _ifoodDal )
        {
            _foodieDal = _ifoodDal;
        }
        public ModelFoodie EntityToModel( EntityFoodie eFoodie)
        {
            ModelFoodie mFoodie = new ModelFoodie();
            mFoodie.Id = eFoodie.Id;
            mFoodie.Name = eFoodie.Name;
            mFoodie.Contact = eFoodie.Contact;
            mFoodie.Address = eFoodie.Address;
            mFoodie.CurrentAddress = eFoodie.CurrentAddress;
            mFoodie.PlanId = eFoodie.PlanId;
            mFoodie.Type = eFoodie.Type;
            mFoodie.Status = eFoodie.Status;
            return mFoodie;
        }
        public EntityFoodie ModelToEntity(ModelFoodie mFoodie)
        {
            EntityFoodie eFoodie = new EntityFoodie();
            eFoodie.Id = mFoodie.Id;
            eFoodie.Name = mFoodie.Name;
            eFoodie.Contact = mFoodie.Contact;
            eFoodie.Address = mFoodie.Address;
            eFoodie.CurrentAddress = mFoodie.CurrentAddress;
            eFoodie.PlanId = mFoodie.PlanId;
            eFoodie.Type = mFoodie.Type;
            eFoodie.Status = mFoodie.Status;
            return eFoodie;
        }

        [HttpGet("GetProfiles")]
        public IActionResult GetProfiles()
        {
            List<EntityFoodie> eFoodies = new List<EntityFoodie>();
            List<ModelFoodie> mFoofies = new List<ModelFoodie>();
            eFoodies = _foodieDal.GetProfiles();
            if(eFoodies !=null)
            {
                foreach(var item in eFoodies)
                {
                    mFoofies.Add(EntityToModel(item));
                }
                return Ok(mFoofies);
            }
            return NotFound();
        }




        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
