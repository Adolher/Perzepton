using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perzepton
{
    internal class Neuron                                                           //  j = Neuron
    {
        private const Single _schwellenWert = 1.1f;
        private const Single _template_Wichtung = 0.0f, _lernFaktor = 0.2f;
        private List<Single> _Wichtungen = new List<Single>();
        private Boolean _identity = false;

        public Boolean activate(in List<Boolean> Eingabe, Boolean expected_output)
        {
            if (_Wichtungen.Count == 0)
            {
                for (Int16 i = 0; i < Eingabe.Count; i++)
                {
                    _Wichtungen.Add(_template_Wichtung);
                }
            }
            _eingabe_Information(Eingabe);
            if (_identity != expected_output)
                _learn(ref _Wichtungen, in Eingabe, _identity, expected_output);
           
            return _identity;
        }

        private void _eingabe_Information(List<Boolean> eingabe_Impulse)            //  ox=Impuls                                           Impulse (Boolean) werden als Eingabe ( Array? ) gespeichert
        {
            List<Int16> eingabe_Werte = new List<Int16>();
            for (Int16 i = 0; i < eingabe_Impulse.Count; i++)
            {
                if (eingabe_Impulse[i])
                    eingabe_Werte.Add(1);
                else
                    eingabe_Werte.Add(0);
            }
            _propagierungs_Funktion(eingabe_Werte);
        }
        private void _learn(ref List<Single> Wichtungen, in List<Boolean> Eingabe, Boolean identity, Boolean expected_output)
        {
            Int16 ex_out = 0, id = 0;
            if (expected_output == true)
                ex_out = 1;
            if (identity == true)
                id = 1;

            for (Int16 i = 0; i < Eingabe.Count; i++)
            {
                Int16 inp = 0;
                if (Eingabe[i] == true)
                    inp = 1;
                Wichtungen[i] = Wichtungen[i] + _lernFaktor * (ex_out - id) * inp;
            }
        }
        private void _propagierungs_Funktion(List<Int16> eingabe_Werte)             //  netj=o1*w1 + o2*w2 + ... + on*wn                    Netzeingabe ist die Summe der Produkte der Eingabesignale ( ox ) und deren Wichtungen ( wx )
        {                                                                           //                                                      optional: Netzeingabe = Produkt aller Eingabesignale und Wichtungen
            Single Netzeingabe = 0;
            for (Int16 i = 0; i < eingabe_Werte.Count; i++)
            {
                Netzeingabe += eingabe_Werte[i] * this._Wichtungen[i];
            }
            _aktivierungs_Funktion(Netzeingabe);
        }
        private void _aktivierungs_Funktion(Single Netzeingabe)                     //  IF netj>= theta THEN Id = aktiv ELSE not            Wenn der Schwellenwert Theta überschritten ist, ist das Neuron aktiv (Identität)
        {                                                                           //  lineare Funktion ODER Gleichrichter-Funktion ODER logistische Funktion ODER Tangens Hyperbolicus ODER Schwellwertfunktion 
            if (Netzeingabe >= _schwellenWert)
                _ausgabe_Funktion(1);
            else
                _ausgabe_Funktion(0);
        }
        private void _ausgabe_Funktion(Int16 Identity)                              //  Id = oj                                             Ausgabe ist (meist) gleich der Identität ( Id )
        {
            if (Identity == 1)
                _identity = true;
            else
                _identity = false;
        }
    }
}