CREATE DATABASE afmsDataBase;

USE afmsDataBase;

CREATE TABLE clientTable(
	[clientID] int primary key identity(1,1),
	[clientName] varchar(50) not null unique,
	[GSTIN] varchar(15) not null unique,
	[Email] varchar(20) not null unique,
	[Password] varchar(20) not null unique,
	[loyaltyPoints] int
)

CREATE TABLE adminTable(
	[adminName] varchar(20) not null unique,
	[adminID] int primary key identity(1,1),
	[Password] varchar(20) not null unique,
	[Role] varchar(10) not null,
	[Remarks] varchar(10)
)

CREATE TABLE flightDetails(
	[flightNo] varchar(10) not null primary key,
	[Origin] varchar(20) not null,
	[Destination] varchar(20) not null,
	[aircraftType] varchar(10) not null,
	[clientID] int not null unique foreign key references clientTable(clientID)
)

CREATE TABLE fuelList(
	[fuelID] int primary key identity(1,1),
	[fuelName] varchar(15) not null unique,
	[fuelPrevCost] real not null default 0,
	[fuelCurrentPrice] real not null default 0,
	[lastUpdated] time,
	[Place] varchar(20) not null
)


CREATE TABLE orderDetails(
	[orderID] int primary key identity(1,1),
	[clientID] int foreign key references clientTable(clientID),
	[flightNo] varchar(10) foreign key references flightDetails(flightNo),
	[fuelAmt] real not null,
	[fuelID] int foreign key references fuelList(fuelID),
	[orderPlaceDate] date not null unique,
	[orderDeliveryDate] date,
	[Status] varchar(10) constraint stsconst check (Status in 
			('Processing', 'Pending', 'Delivered'))
)
