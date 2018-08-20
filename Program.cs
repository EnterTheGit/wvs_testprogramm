// Lösung 4. Handlungsschritt – Beliebte Artikel vorschlagen
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Lösung_IHK_ArtikelVorschlagen
{
    public static class Extension
    {
        // Extension-Methode:
        // Die Klasse Hashtable wird um die Methode "Get" erweitert
        public static int Get(this Hashtable h, string key)
        {
            int ret = 0;
            if (h.ContainsKey(key))
            {
                ret = (int)h[key];
            }
            return ret;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] artikel = new string[] { "Auto", "Haus", "Boot", "Smartphone" };
            Hashtable artikelAnzahl = new Hashtable();
            artikelAnzahl.Add("Auto", 3);
            artikelAnzahl.Add("Haus", 7);
            artikelAnzahl.Add("Boot", 2);
            artikelAnzahl.Add("Smartphone", 10);
            int numOfEmpfehlung = 3;
            int aktuellesMaximum = 0;
            string keyOfMaximum = "";
            List<string> empfehlung = new List<string>();
            // Vorhandene Artikel ausgeben
            for (int i = 0; i < artikel.Length; ++i)
            {
                string key = artikel[i];
                int anzahl = artikelAnzahl.Get(key); // Extensionmethode wird genutzt
                Console.WriteLine(key + ", " + anzahl);
            }
            // Beliebteste Artikel ermitteln für die Empfehlung
            for (int j = 0; j < numOfEmpfehlung; ++j)
            {
                aktuellesMaximum = 0;
                for (int i = 0; i < artikel.Length; ++i)
                {
                    string key = artikel[i];
                    int anzahl = artikelAnzahl.Get(key);
                    if (anzahl > aktuellesMaximum && empfehlung.Contains(key) == false)
                    {
                        aktuellesMaximum = anzahl;
                        keyOfMaximum = key;
                    }
                }
                if (empfehlung.Contains(keyOfMaximum) == false)
                {
                    empfehlung.Add(keyOfMaximum);
                }
            }

            // Empfehlung ausgeben
            Console.WriteLine("\n" + numOfEmpfehlung + " Empfehlungen:");
            foreach (string a in empfehlung)
            {
                Console.Write(a + " ");
            }
            Console.ReadKey();
        }
    }
}