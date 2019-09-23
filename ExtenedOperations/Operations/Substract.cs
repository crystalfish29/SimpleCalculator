using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Contracts;

namespace ExtenedOperations
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol",'-')]
    public class Substract : IOperation
    {
        public int Operate(int left, int right)
        {
            return left - right;
        }
    }
}
