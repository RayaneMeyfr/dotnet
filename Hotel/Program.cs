// See https://aka.ms/new-console-template for more information
using Hotel.data;
using Hotel.models;
using Hotel.models.enums;
using Hotel.repository;

var context = new ApplicationDbContext();

var chambreRepository = new ChambreRepository(context);
var clientRepository = new ClientRepository(context);
var reservationRepository = new ReservationRepository(context, clientRepository, chambreRepository);

Console.WriteLine("Les clients :");

foreach (var client in clientRepository.GetAll())
{
    Console.WriteLine(client);
}

Console.WriteLine("Les chambres :");

foreach (var chambre in chambreRepository.GetAll())
{
    Console.WriteLine(chambre);
}

Console.WriteLine("Les réservations :");

foreach (var reservation in reservationRepository.GetAll())
{
    Console.WriteLine(reservation);
}

//var chambres = new List<Chambre>
//{
//    new Chambre { NumeroChambre = 101, Status = StatutChambre.Libre, NombreLit = 2, Tarrif = 50 },
//    new Chambre { NumeroChambre = 102, Status = StatutChambre.Libre, NombreLit = 1, Tarrif = 40 },
//    new Chambre { NumeroChambre = 103, Status = StatutChambre.Libre, NombreLit = 3, Tarrif = 70 },
//    new Chambre { NumeroChambre = 104, Status = StatutChambre.Libre, NombreLit = 2, Tarrif = 60 },
//    new Chambre { NumeroChambre = 105, Status = StatutChambre.Libre, NombreLit = 1, Tarrif = 45 },
//};

//foreach (var chambre in chambres)
//{
//    chambreRepository.Add(chambre);
//}

//var clients = new List<Client>
//{
//    new Client { Nom = "Dupont", Prenom = "Jean", Numero = "0600000001" },
//    new Client { Nom = "Martin", Prenom = "Sophie", Numero = "0600000002" },
//    new Client { Nom = "Durand", Prenom = "Paul", Numero = "0600000003" },
//    new Client { Nom = "Bernard", Prenom = "Claire", Numero = "0600000004" },
//    new Client { Nom = "Petit", Prenom = "Luc", Numero = "0600000005" },
//};

//foreach (var client in clients)
//{
//    clientRepository.Add(client);
//}

//var reservations = new List<Reservation>
//{
//    new Reservation { statut = StatutReservation.Prevu, unClient = clients[0], uneChambre = chambres[0] },
//    new Reservation { statut = StatutReservation.Prevu, unClient = clients[1], uneChambre = chambres[1] },
//    new Reservation { statut = StatutReservation.EnCour, unClient = clients[2], uneChambre = chambres[2] },
//    new Reservation { statut = StatutReservation.Fini, unClient = clients[3], uneChambre = chambres[3] },
//    new Reservation { statut = StatutReservation.Annuler, unClient = clients[4], uneChambre = chambres[4] },
//};

//foreach (var reservation in reservations)
//{
//    reservationRepository.Add(reservation);
//}

//Console.WriteLine("5 chambres, 5 clients et 5 réservations créés avec succès !");