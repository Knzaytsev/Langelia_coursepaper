using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langelia
{
    public class City
    {
        private int _id;
        private string _nameCity;
        private int _numberCitizen;
        private int _numberProduct;
        private int _numberFood;

        public City() { }

        public City(int id, string nameCity, int numberCitizen, int numberProduct, int numberFood)
        {
            _id = id;
            _nameCity = nameCity;
            _numberCitizen = numberCitizen;
            _numberFood = numberFood;
            _numberProduct = numberProduct;
        }
    }
}
