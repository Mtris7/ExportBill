namespace ExportBill
{
    public class CustomerModel
    {
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PlateID { get; set; }
        public string IdentityCard { get; set; }
        public string CountCheck { get; set; }
        public string VehicleType { get; set; }
        public string CreateService { get; set; }
        public CustomerModel(){}
        public CustomerModel(string customerNumber, string customerName, string address = null, string phone = null,
                            string plateID = null, string identityCard = null, string countCheck = null, string vehicleType = null, string createService = "+")
        {
            CustomerNumber = customerNumber;
            CustomerName = customerName;
            Address = address;
            Phone = phone;
            PlateID = plateID;
            IdentityCard = identityCard;
            CountCheck = countCheck; 
            VehicleType = vehicleType;
            CreateService = createService;
        }
    }
}
