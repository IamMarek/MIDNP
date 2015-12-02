using System.Collections.Generic;

namespace EFCodeFirst.Persistence
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
