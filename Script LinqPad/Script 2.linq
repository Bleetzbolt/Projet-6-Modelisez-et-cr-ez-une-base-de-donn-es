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

//Obtenir tous les problèmes en cours/résolu pour un produit (toutes les versions)
//Paramètres: 
//productId	  1:Trader en herbe 
//			  2:Maire des investissements 
//			  3:Planificateur d'entrainement  
//    		  4:Planificateur d'anxiété sociale

// isSolved:	false => En cours
// 				true => Résolu 

int productId= Util.ReadLine<int>("N° Id produit: 1 à 4");
bool isSolved = Util.ReadLine<bool>("Problèmes en cours:false / Résolus:true");

Tickets
	.Where(t=>	t.Configuration.ProductId == productId 
			&& 	t.IsResolved==isSolved)
	.Dump();
	