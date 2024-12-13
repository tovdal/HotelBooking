using HotelBooking.Service.GuestService;

namespace HotelBooking.Controllers
{
    public class GuestController
    {
        //private readonly GuestCreate _guestCreate;
        private readonly GuestRead _guestRead;
        //private readonly GuestUpdate _guestUpdate;
        //private readonly GuestDelete _guestDelete;

        public GuestController(GuestRead guestRead)
        {
            //_guestCreate = guestCreate;
            _guestRead = guestRead;
            //_guestUpdate = guestUpdate;
            //_guestDelete = guestDelete;
        }

        public void CreateANewGuest()
        {


        }
        public void ShowAllGuests()
        {
            var guests = _guestRead.GetAllGuestsInDatabase();
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
        public void ShowAllActiveGuests()
        {
            var guests = _guestRead.GetAllActiveGuestsInDatabase();
            if (guests == null)
            {
                Console.WriteLine("There is no customers registerd.");
                return;
            }
            else
            {
                Console.WriteLine("List of Customers:");
                // Spector....?
                foreach (var guest in guests)
                {
                    Console.WriteLine(guest); // richard säger ToString.
                }
            }
        }
        public void ShowAllInactiveGuests()
        {
            var guests = _guestRead.GetAllInactiveGuestsInDatabase();
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
        public void ShowAllDeletedGuests()
        {
            var guests = _guestRead.GetAllDeletedGuestsInDatabase();
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
        public void ShowAGuestDetailes()
        {
            Console.WriteLine("Enter the ID of the guest you want to look at: ");
            var stringGuestID = Console.ReadLine();

            if (!int.TryParse(stringGuestID, out int guestId))
            {
                Console.WriteLine("Please enter a valid number ID.");
                return;
            }

            var guests = _guestRead.GetGuestDetailes(guestId);

            if (guests == null || guests.Count == 0)
            {
                Console.WriteLine($"No guest with ID number: {guestId}.");
                return;
            }
            foreach (var guest in guests)
            {
                Console.WriteLine($"Guest ID: {guest.GuestId}");
                Console.WriteLine($"Name: {guest.FirstName}");
                Console.WriteLine($"Name: {guest.LastName}");
                Console.WriteLine($"IsActive: {guest.IsGuestStatusActive}");
                Console.WriteLine("-------------------------");
            }
        }
        public void UpdateAGuest()
        {

        }
        public void DeleteAGuest()
        {

        }
        public void TakeBackDeletedGuest()
        {

        }
    }
}
