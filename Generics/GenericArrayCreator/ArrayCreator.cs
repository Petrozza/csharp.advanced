using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {


        public static T[] Create<T>(int lenght, T item)
        {
            T[] array = new T[lenght];

            for (int L = 0; L < lenght; L++)
            {
                array[L] = item;
            }
            return array;
        }
    }

}
