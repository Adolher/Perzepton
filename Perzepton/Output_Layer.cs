using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perzepton
{
    internal class Output_Layer
    {
        private Boolean[,] expected_output, output;
        private Neuron[,] Neuron_Layer;
        private Int32 width, height;

        public Output_Layer(Int32 width = 0, Int32 height = 0)
        {
            this.width = width;
            this.height = height;
            Neuron_Layer = new Neuron[width, height];
            output = new Boolean[width, height];
            expected_output = new Boolean[width,height];

            for(Int32 i = 0; i < width; i++)
            {
                for(Int32 j = 0; j < height; j++)
                {
                    Neuron_Layer[i,j] = new Neuron();
                    output[i, j] = false;
                    expected_output[i,j] |= false;
                }
            }
        }
        public Boolean[,] activate_Output_Layer(in List<Boolean> Eingabe, in Boolean[,] expected_output)
        {
            for (Int32 i = 0; i < width; i++)
            {
                for (Int32 j = 0; j < height; j++)
                {
                    output[i,j] = Neuron_Layer[i, j].activate(Eingabe, expected_output[i,j]);
                }
            }
            return output;
        }

        public void print_output(in Boolean[,] expected_output)
        {
            Console.Write("Erlernte Ausgabe:\t");
            for (Int32 i = 1; i < width; i++)
            {
                for (Int32 j = 0; j < height; j++)
                {
                    Console.Write($" {i}{output[i, j]}");
                }
            }
            Console.WriteLine();
            Console.Write("Erwartete Ausgabe:\t");
            for (Int32 i = 1; i < width; i++)
            {
                for (Int32 j = 0; j < height; j++)
                {
                    Console.Write($" {i}{expected_output[i, j]}");
                }
            }
        }
    }
}
