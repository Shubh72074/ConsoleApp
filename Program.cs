internal class Program
{
    private static void Main(string[] args)
    {
        int maxPets = 10;
        string[,] animals = new string[maxPets, 6];

        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";

        animals[0, 0] = "ID #: d1";
        animals[0, 1] = "Species: dog";
        animals[0, 2] = "Age: 8";
        animals[0, 3] = "Nickname: horu";
        animals[0, 4] = "Personality: loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
        animals[0, 5] = "Physical description: large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";

        animals[1, 0] = "ID #: d2";
        animals[1, 1] = "Species: dog";
        animals[1, 2] = "Age: 10";
        animals[1, 3] = "Nickname: hanko";
        animals[1, 4] = "Personality: loves to bark loud";
        animals[1, 5] = "Physical description: medium-sized black-and-white golden";

        animals[2, 0] = "ID #: c1";
        animals[2, 1] = "Species: cat";
        animals[2, 2] = "Age: 2";
        animals[2, 3] = "Nickname: kaiko";
        animals[2, 4] = "Personality: loves to play with toys and loves";
        animals[2, 5] = "Physical description: small black cat with long fur and white";

        string menuChoice = "";
        string readResponse = "";

        do
        {
            Console.WriteLine(@"Welcome to the Contoso PetFriends app. Your main menu options are:
  1. List all of our current pet information
  2. Add a new animal friend to the ourAnimals array
  3. Ensure animal ages and physical descriptions are complete
  4. Ensure animal nicknames and personality descriptions are complete
  5. Edit an animal's age
  6. Edit an animal's personality description
  7. Display all cats with a specified characteristic
  8. Display all dogs with a specified characteristic

  Enter your selection number (or type Exit to exit the program)");

            menuChoice = Console.ReadLine()!;

            switch (menuChoice)
            {
                case "1":
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (animals[i, 0] != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{animals[i, 0]}\n{animals[i, 1]}\n{animals[i, 2]}\n{animals[i, 3]}\n{animals[i, 4]}\n{animals[i, 5]}");
                        }
                    }
                    Console.WriteLine("Press the Enter key to continue.");
                    readResponse = Console.ReadLine()!;
                    break;

                case "2":
                    string anotherPet = "y";
                    int petCount = 0;
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (animals[i, 0] != null)
                        {
                            petCount++;
                        }
                    }
                    if (petCount < maxPets)
                    {
                        Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {maxPets - petCount} more.");
                    }
                    // get species (cat or dog) - string animalSpecies is a required field 

                    while (anotherPet == "y" && petCount < maxPets)
                    {
                        bool validEntry = false;
                        do
                        {
                            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                            readResponse = Console.ReadLine()!;
                            if (readResponse != null)
                            {
                                animalSpecies = readResponse.ToLower();
                                if (animalSpecies != "dog" && animalSpecies != "cat")
                                {
                                    //Console.WriteLine($"You entered: {animalSpecies}.");
                                    validEntry = false;
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);
                        // build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                        animalID = string.Concat(animalSpecies.AsSpan(0, 1), (petCount + 1).ToString());
                        // get the pet's age. can be ? at initial entry.
                        do
                        {
                            int petAge;
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            readResponse = Console.ReadLine()!;
                            if (readResponse != null)
                            {
                                animalAge = readResponse;
                                if (animalAge != "?")
                                {
                                    validEntry = int.TryParse(animalAge, out petAge);
                                }
                                else
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);
                        // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                        do
                        {
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResponse = Console.ReadLine()!;
                            if (readResponse != null)
                            {
                                animalPhysicalDescription = readResponse.ToLower();
                                if (animalPhysicalDescription == "")
                                {
                                    animalPhysicalDescription = "tbd";
                                }
                            }
                        } while (animalPhysicalDescription == "");
                        // get a description of the pet's personality - animalPersonalityDescription can be blank.
                        do
                        {
                            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                            readResponse = Console.ReadLine()!;
                            if (readResponse != null)
                            {
                                animalPersonalityDescription = readResponse.ToLower();
                                if (animalPersonalityDescription == "")
                                {
                                    animalPersonalityDescription = "tbd";
                                }
                            }
                        } while (animalPersonalityDescription == "");
                        // get the pet's nickname. animalNickname can be blank.
                        do
                        {
                            Console.WriteLine("Enter a nickname for the pet");
                            readResponse = Console.ReadLine()!;
                            if (readResponse != null)
                            {
                                animalNickname = readResponse.ToLower();
                                if (animalNickname == "")
                                {
                                    animalNickname = "tbd";
                                }
                            }
                        } while (animalNickname == "");

                        // store the pet information in the ourAnimals array (zero based)
                        animals[petCount, 0] = "ID #: " + animalID;
                        animals[petCount, 1] = "Species: " + animalSpecies;
                        animals[petCount, 2] = "Age: " + animalAge;
                        animals[petCount, 3] = "Nickname: " + animalNickname;
                        animals[petCount, 4] = "Personality: " + animalPhysicalDescription;
                        animals[petCount, 5] = "Physical description: " + animalPersonalityDescription;
                        petCount++;

                        if (petCount < maxPets)
                        {
                            Console.WriteLine("Do you want to add a new pet? (y/n)");
                            do
                            {
                                readResponse = Console.ReadLine()!;
                                if (readResponse != null)
                                {
                                    anotherPet = readResponse.ToLower();
                                }
                            } while (anotherPet != "y" && anotherPet != "n");

                        }
                    }
                    if (petCount >= maxPets)
                    {
                        Console.WriteLine("We can't add any more pets. We have reached the maximum limit of pet homes.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResponse = Console.ReadLine()!;
                    }
                    break;

                case "3":
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (animals[i, 0] != null)
                        {
                            if (animals[i, 2].Contains('?'))
                            {
                                do
                                {
                                    Console.WriteLine($"Enter the pet's age for ID<{animals[i, 0]}> :");
                                    readResponse = Console.ReadLine()!;
                                    if (readResponse != null)
                                    {
                                        if (int.TryParse(readResponse, out int petAge))
                                        {
                                            animalAge = "Age: " + petAge.ToString();
                                            animals[i, 2] = animalAge;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Invalid input. Please enter a proper age for ID<{animals[i, 0]}>");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a proper age for ID<{animals[i, 0]}>");
                                    }
                                } while (animals[i, 2] == "?");
                            }
                            if (animals[i, 5].Contains("tbd"))
                            {
                                do
                                {
                                    Console.WriteLine($"Enter the pet's Physical Desciption (size, color, breed, gender, weight, housebroken) for ID<{animals[i, 0]}> :");
                                    readResponse = Console.ReadLine()!;
                                    if (readResponse != null)
                                    {
                                        animalPhysicalDescription = "Physical description: " + readResponse.ToLower();
                                        animals[i, 5] = animalPhysicalDescription;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a proper Description for ID<{animals[i, 0]}>");
                                    }
                                } while (animals[i, 5].Contains("tbd"));
                            }
                        }
                    }
                    Console.WriteLine("Press the Enter key to continue.");
                    readResponse = Console.ReadLine()!;
                    break;

                case "4":
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (animals[i, 0] != null)
                        {
                            if (animals[i, 3].Contains("tbd"))
                            {
                                do
                                {
                                    Console.WriteLine($"Enter the pet's NickName for ID<{animals[i, 0]}> :");
                                    readResponse = Console.ReadLine()!;
                                    if (readResponse != null)
                                    {
                                        animalNickname = "Nickname: " + readResponse.ToLower();
                                        animals[i, 3] = animalNickname;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a proper NickName for ID<{animals[i, 0]}>");
                                    }
                                } while (animals[i, 3].Contains("tbd"));
                            }
                            if (animals[i, 4].Contains("tbd"))
                            {
                                do
                                {
                                    Console.WriteLine($"Enter the pet's Personality Description (likes or dislikes, tricks, energy level) for ID<{animals[i, 0]}> :");
                                    readResponse = Console.ReadLine()!;
                                    if (readResponse != null)
                                    {
                                        animalPersonalityDescription = "Personality: " + readResponse.ToLower();
                                        animals[i, 3] = animalPersonalityDescription;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a proper Description for ID<{animals[i, 0]}>");
                                    }
                                } while (animals[i, 4].Contains("tbd"));
                            }
                        }
                    }
                    Console.WriteLine("Challenge Project - please check back soon to see progress.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResponse = Console.ReadLine()!;
                    break;

                case "5":
                    Console.WriteLine("Enter the pet ID you want to update age for:");
                    readResponse = Console.ReadLine()!;
                    if (readResponse != null)
                    {
                        if (!readResponse.ToLower().Equals(""))
                        {
                            for (int i = 0; i < maxPets; i++)
                            {
                                if (animals[i, 0] != null && animals[i, 0].Contains("ID #: " + readResponse!.ToLower()))
                                {
                                    bool validEntry = false;
                                    do
                                    {
                                        Console.WriteLine($"Enter the pet's age for ID<{animals[i, 0]}> :");
                                        readResponse = Console.ReadLine()!;
                                        if (readResponse != null)
                                        {
                                            if (int.TryParse(readResponse, out int petAge))
                                            {
                                                animalAge = "Age: " + petAge.ToString();
                                                animals[i, 2] = animalAge;
                                                validEntry = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Invalid input. Please enter a proper age for ID<{animals[i, 0]}>");
                                            }
                                        }
                                    } while (validEntry == false);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid pet ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid pet ID.");
                    }
                    Console.WriteLine("Press the Enter key to continue.");
                    readResponse = Console.ReadLine()!;
                    break;

                case "6":
                    Console.WriteLine("Enter the pet ID you want to update the personality description for:");
                    readResponse = Console.ReadLine()!;
                    if (readResponse != null)
                    {
                        if (!readResponse.ToLower().Equals(""))
                        {
                            for (int i = 0; i < maxPets; i++)
                            {
                                if (animals[i, 0] != null && animals[i, 0].Contains("ID #: " + readResponse!.ToLower()))
                                {
                                    bool validEntry = false;
                                    do
                                    {
                                        Console.WriteLine($"Enter the pet's Personality Description (likes or dislikes, tricks, energy level) for ID<{animals[i, 0]}> :");
                                        readResponse = Console.ReadLine()!;
                                        if (readResponse != null)
                                        {
                                            animalPersonalityDescription = "Personality: " + readResponse.ToLower();
                                            animals[i, 4] = animalPersonalityDescription;
                                            validEntry = true;
                                        }
                                    } while (validEntry == false);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid pet ID.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid pet ID.");
                        }
                    }
                    Console.WriteLine("Press the Enter key to continue.");
                    readResponse = Console.ReadLine()!;
                    break;

                case "7":
                    Console.WriteLine("Enter a characteristic to search for <Cats>:");
                    readResponse = Console.ReadLine()!;
                    if (readResponse != null)
                    {
                        Console.WriteLine("Search Results:");
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (animals[i, 0] != null && animals[i, 1] == "Species: cat")
                            {
                                if (animals[i, 2].Contains(readResponse) || animals[i, 3].Contains(readResponse) || animals[i, 4].Contains(readResponse) || animals[i, 5].Contains(readResponse))
                                {
                                    Console.WriteLine($"{animals[i, 0]}\n{animals[i, 1]}\n{animals[i, 2]}\n{animals[i, 3]}\n{animals[i, 4]}\n{animals[i, 5]}");
                                }
                            }
                        }
                    }
                    Console.WriteLine("Press the Enter key to continue.");
                    readResponse = Console.ReadLine()!;
                    break;

                case "8":
                    Console.WriteLine("Enter a characteristic to search for <Dogs>:");
                    readResponse = Console.ReadLine()!;
                    if (readResponse != null)
                    {
                        Console.WriteLine("Search Results:");
                        for (int i = 0; i < maxPets; i++)
                        {
                            if (animals[i, 0] != null && animals[i, 1] == "Species: dog")
                            {
                                if (animals[i, 2].Contains(readResponse) || animals[i, 3].Contains(readResponse) || animals[i, 4].Contains(readResponse) || animals[i, 5].Contains(readResponse))
                                {
                                    Console.WriteLine($"{animals[i, 0]}\n{animals[i, 1]}\n{animals[i, 2]}\n{animals[i, 3]}\n{animals[i, 4]}\n{animals[i, 5]}");
                                }
                            }
                        }
                    }
                    Console.WriteLine("Press the Enter key to continue.");
                    readResponse = Console.ReadLine()!;
                    break;
                default:
                    break;

            }

        } while (menuChoice != "q");
    }
}