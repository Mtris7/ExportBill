namespace ExportBill
{
    public class StaffModel
    {
        public string UserID;
        public string UserName;
        public StaffModel(){}
        public StaffModel(string userID, string userName)
        {
            UserID = userID;
            UserName = userName;
        }
    }
}
