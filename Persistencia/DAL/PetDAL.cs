using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;
using Modelo;
using Persistencia.Contexts;

namespace Persistencia.DAL
{
    public class PetDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Pet> ObterPetsClassificadosPorId()
        {
            return context.Pets.OrderBy(b => b.PetId);
        }
        public Pet ObterPetsPorId(long id)
        {
            return context.Pets.Where(f => f.PetId == id).First();
        }
        public void GravarPet(Pet pet)
        {
            if (pet.PetId == 0)
            {
                context.Pets.Add(pet);
            }
            else
            {
                context.Entry(pet).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Pet EliminarPetPorId(long id)
        {
            Pet pet = ObterPetsPorId(id);
            context.Pets.Remove(pet);
            context.SaveChanges();
            return pet;
        }
    }
}
