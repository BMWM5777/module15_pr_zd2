using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace module15_pr_zd2
{
    class MyClass
    {
        private int privateField;
        public int PublicField;

        private MyClass() { }

        public MyClass(int value)
        {
            privateField = value;
            PublicField = value;
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Private method called");
        }

        public void PublicMethod()
        {
            Console.WriteLine("Public method called");
        }
    }

    class Program
    {
        static void Main()
        {
            Type myClassType = typeof(MyClass);

            // Получение конструктора с параметрами или без параметров
            ConstructorInfo constructor = myClassType.GetConstructor(Type.EmptyTypes) ?? myClassType.GetConstructors()[0];

            // Создание экземпляра
            object myObject = constructor.Invoke(null);

            // Вывод значений свойств до изменения
            Console.WriteLine($"PublicField до изменения: {myClassType.GetProperty("PublicField").GetValue(myObject)}");

            // Манипулирование свойствами
            myClassType.GetProperty("PublicField").SetValue(myObject, 42);

            // Вывод значений свойств после изменения
            Console.WriteLine($"PublicField после изменения: {myClassType.GetProperty("PublicField").GetValue(myObject)}");
        }
    }
}
