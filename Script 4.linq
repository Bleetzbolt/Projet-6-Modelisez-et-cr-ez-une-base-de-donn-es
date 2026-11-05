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

//Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit (toutes les versions)
// Paramètres:
//Paramètres: productId
//			  1:Trader en herbe 
//			  2:Maire des investissements 
//			  3:Planificateur d'entrainement  
//    		  4:Planificateur d'anxiété sociale

//beginDate: date du début de période
//endDate: date de fin de période

int productId= Util.ReadLine<int>("N° Id produit: 1 à 4");
DateOnly beginDate = Util.ReadLine<DateOnly>("Date début de période: Année, Mois, Jours");
DateOnly endDate = Util.ReadLine<DateOnly>("Date fin de période: Année, Mois, Jours");

Tickets
	.Where(t=>	t.Configuration.ProductId == productId
		 &&		((t.CreationDate >= beginDate && t.CreationDate <= endDate)
		 		|| 	((t.ResolutionDate >=beginDate && t.ResolutionDate <= endDate)))
		   )
		 		
	.Dump();
	