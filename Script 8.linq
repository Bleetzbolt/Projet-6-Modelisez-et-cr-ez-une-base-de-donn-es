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

//Obtenir tous les problèmes en cours /résolu pour un produit contenant une liste de mots-clés (une seule version)
//Paramètres: productId
//			  1:Trader en herbe 
//			  2:Maire des investissements 
//			  3:Planificateur d'entrainement  
//    		  4:Planificateur d'anxiété sociale

//appVersionId	1: 1.0  
//				2: 1.1  
//				3: 1.2  
//				4: 1.3  
//				5: 2.0  
//				6: 2.1  

// isSolved:	false => En cours
// 			true => Résolu 

//keyWordsList: Liste de mots à saisir séparé d'une virgule 


var productId= Util.ReadLine<int>("N° Id produit: 1 à 4");
var appVersionId= Util.ReadLine<int>("N° Id version: 1 à 6");
bool isSolved = Util.ReadLine<bool>("Problèmes en cours:false / Résolus:true");
string dataEntry  =Util.ReadLine("Liste des mots-clefs espacés par des virgules");
//dataEntry=dataEntry.Replace(","," ,")+" ";
IList<string> keyWordsList  =dataEntry	.Split(',')
							.ToList();


Tickets
		.Where(t=>	t.IsResolved==isSolved 
				&& 	t.Configuration.AppVersionId == appVersionId
				&&	t.Configuration.ProductId == productId 
				&& 	(keyWordsList.All(mot => t.ProblemDescription.Contains(mot))
				|| 	keyWordsList.All(mot => t.ResolutionDescription.Contains(mot)))
		)
		.Dump();