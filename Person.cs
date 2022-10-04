using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Course5
{
    public class Person
    {
        private string _name;

        public Person(string _name)
        {
            this._name = _name;
        }

        public Person()
        {
            this._name = string.Empty;
        }

        public override string ToString()
        {
            return $"Name: {_name}";
        }
        public string Name
        {
            get => this._name;
            set => _name = (!string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("The name must not be empty or null");
        }
    }
}
