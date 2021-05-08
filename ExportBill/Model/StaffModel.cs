namespace ExportBill
{
    public class StaffModel
    {
        public string UserID;
        public string UserName;
        public string AdviserId;
        public string NameAdviser;
        public StaffModel() { }
        public StaffModel(string userID, string userName, string adviserId, string nameAdviser)
        {
            UserID = userID;
            UserName = userName;
            AdviserId = userID;
            NameAdviser = nameAdviser;
        }
    }
}
