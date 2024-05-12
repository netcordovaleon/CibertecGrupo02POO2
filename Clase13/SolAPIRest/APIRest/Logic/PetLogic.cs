using APIRest.Model;

namespace APIRest.Logic
{
    public class PetLogic
    {
        public IEnumerable<PetModel> GetAllPets() {
            IEnumerable<PetModel> lista = new  List<PetModel>();
            return lista;
        }

        public PetModel GetById(int id)
        {
            PetModel item = new PetModel();
            return item;
        }

        public PetModel SavePet(PetModel model)
        {
            return model;
        }

        public PetModel UpdatePet(PetModel model)
        {
            return model;
        }

        public void Delete(int id)
        {
            PetModel item = new PetModel();
        }

    }
}
