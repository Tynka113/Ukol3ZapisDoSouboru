using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net.Sockets;


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
        static int ZadejUkon()
        {
            string menu = @"Jak má být naloženo se zadaným obsahem? Zadej volbu 1-4 pro:
                1 - Přidat text (přepsat soubor)
                2 - Přidat text (přidat do souboru)
                3 - Vypsat obsah souboru
                4 - Ukončit
             ";

            Console.WriteLine(menu);
            string zadanaVolbaText = Console.ReadLine();
            int zadanaVolba;

            while (!int.TryParse(zadanaVolbaText, out zadanaVolba) || zadanaVolba > 4 || zadanaVolba < 1)
            {
                Console.WriteLine("Neplatná volba, zkus to znovu:");
                zadanaVolbaText = Console.ReadLine();

            }
            return zadanaVolba;
        }

        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();
            Console.WriteLine("Nyní zadávej texty, pro ukončení zadávání stiskni 2x enter: ");
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
            int zadanaVolba = ZadejUkon();

            for(int i=0; i<zadanaVolba+1;i++)
            {
                if (zadanaVolba == 4)
                {
                    break;
                    //Console.WriteLine("Chceš-li ukončit, zmáčkni enter");
                    //Console.ReadLine();
                }
                else if (zadanaVolba == 1)
                {
                    File.WriteAllText(cesta, zadanyText);
                }
                else if (zadanaVolba == 2)
                {
                    File.AppendAllText(cesta, zadanyText);
                }
                else if (zadanaVolba == 3)
                {
                    Console.WriteLine(File.ReadAllText(cesta));
                }

                Console.WriteLine("Úspěšně dokončeno, co dál?");
                zadanaVolba = ZadejUkon();
                i = 0;
            }
            


           

        }
    }
}

