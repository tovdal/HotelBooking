using HotelBooking.Models;

namespace HotelBooking.CRUD
{
    public class CRUDGuest
    {
        // Create
        public void CreateNewGuest(Guest newGuest)
        {
            Guest.Add(newGuest);
            // Richard said that this was important or it wont save to database
            dbContext.SaveChanges(); // the dbContext not created yet
        }

        //Read
        public List<Guest> GetActiveGuestInDatabase()
        {
            return
        }
        public List<Guest> GetDeteletGuestInDatabase()
        {
            return
        }
        public List<Guest> GetAllGuestInDatabase()
        {
            return
        }

        // Update
        public void UpdateGuestStatus()
        {

        }
        public void TakeBackSoftDeletedGuest()
        {

        }

        // Delete
        public void SoftDeleteGuest() 
        {

        }



    }
}
