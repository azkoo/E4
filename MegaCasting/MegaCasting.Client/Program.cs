using MegaCasting.DBLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Client
{
    class Program
    {
        #region Static Attributes

        /// <summary>
        /// Récupération du contexte
        /// </summary>
        public static MegaCastingEntities megaCastingEntities = new MegaCastingEntities();

        #endregion

        #region Static Methods

        /// <summary>
        /// Méthode principale
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(
                "---MegaCasting---" + Environment.NewLine
                + "1 - Ajout d'un producteur" + Environment.NewLine
               + "2 - Modification d'un producteur" + Environment.NewLine
               + "3 - Liste des producteurs" );

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    AddProducer();
                    break;
                case "2":
                    UpdateProducers();
                    break;
                case "3":
                    ListProducers();
                    break;
                case "4":
                    break;
                default:
                    break;
            }
            // Instanciation du contexte
            /* MegaCastingEntities entities = new MegaCastingEntities();


                 List<ContractType> contractTypes = entities.ContractTypes.ToList(); 
                 contractTypes
                     .ForEach(contractType => Console.WriteLine(contractType.Name));
                 Console.ReadKey();
                 */
            Console.ReadKey();

        }

        /// <summary>
        /// Ajoute en base de données un nouveau producteur
        /// </summary>
        public static void AddProducer()
        {
            Producer producer = new Producer();

            Console.WriteLine("Le nom du producteur : ");

            producer.Name = Console.ReadLine();
            Console.WriteLine("Un mot de passe par défaut va être affecté");
            //producer.Password =; 
            /*int i = 0;
            Random random = new Random();

            while (i <= 6)
            {
               random.
            }*/
            
            //TODO : Générer un mot de passe  aléatoire

            // On ajoute le producteur à la liste
            megaCastingEntities.Producers.Add(producer);

            // On push les modifications en base de données.
            megaCastingEntities.SaveChanges();

        }

        /// <summary>
        /// Liste les prodructeur et demande pour en supprimer un
        /// </summary>
        public static void ListProducers()
        {
            // Récupération de la liste des producteurs
            List<Producer> producers = megaCastingEntities.Producers.ToList();

            //Ici, on les affichent
            producers.ForEach(producer => Console.WriteLine(producer.Id + " - " + producer.Name));

            //Demande de suppression éventuelle ?
            Console.WriteLine("Si vous souhaitez supprimer un producteur, écrivez son identifiant");
            string toDeleteString = Console.ReadLine();

            int isInteger = 0;

            //Passer le choic utilisateur dans un string
            if (int.TryParse(toDeleteString, out isInteger))
            {
                if (megaCastingEntities.Producers.Any(producer => producer.Id == isInteger))
                {
                    //Si il existe on le récupère
                    Producer producer = megaCastingEntities.Producers.First(producerTemp => producerTemp.Id == isInteger);
                    //On le supprime
                    megaCastingEntities.Producers.Remove(producer);
                    // On le sauvegarde
                    megaCastingEntities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Le producteur à supprimer n'a pas été trouvé");
                }

            }

        }

        /// <summary>
        /// Modifie les informations sur le producteurs
        /// </summary>
        public static void UpdateProducers()
        {
            // Récupération de la liste des producteurs
            List<Producer> producers = megaCastingEntities.Producers.ToList();

            //Ici, on les affichent
            producers.ForEach(producer => Console.WriteLine(producer.Id + " - " + producer.Name));

            //Demande de suppression éventuelle ?
            Console.WriteLine("Si vous souhaitez modifier un producteur, écrivez son identifiant");
            string toDeleteString = Console.ReadLine();
            int isInteger = 0;

            //Passer le choic utilisateur dans un string
            if (int.TryParse(toDeleteString, out isInteger))
            {
                if (megaCastingEntities.Producers.Any(producer => producer.Id == isInteger))
                {
                    //Si il existe on le récupère
                    Producer producer = megaCastingEntities.Producers.First(producerTemp => producerTemp.Id == isInteger);
                    //On le modifie
                    Console.WriteLine("Nouveau nom : ");
                    string nametoUpdate = Console.ReadLine();

                    Console.WriteLine("Nouveau mot de passe : ");
                    string passwordtoUpdate = Console.ReadLine();
                    producer.Password = passwordtoUpdate;
                    // On le sauvegarde
                    megaCastingEntities.SaveChanges();
                    Console.WriteLine("Informations changé avec succès !");
                }
                else
                {
                    Console.WriteLine("Le producteur à modifier n'a pas été trouvé");
                }

            }
        }
        #endregion
    }
}

