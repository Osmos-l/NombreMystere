/* FUNCTION RETURN NOMBRE ALEATOIRE */
        static int RandomNumber()
        {
            Random rnd = new Random();
            int Number = rnd.Next(1, 1000);

            return Number;
        }

        /* RETRY GAME ? */
        static void WantRetry()
        {
            string InputUser;
            char OutUser;
            do
            {

                Console.WriteLine("Souhaites-tu recommencer ? [Y / N]");
                InputUser = Console.ReadLine().ToUpper();

                if (!char.TryParse(InputUser, out OutUser))
                {
                    PrintColorMessage(ConsoleColor.Red, "\nLe choix n'est pas correct !");
                    continue;
                }

                OutUser = char.Parse(InputUser);

                if (OutUser == 'Y')
                {
                    Console.Clear();
                    ChoiceDifficulty();
                    break;
                }
                else if (OutUser != 'N')
                {
                    PrintColorMessage(ConsoleColor.Red, "\nLe choix n'est pas correct !");
                    continue;

                }
                else
                {
                    Environment.Exit(0);
                    break;
                }

            } while (true);

        }

        /* WHAT DIFFICULTY */ 
        static void ChoiceDifficulty()
        {
            int Difficulte;

            // Demande choix de la difficulté 
            Console.WriteLine("\nChoisis la difficulté :");
            Console.WriteLine("\t1 - Simple");
            Console.WriteLine("\t2 - Normal");
            Console.WriteLine("\t3 - Hard");

            while (true)
            {

                string InputDiffuclte = Console.ReadLine();

                if (!int.TryParse(InputDiffuclte, out Difficulte))
                {
                   PrintColorMessage(ConsoleColor.Red, "\nEntre un nombre !");
                    continue;
                }

                // Transfert en int
                Difficulte = int.Parse(InputDiffuclte);

                if ((Difficulte <= 0) || (Difficulte > 3))
                {
                    PrintColorMessage(ConsoleColor.Red, "Choix incorrect !");

                    continue;
                }

                break;
            }

            Console.Clear();

            switch (Difficulte)
            {
                case 1: StartEasy(); break;
                case 2: StartGame(15); break;
                case 3: StartGame(7); break;
            }
        }

        static void PrintColorMessage(ConsoleColor color, string Message)
        {
            // Change la couleur du texte
            Console.ForegroundColor = color;

            // Affichage des informations de l'application
            Console.WriteLine(Message);

            // Remet la couleur de texte basique
            Console.ResetColor();
        }

        static void Main(string[] args)
        {

            // Informations application
            string AppAuthor = "Osmos Kesko Alias ThePsyca";
            string AppVersion = "1.0.0";
            string AppName = "Nombre inconnu";

            // Change la couleur du texte
            Console.ForegroundColor = ConsoleColor.Green;

            // Affichage des informations de l'application
            Console.WriteLine("{0}, Version {1} Créée par {2}", AppName, AppVersion, AppAuthor);

            // Remet la couleur de texte basique
            Console.ResetColor();

            // Changement du titre de la console
            Console.Title = AppName + " " + AppVersion;

            // Demande du nom du joueur
            Console.Write("\nEntre ton nom de joueur : ");

            // Récupération du nom du joueur
            string InputName = Console.ReadLine();

            // Choix difficulté
            ChoiceDifficulty();
        }

        /* START EASY GAME */
        static void StartEasy()
        {
            // Change la couleur du texte
            Console.ForegroundColor = ConsoleColor.Green;

            // Affichage des informations de l'application
            Console.WriteLine("Difficulté : ");
            Console.WriteLine("\t- Simple");
            Console.WriteLine("Règles :");
            Console.WriteLine("\t- Tu as un nombre d'essais infini afin de trouver le nombre caché !");
            Console.WriteLine("\t- Amuse toi bien !");

            // Remet la couleur de texte basique
            Console.ResetColor();

            // Assignation du nombre aléatoire
            int GuessNumber = RandomNumber();
            Console.WriteLine(GuessNumber);
            // Assignation du choix user de base
            int NbUser = 0;

            // Déclaration du compteur
            int Compteur = 0;

            // Affichage du début
            Console.WriteLine("\nSaisir un nombre entier entre 1 et 1000 :\n");

            do
            {
                // Augmentation du compteur
                Compteur++;

                // Enregistre le choix de l'utilisateur
                string InputUser = Console.ReadLine();

                if (!int.TryParse(InputUser, out NbUser))
                {
                    PrintColorMessage(ConsoleColor.Red, "Entre un nombre !");
                    continue;
                }

                NbUser = int.Parse(InputUser);

                if (NbUser > GuessNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Trop grand !");
                    continue;
                }
                else if (NbUser < GuessNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Trop petit !");
                    continue;
                }

            } while (NbUser != GuessNumber);

            Console.WriteLine("\nBravo ! Le nombre mystère était bien {0} !", GuessNumber);
            Console.WriteLine("Tu as trouvé en {0} essais !", Compteur);

            WantRetry();
        }

        /* START NORMAL GAME */
        static void StartGame(int MAXESSAIS )
        {
            // Change la couleur du texte
            Console.ForegroundColor = ConsoleColor.Green;

            // Affichage des informations de l'application
            Console.WriteLine("Difficulté : ");
            Console.WriteLine("\t- Normal");
            Console.WriteLine("Règles :");
            Console.WriteLine("\t- Tu as {0} essais maximum afin de trouver le nombre caché !", MAXESSAIS);
            Console.WriteLine("\t- Amuse toi bien !");

            // Remet la couleur de texte basique
            Console.ResetColor();

            // Assignation du nombre aléatoire
            int GuessNumber = RandomNumber();

            // Assignation du choix user de base
            int NbUser = 0;

            // Déclaration du compteur
            int Compteur = 0;

            // Affichage du début
            Console.WriteLine("\nSaisir un nombre entier entre 1 et 1000 :\n");

            do
            {
                // Augmentation du compteur
                Compteur++;

                // Enregistre le choix de l'utilisateur
                string InputUser = Console.ReadLine();

                if (!int.TryParse(InputUser, out NbUser))
                {
                    PrintColorMessage(ConsoleColor.Red, "Entre un nombre !");
                    continue;
                }

                NbUser = int.Parse(InputUser);

                if (NbUser > GuessNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Trop grand !");
                    continue;
                }
                else if (NbUser < GuessNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Trop petit !");
                    continue;
                }



            } while ( (NbUser != GuessNumber) && ( Compteur <= MAXESSAIS ) );

            if (NbUser == GuessNumber)
            {
                Console.WriteLine("\nBravo ! Le nombre mystère était bien {0} !", GuessNumber);
                Console.WriteLine("Tu as trouvé en {0} essais !", Compteur);
            }
            else
            {
                Console.WriteLine("Perdu !");
                Console.WriteLine("Le nombre mystère était {0} mais tu as dépassé le nombre maximum d'essais", GuessNumber);
            }

            WantRetry();

        }
