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
            Int32 counter = 0, c = 0, width = 10, height = 1;
            Boolean[,] ausgabe_Erwartung = new Boolean[width, height];
            Output_Layer out_Lay = new Output_Layer(width,height);

            while (true)
            {
                for (Int32 i = 0; i < width; i++)
                {
                    for (Int32 j = 0; j < height; j++)
                    {
                        ausgabe_Erwartung[i,j] = false;
                    }
                }
                List<Boolean> w_in = new List<Boolean> { false, false, false, false };
                Int32 eingabe = input(ref w_in, counter);
                ausgabe_Erwartung[eingabe,height-1] = true;

                
                out_Lay.activate_Output_Layer(w_in, ausgabe_Erwartung);
                out_Lay.print_output(ausgabe_Erwartung);
                
                
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