using EFCodeFirst.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var ctx = new SchoolContext())
            //{
            //    var osmaci = ctx.Classes.FirstOrDefault(c => c.ClassName.Contains("8.A"));
            //    var stud = new Student() { StudentName = "Marek", Class = osmaci };

            //    if (osmaci == null)
            //    {
            //        osmaci = new Class() { ClassName = "8.A" };
            //        ctx.Classes.Add(osmaci);
            //    }

            //    ctx.Students.Add(stud);
            //    ctx.SaveChanges();

            //    var students = ctx.Students.ToList();
            //    var studentMarek = ctx.Students.FirstOrDefault(s => s.StudentName.Contains("Marek"));

            //    studentMarek.StudentName = "Marek Skotnica";

            //    ctx.SaveChanges();
            //}


            using (var ctx = new SchoolContext())
            {
                var marek = ctx.Students.FirstOrDefault(s => s.StudentName.Contains("Marek"));
                ctx.Students.Remove(marek);
                ctx.SaveChanges();
            }


            //if (marek != null)
            //{
            //    marek.StudentName = "Marek Skotnica";
            //}

            //using (var ctx = new SchoolContext())
            //{
            //    ctx.Entry(marek).State = System.Data.Entity.EntityState.Modified;
            //    ctx.SaveChanges();
            //}
        }
    }
}
