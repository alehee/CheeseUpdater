-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Czas generowania: 12 Gru 2020, 21:04
-- Wersja serwera: 10.4.15-MariaDB
-- Wersja PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `Version`
--

CREATE TABLE `Version` (
  `ID` int(11) NOT NULL,
  `Program` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `Ver` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL,
  `URL` text CHARACTER SET utf8 COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin2;

--
-- Zrzut danych tabeli `Version`
--

INSERT INTO `Version` (`ID`, `Program`, `Ver`, `URL`) VALUES
(6, 'programName', '1.0.0', 'https://www.urlexample.pl/updates/programName/update.zip');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `Version`
--
ALTER TABLE `Version`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT dla tabel zrzutów
--

--
-- AUTO_INCREMENT dla tabeli `Version`
--
ALTER TABLE `Version`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
