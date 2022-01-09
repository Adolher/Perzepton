using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perzepton
{
    internal class Program
    {
        static void Main()
        {
            List<Neuron> oN = new List<Neuron>();
            Boolean[] ausgabe = new Boolean[10];
            Boolean[] ra = new Boolean[] { false, false, false, false, false, false, false, false, false, false };
            List<Boolean> ausgabe_Erwartung = new List<Boolean>();
            ausgabe_Erwartung.AddRange(ra);
            Int32 counter = 0, c = 0;

            for (Int32 i = 0; i < ausgabe.Length; i++)
            {
                oN.Add(new Neuron());
            }

            while (true)
            {
                for (Int32 i = 0; i < ausgabe.Length; i++)
                {
                    ausgabe[i] = false;
                    ausgabe_Erwartung[i] = false;
                }

                List<Boolean> w_in = new List<Boolean> { false, false, false, false };
                Int32 eingabe = input(ref w_in, counter);
                ausgabe_Erwartung[eingabe] = true;

                Console.Write("Erlernte Ausgabe:\t");
                for(Int32 i = 0;i < ausgabe.Length;i++)
                {
                    ausgabe[i] = oN[i].activate(in w_in, ausgabe_Erwartung[i]);
                    Console.Write($" {i}{ausgabe[i]}");
                }
                Console.WriteLine();
                Console.Write("Erwartete Ausgabe:\t");
                for (Int32 i = 0; i < ausgabe.Length; i++)
                {
                    Console.Write($" {i}{ausgabe_Erwartung[i]}");
                }
                
                if (counter%10 == 0)
                {
                    c++;
                    Console.WriteLine();
                    Console.WriteLine(c);
                    Console.ReadKey(true);
                    Console.Clear();
                }
                counter++;
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }

        static Int32 input(ref List<Boolean> w_in, Int32 counter)
        {
            Console.Write("\nZiffer eingeben: ");
            

            Int32 input = counter % 10;                                                          //Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(input);

            switch (input)
            {
                case 0:
                    break;
                case 1:
                    w_in[3] = true;
                    break;
                case 2:
                    w_in[2] = true;
                    break;
                case 3:
                    w_in[3] = true;
                    w_in[2] = true;
                    break;
                case 4:
                    w_in[1] = true;
                    break;
                case 5:
                    w_in[3] = true;
                    w_in[1] = true;
                    break;
                case 6:
                    w_in[2] = true;
                    w_in[1] = true;
                    break;
                case 7:
                    w_in[3] = true;
                    w_in[2] = true;
                    w_in[1] = true;
                    break;
                case 8:
                    w_in[0] = true;
                    break;
                case 9:
                    w_in[3] = true;
                    w_in[0] = true;
                    break;
            }
            return input;
        }
    }
}