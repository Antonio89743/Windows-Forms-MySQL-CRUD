-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 12, 2023 at 09:56 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `project_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `constructors_results`
--

CREATE TABLE `constructors_results` (
  `ID` int(11) NOT NULL,
  `Name` varchar(70) NOT NULL,
  `Points` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `constructors_results`
--

INSERT INTO `constructors_results` (`ID`, `Name`, `Points`) VALUES
(1, 'ar', 0),
(7, '', 90),
(65, '', 0),
(535, 'fsdga', 0),
(539, 'qasdfghj', 0),
(540, 'dasdas', 0),
(543, 'stari', 0),
(544, 'aa', 0),
(545, 'oo', 0),
(546, 'k', 0),
(547, 'aaa', 0),
(548, 'ddd', 0),
(549, 'ccc', 0),
(550, '', 100),
(551, 'fdsa', 0),
(552, '', 90),
(745, '', 0),
(5524, '', 0),
(7000, '', 0),
(90000, '', 0),
(900006, '', 0),
(3567835, '', 0),
(3567836, 'SomeTeam', 0),
(3567837, 'SomeTeam', 0),
(3567838, 'jdgh', 0);

-- --------------------------------------------------------

--
-- Table structure for table `drivers_results`
--

CREATE TABLE `drivers_results` (
  `ID` int(11) UNSIGNED NOT NULL,
  `FirstName` varchar(30) NOT NULL,
  `LastName` varchar(30) NOT NULL,
  `Constructor` varchar(70) NOT NULL,
  `Points` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `drivers_results`
--

INSERT INTO `drivers_results` (`ID`, `FirstName`, `LastName`, `Constructor`, `Points`) VALUES
(6, '', '', '', 0),
(15, '', '', '', 0),
(91, 'gfsd', '', '', 0),
(2000, 'fhsdf', 'hfgsh', 'ghsfghbv', 50);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `constructors_results`
--
ALTER TABLE `constructors_results`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `drivers_results`
--
ALTER TABLE `drivers_results`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `constructors_results`
--
ALTER TABLE `constructors_results`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3567839;

--
-- AUTO_INCREMENT for table `drivers_results`
--
ALTER TABLE `drivers_results`
  MODIFY `ID` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2001;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
