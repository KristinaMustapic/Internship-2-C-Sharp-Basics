using System;
using System.Collections.Generic;
using System.Linq;

namespace dr2_dump
{
    class Program
    {
        static void Main(string[] args)
        {
            //TO FIX:
            
            //popraviti kad zavrsi s nekom radnjom/ unosom da se vrati na pocetni izbornik i nastavi dalje
            //povratak na pocetni -> preko funkcija
          
          

            Menu();

            var playlist = new Dictionary<int, string>()
            {
                {0, "Song 1" },
                {1, "Song 2" },
                {2, "Song 3" },
                {3, "Song 4" }
            };

            var choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Playlista sadrži pjesme: ");

                    if(playlist.Count == 0)
                        Console.WriteLine("Lista pjesama je prazna.");

                    else
                    foreach (var song in playlist)
                        Console.WriteLine(song.Key + " - " + song.Value);

                    break;


                case 2:
                    Console.WriteLine("Unesite redni broj pjesme koju želite ispisati: ");
                    var position = int.Parse(Console.ReadLine());

                    if (playlist.ContainsKey(position))
                    {
                        foreach (var song in playlist)
                            if (song.Key == position)
                                Console.WriteLine(song.Value);
                    }
                    else { 
                        Console.WriteLine("Uneseni redni broj nije ispravan.");
                        //povratak na pocetni izbornik
                    }
                    break;


                case 3:
                    Console.WriteLine("Unesite ime pjesme ciji redni broj zelite ispisati: ");
                    var songName = Console.ReadLine();

                    if (playlist.ContainsValue(songName))
                    {
                        foreach (var song in playlist)
                            if (song.Value == songName)
                                Console.WriteLine(song.Key);
                    }
                    else
                    {
                        Console.WriteLine("Trazena pjesma ne postoji.");
                        //povratak na pocetni izbornik
                    }
                        
                    
                    break;


                case 4:
                    Console.WriteLine("Unesite poziciju i ime nove pjesme");
                    Console.WriteLine("Pozicija: ");
                    var pos = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ime pjesme: ");
                    string name = Console.ReadLine();

                    if (ConfirmChoice())
                    {
                        var flag = 0;
                        foreach (var song in playlist)
                            if (song.Value == name)
                                flag = 1;

                        if (flag == 1)
                        {
                            Console.WriteLine("Pjesma vec postoji.");
                            //povratak na pocetni izbornik
                        }

                        else if(name.Length == 0)
                        {
                            Console.WriteLine("Unijeli ste prazan string.");
                            //povratak na pocetni izbornik
                        }

                        else
                            playlist.Add(pos, name);
                    }
                        
                    else
                    {   //povratak na pocetni izbornik
                        
                    }
                    
                    //pazi ako unese indeks na kojen vec ima neku pjesma
                    

                    break;


                case 5:
                    Console.WriteLine("Unesite redni broj pjesme koju želite izbrisati: ");
                    var posi = int.Parse(Console.ReadLine());

                    if (playlist.ContainsKey(posi))
                        if (ConfirmChoice())
                        {
                            playlist.Remove(posi);
                        }
                        else
                        {
                            //povratak na pocetni izbornik
                        }
                    else
                    {
                        Console.WriteLine("Uneseni redni broj pjesme nije valjan.");
                        //povratak na pocetni izbornik
                    }


                    break;


                case 6:
                    Console.WriteLine("Unesite ime pjesme koju želite izbrisati: ");
                    var songName2 = Console.ReadLine();

                    if (playlist.ContainsValue(songName2))
                    {
                        if (ConfirmChoice())
                        {
                            foreach (var song in playlist)
                                if (song.Value == songName2)
                                    playlist.Remove(song.Key);
                        }
                    }
                    else
                    { 
                        Console.WriteLine("Unos imena pjesme nije valjan.");
                        //povratak na pocetni izbornik
                    }
                    break;

                case 7:
                    Console.WriteLine("Brisanje cijele liste");
                    if (ConfirmChoice())
                    {
                        playlist.Clear();
                    }
                
                    break;


                case 8:
                    //dohvacanje po broju/kljucu
                    Console.WriteLine("Unesite redni broj pjesme koju želite editirati: ");
                    var posit = int.Parse(Console.ReadLine());

                    if (playlist.ContainsKey(posit))
                        if (ConfirmChoice())
                        {
                            Console.WriteLine($"Unesite novo ime pjesme na poziciji {posit}: ");
                            var newSongName = Console.ReadLine();
                            playlist[posit] = newSongName;

                        }
                        else
                        {
                            Console.WriteLine("Unos nije valjan.");
                            //povratak na pocetni izbornik
                        }

                    break;


                case 9:
                    Console.WriteLine("Unesite redni broj pjesme koju zelite prebaciti: ");
                    var oldPosition = int.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite redni broj (poziciju) na koju zelite prebaciti pjesmu: ");
                    var newPosition = int.Parse(Console.ReadLine());

                    //solve till end
                        
               
                    
                    break;


                case 0:
                    Console.WriteLine("Izlaz iz aplikacije.");
                    break;


                default:
                    Console.WriteLine("Unos nije valjan");
                    //povratak na pocetni izbornik
                    break;
            }


            static void Menu()
            {
               Console.WriteLine(
           "Odaberite akciju:\n" +
           "1 - Ispis cijele liste\n" +
           "2 - Ispis imena pjesme unosom pripadajuceg rednog broja\n" +
           "3 - Ispis rednog broja pjesme unosom pripadajuceg imena\n" +
           "4 - Unos nove pjesme\n" +
           "5 - Brisanje pjesme po rednom broju\n" +
           "6 - Brisanje pjesme po imenu\n" +
           "7 - Brisanje cijele liste\n" +
           "8 - Uredivanje imena pjesme\n" +
           "9 - Uredivanje rednog broja pjesme\n" +
           "0 - Izlaz iz aplikacije\n");
            }

            static bool ConfirmChoice()
            {
                Console.WriteLine("Potvrdite svoj odabir unosom odgovarajuceg broja:\n" +
                                   "Da (1)\n" +
                                   "Ne (0)\n");
                var confirmChoice = int.Parse(Console.ReadLine());

                if (confirmChoice == 1)
                    return true;
                else
                    return false;
            }



        }
    }
}
