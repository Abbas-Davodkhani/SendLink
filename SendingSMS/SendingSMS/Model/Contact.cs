namespace SendingSMS.Model
{
    public class Contact
    {
        public Contact(string phoneNumber , bool isDeleted = false)
        {
            PhoneNumber = phoneNumber;
            IsDeleted = isDeleted;  
        }
    
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}
