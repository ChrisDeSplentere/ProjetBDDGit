-- *********************************************
-- * Standard SQL generation                   
-- *--------------------------------------------
-- * DB-MAIN version: 9.2.0              
-- * Generator date: Oct 16 2014              
-- * Generation date: Sat Dec 26 12:50:03 2015 
-- * LUN file: C:\Users\Chris\Desktop\Cours3eIesn\BDD avancées et appl web\Projet\SousSchemaEmploi.lun 
-- * Schema: sousSchemaLogique/SQL 
-- ********************************************* 


-- Database Section
-- ________________ 

create database sousSchemaLogique;


-- DBSpace Section
-- _______________


-- Tables Section
-- _____________ 

create table Emploi (
     ID numeric(8) not null,
     EstSoumis char not null,
     DateDebut date not null,
     IDTravailleur numeric(8) not null,
     CodeProfession numeric(8) not null,
     DateFin date,
     NumeroEntreprise numeric(8) not null,
     constraint ID_Emploi_ID primary key (ID),
     constraint SID_Emploi_ID unique (DateDebut, IDTravailleur, CodeProfession));

create table Entreprise (
     Numero numeric(8) not null,
     Denomination varchar(40) not null,
     NomRue varchar(40) not null,
     NumeroRue varchar(10) not null,
     NumTel varchar(20) not null,
     NbSoumis numeric(8) not null,
     NbNonSoumis numeric(8) not null,
     IDLocalite numeric(8) not null,
     constraint ID_Entreprise_ID primary key (Numero));

create table Localite (
     ID numeric(8) not null,
     Nom varchar(40) not null,
     CodePostal varchar(10) not null,
     Pays varchar(40) not null,
     constraint ID_Localite_ID primary key (ID));

create table Profession (
     Code numeric(8) not null,
     Denomination varchar(40) not null,
     constraint ID_Profession_ID primary key (Code));

create table Travailleur (
     ID numeric(8) not null,
     Nom varchar(40) not null,
     Prenom varchar(40) not null,
     Sexe char(1) not null,
     NomRueDomicile varchar(40) not null,
     NumeroRueDomicile varchar(10) not null,
     NumDossierMedic numeric(8),
     IDDomicile numeric(8) not null,
     constraint ID_Travailleur_ID primary key (ID),
     constraint SID_Travailleur_ID unique (NumDossierMedic));


-- Constraints Section
-- ___________________ 

alter table Emploi add constraint REF_Emplo_Trava_FK
     foreign key (IDTravailleur)
     references Travailleur;

alter table Emploi add constraint REF_Emplo_Entre_FK
     foreign key (NumeroEntreprise)
     references Entreprise;

alter table Emploi add constraint REF_Emplo_Profe_FK
     foreign key (CodeProfession)
     references Profession;

alter table Entreprise add constraint REF_Entre_Local_FK
     foreign key (IDLocalite)
     references Localite;

alter table Travailleur add constraint REF_Trava_Local_FK
     foreign key (IDDomicile)
     references Localite;


-- Index Section
-- _____________ 

create unique index ID_Emploi_IND
     on Emploi (ID);

create unique index SID_Emploi_IND
     on Emploi (DateDebut, IDTravailleur, CodeProfession);

create index REF_Emplo_Trava_IND
     on Emploi (IDTravailleur);

create index REF_Emplo_Entre_IND
     on Emploi (NumeroEntreprise);

create index REF_Emplo_Profe_IND
     on Emploi (CodeProfession);

create unique index ID_Entreprise_IND
     on Entreprise (Numero);

create index REF_Entre_Local_IND
     on Entreprise (IDLocalite);

create unique index ID_Localite_IND
     on Localite (ID);

create unique index ID_Profession_IND
     on Profession (Code);

create unique index ID_Travailleur_IND
     on Travailleur (ID);

create unique index SID_Travailleur_IND
     on Travailleur (NumDossierMedic);

create index REF_Trava_Local_IND
     on Travailleur (IDDomicile);

