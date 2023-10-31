using System;
using System.Collections.Generic;

#nullable disable

namespace ApiDemoLiv.datamodel
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
