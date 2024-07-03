using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Final_Project_API
{
    class Program
    {
        #region HTTP Links
        private const string gamesApiUrl = "https://zelda.fanapis.com/api/games";
        private const string charactersApiUrl = "https://zelda.fanapis.com/api/characters";
        private const string monstersApiUrl = "https://zelda.fanapis.com/api/monsters";
        private const string bossesApiUrl = "https://zelda.fanapis.com/api/bosses";
        private const string dungeonsApiUrl = "https://zelda.fanapis.com/api/dungeons";
        private const string placesApiUrl = "https://zelda.fanapis.com/api/places";
        private const string itemsApiUrl = "https://zelda.fanapis.com/api/items";
        private static WaveOutEvent outputDevice;
        private static readonly HttpClient client = new HttpClient();
        #endregion   
        static async Task Main(string[] args)
        {
            CrestGraphic.DisplayLegendOfZelda();
            string introAudioFilePath = @"C:\Users\Scooo\OneDrive\Desktop\TP_WiiIntro.wav";
            PlayAudio(introAudioFilePath);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Legend of Zelda Encyclopedia!");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("\nWhat do you want to learn about?");
                Console.WriteLine();
                Console.WriteLine("1. Games");
                Console.WriteLine("2. Characters");
                Console.WriteLine("3. Monsters");
                Console.WriteLine("4. Bosses");
                Console.WriteLine("5. Dungeons");
                Console.WriteLine("6. Places");
                Console.WriteLine("7. Items");
                Console.WriteLine();
                Console.WriteLine("Type 'exit' to quit.");

                string input = Console.ReadLine().Trim(); // Trim whitespace from user input

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting program...");
                    return;
                }

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 7)
                {
                    switch (choice)
                    {
                        case 1:
                            
                            PlayGamesSound.PlayGamesSound1();
                            await DisplayGames();
                            Console.Clear();
                            break;
                        case 2:
                            CharactersSound.PlayCharactersSound();
                            await DisplayCharacters();
                            break;
                        case 3:
                            MonstersSound.PlayMonstersSound();
                            await DisplayMonsters();
                            break;
                        case 4:
                            BossesSound.PlayBossesSound();
                            await DisplayBosses();
                            break;
                        case 5:
                            DungeonsSound.PlayDungeonsSound();
                            await DisplayDungeons();
                            break;
                        case 6:
                            PlacesSound.PlayPlacesSound();
                            await DisplayPlaces();
                            break;
                        case 7:
                            ItemsSound.PlayItemsSound();
                            await DisplayItems();
                            break;
                    }

                    Console.Clear(); // Clear the console after displaying category details
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 7, or 'exit' to quit.");
                }
            }
        }
        private static void PlayAudio(string filePath)
        {
            try
            {
                if (outputDevice != null && outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    outputDevice.Stop();
                    outputDevice.Dispose();
                }

                outputDevice = new WaveOutEvent();
                var audioFile = new AudioFileReader(filePath);
                outputDevice.Init(audioFile);
                outputDevice.Play();

                // Wait for audio to finish playing before proceeding
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Task.Delay(100).Wait();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to play audio: {ex.Message}");
            }
        }
        static async Task DisplayGames()
        {
            var AdditionalGamesSkywardSword = new AdditionalGames
            {

                Name = "The Legend Of Zelda : Skyward Sword",
                Description = "The Legend of Zelda: Skyward Sword[b] is a 2011 action-adventure game developed and published by Nintendo for the Wii. A high-definition remaster of the game, The Legend of Zelda: Skyward Sword HD, was co-developed by Tantalus Media and released for the Nintendo Switch in July 2021.Taking the role of series protagonist Link, players navigate the floating island of Skyloft and the land below it, completing quests that advance the story and solving environmental and dungeon-based puzzles. The mechanics and combat, the latter focusing on attacking and blocking with sword and shield, are reliant on the Wii MotionPlus peripheral. A mainline entry in The Legend of Zelda series, Skyward Sword is the first game in the Zelda timeline, and details the origins of the Master Sword (created from the Goddess Sword), a recurring weapon within the series. Link, a resident of a floating town called Skyloft, sets out to rescue his childhood friend Zelda after she is kidnapped and brought to the surface, the abandoned lands below the clouds. Development took around five years, beginning after the release of Twilight Princess in 2006. Multiple earlier Zelda games influenced the developers, including Twilight Princess, Ocarina of Time and Majora's Mask. Many aspects of the game's overworld and gameplay were designed to streamline and populate the experience for players. The art style was influenced by the work of impressionist and post-impressionist painters, including Paul Cézanne. The implementation of Wii MotionPlus proved problematic for the developers, to the point where it was nearly discarded. It was the first Zelda game to use a live orchestra for the majority of its tracks, with music composed by a team led by Hajime Wakai and supervised by Koji Kondo. Announced in 2009, Skyward Sword was planned for release in 2010 but was delayed to November 2011 to further refine and expand it. It was a critical and commercial success, receiving perfect scores from multiple journalistic sites, winning and receiving nominations for numerous industry and journalist awards, and selling over three million copies worldwide. The 2021 remaster sold over 4 million worldwide on the Nintendo Switch. Feedback on the game later influenced the development of the next entry for home consoles, Breath of the Wild."


            };
            var AdditionalGamesTOTK = new AdditionalGames
            {
                Name = "The Legend Of Zelda : Tears Of The Kingdom",
                Description = "The Legend of Zelda: Tears of the Kingdom[b] is a 2023 action-adventure game developed and published by Nintendo for the Nintendo Switch. The player controls Link as he searches for Princess Zelda and fights to prevent Ganondorf from destroying Hyrule. Tears of the Kingdom retains the open-world gameplay and setting of its predecessor, Breath of the Wild (2017), and features new environments including the Sky, an area composed of floating islands, and an expansive cavern beneath Hyrule known as the Depths. The player has access to various devices that aid combat or exploration, and which can be used to construct vehicles."
            };
            var AdditionalGamesEchosOfWisdom = new AdditionalGames
            { 
            
                Name = "The Legend Of Zelda : Echos Of Wisdom",
                Description = "Coming soon! Releases 9/24/2024"
            
            };
            var AdditionalGamesOracleOfAges = new AdditionalGames
            {
                Name = "The Legend Of Zeld : Oracle Of Ages",
                Description = "The Legend of Zelda: Oracle of Seasons and The Legend of Zelda: Oracle of Ages are 2001 action-adventure games in the Legend of Zelda series. They were developed by Flagship (a subsidiary of Capcom) and published by Nintendo for the Game Boy Color.The player controls Link from an overhead perspective. In Seasons, the Triforce transports Link to the land of Holodrum, where he sees Onox kidnap Din, the Oracle of Seasons. In Ages, the Triforce transports Link to Labrynna, where Veran possesses Nayru. The main plot is revealed once the player finishes both games. Link is armed with a sword and shield as well as a variety of secondary weapons and items for battling enemies and solving puzzles. The central items are the Rod of Seasons, which controls the seasons in Holodrum, and the Harp of Ages, which lets Link travel through time in Labrynna. Before he can infiltrate Onox's castle and Veran's tower, Link must collect the eight Essences of Nature and the eight Essences of Time, which are hidden in dungeons and guarded by bosses."

            };
            var AdditionalGamesPhantomHourGlass = new AdditionalGames
            {   
                Name = "The Legend Of Zelda : Phantom Hourglass",
                Description = "The Legend of Zelda: Phantom Hourglass is a 2007 action-adventure game developed and published by Nintendo for the Nintendo DS handheld game console. It is the fourteenth installment in The Legend of Zelda series and the direct sequel to the 2002 GameCube title The Wind Waker. Phantom Hourglass was released worldwide in 2007, with the exception of South Korea in April 2008. The game was re-released for the Wii U via the Virtual Console service in the PAL region in November 2015, in North America in May 2016, and in Japan in August."


            };
            var AdditionalGamesALinkBetweenWorlds = new AdditionalGames
            {
                Name = "The Legend Of Zelda : A Link Between Worlds",
                Description = "The Legend of Zelda: A Link Between Worlds is a 2013 action-adventure game developed and published by Nintendo for the Nintendo 3DS. The game is the 17th in The Legend of Zelda series and is a sequel to the 1991 title The Legend of Zelda: A Link to the Past. Announced in April 2013, A Link Between Worlds was released in Australia, Europe, and North America in November, and in Japan a month later."

            };
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                MajorasMaskArt.MaskArt(); // Display Majora's Mask graphic in red

                Console.ForegroundColor = ConsoleColor.Green; // Set console color back to green
                var games = await GetGamesFromApi(gamesApiUrl);

                if (games != null)
                {
                    var filteredGames = games.data.Where(game =>
                !game.name.Contains("Zelda: The Wand of Gamelon", StringComparison.OrdinalIgnoreCase) &&
                !game.name.Contains("Hyrule Warriors", StringComparison.OrdinalIgnoreCase) &&
                !game.name.Contains("BS The Legend of Zelda: Ancient Stone Tablets", StringComparison.OrdinalIgnoreCase)
                 ).ToList();
                    // Create a list to hold all games (API and additional)
                    var mergedGames = new List<object>();

                    // Add API games to the merged list
                    mergedGames.AddRange(filteredGames);

                    // Add additional game (TOTK) to the end of the merged list
                    mergedGames.Add(AdditionalGamesALinkBetweenWorlds);
                    mergedGames.Add(AdditionalGamesPhantomHourGlass);
                    mergedGames.Add(AdditionalGamesOracleOfAges);
                    mergedGames.Add(AdditionalGamesTOTK);
                    mergedGames.Add(AdditionalGamesSkywardSword);
                    mergedGames.Add(AdditionalGamesEchosOfWisdom);

                    while (true)
                    {
                        Console.Clear(); // Clear the console screen

                        Console.WriteLine("List of Legend of Zelda Games:\n");

                        for (int i = 0; i < mergedGames.Count; i++)
                        {
                            if (mergedGames[i] is GamesDatum apiGame)
                            {
                                Console.WriteLine($"{i + 1}. {apiGame.name} ");
                            }
                            else if (mergedGames[i] is AdditionalGames additionalGame)
                            {
                                Console.WriteLine($"{i + 1}. {additionalGame.Name} ");
                            }
                        }

                        Console.WriteLine("\nEnter the number of the game you want to learn about (or type 'back' to go back):");

                        string input = Console.ReadLine().Trim().ToLower();

                        if (input == "back")
                        {
                            return; // Return to main menu if user types 'back'
                        }

                        if (int.TryParse(input, out int index) && index > 0 && index <= mergedGames.Count)
                        {
                            int selectedIndex = index - 1;

                            Console.Clear(); // Clear the console screen

                            // Handle selected game
                            if (mergedGames[selectedIndex] is GamesDatum apiGame)
                            {
                                Console.WriteLine($"Name: {apiGame.name}");
                                Console.WriteLine($"Description: {apiGame.description}");
                                Console.WriteLine($"Developer: {apiGame.developer}");
                                Console.WriteLine($"Publisher: {apiGame.publisher}");
                                Console.WriteLine($"Released Date: {apiGame.released_date}");

                            }
                            else if (mergedGames[selectedIndex] is AdditionalGames additionalGame)
                            {
                                // Display additional game details
                                Console.WriteLine($"Name: {additionalGame.Name}");
                                Console.WriteLine($"Description: {additionalGame.Description}");
                            }

                            Console.WriteLine("\nPress 'g' to go back to the list of games or 'm' to return to the main menu:");

                            while (true)
                            {
                                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                                if (keyInfo.KeyChar == 'g')
                                {
                                    break; // Break the inner loop to return to the list of games
                                }
                                else if (keyInfo.KeyChar == 'm')
                                {
                                    return; // Return to main menu if 'm' is pressed
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Press 'g' to go back to the list of games or 'm' to return to the main menu:");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid game number or 'back' to go back:");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed to retrieve game data.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static async Task DisplayCharacters()
        {
            // Define additional characters
            var AdditionalCharactersLink = new AdditionalCharacters
            {
                Name = "Link",
                Description = "Link is the main character and protagonist of The Legend of Zelda series. He has appeared across many incarnations throughout the series, depicted as an ordinary boy or young man who becomes a legendary hero by saving the world through feats of courage. He is often the holder of the Triforce of Courage, a sign of his being chosen by the Golden Goddesses. Link is almost always seen wielding a sword and shield, most often the Master Sword and Hylian Shield.",
                
                
            };

            var AdditionalCharactersZelda = new AdditionalCharacters
            {
                Name = "Princess Zelda",
                Description = "Princess Zelda is a character in Nintendo's The Legend of Zelda video game series. She was created by Shigeru Miyamoto for the original 1986 game The Legend of Zelda. As one of the central characters in the series, she has appeared in the majority of the games in various incarnations. Zelda is the elf-like Hylian princess of the kingdom of Hyrule, an associate of the series protagonist Link, and bearer of the Triforce of Wisdom.",
                
             
          
            };
            var AdditionalCharactersMidna = new AdditionalCharacters
            {
                Name = "Midna",
                Description = "Midna is a fictional character in Nintendo's The Legend of Zelda series, introduced as one of the main protagonists in Twilight Princess. She is a member of the magic-wielding Twili who joins forces with Link to prevent the kingdom of Hyrule from being enveloped by a corrupted parallel dimension known as the Twilight Realm. While Midna appears as an imp-like creature in the majority of Twilight Princess, her actual form is humanoid. She was designed by Yusuke Nakano and voiced by Akiko Kōmoto. Midna also appears as a playable character in Hyrule Warriors, and makes minor appearances in the Super Smash Bros. series."

            };
            var AdditionalCharactersGanon = new AdditionalCharacters
            {
                Name = "Ganon",
                Description = "Ganon is a character and the main antagonist of Nintendo's The Legend of Zelda video game series and franchise, as well as the final boss in many Zelda titles. In his humanoid Gerudo form, he is known as Ganondorf.[b] A massive and malevolent pig-like creature, Ganon first appeared in the original The Legend of Zelda game in 1986, while his alter ego, Ganondorf, was introduced in Ocarina of Time. He has since appeared in the majority of the games in the series in various forms. He is the archenemy of the protagonist Link and Princess Zelda of Hyrule and originally the leader of the Gerudo, a race of humanoid desert nomads before becoming the ruler of his demon army."


            };
            while (true)
            {
                try
                {
                    Console.Clear(); // Clear the console screen
                    var characters = await GetCharactersFromApi(charactersApiUrl);

                    if (characters != null)
                    {
                        // Merge API characters with additional characters (Link and Zelda)
                        var mergedCharacters = new List<object>();
                        mergedCharacters.Add(AdditionalCharactersLink);
                        mergedCharacters.Add(AdditionalCharactersZelda);
                        mergedCharacters.Add(AdditionalCharactersMidna);
                        mergedCharacters.Add(AdditionalCharactersGanon);
                        mergedCharacters.AddRange(characters.data); 

                        Console.WriteLine("List of Legend of Zelda Characters:\n");

                        for (int i = 0; i < mergedCharacters.Count; i++)
                        {
                            if (mergedCharacters[i] is AdditionalCharacters additional)
                            {
                                Console.WriteLine($"{i + 1}. {additional.Name} ");
                            }
                            else if (mergedCharacters[i] is CharactersDatum apiCharacter)
                            {
                                Console.WriteLine($"{i + 1}. {apiCharacter.name}");
                            }
                        }

                        Console.WriteLine("\nEnter the number of the character you want to learn about (or type 'back' to go back):");

                        string input = Console.ReadLine().Trim().ToLower();

                        if (input == "back")
                        {
                            return; // Return to main menu if user types 'back'
                        }

                        if (int.TryParse(input, out int index) && index > 0 && index <= mergedCharacters.Count)
                        {
                            int selectedIndex = index - 1;

                            Console.Clear(); // Clear the console screen

                            // Handle selected character
                            if (mergedCharacters[selectedIndex] is AdditionalCharacters)
                            {
                                var selectedAdditionalCharacter = (AdditionalCharacters)mergedCharacters[selectedIndex];

                                // Display additional character details
                                Console.WriteLine($"Name: {selectedAdditionalCharacter.Name}");
                                Console.WriteLine($"Description: {selectedAdditionalCharacter.Description}");
                                
                            }
                            else if (mergedCharacters[selectedIndex] is CharactersDatum apiCharacter)
                            {
                                var selectedApiCharacter = apiCharacter;

                               
                            }

                            Console.WriteLine("\nPress any key to go back to the list of characters...");
                            Console.ReadKey(true); // Wait for user to press any key

                            Console.Clear(); // Clear the console screen again
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid character number or 'back' to go back:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve character data.");
                        return; // Return to main menu on failure
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return; // Return to main menu on error
                }
            }
        }
        static async Task DisplayMonsters()
        {
            while (true)
            {
                try
                {
                    Console.Clear(); // Clear the console screen
                    var monsters = await GetMonstersFromApi(monstersApiUrl);

                    if (monsters != null)
                    {
                        Console.WriteLine("List of Legend of Zelda Monsters:\n");

                        for (int i = 0; i < monsters.data.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {monsters.data[i].name}");
                        }

                        Console.WriteLine("\nEnter the number of the monster you want to learn about (or type 'back' to go back):");

                        string input = Console.ReadLine().Trim().ToLower();

                        if (input == "back")
                        {
                            return; // Return to main menu if user types 'back'
                        }

                        if (int.TryParse(input, out int index) && index > 0 && index <= monsters.data.Count)
                        {
                            int selectedIndex = index - 1;
                            var selectedMonster = monsters.data[selectedIndex];

                            Console.Clear(); // Clear the console screen

                            Console.WriteLine($"Name: {selectedMonster.name}");
                            Console.WriteLine($"Description: {selectedMonster.description}");
                            Console.WriteLine($"ID: {selectedMonster.id}");
                            Console.WriteLine($"Appearances: {string.Join(", ", selectedMonster.appearances)}");

                            Console.WriteLine("\nPress any key to go back to the list of monsters...");
                            Console.ReadKey(true); // Wait for user to press any key

                            Console.Clear(); // Clear the console screen again
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid monster number or 'back' to go back:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve monster data.");
                        return; // Return to main menu on failure
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return; // Return to main menu on error
                }
            }
        }

        static async Task DisplayBosses()
        {
            while (true)
            {
                try
                {
                    Console.Clear(); // Clear the console screen
                    var bosses = await GetBossesFromApi(bossesApiUrl);

                    if (bosses != null)
                    {
                        Console.WriteLine("List of Legend of Zelda Bosses:\n");

                        for (int i = 0; i < bosses.data.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {bosses.data[i].name}");
                        }

                        Console.WriteLine("\nEnter the number of the boss you want to learn about (or type 'back' to go back):");

                        string input = Console.ReadLine().Trim().ToLower();

                        if (input == "back")
                        {
                            return; // Return to main menu if user types 'back'
                        }

                        if (int.TryParse(input, out int index) && index > 0 && index <= bosses.data.Count)
                        {
                            int selectedIndex = index - 1;
                            var selectedBoss = bosses.data[selectedIndex];

                            Console.Clear(); // Clear the console screen

                            Console.WriteLine($"Name: {selectedBoss.name}");
                            Console.WriteLine($"Description: {selectedBoss.description}");
                            Console.WriteLine($"ID: {selectedBoss.id}");
                            Console.WriteLine($"Appearances: {string.Join(", ", selectedBoss.appearances)}");
                            Console.WriteLine($"Dungeons: {string.Join(", ", selectedBoss.dungeons)}");

                            Console.WriteLine("\nPress any key to go back to the list of bosses...");
                            Console.ReadKey(true); // Wait for user to press any key

                            Console.Clear(); // Clear the console screen again
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid boss number or 'back' to go back:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve boss data.");
                        return; // Return to main menu on failure
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return; // Return to main menu on error
                }
            }
        }

        static async Task DisplayDungeons()
        {
            while (true)
            {
                try
                {
                    Console.Clear(); // Clear the console screen
                    var dungeons = await GetDungeonsFromApi(dungeonsApiUrl);

                    if (dungeons != null)
                    {
                        Console.WriteLine("List of Legend of Zelda Dungeons:\n");

                        for (int i = 0; i < dungeons.data.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {dungeons.data[i].name}");
                        }

                        Console.WriteLine("\nEnter the number of the dungeon you want to learn about (or type 'back' to go back):");

                        string input = Console.ReadLine().Trim().ToLower();

                        if (input == "back")
                        {
                            return; // Return to main menu if user types 'back'
                        }

                        if (int.TryParse(input, out int index) && index > 0 && index <= dungeons.data.Count)
                        {
                            int selectedIndex = index - 1;
                            var selectedDungeon = dungeons.data[selectedIndex];

                            Console.Clear(); // Clear the console screen

                            Console.WriteLine($"Name: {selectedDungeon.name}");
                            Console.WriteLine($"Description: {selectedDungeon.description}");
                            Console.WriteLine($"ID: {selectedDungeon.id}");
                            Console.WriteLine($"Appearances: {string.Join(", ", selectedDungeon.appearances)}");

                            Console.WriteLine("\nPress any key to go back to the list of dungeons...");
                            Console.ReadKey(true); // Wait for user to press any key

                            Console.Clear(); // Clear the console screen again
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid dungeon number or 'back' to go back:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve dungeon data.");
                        return; // Return to main menu on failure
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return; // Return to main menu on error
                }
            }
        }

        static async Task DisplayPlaces()
        {
            while (true)
            {
                try
                {
                    Console.Clear(); // Clear the console screen
                    var places = await GetPlacesFromApi(placesApiUrl);

                    if (places != null)
                    {
                        Console.WriteLine("List of Legend of Zelda Places:\n");

                        for (int i = 0; i < places.data.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {places.data[i].name}");
                        }

                        Console.WriteLine("\nEnter the number of the place you want to learn about (or type 'back' to go back):");

                        string input = Console.ReadLine().Trim().ToLower();

                        if (input == "back")
                        {
                            return; // Return to main menu if user types 'back'
                        }

                        if (int.TryParse(input, out int index) && index > 0 && index <= places.data.Count)
                        {
                            int selectedIndex = index - 1;
                            var selectedPlace = places.data[selectedIndex];

                            Console.Clear(); // Clear the console screen

                            Console.WriteLine($"Name: {selectedPlace.name}");
                            Console.WriteLine($"Description: {selectedPlace.description}");
                            Console.WriteLine($"ID: {selectedPlace.id}");
                            Console.WriteLine($"Appearances: {string.Join(", ", selectedPlace.appearances)}");
                            Console.WriteLine($"Inhabitants: {string.Join(", ", selectedPlace.inhabitants)}");

                            Console.WriteLine("\nPress any key to go back to the list of places...");
                            Console.ReadKey(true); // Wait for user to press any key

                            Console.Clear(); // Clear the console screen again
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid place number or 'back' to go back:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve place data.");
                        return; // Return to main menu on failure
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return; // Return to main menu on error
                }
            }
        }

        static async Task DisplayItems()
        {
            while (true)
            {
                try
                {
                    Console.Clear(); // Clear the console screen
                    var items = await GetItemsFromApi(itemsApiUrl);

                    if (items != null)
                    {
                        Console.WriteLine("List of Legend of Zelda Items:\n");

                        for (int i = 0; i < items.data.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {items.data[i].name}");
                        }

                        Console.WriteLine("\nEnter the number of the item you want to learn about (or type 'back' to go back):");

                        string input = Console.ReadLine().Trim().ToLower();

                        if (input == "back")
                        {
                            return; // Return to main menu if user types 'back'
                        }

                        if (int.TryParse(input, out int index) && index > 0 && index <= items.data.Count)
                        {
                            int selectedIndex = index - 1;
                            var selectedItem = items.data[selectedIndex];

                            Console.Clear(); // Clear the console screen

                            Console.WriteLine($"Name: {selectedItem.name}");
                            Console.WriteLine($"Description: {selectedItem.description}");
                            Console.WriteLine($"ID: {selectedItem.id}");
                            Console.WriteLine($"Games: {string.Join(", ", selectedItem.games)}");

                            Console.WriteLine("\nPress any key to go back to the list of items...");
                            Console.ReadKey(true); // Wait for user to press any key

                            Console.Clear(); // Clear the console screen again
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid item number or 'back' to go back:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve item data.");
                        return; // Return to main menu on failure
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return; // Return to main menu on error
                }
            }
        }

        static async Task<GamesRoot> GetGamesFromApi(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var games = JsonSerializer.Deserialize<GamesRoot>(jsonString);
                return games;
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data from {url}. Status code: {response.StatusCode}");
                return null;
            }
        }

        static async Task<CharactersRoot> GetCharactersFromApi(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var characters = JsonSerializer.Deserialize<CharactersRoot>(jsonString);
                return characters;
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data from {url}. Status code: {response.StatusCode}");
                return null;
            }
        }

        static async Task<MonstersRoot> GetMonstersFromApi(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var monsters = JsonSerializer.Deserialize<MonstersRoot>(jsonString);
                return monsters;
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data from {url}. Status code: {response.StatusCode}");
                return null;
            }
        }

        static async Task<BossesRoot> GetBossesFromApi(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var bosses = JsonSerializer.Deserialize<BossesRoot>(jsonString);
                return bosses;
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data from {url}. Status code: {response.StatusCode}");
                return null;
            }
        }

        static async Task<DungeonsRoot> GetDungeonsFromApi(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dungeons = JsonSerializer.Deserialize<DungeonsRoot>(jsonString);
                return dungeons;
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data from {url}. Status code: {response.StatusCode}");
                return null;
            }
        }

        static async Task<PlacesRoot> GetPlacesFromApi(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var places = JsonSerializer.Deserialize<PlacesRoot>(jsonString);
                return places;
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data from {url}. Status code: {response.StatusCode}");
                return null;
            }
        }

        static async Task<ItemsRoot> GetItemsFromApi(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var items = JsonSerializer.Deserialize<ItemsRoot>(jsonString);
                return items;
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data from {url}. Status code: {response.StatusCode}");
                return null;
            }
        }
    }
}