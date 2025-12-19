namespace WebApplication3.Models
{
    public class DBSelectOutClass
    {
        public string sID { get; set; }
		public string cName { get; set; }
        public string eName { get; set; }
        public string sName { get; set; }
        public string eMail { get; set; }
	    public byte status { get; set; }	    
        public bool stop { get; set; }
        public string stopMemo { get; set; }
        public string loginID  { get; set; }
        public string loginPWD { get; set; }
        public string memo { get; set; }
        public DateTime nowDateTime { get; set; }
        public string nowID { get; set; }
        public DateTime updDateTime { get; set; }
        public string updID { get; set; }
    }
    public class DBInsertInClass
    {
        public string cName { get; set; }
        public string eName { get; set; }
        public string sName { get; set; }
        public string eMail { get; set; }
        public string loginID { get; set; }
        public string loginPWD { get; set; }
        public string createrName { get; set; }
    }
    public class DBUpdateInClass
    {
        public string oldName { get; set; }
        public string newName { get; set; }
    }

    public class DBNameInClass
    {
        public string name { get; set; }
    }
}
