namespace hotel_application
{
    // Model of Customer Data
    public class CustomerData
    {
        public string name, contact, email, gender, dob, stayFromDate, stayTillDate;
        public CustomerData(string name, string contact, string email, string gender, string dob, string stayFromDate, string stayTillDate)
        {
            this.name = name;
            this.contact = contact;
            this.email = email;
            this.gender = gender;
            this.dob = dob;
            this.stayFromDate = stayFromDate;
            this.stayTillDate = stayTillDate;
        }
    }
}
