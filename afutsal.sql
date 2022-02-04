-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 04 Feb 2022 pada 17.27
-- Versi server: 10.4.17-MariaDB
-- Versi PHP: 7.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `afutsal`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_lapang`
--

CREATE TABLE `tb_lapang` (
  `IdLapang` varchar(767) NOT NULL,
  `NamaLapang` text DEFAULT NULL,
  `Fasilitas` text DEFAULT NULL,
  `Tarif` int(11) NOT NULL,
  `Status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_lapang`
--

INSERT INTO `tb_lapang` (`IdLapang`, `NamaLapang`, `Fasilitas`, `Tarif`, `Status`) VALUES
('27UVP', 'Lapangan2', '-', 15000, 1),
('QXUT9', 'Lapangan1', 'Gratis Bola', 25000, 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_reservasi`
--

CREATE TABLE `tb_reservasi` (
  `IdBooking` varchar(767) NOT NULL,
  `Nama` text DEFAULT NULL,
  `NoHP` text DEFAULT NULL,
  `Email` text DEFAULT NULL,
  `Tanggal` datetime NOT NULL,
  `Jam` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_reservasi`
--

INSERT INTO `tb_reservasi` (`IdBooking`, `Nama`, `NoHP`, `Email`, `Tanggal`, `Jam`) VALUES
('NOCCF', 'Afi', '089999999', 'aaaa@gmail.com', '2022-02-17 22:48:00', '00:00:10');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_roles`
--

CREATE TABLE `tb_roles` (
  `Id` varchar(767) NOT NULL,
  `Name` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_roles`
--

INSERT INTO `tb_roles` (`Id`, `Name`) VALUES
('1', 'Admin\r\n'),
('2', 'User');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_user`
--

CREATE TABLE `tb_user` (
  `Username` varchar(767) NOT NULL,
  `Password` text DEFAULT NULL,
  `Email` text DEFAULT NULL,
  `Name` text DEFAULT NULL,
  `RolesId` varchar(767) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tb_user`
--

INSERT INTO `tb_user` (`Username`, `Password`, `Email`, `Name`, `RolesId`) VALUES
('a123', '1234', 'randykelvin26@gmail.com', 'usro', '2'),
('abcd', '123', 'randykelvin26@gmail.com', 'udin', '1'),
('annisa12', '12345', 'randykelvin26@gmail.com', 'Annisa', '1'),
('ba', 'ba', 'randykelvin26@gmail.com', 'Nisa', '1');

-- --------------------------------------------------------

--
-- Struktur dari tabel `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220204030617_tambahtabel', '5.0.13'),
('20220204073304_tabelreservasi', '5.0.13');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tb_lapang`
--
ALTER TABLE `tb_lapang`
  ADD PRIMARY KEY (`IdLapang`);

--
-- Indeks untuk tabel `tb_reservasi`
--
ALTER TABLE `tb_reservasi`
  ADD PRIMARY KEY (`IdBooking`);

--
-- Indeks untuk tabel `tb_roles`
--
ALTER TABLE `tb_roles`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks untuk tabel `tb_user`
--
ALTER TABLE `tb_user`
  ADD PRIMARY KEY (`Username`),
  ADD KEY `IX_Tb_User_RolesId` (`RolesId`);

--
-- Indeks untuk tabel `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `tb_user`
--
ALTER TABLE `tb_user`
  ADD CONSTRAINT `FK_Tb_User_Tb_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `tb_roles` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
