using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [Required]
        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }

        [Required]
        [Range(2, 35)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(1, 100_000)]
        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        [Required]
        public int ShellId { get; set; }

        public virtual Shell Shell { get; set; }

        public virtual ICollection<CountryGun> CountriesGuns { get; set; } = new HashSet<CountryGun>();
    }
}
