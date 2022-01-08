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
            List<output_Neuron> oN = new List<output_Neuron>();
            Int32[] ausgabe = new Int32[10];
            Int32[] ausgabe_Erwartung = new Int32[10];
            Int32 counter = 0, c = 0;

            for (Int32 i = 0; i < ausgabe.Length; i++)
            {
                oN.Add(new output_Neuron(10));
            }

            while (true)
            {
                for (Int32 i = 0; i < ausgabe.Length; i++)
                {
                    ausgabe[i] = 0;
                    ausgabe_Erwartung[i] = 0;
                }

                Int32[] w_in = new Int32[4] { 0, 0, 0, 0 };
                Int32 eingabe = input(ref w_in, counter);
                ausgabe_Erwartung[0] = 1;

                Console.Write("Erlernte Ausgabe:\t");
                for(Int32 i = 0;i < ausgabe.Length;i++)
                {
                    ausgabe[i] = oN[i].input(in w_in);
                    Console.Write(ausgabe[i]);
                }
                Console.WriteLine();
                Console.Write("Erwartete Ausgabe:\t");
                for (Int32 i = 0; i < ausgabe.Length; i++)
                {
                    Console.Write(ausgabe_Erwartung[i]);
                }

                for (Int32 i = 0; i < ausgabe.Length; i++)
                {
                    if(ausgabe[i] != ausgabe_Erwartung[i])
                    {
                        oN[i].Delta_Regel_Training(in w_in, in ausgabe_Erwartung[i]);
                    }
                }
                
                if (counter%10 == 9)
                {
                    c++;
                    Console.WriteLine(c);
                    Console.ReadKey(true);
                    Console.Clear();
                }
                counter++;
                Console.WriteLine();
                Console.WriteLine();
            }
            
        }

        static Int32 input(ref Int32[] w_in, Int32 counter)
        {
            Console.Write("\nZiffer eingeben: ");
            

            Int32 input = counter % 10;                                                          //Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(input);

            switch (input)
            {
                case 0:
                    break;
                case 1:
                    w_in[3] = 1;
                    break;
                case 2:
                    w_in[2] = 1;
                    break;
                case 3:
                    w_in[3] = 1;
                    w_in[2] = 1;
                    break;
                case 4:
                    w_in[1] = 1;
                    break;
                case 5:
                    w_in[3] = 1;
                    w_in[1] = 1;
                    break;
                case 6:
                    w_in[2] = 1;
                    w_in[1] = 1;
                    break;
                case 7:
                    w_in[3] = 1;
                    w_in[2] = 1;
                    w_in[1] = 1;
                    break;
                case 8:
                    w_in[0] = 1;
                    break;
                case 9:
                    w_in[3] = 1;
                    w_in[0] = 1;
                    break;
            }
            return input;
        }
    }
}

class output_Neuron
{
    private Double[] _eingabeWichtung;
    private Double _schwellenWert;
    private const Double _eW = 1.0;
    private const Double _lernFaktor = 0.2;

    public output_Neuron(Int32 l)
    {
        this._eingabeWichtung = new Double[l];
        this._schwellenWert = 1.5;

        for (Int32 i = 0; i < _eingabeWichtung.Length; i++)
        {
            _eingabeWichtung[i] = _eW;
        }
    }

    public Int32 input(in Int32[] EingabeInformation)
    {
        Double Netzeingabe = _Propagierungsfunktion(in EingabeInformation);
        Int32 Aktivierung = _Aktivierungsfunktion(in Netzeingabe);
        Int32 Ausgabe = _Ausgabefunktion(in Aktivierung);
        return Ausgabe;
    }

    public void Delta_Regel_Training(in Int32[] EingabeInformation, in Int32 AusgabeErwartung)
    {
        Int32 Ausgabe = input(in EingabeInformation);

        Console.WriteLine();
        for (Int32 i=0;i<EingabeInformation.Length;i++)
        {
            Console.Write($"{this._eingabeWichtung[i]} + {_lernFaktor} * ({AusgabeErwartung} - {Ausgabe}) * {EingabeInformation[i]} = ");
            this._eingabeWichtung[i] = this._eingabeWichtung[i] + _lernFaktor * (AusgabeErwartung - Ausgabe) * EingabeInformation[i];
            Console.WriteLine(this._eingabeWichtung[i]);
            Console.Write(" ");
        }
    }

    private Double _Propagierungsfunktion( in Int32[] EingabeInformation)
    {
        Double Netzeingabe = 0;

        for(Int32 i = 0; i < EingabeInformation.Length; i++)
        {
            Netzeingabe += EingabeInformation[i] * this._eingabeWichtung[i];
        }
        return Netzeingabe;
    }
    private Int32 _Aktivierungsfunktion(in Double Netzeingabe)
    {
        if (Netzeingabe >= this._schwellenWert)
            return 1;
        else
            return 0;
    }
    private Int32 _Ausgabefunktion(in Int32 Aktivierung)
    {
        if (Aktivierung == 1)
            return 1;
        else
            return 0;
    }
}