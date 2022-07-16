using System.Collections.Generic;

namespace ProductShop.DTOs
{
    public class ExportUsersRootDTO
    {
        public int UsersCount { get; set; }

        public IEnumerable<UserDTO> Users { get; set; }
    }
}
