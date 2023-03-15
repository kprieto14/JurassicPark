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
    static void Description(string prompt, List<Dinosaur> list)
    {
      Console.Write(prompt);
      var dinosaurs = list;

      var response = Console.ReadLine().ToUpper();
      switch (response)
        {
          case "N":
            //Sorts the dinosaurs by ABC order, then prints out list accordingly.
            var abcOrder = dinosaurs.OrderBy(dino => dino.Name);
            //Checks if there are no dinosaurs in the zoo to print out a special message
            if(list.Count == 0)
            {
              Console.WriteLine("There are no dinosaurs in this zoo.");
            }
            else
            {
              foreach(var dino in abcOrder)
              {
                Console.WriteLine($"{dino.Name} is a {dino.DietType}, weighing {dino.Weight} lbs living in Enclosure Number {dino.EnclosureNumber}. They were added on {dino.DateAcquired}");
              }
            }
            break;

          case "E":
            //Sorts the dinosaurs by their enclosure numbers first, then prints out the list.
            var numericalOrder = dinosaurs.OrderBy(dino => dino.EnclosureNumber);
            //Again checks if there are no dinosaurs in the zoo to print out a special message.
            if(list.Count == 0)
            {
              Console.WriteLine("There are no dinosaurs in this zoo.");
            }
            else
            {
              foreach(var dino in numericalOrder)
              {
                Console.WriteLine($"{dino.Name} is a {dino.DietType}, weighing {dino.Weight} lbs living in Enclosure Number {dino.EnclosureNumber}. They were added on {dino.DateAcquired}");
              }
            }
            break;
          
          case "C":
            //Looks up how many carnivores there are and counts them.
            var carnivore = dinosaurs.Where(carnivore => carnivore.DietType == "Carnivore").Count();
            
            //Prints a special message depending on how many carnivores there are.
            if(carnivore > 1)
            {
              Console.WriteLine($"There are {carnivore} carnivores in this zoo.");
            }
            else if (carnivore == 1)
            {
              Console.WriteLine("There is only one carnivore in this zoo.");
            }
            else
            {
              Console.WriteLine("There are no carnivores in this zoo.");
            }
            break;
          
          case "H":
            //Looks up how many herbivores there are and counts them.
            var herbivore = dinosaurs.Where(herbivore => herbivore.DietType == "Herbivore").Count();
            
            //Prints a special message depending on how many carnivores there are.
            if(herbivore > 1)
            {
              Console.WriteLine($"There are {herbivore} herbivores in this zoo.");
            }
            else if (herbivore == 1)
            {
              Console.WriteLine("There is only one herbivore in this zoo.");
            }
            else
            {
              Console.WriteLine("There are no herbivores in this zoo.");
            }
            break;

          default:
            Console.WriteLine("I don't get what you're saying. Please go back and choose a valid response.");
            break;
        }
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
        Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer. If this is incorrect, please remove the dinosaur and re-add them.");
        return 0;
      }
    }
    static Dinosaur AddDinosaur(string prompt, List<Dinosaur> List)
    {
      var rightNow = DateTime.Now;
      var checkDinosaurs = List;
      var dinosaur = new Dinosaur();

      //I have the dinosaur list sent here for future code where it will double check if another dinosaur has the same name. Will also check to make sure the user inputs a C or H.
      dinosaur.Name = PromptForString(prompt);
      dinosaur.DietType = PromptForString("Are they a (C)arnivore or an (H)erbivore? ");
      dinosaur.DateAcquired = rightNow.ToString();
      dinosaur.Weight = PromptForInteger("How much does the dinosaur weigh (in lbs?) ");
      dinosaur.EnclosureNumber = PromptForInteger("Which enclosure number should they enter? ");

      return dinosaur;
    }
    static Dinosaur RemoveDinosaur(string prompt, List<Dinosaur> list)
    {
      var dinosaurs = list;

      Console.WriteLine(prompt);
      var name = Console.ReadLine().ToUpper();

      //Will look through list to find if what the user inputted matched a dinosaur name in the list
      Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);

      //If a dinosaur was found, will ask to confirm to delete and process accordingly
      if (foundDinosaur != null) 
      {
        Console.WriteLine($"{foundDinosaur.Name} was found in enclosure {foundDinosaur.EnclosureNumber}.");

        //Asks user to confirm dino for deletion    
        var confirm = PromptForString($"Are you sure you want to delete {foundDinosaur.Name}? (Y/N) ");
        //If user chooses yes, this will send the dinosaur back to main for deletion :(
        if (confirm == "Y")
        {
          Console.WriteLine($"Good-bye {foundDinosaur.Name}, we knew you well 🕯️ ");
          return foundDinosaur;
        }
        //Otherwise if user chooses no, this method won't send anything back.
        else if (confirm == "N")
        {
          Console.WriteLine($"You've saved {foundDinosaur.Name}. They will be spared from deletion.");
          return null;
        }
        //And if user inputted something wrong, the usual bad code exists here.
        else
        {
          Console.WriteLine("I don't get what you're saying. Please go back and choose a valid response.");
          return null;
        }
      }
      //Prints if no dinosaur was found and will return no value.
      else
      {
        Console.WriteLine("No dinosaur found 🙁 Please try again."); 
        return null;
      }
    }
    static Dinosaur TransferDinosaur(string prompt, List<Dinosaur> list)
    {
      var dinosaurs = list;

      Console.WriteLine(prompt);
      var name = Console.ReadLine().ToUpper();

      //Will look through list to find if what the user inputted matched a dinosaur name in the list
      Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);

      //If a dinosaur was found, will ask to confirm for transfer process
      if (foundDinosaur != null) 
      {
        Console.WriteLine($"{foundDinosaur.Name} was found in enclosure {foundDinosaur.EnclosureNumber}.");

        //Asks user to confirm dino for deletion    
        var confirm = PromptForString($"Are you sure you want to move {foundDinosaur.Name}? (Y/N) ");
        //If user chooses yes, this will send the dinosaur back to main for transfer
        if (confirm == "Y")
        {
          Console.WriteLine($"{foundDinosaur.Name} will move to a different pen in a bit.");
          return foundDinosaur;
        }
        //Otherwise if user chooses no, this method won't send anything back.
        else if (confirm == "N")
        {
          Console.WriteLine($"{foundDinosaur.Name} will stay in Enclosure {foundDinosaur.EnclosureNumber}.");
          return null;
        }
        //And if user inputted something wrong, the usual bad code exists here.
        else
        {
          Console.WriteLine("I don't get what you're saying. Please go back and choose a valid response.");
          return null;
        }
      }
      //Prints if no dinosaur was found and will return no value.
      else
      {
        Console.WriteLine("No dinosaur found 🙁 Please try again."); 
        return null;
      }
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
            //Sends a message to Description method to print out, and also sends the current dinosaurs list.
            Description("Would you like to see the dinosaur's by (N)ames or by (E)nclosure Numbers? ", dinosaurs);
            break;

          //Add 
          case "A":
            //Sends list of dinosaurs to check for repeat names, and also processes the user input for dino information, then adds it to the list if everything works out
            var dinosaur = AddDinosaur("What is the new dinosaur's name? ", dinosaurs);
            dinosaurs.Add(dinosaur);
            break;

          //Remove
          case "R":
            //Sends list of dinosaurs to then search and complete in remove method and return a dinosaur to be removed if necessary.
            var foundDinosaur = RemoveDinosaur("Please type in the name of the dinosaur you are looking for: ", dinosaurs);
            dinosaurs.Remove(foundDinosaur);
            break;

          //Transfer
          case "T":
            //Sends list to search for a dinosaur and returns said dinosaur for transfer, then asks user where to transfer to
            foundDinosaur = TransferDinosaur("Which dinosaur do you want to transfer? ", dinosaurs);
            
            var newEnclosure = PromptForInteger($"Where would you like to send {foundDinosaur.Name} to? ");
            //Adds new enclosure number to dinosaur from before.
            foundDinosaur.EnclosureNumber = newEnclosure;
            Console.WriteLine($"{foundDinosaur.Name} has been moved to Enclosure {foundDinosaur.EnclosureNumber}.");
            break;

          //Summary
          case "S":
            //Calls upon the Description method to show amount of each diet types
            Description("Would you like to see how many (C)arnivores or (H)erbivores there are? ", dinosaurs);
            break;

          //Quit
          case "Q":
            Console.WriteLine("Bye-bye! Come back again soon!");
            keepGoing = false;
            break;

          default:
            Console.WriteLine("I don't get what you're saying. Please go back and choose a valid response.");
            break;
        }
      }
    }
  }
}
