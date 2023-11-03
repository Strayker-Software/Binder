-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 02 Lis 2023, 23:36
-- Wersja serwera: 10.4.27-MariaDB
-- Wersja PHP: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `binder_db`
--

--
-- Zrzut danych tabeli `tables`
--

INSERT INTO `tables` (`Id`, `Name`) VALUES
(1, 'ToDo List'),
(2, 'Work'),
(3, 'Hobby');

--
-- Zrzut danych tabeli `todotasks`
--

INSERT INTO `todotasks` (`Id`, `Name`, `Description`, `IsCompleted`, `TableId`) VALUES
(1, 'Zadanko', 'Fajne Zadanko', 0, 1),
(2, 'Kolejne', 'Jeszcze jedno', 0, 2),
(3, 'Następne', 'OK', 0, 1),
(4, 'Dobre Zadanie', 'Bardzo dobre zadanie', 0, 3);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
