-- phpMyAdmin SQL Dump
-- version 4.7.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 29. Nov 2017 um 18:18
-- Server-Version: 10.0.31-MariaDB-cll-lve
-- PHP-Version: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `kd34167_Crypto`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `message`
--

CREATE TABLE `message` (
  `id` varchar(40) NOT NULL,
  `messageHeader` text NOT NULL,
  `receivingChannel` varchar(40) NOT NULL,
  `timestamp` int(11) NOT NULL,
  `message` text NOT NULL,
  `processingCounter` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `message`
--

INSERT INTO `message` (`id`, `messageHeader`, `receivingChannel`, `timestamp`, `message`, `processingCounter`) VALUES
('271e70ac13934147967a47146705aed7', '47192254bc07489b8252f6688d1dba1d', 'c576e5ce11d44393a9dfffcbba35496f', 1509885719, 'mupb', 2),
('2f34c7d142184f22aeb99653179a9072', 'effd028f89d34e86a08bff5595729bf3', 'c576e5ce11d44393a9dfffcbba35496f', 1509885506, 'lnu0lnqvnvlnqvq3lnq3lnq3rÃŸln2jq3swswÃŸ9qtqwqwxcÃŸ9', 2),
('b19fe8fc77934a7ca07cad81dde7d20c', 'effd028f89d34e86a08bff5595729bf3', 'c576e5ce11d44393a9dfffcbba35496f', 1509885575, '010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000qubfnmymip', 2),
('b5cf2c7e73b444c487728a128ba558f6', '47192254bc07489b8252f6688d1dba1d', 'c576e5ce11d44393a9dfffcbba35496f', 1509885591, 'q8wewewewewewewewewerf', 2),
('c7af6dc47b1d46fe90305f38c962582f', 'd753ea41064b438dbcd0452cd8699e54', 'c576e5ce11d44393a9dfffcbba35496f', 1509885744, '2mopgh42lzghm,,a42ghz,42d7opxr', 2),
('e1ed477ab41e418ca1c873eb0305ddda', '47192254bc07489b8252f6688d1dba1d', 'c576e5ce11d44393a9dfffcbba35496f', 1509885583, '2mwdwdwdwdwdwdwd2p', 2),
('eb8859cce917459291fefd0f65b6193b', 'd753ea41064b438dbcd0452cd8699e54', 'c576e5ce11d44393a9dfffcbba35496f', 1509890599, 'xe1ble5psioyc7m45pautx', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `user`
--

CREATE TABLE `user` (
  `id` varchar(40) NOT NULL,
  `firstname` varchar(30) NOT NULL,
  `surname` varchar(30) NOT NULL,
  `email` varchar(254) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `user`
--

INSERT INTO `user` (`id`, `firstname`, `surname`, `email`) VALUES
('47192254bc07489b8252f6688d1dba1d', 'Wolfgang ', 'Maier', 'tablet2@sfzlab.de'),
('d753ea41064b438dbcd0452cd8699e54', 'Elisa', 'Schmitt', 'tablet1@sfzlab.de'),
('effd028f89d34e86a08bff5595729bf3', 'Caroline', 'Kunze', 'computer1@sfzlab.de');

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `message`
--
ALTER TABLE `message`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
