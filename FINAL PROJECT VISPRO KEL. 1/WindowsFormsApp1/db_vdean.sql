-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 01, 2023 at 02:58 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_vdean`
--

-- --------------------------------------------------------

--
-- Table structure for table `data_mahasiswa`
--

CREATE TABLE `data_mahasiswa` (
  `nomor` int(10) NOT NULL,
  `nama_mahasiswa` varchar(50) NOT NULL,
  `status` varchar(50) NOT NULL,
  `jumlah_poin` int(100) NOT NULL,
  `seating` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `data_mahasiswa`
--

INSERT INTO `data_mahasiswa` (`nomor`, `nama_mahasiswa`, `status`, `jumlah_poin`, `seating`) VALUES
(1, 'Purukan, Jeremy Sylgwyn Arnold', 'Outsider - Long Range', 10, 'FWC H-5-2'),
(2, '-, I Kadek Tresna Jeverly', 'Outsider - Long Range', 0, 'FWC H-12-1'),
(3, '-, I Wayan Krisna Weda', 'Outsider - Short Range', 22, 'PC R-4-2'),
(4, 'Supit, Vincent Vian', 'Outsider - Long Range', 2, 'PC R-9-3'),
(5, 'Aruperes, Revando Karlhen', 'Outsider - Long Range', 28, 'FWC B-6-8'),
(6, 'Rawung, Arturito Imanuel', 'Outsider - Short Range', 48, 'PC D-4');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `id_pengguna` int(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `level` varchar(35) NOT NULL,
  `status` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`id_pengguna`, `username`, `password`, `level`, `status`) VALUES
(1, 'admin', 'admin', '1', 'active'),
(2, 'rothel', 'rothel123', '2', 'active');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
