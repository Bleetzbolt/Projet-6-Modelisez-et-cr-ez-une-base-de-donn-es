# Projet N°6: Modélisez et créez une base de données

Le projet comporte le dump de la base de données prévue pour la société NexaWorks: TicketDB.bak.
Cette base de données stock des tickets détaillant des problèmes survenus sur un de leurs logiciels sur une certaine version avec un certain système d'exploitation.
La base de données contient les informations suivantes:
- une table de produits logiciels
- une table versions logicielle
- une table de systèmes d'exploitation
- une table de configuration.Chaque configuration valide possède un produit, une version et un système d'exploitation.
- Chaque ticket possède une date de création, une date de résolution(NULL si non résolu), une description du problème,
  une description de résolution(NULL si non résolu) et un Id de configuration unique.


## Modèle de données
Ci-après le modèle de données entité-association utilisé pour modéliser la base de données.
<img width="844" height="575" alt="image" src="https://github.com/user-attachments/assets/56bc9186-912b-417e-bef3-75bf1f7173e4" />

## Requêtes sur BDD
Ajout de 14 requêtes LINQ créées à partir du pdf "P6+.NET+Liste+des+requêtes.pdf" avec le logiciel LinqPad.


[Accéder au dossier des requêtes LINQ](https://github.com/Bleetzbolt/Projet-6-Modelisez-et-cr-ez-une-base-de-donn-es/tree/master/Script%20LinqPad)
