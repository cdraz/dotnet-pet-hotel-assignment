using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets
                .Include(pet => pet.petOwner);        }

        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }

        [HttpPost]

        public ActionResult<Pet> Post(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        [HttpPut("{id}/checkin")]
        public IActionResult CheckIn(int id)
        {
            Pet petToUpdate = _context.Pets.Find(id);
            petToUpdate.checkInPet();
            _context.Pets.Update(petToUpdate);
            _context.SaveChanges();

            return Ok(petToUpdate);
        }

        [HttpPut("{id}/checkout")]
        public IActionResult CheckOut(int id)
        {
            Pet petToUpdate = _context.Pets.Find(id);
            petToUpdate.checkOutPet();
            _context.Pets.Update(petToUpdate);
            _context.SaveChanges();

            return Ok(petToUpdate);
        }

        [HttpDelete("{id}")]
        public void Delete(int id) {
            Pet pet = _context.Pets.Find(id);
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }
    }
}
