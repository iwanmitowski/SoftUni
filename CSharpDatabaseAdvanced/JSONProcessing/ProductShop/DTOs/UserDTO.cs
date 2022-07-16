using System.Collections.Generic;

namespace ProductShop.DTOs
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public SoldProductExportRootDTO SoldProducts { get; set; }
    }
}
