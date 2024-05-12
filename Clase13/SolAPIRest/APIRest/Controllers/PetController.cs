using APIRest.Interfaces;
using APIRest.Logic;
using APIRest.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetLogic _petLogic;
        public PetController(IPetLogic petLogic)
        {
            _petLogic = petLogic;
        }
        [HttpGet]
        public IEnumerable<PetModel> GetAll() {
            return _petLogic.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public PetModel GetById(int id)
        {
            PetLogic petLogic = new PetLogic();
            return petLogic.GetById(id);
        }

        [HttpPost]
        public PetModel Create(PetModel model)
        {
            return _petLogic.SavePet(model);
        }

        [HttpPut]
        public PetModel Update(PetModel model)
        {
            PetLogic petLogic = new PetLogic();
            return petLogic.UpdatePet(model);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            PetLogic petLogic = new PetLogic();
            petLogic.Delete(id);
            return Ok("");
        }

    }
}
