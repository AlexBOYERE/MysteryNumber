using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable
            int intParty = 1;

            //home
            Console.WriteLine("---------------");
            Console.WriteLine("---------------");
            Console.WriteLine("-Nombre Mystère-");
            Console.WriteLine("---------------");
            Console.WriteLine("---------------");

            int intTry = 0;
            int limitMin = 0;
            int limitMax = 100;
            int intGoal = 54;
            int[] listNumbers = new int[] { 0, 100 };
            int intChooseByPlayer;

            do
            {
                if (intTry != 0)
                {
                    Console.Write("Voulez-vous voir vos précédentes propositions ? (Y OR N): ");
                    string choiceList = Console.ReadLine();

                    if(choiceList == "Y")
                    {
                        foreach(int Number in listNumbers)
                        {
                            Console.WriteLine(Number);
                        }
                    }
                }//Afficher les anciennes tentatives

                Console.Write("Choisir un nombre entre " + limitMin + " à " + limitMax + ": ");
                string stringChooseByPlayer = Console.ReadLine();
                if (int.TryParse(stringChooseByPlayer, out intChooseByPlayer))
                {
                    intTry++;
                    if (intGoal > intChooseByPlayer)
                    {
                        Console.WriteLine("Numéro trop petit");
                    } //Numéro trop petit 
                    else if (intGoal < intChooseByPlayer)
                    {
                        Console.WriteLine("Numéro trop grand");
                    } // Numéro trop grand
                    else
                    {
                        Console.WriteLine("Nooon, mais c'est une victoire woahhh");
                        Console.WriteLine("Partie N° " + intParty + " , valeur secrète=… , trouvé en " + intTry + " coup(s).");

                        Retry();
                    }

                    Array.Resize(ref listNumbers, listNumbers.Length + 1);
                    listNumbers[listNumbers.GetUpperBound(0)] = intChooseByPlayer;
                }
                else
                {
                    Console.WriteLine("Un numéro, nu-mé-ro tu sais ce que c'est ?");
                } // Valeur n'est pas un numéro
            } while (intGoal != intChooseByPlayer);

            static bool Retry()
            {
                string choice;
                do
                {
                    Console.WriteLine("Tu veux encore jouer ? (Y or N): ");
                    choice = Console.ReadLine();
                    if (choice == "Y")
                    {
                        Console.WriteLine("Relancement d'une partie...");
                    }

                    else if (choice == "N")
                    {
                        Close();
                    } //Ferme l'application

                    else
                    {
                        Console.WriteLine("Réponds juste à la question...");
                    } //L'utilisateur à mal répondu

                }
                while (choice != "Y");
                return false;
            }//Demande si il veut relancer le jeu
            static void Close()
            {
                Environment.Exit(0);
            }//Ferme l'application
        }
    }
}