﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Eruption> eruptions = new List<Eruption>()
        {
            new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
            new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
            new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
            new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
            new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
            new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
            new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
            new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
            new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
            new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
            new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
            new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
            new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
        };

        // Exemple de requête - Imprime toutes les éruptions de Stratovolcan.
        IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
        PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

        // Exécutez les tâches d'assignation ici !

        static void PrintEach(IEnumerable<Eruption> items, string msg = "")
        {
            Console.WriteLine("\n" + msg);
            foreach (Eruption item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
