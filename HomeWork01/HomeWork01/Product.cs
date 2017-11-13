using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* TASK:
 * создать класс у которого будет три филда два конструктора три проперти и будет оверрайд тустринг
 * создать экземпляр и вывести значения на консоль
 * 186-191
 * 215-220
 * 222-226
 * 263-285

*/


namespace HomeWork01
{
    class Product
    {
        private uint _id;
        private double _price;
        private string _name;

        public uint Id
        {
            get => _id;
            set => _id = value;
        }
        

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Product()
        {
            _id = 0;
            _price = 0;
            _name = "Unknown";
        }

        public Product(uint id)
        {
            _id = id;
            _price = 0;
            _name = "Unknown";
        }

        public Product(uint id, float price)
        {
            _id = id;
            _price = price;
            _name = "Unknown";
        }

        public Product(uint id, double price, string name)
        {
            _id = id;
            _price = price;
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
