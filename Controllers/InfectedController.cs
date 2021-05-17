using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using DotnetApiMongoDB.Data.Collections;
using DotnetApiMongoDB.Models;


namespace DotnetApiMongoDB.Controllers
{   

    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infected> _infectedCollection;
        public InfectedController(Data.MongoDB mongoDB)
        {   
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());

        }

        [HttpPost]
        public ActionResult saveInfected([FromBody] InfectedDTO dto)
        {
            var infected = new Infected(dto.bornData, dto.gender, dto.latitude, dto.latitude);
            _infectedCollection.InsertOne(infected);
            return StatusCode(201, "Infected person addition with success!");
        }

        [HttpGet]
        public ActionResult getInfected()
        {            
            var infected = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();

            return Ok(infected);
        }
        
    }
}