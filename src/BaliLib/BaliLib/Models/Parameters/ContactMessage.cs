namespace BaleLib.Models.Parameters
{
    public class ContactMessage :  BaseInput
    {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ContactMessage()
        {
        }

        public ContactMessage(string phoneNumber, string firstName, string lastName)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
