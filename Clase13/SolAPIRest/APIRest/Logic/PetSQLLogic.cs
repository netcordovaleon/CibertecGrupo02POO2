using APIRest.Database;
using APIRest.Interfaces;
using APIRest.Model;

namespace APIRest.Logic
{
    public class PetSQLLogic : IPetLogic
    {
        PetContext _context;
        public PetSQLLogic(PetContext context)
        {
            _context = context;
        }
        public IEnumerable<PetModel> GetAll()
        {
            return (from c in _context.Pet.ToList()
                    select new PetModel() { 
                        Id = c.Id,
                        Name    = c.Name,
                        Age = c.Age,
                        Gender = c.Gender
                    });
        }

        public PetModel SavePet(PetModel petmodel)
        {
            var entity = _context.Pet.Add(new PetEntity() {
                Age = petmodel.Age,
                Gender = petmodel.Gender,
                Name = petmodel.Name
            });
            petmodel.Id = entity.Entity.Id;
            _context.SaveChanges();
            return petmodel;
        }
    }
}
