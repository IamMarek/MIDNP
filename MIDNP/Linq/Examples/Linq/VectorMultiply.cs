using System.Linq;

namespace Linq.Examples.Linq
{
    public class VectorMultiply : IExample
    {
        public void Run()
        {
            int[] v1 = { 1, 2, 3 }; //First vector
            int[] v2 = { 3, 2, 1 }; //Second vector
                                    //dot product of vector
            var result = v1.Zip(v2, (a, b) => a * b);
        }
    }
}
