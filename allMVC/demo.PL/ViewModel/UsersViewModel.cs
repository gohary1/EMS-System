using System.Collections;
using System.Collections.Generic;

namespace demo.PL.ViewModel
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }

        public string phoneNumber { get; set; }

        public IEnumerable<string> Roles { get; set; }

    }
}
