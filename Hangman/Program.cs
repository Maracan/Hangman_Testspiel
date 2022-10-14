namespace Hangmangame
{

    class Program
    {



        static void Main (string[] args)
        {
            //Aufruf des Hauptmenüs
            
            MainMenu();
            


        }

        static void MainMenu()
        {
            // Schleife damit das Menü so lange läuft bis wir es beenden.
            while(true) { 



            //Hauptmenü zur Steuerung

            //Titel
            Console.WriteLine("### HANGMAN ###");
            Console.WriteLine("###############");
            Console.WriteLine();

            //Eingabeaufforderung 1/2 - Auswahlmöglichkeiten angezeigt
            Console.WriteLine("Wähle eine Aktion aus:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[1] Spielen");
            Console.WriteLine("[2] Beenden");
            Console.ResetColor();
            Console.WriteLine();

            //Eingabeaufforderung 2/2 - Aufforderung zur Eingabe
            Console.Write("Akion: ");

            //Verarbeitung und Speicherung der Eingabe 
            //Eingabe ist immer ein String somit brauchen wir ein Convert to int da wir ja zur Auswahl einen INT-Wert verarbeiten wollen (1 oder 2)
            int action = Convert.ToInt32(Console.ReadLine());

            // Diesen bool end benutzen wir ob der user 2 gewählt hat. Denn ist es auf true wollen wir das Spiel damit beenden. 
            bool end = false;


            //Switchblock zur Prüfung was der User eingegeben hat.
            switch (action)
            {
                // Hat der User nun 1 eingegeben - startet die Methode StartGame()
                case 1:
                    StartGame();
                    break;
                // Hat der User nun 2 eingegeben - wird der bool "end" auf true gesetzt. 
                case 2:
                    end = true;
                    break;
            }
                //Spiel wird beendet. Kurze Rückmeldung an user -> beenden. 
                if (end)
                {
                    Console.WriteLine("Spiel wird beendet....");
                    break;

                }

                    Console.Clear();
        }

        }

        static void StartGame()
        {
            string[] words = new string[]
            {

                //Liste von benutzten Wörtern 
               "Umweltschutzorganisation",
               "Finanzdienstleistungsunternehmen",
               "Nahrungsmittel",
               "Taschenmesser",
               "Haftpflichtversicherung",
               "mutterseelenallein",
                "Geburtstagskuchen",
                "Kopfsteinpflaster",
                "Fussballweltmeisterschaft",
                "Terroranschlag",
                "Babypuppe",
                "Hupfdohle",
                "Quizshow",
                "Kuddelmuddel",
                "Vollmond",
                "Hollywood",
                "Puzzle",
                "Kopfball",
                "Dumpfbacke",
                "Kruzifix",
                "Finanzdienstleistungsunternehmen",
                "Fussballweltmeisterschaft",
                "Umweltschutzorganisation",
                "Schifffahrtsgesellschaft",
                "Haftpflichtversicherung",
                "Brechreizbeschleuniger",
                "Intelligenzallergiker",
                "Steckdosenbefruchter",
                "Wasserverschmutzung",
                "Geschmacksverirrung",
                "Sex",
                "Hund",
                "Oper",
                "Mond",
                "Yeti",
                "Mars",
                "Quiz",
                "Auto",
                "Zebra",
                "Venus",
                "Kuddelmuddel",
                "Geschlechtsverkehr",
                "Zukunftsmusik",
                "Warenentgegennahme",
                "Puderzucker",
                "Zwiebelsuppe",
                "Papperlapapp",
                "Apfelkuchen",
                "Alarmanlage",
                "Videospiel",
                "Vollkornbrot",
                "Lastwagen",
                "Kraftfahrzeug",
                "Gemüsesuppe",


            };
            // Randomgenerator der zufällig ein Wort aus dem Array nimmt.
            Random rnd = new Random();
            int index = rnd.Next(0, words.Length);
            //.ToLower stellt alle Buchsteiben klein zur besseren/einfacheren Verarbeitung.
            string word = words[index].ToLower();

            GameLoop(word);
        }

        static void GameLoop(string word)
        {
             


            // Definition von max. Leben des Users.
            int lives = 10;
            //Variable für das gesuchte Wort.
            string hiddenWord = "";

            //Eine Zeichenfolge von _ für jeden Buchstaben des gesuchten Wortes
            for (int i = 0; i < word.Length; i++)
            {
                hiddenWord += "_";
            }


            //Die Schleife läuft so lange wie das Wort gefunden wurde oder man keine Leben mehr hat.
            while (true)
            {
                // Wir machen die Konsole erstmal leer damit das Menü nicht mehr zu sehen ist.
                Console.Clear();

                Console.WriteLine("Gesuchtes Wort: " + hiddenWord);
                Console.Write("Noch übrige Versuche: ");

                //Schleife für die Lebensanzeige in rot
                for (int j = 0; j < lives; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("#");
                    Console.ResetColor();

                }
                //Zeilenumbruch und AUfforderung an den User er soll einen Buchstaben eingeben. 
                //Speichern des Buchstaben in eine var char = character
                //Werden als kleine Buchstaben gespeichert.
                Console.WriteLine();
                Console.Write("Buchtstabe: ");
                char character = Convert.ToChar(Console.ReadLine().ToLower());


                bool foundcharacterInWord = false;

                //Schleife zur überprüfung ob der Buchstabe nun vorhanden ist im gesuchten Wort.
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == character)
                    {
                        foundcharacterInWord = true;
                        break;
                    }

                }

                //Temporär übertragen wir zu Überprüfung des Wortes dieses in einen neuen String
                // Oben die Überprüfung nun arbeiten wir mit den eingebenen Buchstaben.
                string tempHiddenWord = hiddenWord;
                hiddenWord = "";

                //Wenn ein Buchstabe gefunden wurde ersetzen wir wir die "_" mit dem gefunden Buchstaben.
                // Wenn wir den Buchstaben gefunden haben dann laufen wir alle Buchstaben des Wortes durch.
                if (foundcharacterInWord)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        //Wenn der Buchstaben den wir eingeben ist in dem Wort enthalten ist 
                        if (word[i] == character)
                        {
                            // dann fürgen wir den Buchstaben dem hiddenWord hinzu.
                            hiddenWord += character;
                        }
                            //Wenn wir an dieser Stelle bereits einen Buchstaben gefunden haben und dort was anderes als ein "_" steht, dann fügen wir den dazu.
                        else if (tempHiddenWord[i] != '_')
                        {
                            hiddenWord += tempHiddenWord[i];
                        } //Wenn das nicht der Fall ist fügen wir ein "_" dazu.
                        else
                        {
                            hiddenWord += '_';
                        }
                    }

                    // Wir prüfen nun ob wir das Wort schon komplett gefunden haben.
                    if (hiddenWord == word)
                    {
                        //Wenn das Wort gefunden wurde dann clearen wir die Konsole, schalten die Farbe auf Grün und geben Meldung an user.
                     
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Gewonnen!!!!");
                        Console.WriteLine("Das gesuchte Wort war:  " + word.ToUpper());
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }
                }
                else
                {
                    //Wenn der Buchstabe nicht in dem Wort vorkommt dann muss ein Leben abgezogen werden.
                    // Dafür setzen wir das tempHiddenWord wieder auf hiddenWord.
                    hiddenWord = tempHiddenWord;

                    // Wir prüfen wie viele Leben noch vorhanden sind, ziehen eins ab, wenn keins mehr vorhanden ist dann GameOver
                    if (lives > 0)
                    {
                        lives -= 1;

                    } else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("GAME OVER!!!");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;

                    }
                }

            }
        }
    }

}