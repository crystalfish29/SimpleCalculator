using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace SimpleCalculator
{
    class Program
    {
        private CompositionContainer _container;

        [Import(typeof(ICaculator))]
        public ICaculator calculator;

        //A catalog is an object that makes available parts discovered from some source
        //MEF provides catalogs to discover parts from a provided type, an assembly , or a directory.
        private Program()
        { 
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            _container = new CompositionContainer(catalog);

            //tells the composition container to compose a specific set of parts,
            this._container.ComposeParts(this);

        }


        static void Main(string[] args)
        {
            var p = new Program();
            Console.WriteLine("Enter command");
            while (true) {
                var str = Console.ReadLine();
                str = p.calculator.Calculate(str);
                Console.WriteLine(str);
            }


            

        }
    }
}
