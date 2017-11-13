using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* TASK
 * 
 * 1. Create composition from 3 classes(1 parent - abstract, 2 - child). 
 *    Parent class must have one or more field and one or more method
 * 2. Fill array(min. 3 items) type of abstract class using simple initialization(set element count)
 * 3. Display array to console using "for"
 * 4. Create interface and implement it in 2 child classes
 * 5. Fill array type of interface using object initializer
 * 6. Display array to console using "foreach"

 * Read book: 333-355, 416-423
 */
 
namespace HomeWork02
{
    class Program
    {
        static void Main(string[] args)
        {
            Buildings[] buidlings = new Buildings[2];
            buidlings[0] = new Barrack(1000, "Barrack");
            buidlings[1] = new Farm(300, "Farm");

            for(int i = 0; i < buidlings.Length; i++)
            {
                buidlings[i].Draw();
                buidlings[i].Produce();
            }

            IDrawable[] units =
            {
                new Archer(true, 100),
                new FootMan(false, 500),
                new Farm(350, "Farm"),
            };

            foreach (IDrawable unit in units)
            {
                unit.Draw();
            }
        }
    }
}
