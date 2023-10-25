using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


/*
Zadání
VYtvoř program podobný tomu, který jsi dělala v breakout roomu na lekci.

Tedy načítej řádky, dokud není načtený prázdný řádek a zapisuj je do souboru.

Následně obsah souboru vypiš.

Možná vylepšení:

udělej na úvod menu jestli chce uživatel přidávat řádky nebo vypsat soubor.
pořeš aby prvním řádkem se soubor přepsal a další se jen přidávaly
dej na výběr jestli se zápisem má soubor přepsat nebo se má přidat na konec
umožni zadání cesty uživatelem
případně další dle fantazie a kreativity 
 */


namespace Ukol3ZapisDoSouboru
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            Console.WriteLine("Zadávej texty, pro ukončení zadávání 2x odentruj: ");
            string text = "startujeme";
            string cesta = "C:\\Users\\macha\\OneDrive\\C#2\\Ukol3ZapisDoSouboru\\text.txt";

            while (!String.IsNullOrEmpty(text))
            {
                text = Console.ReadLine();
                if (!String.IsNullOrEmpty(text))
                {
                    builder.AppendLine(text);
                }
            }
            string zadanyText = builder.ToString();

            File.WriteAllText(cesta, zadanyText);
            Console.WriteLine(File.ReadAllText(cesta));

            Console.ReadLine();
        }
    }
}
