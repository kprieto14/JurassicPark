using System;
using System.Linq;
using System.Collections.Generic;

namespace JurassicPark
{
  class Dinosaur 
    {
      public string Name {get; set;}
      public string DietType {get; set;}
      public string DateAcquired {get; set;}
      public int Weight {get; set;}
      public int EnclosureNumber {get;set;}
    }
  class Program
  {
    static string Description(string send)
    {
      var response = send;
      //This will eventually print out a string with all the class properties when called upon
      return null;
    }
    static string PromptForString(string prompt)
    {
      Console.Write(prompt);
      var userInput = Console.ReadLine().ToUpper();

      if (userInput == "C")
      {
        userInput = "Carnivore";
        return userInput;
      }
      else if (userInput == "H")
      {
        userInput = "Herbivore";
        return userInput;
      }
      else
      {
        return userInput;
      }
    }
    static int PromptForInteger(string prompt)
    {
      Console.Write(prompt);
      int userInput;
      var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
      
      if (isThisGoodInput)
      {
        return userInput;
      }
      else
      {
        Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer. If this is incorrect, please fix this in Update Dinosaur section.");
        return 0;
      }
    }
    static void RemoveDinosaur()
    {

    }
    static void TransferDinosaur()
    {

    }
    static void Main(string[] args)
    {
      var rightNow = DateTime.Now;

      //Houses our dinosaurs
      var dinosaurs = new List<Dinosaur> ()
      {
        new Dinosaur()
          {
            Name = "T-REX",
            DietType = "Carnivore",
            DateAcquired = rightNow.ToString(),
            Weight = 200,
            EnclosureNumber = 3
          },

        new Dinosaur()
          {
            Name = "RAPTOR",
            DietType = "Carnivore",
            DateAcquired = rightNow.ToString(),
            Weight = 50,
            EnclosureNumber = 10
          },
      
        new Dinosaur()
          {
            Name = "LONG NECK",
            DietType = "Herbivore",
            DateAcquired = rightNow.ToString(),
            Weight = 2300,
            EnclosureNumber = 2
          },
      };

      Console.WriteLine("  🦕 Welcome to my dinosaur database! 🦖");
      Console.WriteLine("What would you like to do during your visit?");

      //The start of how the program will do its database thing
      var keepGoing = true;
      while(keepGoing == true)
      {
        Console.WriteLine();
        Console.WriteLine("Please pick from one of the options below: ");
        Console.WriteLine("(V)iew the dinosaurs");
        Console.WriteLine("(A)dd a new one");
        Console.WriteLine("(R)emove an existing dinosaur 😢");
        Console.WriteLine("(T)ransfer to a different enclosure");
        Console.WriteLine("(S)ummary of diet types");
        Console.WriteLine("(Q)uit");
        var response = Console.ReadLine().ToUpper();

        switch (response)
        {
          //View the dinosaurs
          case "V":
            response = PromptForString("Would you like to see the dinosaur's by (N)ames or by (E)nclosure Numbers?");
            switch (response)
              {
              case "N":
                //Sorts the dinosaurs by ABC order, then prints out list accordingly.
                var abcOrder = dinosaurs.OrderBy(dino => dino.Name);
                foreach(var dino in abcOrder)
                {
                Console.WriteLine($"{dino.Name} is a {dino.DietType}, weighing {dino.Weight} lbs living in Enclosure Number {dino.EnclosureNumber}. They were added on {dino.DateAcquired}");
                }
                break;

              case "E":
                //Sorts the dinosaurs by their enclosure numbers first, then prints out the list.
                var numericalOrder = dinosaurs.OrderBy(dino => dino.EnclosureNumber);
                foreach(var dino in numericalOrder)
                {
                Console.WriteLine($"{dino.Name} is a {dino.DietType}, weighing {dino.Weight} lbs living in Enclosure Number {dino.EnclosureNumber}. They were added on {dino.DateAcquired}");
                }
                break;

              default:
                Console.WriteLine("I don't get what you're saying. Please pick choose a valid response.");
                break;
              }
            break;

          //Add 
          case "A":
            //Adds a dinosaur when chosen.
            var dinosaur = new Dinosaur();
            dinosaur.Name = PromptForString("What is the new dinosaur's name? ");
            dinosaur.DietType = PromptForString("Are they a (C)arnivore or an (H)erbivore? ");
            dinosaur.DateAcquired = rightNow.ToString();
            dinosaur.Weight = PromptForInteger("How much does the dinosaur weigh (in lbs?) ");
            dinosaur.EnclosureNumber = PromptForInteger("Which enclosure number should they enter? ");

            dinosaurs.Add(dinosaur);
            break;

          //Remove
          case "R":
            //NEW remove method
            Console.WriteLine("You've chosen R");
            break;

          //Transfer
          case "T":
            //NEW transfer method
            Console.WriteLine("You've chosen T");
            break;

          //Summary
          case "S":
            //Use description method in here
            Console.WriteLine("You've chosen S");
            break;

          //Quit
          case "Q":
            Console.WriteLine("Bye-bye! Come back again soon!");
            keepGoing = false;
            break;

          default:
            Console.WriteLine("I don't get what you're saying. Please pick choose a valid response.");
            break;
        }
      }
    }
  }
}
