using APIRest.Model;

namespace APIRest.Interfaces
{
    public interface IPetLogic
    {
        PetModel SavePet(PetModel petmodel);
        IEnumerable<PetModel> GetAll();
    }
}
