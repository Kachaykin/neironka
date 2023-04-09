using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neironka1
{
    class Program
    {
        public class Neiron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smoothing { get; set; } = 0.00001m;
           
            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }
            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }
            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }
        }


        static void Main(string[] args)
        {
            decimal kg = 100;
            decimal pound = 6.10475m;

            Neiron neiron = new Neiron();


            int i = 0;
            do
            {
                i++;
                neiron.Train(kg, pound);
                Console.WriteLine($"Итерация: {i} \tОшибка: \t{neiron.LastError}");
            } while (neiron.LastError > neiron.Smoothing || neiron.LastError < -neiron.Smoothing);

            Console.WriteLine("Обучение завершенно!");
            Console.WriteLine($"{neiron.ProcessInputData(100)} пудов в {100} кг ");
            Console.WriteLine($"{neiron.ProcessInputData(541)} пудов в {541} кг ");
            Console.WriteLine($"{neiron.RestoreInputData(541)} кг в {541} пудах ");
            Console.ReadKey();

        }
    }
}
