using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Examples.Linq
{
    public class WeightSum : IExample
    {
        public void Run()
        {
            int[] values = { 1, 2, 3 };
            int[] weights = { 3, 2, 1 };
            //dot product of vector
            values.Zip(weights, (value, weight) => value * weight) //same as a dot product
                  .Sum();  //sum of the multiplications of values and weights
        }
    }
}
