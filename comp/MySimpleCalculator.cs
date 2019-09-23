using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
namespace SimpleCalculator
{
    [Export(typeof(ICaculator))]
    public class MySimpleCalculator : ICaculator
    {
        string ICaculator.Calculate(string input)
        {
            return input;
        }
    }
}
