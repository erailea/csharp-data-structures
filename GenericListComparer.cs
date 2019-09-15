using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace csharptests
{
    class Personel : IComparable<Personel>
    {
        private int _Age;
        private string _Name;

        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        //1st Overload
        public int CompareTo(Personel cus)
        {
            return this.Name.CompareTo(cus.Name);
        }


        //2nd Overload
        public static int ComparePersonelName(Personel c1, Personel c2)
        {
            return c1.Name.CompareTo(c2.Name);
        }
        public static int ComparePersonelAge(Personel c1, Personel c2)
        {
            return c1.Age.CompareTo(c2.Age);
        }

    }

    //3rd Overload
    class PersonelNameSort : IComparer<Personel>
    {
        public int Compare(Personel c1, Personel c2)
        {
            return c1.Name.CompareTo(c2.Name);
        }
    }


    //3rd Overload
    class PersonelAgeSort : IComparer<Personel>
    {
        public int Compare(Personel c1, Personel c2)
        {
            return c1.Age.CompareTo(c2.Age);
        }
    }
}
