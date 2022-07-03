using P01_StudentSystem.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public ResourceTypeEnum ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
