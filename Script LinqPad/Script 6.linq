<Query Kind="Statements">
  <Connection>
    <ID>658230ba-0b75-497d-aa44-55af815e865f</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <DisplayName>ticketDB_Projet6</DisplayName>
    <Database>TicketDB</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <MapSQLiteDecimals>true</MapSQLiteDecimals>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

//Obtenir tous les problèmes en cours / résolu contenant une liste de mots-clés (tous les produits)
//Paramètres:
// solved:	false => En cours
// 			true => Résolu 

//keyWordsList: Liste de mots à saisir séparé d'une virgule 


bool isSolved = Util.ReadLine<bool>("Problèmes en cours:false / Résolus:true");
string dataEntry  =Util.ReadLine("Liste des mots-clefs espacés par des virgules");
//dataEntry=dataEntry.Replace(","," ,")+" ";
IList<string> keyWordsList = dataEntry	.Split(',')
									.ToList();
									 
Tickets
		.Where(t=>	t.IsResolved==isSolved 
				&&  (keyWordsList.All(mot => t.ProblemDescription.Contains(mot))
				|| 	keyWordsList.All(mot => t.ResolutionDescription.Contains(mot)))
		)
		.Dump();