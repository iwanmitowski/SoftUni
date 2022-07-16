using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.DTOs
{
    public class SoldProductExportRootDTO
    {
        public int Count { get; set; }

        public IEnumerable<SoldProductExportDTO> Products { get; set; }
    }
}
