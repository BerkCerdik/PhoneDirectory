using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Report.Model.ORM.Entities
{
    public class ReportEntity
    {

        public int ID{ get; set; }
        public string Location{ get; set; }
        public int NumberOfPerson { get; set; }
        public int NumberOfPhone { get; set; }


        private bool _status = false;
        public bool ReportStatus 
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        private DateTime _date = DateTime.Now;
        public DateTime RequestDate
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
    }
}
