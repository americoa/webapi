using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabAspWebApi.ViewModel
{
    public sealed class MVClient
    {
        public Int32 ClientID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? DateBirth { get; set; }
        public String State { get; set; }
        public String City { get; set; }
        public Decimal? Zip { get; set; }
        public String Country { get; set; }
        public Decimal? Phone { get; set; }
        public String Email { get; set; }
    }
}