using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MIDNP.Linq
{
    [TestClass]
    public sealed class LinqEssentialsTest
    {
        /// <summary>
        /// A public field with a list of students. (Example of a useless documentation)
        /// </summary>
        public List<Student> Students;

        [TestInitialize]
        public void InitTest()
        {
            Students = new List<Student>() {
                new Student { Name = "Jane", Age = 18 },
                new Student { Name = "John", Age = 18 },
                new Student { Name = "Steve",  Age = 15 },
                new Student { Name = "Eve",  Age = 15 },
                new Student { Name = "Bill",  Age = 25 },
                new Student { Name = "Elizabeth" , Age = 20 },
                new Student { Name = "Ram" , Age = 20 },
                new Student { Name = "Ron" , Age = 19 },
                new Student { Name = "Marek" , Age = 27 },
                new Student { Name = "Igor" , Age = 35 },
                new Student { Name = "Augustýna" , Age = 15 },
                new Student { Name = "Tetrahedron" , Age = 1500 },
                new Student { Name = "Billy" , Age = 87 },
                new Student { Name = "Billy" , Age = 88 }
            };
        }

        /// <summary>
        /// Uuuu. Let's get started. 
        /// </summary>
        [TestMethod]
        public void Test1_Essentials()
        {
            //Select students that are older than 80 years and order them alphabetically - first by name, then descending by age.
            var olderStudents = Students.Where(s => s.Age > 80).OrderBy(s => s.Name).ThenByDescending(s => s.Age);


            //Run it with Ctrl+R Ctrl+T (hold Ctrl). Breakpoints are supported. Code editing while debugging? No problem. 
            Assert.IsTrue(olderStudents.Count() == 3
                          && olderStudents.First().Name == "Billy"
                          && olderStudents.First().Age == 88
                          && olderStudents.Skip(1).First().Name == "Billy"
                          && olderStudents.Skip(1).First().Age == 87
                          && olderStudents.Last().Name == "Tetrahedron"); //This is a horrible way to assert, but you can learn some new linq. 

            //Now calculate average students age. 
            var averageAge = 666;//TODO
            Assert.IsTrue(averageAge == 135.85714285714286); //Comparing double values, lucky to got away with that. Better use decimal.

            //How many students are above average? 
            var aboveAverageCount = 123456789;//TODO
            Assert.IsTrue(aboveAverageCount == 1);

            //Students like to get a good grades. (figure out what to do from the assert)
            var studentGrades = new List<Grade>();//TODO

            Assert.IsTrue(studentGrades.OfType<Grade>().Count() == Students.Count && studentGrades.All(g => g.Value == 1) && studentGrades.All(g => g.Subject == "MI-DNP"));
            //Note. Be carefull when calling a constructor inside a select statement. There is a lazy evaluation and if you dont put ToList or ToArray at the end, it will create new objects each time it is accessed. 

            //Now imagine doing that with for cycles. Ugh. Never again. 
            //Btw. did you noticed the naming of private variables? You should always name them after a result (or a subresult) of a LINQ query. No tmp, or a, or ffs, or os!
        }

        /// <summary>
        /// Now some more magic tricks. 
        /// </summary>
        [TestMethod]
        public void Test2_GroupBy()
        {
            //Students with same age would like to be in the same group. How many such groups are there? 
            var studentGroupsCount = 456465465;//TODO

            Assert.IsTrue(studentGroupsCount == 10);

            //Now get students from groups with more that 1 member to one array. 
            var studentsFromNonSolitareGroups = new List<dynamic>();//TODO

            Assert.IsTrue(studentsFromNonSolitareGroups.Count() == 7);
        }
    }

    public class Student
    {
        public string Name;
        public int Age;
    }

    public class Grade
    {
        public string Subject;
        public Student Student;
        public int Value;
    }
}
