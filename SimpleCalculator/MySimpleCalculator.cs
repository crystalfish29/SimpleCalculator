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
        [ImportMany] // to create an import that can be filled  by any number of exports
        IEnumerable<Lazy<IOperation, IOperationData>> operations;


        string ICaculator.Calculate(string input)
        {
            int left;
            int right;

            int fn = FindFirstNonDigit(input);
            if (fn == -1) return "could not parse command";

            try
            {
                left = int.Parse(input.Substring(0, fn));
                right = int.Parse(input.Substring(fn + 1));
            }
            catch {
                return "could not parse command";
            }

            char operation = input[fn];
            foreach (Lazy<IOperation, IOperationData> i in operations) {
                // 找到实现接口(inplicity)对象,并赋值给实现了 IOperationData 接口胡对象
                // metadata values and exported object can be accessed with the Metadata property 
                // and the Value property respectively. 
                if (i.Metadata.Symbol.Equals(operation)) // check theis metadata
                    return i.Value.Operate(left, right).ToString();
            }
            return "operation not found";
        }


        private int FindFirstNonDigit(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!(Char.IsDigit(s[i])))
                    return i;
            }
            return -1;
        }

    }
}
