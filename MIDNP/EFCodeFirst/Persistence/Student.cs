using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Persistence
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [MaxLength(50), MinLength(2), Required]
        public string StudentName { get; set; }

        public Class Class { get; set; }
    }
}
