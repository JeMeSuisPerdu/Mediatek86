-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : dim. 28 avr. 2024 à 11:20
-- Version du serveur : 8.2.0
-- Version de PHP : 8.2.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediatek86`
--

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idmotif` int NOT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `idmotif` (`idmotif`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES
(1, '2023-12-25 15:30:00', '2023-12-31 12:30:00', 1),
(2, '2024-04-01 11:30:00', '2024-04-01 15:30:00', 3),
(4, '2024-04-01 15:30:00', '2024-04-01 15:30:00', 3),
(5, '2024-04-01 15:30:00', '2024-04-01 15:30:00', 2),
(6, '2024-04-01 15:30:00', '2024-04-01 15:30:00', 2),
(7, '2024-04-01 15:30:00', '2024-04-01 15:30:00', 3),
(8, '2024-04-01 15:30:00', '2024-04-01 15:30:00', 3),
(9, '2024-04-01 15:30:00', '2024-04-01 15:30:00', 2),
(1, '2024-04-01 08:00:00', '2024-04-01 17:00:00', 1),
(2, '2024-05-02 08:30:00', '2024-05-02 16:30:00', 2),
(1, '2000-04-25 23:45:14', '2001-04-25 23:45:14', 1),
(5, '2024-08-05 10:00:00', '2024-08-05 16:00:00', 1),
(6, '2024-09-06 10:30:00', '2024-09-06 15:30:00', 2),
(7, '2024-10-07 11:00:00', '2024-10-07 14:00:00', 3),
(8, '2024-11-08 11:30:00', '2024-11-08 13:30:00', 4),
(9, '2024-12-09 12:00:00', '2024-12-09 12:45:00', 1),
(1, '2020-02-11 08:00:00', '2020-02-11 17:00:00', 2),
(2, '2020-03-12 08:30:00', '2020-03-12 16:30:00', 2),
(4, '2020-05-14 09:30:00', '2020-05-14 17:30:00', 4),
(5, '2020-06-15 10:00:00', '2020-06-15 16:00:00', 1),
(6, '2020-07-16 10:30:00', '2020-07-16 15:30:00', 2),
(28, '2020-08-17 11:00:00', '2020-08-17 14:00:00', 3),
(8, '2020-09-18 11:30:00', '2020-09-18 13:30:00', 4),
(9, '2020-10-19 12:00:00', '2020-10-19 12:45:00', 1),
(1, '2021-12-21 08:00:00', '2021-12-21 17:00:00', 3),
(2, '2021-01-22 08:30:00', '2021-01-22 16:30:00', 4),
(4, '2021-03-24 09:30:00', '2021-03-24 17:30:00', 2),
(5, '2021-04-25 10:00:00', '2021-04-25 16:00:00', 3),
(1, '2024-04-26 00:00:46', '2024-04-26 00:00:46', 1),
(7, '2021-06-27 11:00:00', '2021-06-27 14:00:00', 1),
(8, '2021-07-28 11:30:00', '2021-07-28 13:30:00', 2),
(9, '2021-08-29 12:00:00', '2021-08-29 12:45:00', 3),
(8, '2022-02-11 08:00:00', '2022-02-11 17:00:00', 1),
(5, '2022-04-13 09:00:00', '2022-04-13 18:00:00', 3),
(2, '2022-05-14 09:30:00', '2022-05-14 17:30:00', 4),
(8, '2022-06-15 10:00:00', '2022-06-15 16:00:00', 1),
(4, '2022-07-16 10:30:00', '2022-07-16 15:30:00', 2),
(1, '2022-08-17 11:00:00', '2022-08-17 14:00:00', 3),
(6, '2022-09-18 11:30:00', '2022-09-18 13:30:00', 4),
(8, '2022-10-19 12:00:00', '2022-10-19 12:45:00', 1),
(7, '2022-11-20 12:30:00', '2022-11-20 12:15:00', 2),
(9, '2023-01-22 08:30:00', '2023-02-05 16:30:00', 2),
(6, '2023-02-23 09:00:00', '2023-03-09 18:00:00', 3),
(7, '2023-03-24 09:30:00', '2023-04-07 17:30:00', 4),
(5, '2023-04-25 10:00:00', '2023-05-09 16:00:00', 1),
(16, '2024-04-01 00:04:50', '2024-04-26 00:04:50', 1),
(2, '2023-07-28 11:30:00', '2023-08-11 13:30:00', 4),
(4, '2023-08-29 12:00:00', '2023-09-12 12:45:00', 1),
(8, '2023-09-30 12:30:00', '2023-10-14 12:15:00', 2),
(26, '2024-04-26 00:07:49', '2024-04-27 13:07:49', 3);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `prenom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tel` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `idservice` int NOT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(8, 'Hollyland', 'Kerianne', '0644830036', 'khollylanda@usgs.gov', 2),
(9, 'Fairnie', 'Brietta', '0776531908', 'bfairnieb@mail.ru', 3),
(7, 'Grieveson', 'Janine', '0651383070', 'jgrieveson3@cornell.edu', 1),
(6, 'Barter', 'Lizzie', '0727141000', 'lbarter1@time.com', 2),
(1, 'Mejin', 'Ahmed', '0625351487', 'ahmed@gmail.com', 3),
(16, 'Pastis', 'Anis', '0723145965', 'anis@hotmail.com', 1),
(2, 'Lennon', 'John', '0784952160', 'john@gmail.com', 2),
(3, 'Mimine', 'Léa', '0715263495', 'léa@gmail.com', 3),
(4, 'Fuji', 'Itadori', '0698456212', 'itadori@gmail.com', 2),
(5, 'Ellis', 'Reford', '0629817181', 'ereford0@nationalgeographic.com', 1),
(10, 'Florida', 'Nathan', '0752614236', 'nathan@mail.com', 1),
(11, 'Clafouti', 'Yvann', '0795456832', 'yvann@gmail.com', 3),
(12, 'Armouille', 'Redouane', '0651423697', 'redouane@gmail.com', 2),
(13, 'Guttunberg', 'Hector', '0685231457', 'hector@mail.com', 1),
(14, 'Mirabelle', 'Laura', '0741529632', 'mirabelle@hotmail.com', 3),
(15, 'Coffee', 'Ines', '0697845162', 'ines@gmail.com', 2),
(17, 'Poirot', 'Poirot', '0796521234', 'poirot@hotmail.com', 3),
(18, 'Monk', 'Bobo', '0796521234', 'monk@hotmail.com', 3),
(19, 'Salamander', 'Grimvald', '0784956321', 'grimvald@gmail.com', 1),
(20, 'Potter', 'Harry', '0632145789', 'potter@gmail.com', 2),
(21, 'Mister', 'Vincent', '0658471236', 'vincent@mail.com', 2),
(22, 'Franco', 'James', '0777415236', 'franco@mail.com', 3),
(23, 'Marital', 'Francois', '0784485712', 'francois@gmail.com', 1),
(24, 'Hally', 'Tom', '0625314789', 'tom@gmail.com', 3),
(25, 'Affleck', 'Benjamin', '0632124565', 'ben@gmail.com', 1),
(26, 'Fresh', 'Martin', '0758523214', 'fresh@hotmail.com', 2),
(27, 'Gosling', 'Rayan', '0615987435', 'rayan@example.com', 2),
(28, 'Holland', 'Tom', '0784956231', 'tomholland@gmail.com', 1);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `pwd` varchar(64) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('Kise', 'a35818d6f6e8a8ada16018287a021a888f6f238c5875aabfece7663b4d82a1f8');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
