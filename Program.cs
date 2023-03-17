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
            Console.WriteLine();
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
            response = PromptForString("\nWould you like to see (A)ll dinosaurs by their Enclosure Number or see all dinosaurs in (O)ne Enclosure Number? ");
            
            if(response.ToUpper() == "A")
            {
              //Sorts the dinosaurs by their enclosure numbers first, then prints out the list.
              var numericalOrder = dinosaurs.OrderBy(dino => dino.EnclosureNumber);
              Console.WriteLine();
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
            }
            else if(response.ToUpper() == "O")
            {
              //Requests user for which enclosure they want to see, and looks for it.
              var number = PromptForInteger("\nWhich Enclosure Number would you like to view? ");
              var enclosureRequested = dinosaurs.Where(dino => dino.EnclosureNumber == number);

              //If enclosureRequested finds any dinosaurs, then it will print them out. 
              if (enclosureRequested.Count() > 0)
              {
                Console.WriteLine($"\nYou've chosen to see Enclosure {number}.");
                foreach (var dino in enclosureRequested)
                {
                  Console.WriteLine($"The {dino.Name} is a {dino.DietType}, weighing {dino.Weight} lbs.");
                }
                if (enclosureRequested.Count() > 1)
                {
                  Console.WriteLine("I hope they're all getting along!");
                }
              }
              //If it doesn't find anything. It will print this statement.
              else
              {
                Console.WriteLine($"\nThere is no Enclosure Number {number}, please try again.");
              }
            }  
            break;
          
          case "D":
            //Will ask user for what dates they are looking for. Then print out the dinosaurs accordingly.
            Console.WriteLine("\nYou have chosen to see a certain date.");
            break;

          case "C":
            //Looks up how many carnivores there are and counts them.
            var carnivore = dinosaurs.Where(carnivore => carnivore.DietType == "Carnivore");
            Console.WriteLine();
            //Prints a special message depending on how many carnivores there are.
            if(carnivore.Count() > 1)
            {
              Console.WriteLine($"There are {carnivore.Count()} carnivores in this zoo.");
              //Prints the list of each carnivore if asked
              foreach(var dino in carnivore)
              {
                Console.WriteLine($"The {dino.Name} is a Carnivore weighing {dino.Weight} lbs living in Enclosure Number {dino.EnclosureNumber}.");
              }
            }
            else if (carnivore.Count() == 1)
            {
              foreach(var dino in carnivore)
              {
                Console.WriteLine($"There is only one carnivore in this zoo, the {dino.Name} living in Enclosure Number {dino.EnclosureNumber}.");
              }
            }
            else
            {
              Console.WriteLine("There are no carnivores in this zoo.");
            }
            break;
          
          case "H":
            //Looks up how many herbivores there are and counts them.
            var herbivore = dinosaurs.Where(herbivore => herbivore.DietType == "Herbivore");
            Console.WriteLine();
            //Prints a special message depending on how many carnivores there are.
            if(herbivore.Count() > 1)
            {
              Console.WriteLine($"There are {herbivore.Count()} carnivores in this zoo.");
              //Prints the list of each herbivore if asked
              foreach(var dino in herbivore)
              {
                Console.WriteLine($"The {dino.Name} is a Herbivore weighing {dino.Weight} lbs living in Enclosure Number {dino.EnclosureNumber}.");
              }
            }
            else if (herbivore.Count() == 1)
            {
              foreach(var dino in herbivore)
              {
                Console.WriteLine($"There is only one herbivore in this zoo, the {dino.Name} living in Enclosure Number {dino.EnclosureNumber}.");
              }
            }
            else
            {
              Console.WriteLine("There are no herbivores in this zoo.");
            }
            break;

          default:
            Console.WriteLine("\nI don't get what you're saying. Please go back and choose a valid response.");
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

      Console.Write(prompt);
      var name = Console.ReadLine().ToUpper();

      //First checks if the dinosaur the user is adding has been added before
      Dinosaur foundDinosaur = checkDinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);

      //If no matching dinosaur is found, it will continue like normal adding into the database
      if (foundDinosaur == null)
      {
        dinosaur.Name = name;
      }
      //If another dinosaur with the same name is found, it will prompt the user to confirm if they are sure they want to add and adjusts accordingly.
      else
      {
        var confirm = PromptForString($"\nLooks like another dinosaur had the name {foundDinosaur.Name}, are you sure you want to add? (Y/N) ");
        //If user chooses yes, this will send the dinosaur back to main for deletion :(
        if (confirm == "Y")
        {
          Console.WriteLine($"\nYou've chosen to replicate this dino.");
          dinosaur.Name = name;
        }
        //Otherwise if user chooses no, this method won't send anything back.
        else if (confirm == "N")
        {
          Console.WriteLine($"\nYou've chosen NOT to replicate this dino.");
          return null;
        }
        //And if user inputted something wrong, the usual bad code exists here.
        else
        {
          Console.WriteLine("\nI don't get what you're saying. Please go back and choose a valid response.");
          return null;
        }
      }
        //Continues process of adding, now makes sure the user inputs a correct data type for diet
        var correctDietType = false;
        while (correctDietType == false)
        {
          var diet = PromptForString("\nAre they a (C)arnivore or an (H)erbivore? ");

          if(diet == "Carnivore")
          {
            dinosaur.DietType = diet;
            correctDietType = true;
          }
          else if(diet == "Herbivore")
          {
            dinosaur.DietType = diet;
            correctDietType = true;
          }
          else
          {
            Console.WriteLine("Not a valid diet type. Please try again.");  
          }
        }

        dinosaur.DateAcquired = rightNow.ToString();
        dinosaur.Weight = PromptForInteger("How much does the dinosaur weigh (in lbs?) ");
        dinosaur.EnclosureNumber = PromptForInteger("Which enclosure number should they enter? ");
        
        return dinosaur;
    }
    static Dinosaur RemoveDinosaur(string prompt, List<Dinosaur> list)
    {
      var dinosaurs = list;

      Console.Write(prompt);
      var name = Console.ReadLine().ToUpper();

      //Will look through list to find if what the user inputted matched a dinosaur name in the list
      Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);
      //Will look through and add any dinosaurs with the same name to a list keep track of a count for later.
      var sameDinosaurs = dinosaurs.Where(dinosaur => dinosaur.Name == name).ToList();

      //If a dinosaur was found, will ask to confirm which dinosaur to delete and process accordingly
      if (foundDinosaur != null) 
      {
        //Prints out a list of the dinosaurs with the same name, otherwise continues with deleting a solo dinosaur
        if(sameDinosaurs.Count() > 1)
        {
          Console.WriteLine("\nThere are multiple dinosaurs with that name: ");
          
          for(var count = 0; count < sameDinosaurs.Count(); count++)
          {
            var dino = sameDinosaurs[count];
            Console.WriteLine($"{count}: {dino.Name} weighing {dino.Weight} lbs living in Enclosure Number {dino.EnclosureNumber}. They were added on {dino.DateAcquired}");
          }
          
          foundDinosaur = sameDinosaurs[PromptForInteger("Which dinosaur did you want to choose? Please enter their corresponding number: ")];
        }
        
        //If no other duplicate dinosaurs are found code continues with deleting process
        Console.WriteLine($"\n{foundDinosaur.Name} was found in enclosure {foundDinosaur.EnclosureNumber}.");

        //Asks user to confirm dino for deletion    
        var confirm = PromptForString($"Are you sure you want to delete {foundDinosaur.Name}? (Y/N) ");
        //If user chooses yes, this will send the dinosaur back to main for deletion :(
        if (confirm == "Y")
        {
          Console.WriteLine($"\nGood-bye {foundDinosaur.Name}, we knew you well 🕯️ ");
          return foundDinosaur;
        }
        //Otherwise if user chooses no, this method won't send anything back.
        else if (confirm == "N")
        {
          Console.WriteLine($"\nYou've saved {foundDinosaur.Name}. They will be spared from deletion.");
          return null;
        }
        //And if user inputted something wrong, the usual bad code exists here.
        else
        {
          Console.WriteLine("\nI don't get what you're saying. Please go back and choose a valid response.");
          return null;
        }
      }
      //Prints if no dinosaur was found and will return no value.
      else
      {
        Console.WriteLine("\nNo dinosaur found 🙁 Please try again."); 
        return null;
      }
    }
    static Dinosaur TransferDinosaur(string prompt, List<Dinosaur> list)
    {
      var dinosaurs = list;

      Console.Write(prompt);
      var name = Console.ReadLine().ToUpper();

      //Will look through list to find if what the user inputted matched a dinosaur name in the list
      Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);
      //Will look through and add any dinosaurs with the same name to a list keep track of a count for later.
      var sameDinosaurs = dinosaurs.Where(dinosaur => dinosaur.Name == name).ToList();

      //If a dinosaur was found, will ask to confirm for transfer process
      if (foundDinosaur != null) 
      {
        //Prints out a list of the dinosaurs with the same name, otherwise continues with deleting a solo dinosaur
        if(sameDinosaurs.Count() > 1)
        {
          Console.WriteLine("\nThere are multiple dinosaurs with that name: ");
          
          for(var count = 0; count < sameDinosaurs.Count(); count++)
          {
            var dino = sameDinosaurs[count];
            Console.WriteLine($"{count}: {dino.Name} weighing {dino.Weight} lbs living in Enclosure Number {dino.EnclosureNumber}. They were added on {dino.DateAcquired}");
          }
          
          foundDinosaur = sameDinosaurs[PromptForInteger("Which dinosaur did you want to choose? Please enter their corresponding number: ")];
        }
        
        Console.WriteLine($"\n{foundDinosaur.Name} was found in enclosure {foundDinosaur.EnclosureNumber}.");

        //Asks user to confirm dino for deletion    
        var confirm = PromptForString($"Are you sure you want to move {foundDinosaur.Name}? (Y/N) ");
        //If user chooses yes, this will send the dinosaur back to main for transfer
        if (confirm == "Y")
        {
          var newEnclosure = PromptForInteger($"\nWhich enclosure would you like to send {foundDinosaur.Name} to? ");
          foundDinosaur.EnclosureNumber = newEnclosure;
          Console.WriteLine($"{foundDinosaur.Name} has been moved to Enclosure {foundDinosaur.EnclosureNumber}.");
          return foundDinosaur;
        }
        //Otherwise if user chooses no, this method won't send anything back.
        else if (confirm == "N")
        {
          Console.WriteLine($"\n{foundDinosaur.Name} will stay in Enclosure {foundDinosaur.EnclosureNumber}.");
          return null;
        }
        //And if user inputted something wrong, the usual bad code exists here.
        else
        {
          Console.WriteLine("\nI don't get what you're saying. Please go back and choose a valid response.");
          return null;
        }
      }
      //Prints if no dinosaur was found and will return no value.
      else
      {
        Console.WriteLine("\nNo dinosaur found 🙁 Please try again."); 
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
        
        new Dinosaur()
          {
            Name = "LONG NECK",
            DietType = "Herbivore",
            DateAcquired = rightNow.ToString(),
            Weight = 500,
            EnclosureNumber = 3
          },

        new Dinosaur()
          {
            Name = "LONG NECK",
            DietType = "Herbivore",
            DateAcquired = rightNow.ToString(),
            Weight = 750,
            EnclosureNumber = 7
          },
      };

      Console.WriteLine("\n  🦕 Welcome to my dinosaur zoo! 🦖");
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
            Description("\nWould you like to see the dinosaur's by (N)ames, (E)nclosure Numbers, or dinosaurs added after a certain (D)ate? ", dinosaurs);
            break;

          //Add 
          case "A":
            //Sends list of dinosaurs to check for repeat names, and also processes the user input for dino information, then adds it to the list if everything works out
            var dinosaur = AddDinosaur("\nWhat is the new dinosaur's name? ", dinosaurs);
            dinosaurs.Add(dinosaur);
            break;

          //Remove
          case "R":
            //Sends list of dinosaurs to then search and complete in remove method and return a dinosaur to be removed if necessary.
            var foundDinosaur = RemoveDinosaur("\nPlease type in the name of the dinosaur you are looking for: ", dinosaurs);
            dinosaurs.Remove(foundDinosaur);
            break;

          //Transfer
          case "T":
            //Sends list to search for a dinosaur and returns said dinosaur for transfer, then asks user where to transfer to
            foundDinosaur = TransferDinosaur("\nWhich dinosaur do you want to transfer? ", dinosaurs);
            break;

          //Summary
          case "S":
            //Calls upon the Description method to show amount of each diet types
            Description("\nWould you like to see how many (C)arnivores or (H)erbivores there are?", dinosaurs);
            break;

          //Quit
          case "Q":
            Console.WriteLine("\nBye-bye! Come back again soon!");
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
