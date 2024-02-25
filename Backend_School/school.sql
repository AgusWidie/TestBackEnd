/*
SQLyog Community v12.4.3 (32 bit)
MySQL - 8.0.28 : Database - school
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`school` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `school`;

/*Table structure for table `absen_guru` */

DROP TABLE IF EXISTS `absen_guru`;

CREATE TABLE `absen_guru` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdGuru` bigint DEFAULT '0',
  `IdKelas` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `NamaAbsen` varchar(50) DEFAULT NULL,
  `TanggalAbsen` date DEFAULT NULL,
  `AbsenMasuk` time DEFAULT NULL,
  `AbsenKeluar` time DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdGuru` (`IdGuru`),
  KEY `TanggalAbsen` (`TanggalAbsen`),
  CONSTRAINT `absen_guru_ibfk_1` FOREIGN KEY (`IdGuru`) REFERENCES `guru` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `absen_guru` */

/*Table structure for table `absen_siswa` */

DROP TABLE IF EXISTS `absen_siswa`;

CREATE TABLE `absen_siswa` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdSiswa` bigint DEFAULT '0',
  `IdKelas` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `NamaAbsen` varchar(50) DEFAULT NULL,
  `Tanggal` date DEFAULT NULL,
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdKelas` (`IdKelas`),
  KEY `IdTahunAjaran` (`IdTahunAjaran`),
  KEY `Tanggal` (`Tanggal`),
  KEY `IdSiswa` (`IdSiswa`),
  CONSTRAINT `absen_siswa_ibfk_1` FOREIGN KEY (`IdSiswa`) REFERENCES `siswa` (`Id`),
  CONSTRAINT `absen_siswa_ibfk_2` FOREIGN KEY (`IdKelas`) REFERENCES `kelas` (`Id`),
  CONSTRAINT `absen_siswa_ibfk_3` FOREIGN KEY (`IdTahunAjaran`) REFERENCES `tahun_ajaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `absen_siswa` */

/*Table structure for table `apikey` */

DROP TABLE IF EXISTS `apikey`;

CREATE TABLE `apikey` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `ApiKey` varchar(500) DEFAULT NULL,
  `ApiName` varchar(500) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `apikey` */

/*Table structure for table `bulan` */

DROP TABLE IF EXISTS `bulan`;

CREATE TABLE `bulan` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Bulan` int DEFAULT '0',
  `NamaBulan` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `bulan` */

insert  into `bulan`(`Id`,`Bulan`,`NamaBulan`,`TanggalBuat`) values 
(1,1,'Januari','2022-08-17 07:31:31'),
(2,2,'Februari','2022-08-17 07:31:48'),
(3,3,'Maret','2022-08-17 07:31:57'),
(4,4,'April','2022-08-17 07:32:06'),
(5,5,'Mei','2022-08-17 07:32:15'),
(6,6,'Juni','2022-08-17 07:32:33'),
(7,7,'Juli','2022-08-17 07:32:42'),
(8,8,'Agustus','2022-08-17 07:32:51'),
(9,9,'September','2022-08-17 07:33:01'),
(10,10,'Oktober','2022-08-17 07:33:11'),
(11,11,'November','2022-08-17 07:33:21'),
(12,12,'Desember','2022-08-17 07:33:31');

/*Table structure for table `config_pembayaran` */

DROP TABLE IF EXISTS `config_pembayaran`;

CREATE TABLE `config_pembayaran` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NamaPembayaran` varchar(50) DEFAULT NULL,
  `IdTahunAjaran` bigint DEFAULT '0',
  `NilaiPembayaran` bigint DEFAULT '0',
  `Aktif` bit(1) DEFAULT NULL,
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `NamaPembayaran` (`NamaPembayaran`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `config_pembayaran` */

/*Table structure for table `daftar_ulang` */

DROP TABLE IF EXISTS `daftar_ulang`;

CREATE TABLE `daftar_ulang` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdSiswa` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `IdTahunAjaranTo` bigint DEFAULT '0',
  `DariKelas` bigint DEFAULT '0',
  `KeKelas` bigint DEFAULT '0',
  `NilaiDaftarUlang` bigint DEFAULT '0',
  `Bayar` bigint DEFAULT '0',
  `Kembalian` bigint DEFAULT '0',
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdSiswa` (`IdSiswa`),
  KEY `IdTahunAjaran` (`IdTahunAjaran`),
  CONSTRAINT `daftar_ulang_ibfk_1` FOREIGN KEY (`IdSiswa`) REFERENCES `siswa` (`Id`),
  CONSTRAINT `daftar_ulang_ibfk_2` FOREIGN KEY (`IdTahunAjaran`) REFERENCES `tahun_ajaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `daftar_ulang` */

/*Table structure for table `guru` */

DROP TABLE IF EXISTS `guru`;

CREATE TABLE `guru` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NomorIndukPegawai` varchar(50) DEFAULT NULL,
  `NoKTP` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `NamaGuru` varchar(50) DEFAULT NULL,
  `JenisKelamin` varchar(50) DEFAULT NULL,
  `Agama` varchar(50) DEFAULT NULL,
  `Alamat` varchar(500) DEFAULT NULL,
  `Pendidikan` varchar(50) DEFAULT NULL,
  `TanggalLahir` date DEFAULT NULL,
  `NoHp` varchar(50) DEFAULT NULL,
  `StatusGuru` varchar(50) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT b'0',
  `FilePhoto` varchar(100) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`,`NoKTP`),
  KEY `NamaGuru` (`NamaGuru`),
  KEY `NomorIndukPegawai` (`NomorIndukPegawai`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `guru` */

/*Table structure for table `jadwal_guru` */

DROP TABLE IF EXISTS `jadwal_guru`;

CREATE TABLE `jadwal_guru` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdGuru` bigint DEFAULT '0',
  `Hari` varchar(50) DEFAULT NULL,
  `IdKelas` bigint DEFAULT '0',
  `IdPelajaran` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `DariJam` time DEFAULT NULL,
  `SampaiJam` time DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdKelas` (`IdKelas`),
  KEY `IdTahunAjaran` (`IdTahunAjaran`),
  KEY `Hari` (`Hari`),
  KEY `IdGuru` (`IdGuru`),
  KEY `IdPelajaran` (`IdPelajaran`),
  CONSTRAINT `jadwal_guru_ibfk_1` FOREIGN KEY (`IdGuru`) REFERENCES `guru` (`Id`),
  CONSTRAINT `jadwal_guru_ibfk_2` FOREIGN KEY (`IdKelas`) REFERENCES `kelas` (`Id`),
  CONSTRAINT `jadwal_guru_ibfk_3` FOREIGN KEY (`IdPelajaran`) REFERENCES `pelajaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `jadwal_guru` */

/*Table structure for table `kelas` */

DROP TABLE IF EXISTS `kelas`;

CREATE TABLE `kelas` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Kelas` int DEFAULT '0',
  `NamaKelas` varchar(50) DEFAULT NULL,
  `Deskripsi` varchar(500) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `NamaKelas` (`NamaKelas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `kelas` */

/*Table structure for table `log_config_pembayaran` */

DROP TABLE IF EXISTS `log_config_pembayaran`;

CREATE TABLE `log_config_pembayaran` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NamaPembayaran` varchar(50) DEFAULT NULL,
  `IdTahunAjaran` bigint DEFAULT '0',
  `NilaiPembayaran` bigint DEFAULT '0',
  `Aktif` bit(1) DEFAULT b'0',
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `log_config_pembayaran` */

/*Table structure for table `log_error` */

DROP TABLE IF EXISTS `log_error`;

CREATE TABLE `log_error` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NamaService` varchar(150) DEFAULT NULL,
  `NamaAction` varchar(150) DEFAULT NULL,
  `ErrorDeskripsi` varchar(500) DEFAULT NULL,
  `TanggalError` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `log_error` */

/*Table structure for table `menu` */

DROP TABLE IF EXISTS `menu`;

CREATE TABLE `menu` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdMenuParent` bigint DEFAULT '0',
  `NamaMenu` varchar(50) DEFAULT NULL,
  `NamaController` varchar(50) DEFAULT NULL,
  `NamaAction` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Type` varchar(5) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT b'0',
  `SortHeader` int DEFAULT '0',
  `Sort` int DEFAULT '0',
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `NamaMenu` (`NamaMenu`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `menu` */

insert  into `menu`(`Id`,`IdMenuParent`,`NamaMenu`,`NamaController`,`NamaAction`,`Type`,`Aktif`,`SortHeader`,`Sort`,`PenggunaBuat`,`TerminalBuat`,`TanggalBuat`,`PenggunaPerbarui`,`TerminalPerbarui`,`TanggalPerbarui`) values 
(1,0,'Master Data','','','H','',1,1,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(2,1,'Data Guru','Guru','Index','C','',1,2,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(3,1,'Data Tahun Ajaran','TahunAjaran','Index','C','',1,3,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(4,1,'Data Kelas','Kelas','Index','C','',1,4,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(5,1,'Data Pelajaran','Pelajaran','Index','C','',1,5,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(6,1,'Data Pelanggaran','Pelanggaran','Index','C','',1,6,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(7,1,'Data Pengguna','Pengguna','Index','C','',1,7,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(8,1,'Data Peran','Role','Index','C','',1,8,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(9,1,'Data Peran Menu','MenuRole','Index','C','',1,9,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(10,1,'Data Siswa','Siswa','Index','C','',1,10,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(11,1,'Data Penilaian','Penilaian','Index','C','',1,11,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(12,1,'Data Jadwal Guru','JadwalGuru','Index','C','',1,12,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(13,1,'Data Wali Kelas','WaliKelas','Index','C','',1,13,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(14,1,'Data Config Pembayaran','ConfigurasiPembayaran','Index','C','',1,14,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(15,0,'Absensi','','','H','',2,1,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(16,15,'Absensi Guru','AbsenGuru','Index','C','',2,2,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(17,15,'Absensi Siswa','AbsenSiswa','Index','C','',2,3,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(18,0,'Administrasi','','','H','',3,1,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(19,18,'Data Daftar Ulang','DaftarUlang','Index','C','',3,2,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(20,18,'Data Pembayaran','Pembayaran','Index','C','',3,3,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(21,18,'Data SPP','SPP','Index','C','',3,4,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(22,18,'Data Uang Bangunan','UangBangunan','Index','C','',3,5,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(23,0,'Guru','','','H','',4,1,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(24,23,'Pelanggaran Siswa','PelanggaranSiswa','Index','C','',4,2,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(25,23,'Penilaian Siswa','PenilaianSiswa','Index','C','',4,3,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(26,23,'Raport Siswa','RaportSiswa','Index','C','',4,4,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15'),
(27,18,'Tabungan Siswa','TabunganSiswa','Index','C','',3,6,'System','System','2022-08-20 19:37:15','System','System','2022-08-20 19:37:15');

/*Table structure for table `menu_role` */

DROP TABLE IF EXISTS `menu_role`;

CREATE TABLE `menu_role` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdRole` bigint DEFAULT '0',
  `IdMenu` bigint DEFAULT '0',
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `menu_role` */

insert  into `menu_role`(`Id`,`IdRole`,`IdMenu`,`PenggunaBuat`,`TerminalBuat`,`TanggalBuat`,`PenggunaPerbarui`,`TerminalPerbarui`,`TanggalPerbarui`) values 
(1,1,1,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(2,1,2,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(3,1,3,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(4,1,4,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(5,1,5,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(6,1,6,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(7,1,7,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(8,1,8,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(9,1,9,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(10,1,10,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(11,1,11,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(12,1,12,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(13,1,13,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(14,1,14,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(15,1,15,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(16,1,16,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(17,1,17,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(18,1,18,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(19,1,19,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(20,1,20,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(21,1,21,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(22,1,22,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(23,1,23,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(24,1,24,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(25,1,25,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(26,1,26,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20'),
(28,1,27,'System','System','2022-08-20 23:15:20','System','System','2022-08-20 23:15:20');

/*Table structure for table `pelajaran` */

DROP TABLE IF EXISTS `pelajaran`;

CREATE TABLE `pelajaran` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NamaPelajaran` varchar(50) DEFAULT NULL,
  `Deskripsi` varchar(500) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `NamaPelajaran` (`NamaPelajaran`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `pelajaran` */

/*Table structure for table `pelanggaran` */

DROP TABLE IF EXISTS `pelanggaran`;

CREATE TABLE `pelanggaran` (
  `Id` bigint NOT NULL,
  `NamaPelanggaran` varchar(50) DEFAULT NULL,
  `Poin` bigint DEFAULT '0',
  `Deskripsi` varchar(500) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT b'0',
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `pelanggaran` */

/*Table structure for table `pelanggaran_siswa` */

DROP TABLE IF EXISTS `pelanggaran_siswa`;

CREATE TABLE `pelanggaran_siswa` (
  `Id` bigint NOT NULL,
  `IdSiswa` bigint DEFAULT '0',
  `IdPelanggaran` bigint DEFAULT '0',
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdSiswa` (`IdSiswa`),
  KEY `IdPelanggaran` (`IdPelanggaran`),
  CONSTRAINT `pelanggaran_siswa_ibfk_1` FOREIGN KEY (`IdSiswa`) REFERENCES `siswa` (`Id`),
  CONSTRAINT `pelanggaran_siswa_ibfk_2` FOREIGN KEY (`IdPelanggaran`) REFERENCES `pelanggaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `pelanggaran_siswa` */

/*Table structure for table `pembayaran` */

DROP TABLE IF EXISTS `pembayaran`;

CREATE TABLE `pembayaran` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdSiswa` bigint DEFAULT '0',
  `IdConfigPembayaran` bigint DEFAULT '0',
  `NilaiPembayaran` bigint DEFAULT '0',
  `Bayar` bigint DEFAULT '0',
  `Kembalian` bigint DEFAULT '0',
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `pembayaran` */

/*Table structure for table `pendaftaran` */

DROP TABLE IF EXISTS `pendaftaran`;

CREATE TABLE `pendaftaran` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `Nama` varchar(50) DEFAULT NULL,
  `JenisKelamin` varchar(50) DEFAULT NULL,
  `Alamat` varchar(50) DEFAULT NULL,
  `NoTelp` varchar(15) DEFAULT NULL,
  `Agama` varchar(50) DEFAULT NULL,
  `IdTahunAjaran` bigint DEFAULT '0',
  `TanggalLahir` date DEFAULT NULL,
  `NamaOrangTua` varchar(50) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Nama` (`Nama`),
  KEY `IdTahunAjaran` (`IdTahunAjaran`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `pendaftaran` */

/*Table structure for table `pengguna` */

DROP TABLE IF EXISTS `pengguna`;

CREATE TABLE `pengguna` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NamaPengguna` varchar(50) DEFAULT NULL,
  `IdGuru` bigint DEFAULT '0',
  `Nama` varchar(50) DEFAULT NULL,
  `Pass` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `StatusPengguna` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ExpiredPassword` datetime DEFAULT NULL,
  `Aktif` bit(1) DEFAULT b'0',
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `pengguna` */

insert  into `pengguna`(`Id`,`NamaPengguna`,`IdGuru`,`Nama`,`Pass`,`Email`,`StatusPengguna`,`ExpiredPassword`,`Aktif`,`Deskripsi`,`PenggunaBuat`,`TerminalBuat`,`TanggalBuat`,`PenggunaPerbarui`,`TerminalPerbarui`,`TanggalPerbarui`) values 
(1,'agus',0,'Agus','12345','aguswidie20@gmail.com','','2022-10-20 23:08:39','','','System','System','2022-08-20 23:09:10','System','System','2022-08-20 23:09:10');

/*Table structure for table `pengguna_role` */

DROP TABLE IF EXISTS `pengguna_role`;

CREATE TABLE `pengguna_role` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdPengguna` bigint DEFAULT '0',
  `IdRole` bigint DEFAULT '0',
  `Deskripsi` varchar(500) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT b'0',
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdPengguna` (`IdPengguna`),
  KEY `IdMenu` (`IdRole`),
  CONSTRAINT `pengguna_role_ibfk_1` FOREIGN KEY (`IdRole`) REFERENCES `menu` (`Id`),
  CONSTRAINT `pengguna_role_ibfk_2` FOREIGN KEY (`IdPengguna`) REFERENCES `pengguna` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `pengguna_role` */

insert  into `pengguna_role`(`Id`,`IdPengguna`,`IdRole`,`Deskripsi`,`Aktif`,`PenggunaBuat`,`TerminalBuat`,`TanggalBuat`,`PenggunaPerbarui`,`TerminalPerbarui`,`TanggalPerbarui`) values 
(1,1,1,'','','System','System','2022-08-20 23:10:01','System','System','2022-08-20 23:10:01');

/*Table structure for table `penilaian` */

DROP TABLE IF EXISTS `penilaian`;

CREATE TABLE `penilaian` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdPelajaran` bigint DEFAULT '0',
  `NamaPenilaian` varchar(50) DEFAULT NULL,
  `Deskripsi` varchar(500) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `NamaPenilaian` (`NamaPenilaian`),
  KEY `IdPelajaran` (`IdPelajaran`),
  CONSTRAINT `penilaian_ibfk_1` FOREIGN KEY (`IdPelajaran`) REFERENCES `pelajaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `penilaian` */

/*Table structure for table `penilaian_siswa` */

DROP TABLE IF EXISTS `penilaian_siswa`;

CREATE TABLE `penilaian_siswa` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdSiswa` bigint DEFAULT '0',
  `IdKelas` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `IdPenilaian` bigint DEFAULT '0',
  `Nilai` decimal(10,2) DEFAULT NULL,
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdSiswa` (`IdSiswa`),
  KEY `IdTahunAjaran` (`IdTahunAjaran`),
  KEY `IdPenilaian` (`IdPenilaian`),
  CONSTRAINT `penilaian_siswa_ibfk_1` FOREIGN KEY (`IdSiswa`) REFERENCES `siswa` (`Id`),
  CONSTRAINT `penilaian_siswa_ibfk_2` FOREIGN KEY (`IdTahunAjaran`) REFERENCES `tahun_ajaran` (`Id`),
  CONSTRAINT `penilaian_siswa_ibfk_3` FOREIGN KEY (`IdPenilaian`) REFERENCES `penilaian` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `penilaian_siswa` */

/*Table structure for table `raport_siswa` */

DROP TABLE IF EXISTS `raport_siswa`;

CREATE TABLE `raport_siswa` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdSiswa` bigint DEFAULT '0',
  `IdKelas` bigint DEFAULT '0',
  `IdPelajaran` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `Nilai` decimal(10,2) DEFAULT '0.00',
  `Keterangan` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdSiswa` (`IdSiswa`),
  KEY `IdTahunAjaran` (`IdTahunAjaran`),
  KEY `IdKelas` (`IdKelas`),
  KEY `IdPelajaran` (`IdPelajaran`),
  CONSTRAINT `raport_siswa_ibfk_1` FOREIGN KEY (`IdSiswa`) REFERENCES `siswa` (`Id`),
  CONSTRAINT `raport_siswa_ibfk_2` FOREIGN KEY (`IdTahunAjaran`) REFERENCES `tahun_ajaran` (`Id`),
  CONSTRAINT `raport_siswa_ibfk_3` FOREIGN KEY (`IdKelas`) REFERENCES `kelas` (`Id`),
  CONSTRAINT `raport_siswa_ibfk_4` FOREIGN KEY (`IdPelajaran`) REFERENCES `pelajaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `raport_siswa` */

/*Table structure for table `role` */

DROP TABLE IF EXISTS `role`;

CREATE TABLE `role` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NamaRole` varchar(50) DEFAULT NULL,
  `Deskripsi` varchar(500) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT b'0',
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `role` */

insert  into `role`(`Id`,`NamaRole`,`Deskripsi`,`Aktif`,`PenggunaBuat`,`TerminalBuat`,`TanggalBuat`,`PenggunaPerbarui`,`TerminalPerbarui`,`TanggalPerbarui`) values 
(1,'Admin','','','System','System','2022-08-20 20:19:56','System','System','2022-08-20 20:19:56'),
(2,'Administrasi','','','System','System','2022-08-20 20:19:56','System','System','2022-08-20 20:19:56'),
(3,'Guru','','','System','System','2022-08-20 20:19:56','System','System','2022-08-20 20:19:56');

/*Table structure for table `siswa` */

DROP TABLE IF EXISTS `siswa`;

CREATE TABLE `siswa` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NomorIndukSiswa` varchar(50) DEFAULT NULL,
  `NamaSiswa` varchar(50) DEFAULT NULL,
  `JenisKelamin` varchar(50) DEFAULT NULL,
  `Alamat` varchar(500) DEFAULT NULL,
  `Agama` varchar(50) DEFAULT NULL,
  `TanggalLahir` date DEFAULT NULL,
  `NoHp` varchar(15) DEFAULT NULL,
  `IdKelas` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `NamaOrangTua` varchar(50) DEFAULT NULL,
  `AlamatOrangTua` varchar(500) DEFAULT NULL,
  `NoHpOrangTua` varchar(50) DEFAULT NULL,
  `PenghasilanOrangTua` bigint DEFAULT '0',
  `Aktif` bit(1) DEFAULT b'0',
  `FilePhoto` varchar(100) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdTahunAjaran` (`IdTahunAjaran`),
  KEY `NamaSiswa` (`NamaSiswa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `siswa` */

/*Table structure for table `spp` */

DROP TABLE IF EXISTS `spp`;

CREATE TABLE `spp` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdSiswa` bigint DEFAULT '0',
  `IdKelas` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `Tahun` int DEFAULT '0',
  `Bulan` int DEFAULT '0',
  `NamaBulan` varchar(50) DEFAULT NULL,
  `NilaiSPP` bigint DEFAULT '0',
  `Bayar` bigint DEFAULT '0',
  `Kembalian` bigint DEFAULT '0',
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdSiswa` (`IdSiswa`),
  KEY `IdTahunAjaran` (`IdTahunAjaran`),
  KEY `Tahun` (`Tahun`),
  KEY `Bulan` (`Bulan`),
  CONSTRAINT `spp_ibfk_1` FOREIGN KEY (`IdSiswa`) REFERENCES `siswa` (`Id`),
  CONSTRAINT `spp_ibfk_2` FOREIGN KEY (`IdTahunAjaran`) REFERENCES `tahun_ajaran` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `spp` */

/*Table structure for table `tabungan_siswa` */

DROP TABLE IF EXISTS `tabungan_siswa`;

CREATE TABLE `tabungan_siswa` (
  `Id` bigint NOT NULL,
  `IdSiswa` bigint DEFAULT '0',
  `IdKelas` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `Debit` bigint DEFAULT '0',
  `Credit` bigint DEFAULT '0',
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tabungan_siswa` */

/*Table structure for table `tahun_ajaran` */

DROP TABLE IF EXISTS `tahun_ajaran`;

CREATE TABLE `tahun_ajaran` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `TahunAjaran` varchar(50) DEFAULT NULL,
  `Deskripsi` varchar(500) DEFAULT NULL,
  `Aktif` bit(1) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `TahunAjaran` (`TahunAjaran`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tahun_ajaran` */

/*Table structure for table `token` */

DROP TABLE IF EXISTS `token`;

CREATE TABLE `token` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `NamaPengguna` varchar(50) DEFAULT NULL,
  `NamaGuru` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Token` varchar(500) DEFAULT NULL,
  `ExpiredToken` datetime DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `token` */

/*Table structure for table `uang_bangunan` */

DROP TABLE IF EXISTS `uang_bangunan`;

CREATE TABLE `uang_bangunan` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `IdSiswa` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `Tanggal` datetime DEFAULT NULL,
  `NilaiUangBangunan` bigint DEFAULT '0',
  `Tahun` bigint DEFAULT '0',
  `Bayar` bigint DEFAULT '0',
  `SisaBayar` bigint DEFAULT '0',
  `Keterangan` varchar(50) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdSiswa` (`IdSiswa`),
  CONSTRAINT `uang_bangunan_ibfk_1` FOREIGN KEY (`IdSiswa`) REFERENCES `siswa` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `uang_bangunan` */

/*Table structure for table `wali_kelas` */

DROP TABLE IF EXISTS `wali_kelas`;

CREATE TABLE `wali_kelas` (
  `Id` bigint NOT NULL,
  `IdGuru` bigint DEFAULT '0',
  `IdKelas` bigint DEFAULT '0',
  `IdTahunAjaran` bigint DEFAULT '0',
  `Deskripsi` varchar(500) DEFAULT NULL,
  `PenggunaBuat` varchar(50) DEFAULT NULL,
  `TerminalBuat` varchar(50) DEFAULT NULL,
  `TanggalBuat` datetime DEFAULT NULL,
  `PenggunaPerbarui` varchar(50) DEFAULT NULL,
  `TerminalPerbarui` varchar(50) DEFAULT NULL,
  `TanggalPerbarui` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdGuru` (`IdGuru`),
  KEY `IdKelas` (`IdKelas`),
  CONSTRAINT `wali_kelas_ibfk_1` FOREIGN KEY (`IdGuru`) REFERENCES `guru` (`Id`),
  CONSTRAINT `wali_kelas_ibfk_2` FOREIGN KEY (`IdKelas`) REFERENCES `kelas` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `wali_kelas` */

/* Procedure structure for procedure `sp_AddAbsenGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddAbsenGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddAbsenGuru`(
 IN IdGuru LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN NamaAbsen VARCHAR(50), IN TanggalAbsen DATETIME,
 IN AbsenMasuk TIME, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	INSERT INTO absen_guru (IdGuru, IdKelas, IdTahunAjaran, NamaAbsen, TanggalAbsen, AbsenMasuk, PenggunaBuat,
	                        TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui
	                        )
	VALUES (IdGuru, IdKelas, IdTahunAjaran, NamaAbsen, TanggalAbsen, AbsenMasuk, 
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT absen_guru.Id, absen_guru.IdGuru, guru.NamaGuru, absen_guru.IdKelas, kelas.NamaKelas, absen_guru.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, absen_guru.NamaAbsen, absen_guru.TanggalAbsen, absen_guru.AbsenMasuk, absen_guru.AbsenKeluar,
	       absen_guru.PenggunaBuat, absen_guru.TerminalBuat, absen_guru.TanggalBuat, absen_guru.PenggunaPerbarui, 
	       absen_guru.TerminalPerbarui, absen_guru.TanggalPerbarui
	FROM absen_guru LEFT JOIN guru ON absen_guru.IdGuru = guru.Id 
	                         LEFT JOIN kelas ON absen_guru.IdKelas = kelas.Id
	                         LEFT JOIN tahun_ajaran ON absen_guru.IdTahunAjaran = tahun_ajaran.Id
	WHERE absen_guru.IdGuru = IdGuru AND absen_guru.IdKelas = IdKelas AND absen_guru.IdTahunAjaran = IdTahunAjaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddAbsenSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddAbsenSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddAbsenSiswa`(
 IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN NamaAbsen VARCHAR(50), IN TanggalAbsen DATETIME,
 IN Deskripsi VARCHAR(50), IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	INSERT INTO absen_siswa (IdSiswa, IdKelas, IdTahunAjaran, NamaAbsen, TanggalAbsen, Deskripsi,
	                        TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                        )
	VALUES (IdSiswa, IdKelas, IdTahunAjaran, NamaAbsen, TanggalAbsen, AbsenMasuk, 
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT absen_siswa.Id, absen_siswa.IdSiswa, siswa.NamaSiswa, absen_siswa.IdKelas, kelas.NamaKelas, absen_siswa.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, absen_siswa.NamaAbsen, absen_siswa.TanggalAbsen, absen_siswa.Deskripsi, 
	       absen_siswa.PenggunaBuat, absen_siswa.TerminalBuat, absen_siswa.TanggalBuat, absen_siswa.PenggunaPerbarui, 
	       absen_siswa.TerminalPerbarui, absen_siswa.TanggalPerbarui
	FROM absen_siswa LEFT JOIN siswa ON absen_siswa.IdSiswa = siswa.Id 
	                 LEFT JOIN kelas ON absen_guru.IdKelas = kelas.Id
	                 LEFT JOIN tahun_ajaran ON absen_guru.IdTahunAjaran = tahun_ajaran.Id
	WHERE IdSiswa = IdSiswa AND IdKelas = IdKelas AND IdTahunAjaran = IdTahunAjaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddConfigPembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddConfigPembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddConfigPembayaran`(
 IN NamaPembayaran VARCHAR(50), IN IdTahunAjaran long, IN NilaiPembayaran LONG, IN Aktif BIT, IN Deskripsi VARCHAR(50), 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
	INSERT INTO config_pembayaran (NamaPembayaran, IdTahunAjaran, NilaiPembayaran, Aktif, Deskripsi,
	                               PenggunaBuat, TerminalBuat, TanggalBuat 
	                              )
	VALUES (NamaPembayaran, IdTahunAjaran, NilaiPembayaran, Aktif, Deskripsi, 
	        PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT * FROM config_pembayaran 
	WHERE config_pembayaran.NamaPembayaran = NamaPembayaran and config_pembayaran.IdTahunAjaran = IdTahunAjaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddDaftarUlang` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddDaftarUlang` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddDaftarUlang`(
 IN IdSiswa LONG, IN IdTahunAjaran LONG, IN IdTahunAjaranTo LONG, IN DariKelas LONG, IN KeKelas LONG, IN NilaiDaftarUlang LONG,
 IN Bayar LONG, IN Kembalian LONG, IN Deskripsi VARCHAR(50), IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	INSERT INTO daftar_ulang (IdSiswa, IdTahunAjaran, IdTahunAjaranTo, DariKelas, KeKelas, NilaiDaftarUlang, Bayar,
	                          Kembalian, Deskripsi, PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
	VALUES (IdSiswa, IdTahunAjaran, IdTahunAjaranTo, DariKelas, KeKelas, NilaiDaftarUlang, Bayar, Kembalian, Deskripsi,
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	        
	
	SELECT daftar_ulang.Id, daftar_ulang.IdSiswa, siswa.NamaSiswa, 
	       daftar_ulang.IdTahunAjaran, tahun_ajaran.TahunAjaran, daftar_ulang.IdTahunAjaranTo, TahunAjaranTo.TahunAjaran AS TahunAjaranTo, 
	       daftar_ulang.DariKelas, kelas.NamaKelas AS NamaDariKelas, daftar_ulang.KeKelas, KeKelas.NamaKelas AS NamaKeKelas,
	       daftar_ulang.NilaiDaftarUlang, daftar_ulang.Bayar, daftar_ulang.Kembalian, daftar_ulang.Deskripsi, 
	       daftar_ulang.PenggunaBuat, daftar_ulang.TerminalBuat, daftar_ulang.TanggalBuat, 
	       daftar_ulang.PenggunaPerbarui, daftar_ulang.TerminalPerbarui, daftar_ulang.TanggalPerbarui
	FROM daftar_ulang LEFT JOIN siswa ON daftar_ulang.IdSiswa = siswa.Id 
	                  LEFT JOIN kelas ON daftar_ulang.DariKelas = kelas.Id
	                  LEFT JOIN kelas AS KeKelas ON daftar_ulang.KeKelas = KeKelas.Id
	                  LEFT JOIN tahun_ajaran ON daftar_ulang.IdTahunAjaran = tahun_ajaran.Id
	                  LEFT JOIN tahun_ajaran AS TahunAjaranTo ON daftar_ulang.IdTahunAjaranTo = TahunAjaranTo.Id
	WHERE daftar_ulang.IdSiswa = IdSiswa AND daftar_ulang.IdKelas = IdKelas AND daftar_ulang.IdTahunAjaran = IdTahunAjaran;
	

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddGuru`(
 IN NomorIndukPegawai VARCHAR(50), IN NoKTP VARCHAR(50), IN NamaGuru VARCHAR(50), IN JenisKelamin VARCHAR(50), 
 IN StatusGuru VARCHAR(50), IN Agama VARCHAR(50), IN Alamat VARCHAR(50), IN Pendidikan VARCHAR(50),
 IN TanggalLahir DATETIME, IN NoHp VARCHAR(50), IN Aktif BIT, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
	INSERT INTO guru (NomorIndukPegawai, NoKTP, NamaGuru, JenisKelamin, StatusGuru, Agama, Alamat, Pendidikan, 
	                  TanggalLahir, NoHp, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                 )
	VALUES (NomorIndukPegawai, NoKTP, NamaGuru, JenisKelamin, StatusGuru, Agama, Alamat, Pendidikan, TanggalLahir, NoHp, Aktif,
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT NomorIndukPegawai, NoKTP, NamaGuru, JenisKelamin, StatusGuru, Agama, Alamat, Pendidikan, 
	       TanggalLahir, NoHp, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat,
	       PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui
	FROM guru 
	WHERE NoKTP = NoKTP;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddJadwalGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddJadwalGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddJadwalGuru`(
 IN IdGuru LONG, IN Hari VARCHAR(50), IN IdKelas LONG, IN IdPelajaran LONG, IN IdTahunAjaran LONG, 
 IN DariJam TIME, IN SampaiJam TIME, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	INSERT INTO jadwal_guru (IdGuru, Hari, IdKelas, IdPelajaran, IdTahunAjaran, DariJam, SampaiJam, PenggunaBuat,
	                         TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                        )
	VALUES (IdGuru, Hari, IdKelas, IdPelajaran, IdTahunAjaran, DariJam, SampaiJam, 
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT jadwal_guru.Id, jadwal_guru.IdGuru, guru.NamaGuru, jadwal_guru.IdKelas, kelas.NamaKelas, 
	       jadwal_guru.IdPelajaran, pelajaran.NamaPelajaran, jadwal_guru.DariJam, jadwal_guru.SampaiJam,
	       jadwal_guru.IdTahunAjaran, tahun_ajaran.TahunAjaran, 
	       jadwal_guru.PenggunaBuat, jadwal_guru.TerminalBuat, jadwal_guru.TanggalBuat, jadwal_guru.PenggunaPerbarui, 
	       jadwal_guru.TerminalPerbarui, jadwal_guru.TanggalPerbarui
	FROM jadwal_guru LEFT JOIN guru ON jadwal_guru.IdGuru = guru.Id 
	                         LEFT JOIN kelas ON jadwal_guru.IdKelas = kelas.Id
	                         LEFT JOIN tahun_ajaran ON jadwal_guru.IdTahunAjaran = tahun_ajaran.Id
	                         LEFT JOIN pelajaran ON jadwal_guru.IdPelajaran = pelajaran.Id
	WHERE IdGuru = IdGuru AND Hari = Hari AND IdKelas = IdKelas AND IdTahunAjaran = IdTahunAjaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddKelas`(
 IN NamaKelas VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
	INSERT INTO kelas (NamaKelas, Deskripsi, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat,
	                   PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                  )
	VALUES (NamaKelas, Deskripsi, Aktif,
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT * FROM kelas 
	WHERE NamaKelas = NamaKelas;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddMenuRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddMenuRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddMenuRole`(
 IN IdRole LONG, IN IdMenu LONG, IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	INSERT INTO menu_role (IdRole, IdMenu, PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
	VALUES (IdRole, IdMenu, PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT menu_role.Id, menu_role.IdRole, role.NamaRole, menu_role.IdMenu, menu.NamaMenu,
	       menu_role.PenggunaBuat, menu_role.TerminalBuat, menu_role.TanggalBuat, 
	       menu_role.PenggunaPerbarui, menu_role.TerminalPerbarui, menu_role.TanggalPerbarui
	FROM menu_role 
	                        LEFT JOIN role ON menu_role.IdRole = role.Id
	                        LEFT JOIN menu ON menu_role.IdMenu = menu.Id
	WHERE menu_role.IdRole = IdRole AND menu_role.IdMenu = IdMenu;
	                        

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddPelajaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddPelajaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddPelajaran`(
 IN NamaPelajaran VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
	INSERT INTO pelanggaran (NamaPelajaran, Deskripsi, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat,
	                         PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                        )
	VALUES (NamaPelajaran, Deskripsi, Aktif,
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT * FROM pelajaran 
	WHERE NamaPelajaran = NamaPelanggaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddPelanggaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddPelanggaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddPelanggaran`(
 IN NamaPelanggaran VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
	INSERT INTO pelanggaran (NamaPelanggaran, Deskripsi, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat,
	                         PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                        )
	VALUES (NamaPelanggaran, Deskripsi, Aktif,
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT * FROM pelanggaran 
	WHERE NamaPelanggaran = NamaPelanggaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddPelanggaranSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddPelanggaranSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddPelanggaranSiswa`(
 IN IdSiswa LONG, IN IdPelanggaran LONG, IN Deskripsi VARCHAR(50), 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        insert into pelanggaran_siswa (IdSiswa, IdPelanggaran, Deskripsi, 
                    PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
        values (IdSiswa, IdPelanggaran, Deskripsi, 
                PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT pelanggaran_siswa.Id, pelanggaran_siswa.IdSiswa, siswa.NamaSiswa, 
	       pelanggaran_siswa.IdPelanggaran, pelanggaran.NamaPelanggaran, pelanggaran.Poin, 
	       pelanggaran_siswa.Deskripsi, pelanggaran_siswa.PenggunaBuat, 
	       pelanggaran_siswa.TerminalBuat, pelanggaran_siswa.TanggalBuat,
	       pelanggaran_siswa.PenggunaPerbarui, pelanggaran_siswa.TerminalPerbarui,
	       pelanggaran_siswa.TanggalPerbarui
	FROM pelanggaran_siswa 
	              left join siswa on pelanggaran_siswa.IdSiswa = siswa.Id
	              left join pelanggaran on pelanggaran_siswa.IdPelanggaran = pelanggaran.Id
	WHERE pelanggaran_siswa.IdSiswa = IdSiswa and pelanggaran_siswa.IdPelanggaran = IdPelanggaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddPembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddPembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddPembayaran`(
 IN IdSiswa LONG, IN IdConfigPembayaran LONG, IN NilaiPembayaran LONG, IN Bayar LONG, IN Deskripsi VARCHAR(50),
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        INSERT INTO pembayaran (IdSiswa, IdConfigPembayaran, NilaiPembayaran, Bayar, Kembalian, Deskripsi, 
                                PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
        VALUES (IdSiswa, IdConfigPembayaran, NilaiPembayaran, Bayar, Bayar - NilaiPembayaran, Deskripsi, 
                PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
        
        SELECT pembayaran.Id, pembayaran.IdSiswa, siswa.NamaSiswa, pembayaran.IdConfigPembayaran, config_pembayaran.NamaPembayaran, 
               pembayaran.NilaiPembayaran, tahun_ajaran.TahunAjaran, pembayaran.Bayar, pembayaran.Kembalian, pembayaran.Deskripsi,
               pembayaran.PenggunaBuat, pembayaran.TerminalBuat, pembayaran.TanggalBuat, 
               pembayaran.PenggunaPerbarui, pembayaran.TerminalPerbarui, pembayaran.TanggalPerbarui
        FROM pembayaran LEFT JOIN siswa ON pembayaran.IdSiswa = siswa.Id
                        LEFT JOIN config_pembayaran ON pembayaran.IdConfigPembayaran = config_pembayaran.Id
                        LEFT JOIN tahun_ajaran ON config_pembayaran.IdTahunAjaran = tahun_ajaran.Id
        WHERE pembayaran.IdSiswa = IdSiswa AND pembayaran.IdConfigPembayaran = IdConfigPembayaran;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddPengguna` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddPengguna` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddPengguna`(
 IN NamaPengguna VARCHAR(50), IN IdGuru LONG, IN Pass VARCHAR(50), IN Email VARCHAR(50),
 IN StatusPengguna VARCHAR(50), IN ExpiredPassword DATETIME, IN Aktif BIT,
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        INSERT INTO pengguna (NamaPengguna, IdGuru, Pass, Email, StatusPengguna, ExpiredPassword, Aktif,
                              PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
        VALUES (NamaPengguna, IdGuru, Pass, Email, StatusPengguna, ExpiredPassword, Aktif,
                PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);

        SELECT pengguna.Id, pengguna.NamaPengguna, pengguna.IdGuru, guru.NamaGuru, pengguna.Pass, 
               pengguna.Email, pengguna.StatusPengguna, pengguna.ExpiredPassword, pengguna.Aktif,
               pengguna.PenggunaBuat, pengguna.TerminalBuat, pengguna.TanggalBuat, 
               pengguna.PenggunaPerbarui, pengguna.TerminalPerbarui, pengguna.TanggalPerbarui
        FROM pengguna JOIN guru ON pengguna.IdGuru = guru.Id
             
        WHERE pengguna.NamaPengguna = NamaPengguna;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddPenggunaRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddPenggunaRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddPenggunaRole`(
 IN IdPengguna LONG, IN IdRole LONG, IN Deskripsi VARCHAR(50), IN Aktif BIT,
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        INSERT INTO pengguna_role (IdPengguna, IdRole, Deskripsi, Aktif, 
                                   PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
        VALUES (IdPengguna, IdRole, Deskripsi, Aktif, 
                PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
        
        SELECT pengguna_role.Id, pengguna_role.IdPengguna, pengguna.NamaPengguna, pengguna_role.IdRole, role.NamaRole, pengguna_role.Deskripsi,
               pengguna_role.PenggunaBuat, pengguna_role.TerminalBuat, pengguna_role.TanggalBuat, 
               pengguna_role.PenggunaPerbarui, pengguna_role.TerminalPerbarui, pengguna_role.TanggalPerbarui
        FROM pengguna_role LEFT JOIN pengguna ON pengguna_role.IdPengguna = pengguna.Id
                           LEFT JOIN role ON pengguna_role.IdRole = role.Id
        WHERE pengguna_role.IdPengguna = IdPengguna AND pengguna_role.IdRole = IdRole;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddPenilaian` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddPenilaian` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddPenilaian`(
 IN IdPelajaran LONG, IN NamaPenilaian VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
	INSERT INTO penilaian (IdPelajaran, NamaPenilaian, Deskripsi, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat, 
	                       PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
	VALUES (IdPelajaran, NamaPenilaian, Deskripsi, Aktif,
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT penilaian.Id, penilaian.Idpelajaran, pelajaran.NamaPelajaran, penilaian.NamaPenilaian, penilaian.Deskripsi, penilaian.Aktif,
	       penilaian.PenggunaBuat, penilaian.TerminalBuat, penilaian.TanggalBuat, 
	       penilaian.PenggunaPerbarui, penilaian.TerminalPerbarui, penilaian.TanggalPerbarui
	FROM penilaian 
			LEFT JOIN pelajaran ON penilaian.IdPelajaran = pelajaran.Id
	WHERE penilaian.IdPelajaran = IdPelajaran AND penilaian.NamaPenilaian = NamaPenilaian;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddPenilaianSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddPenilaianSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddPenilaianSiswa`(
 IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN IdPenilaian LONG, IN Nilai decimal,
 IN Deskripsi VARCHAR(50), IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
       insert into penilaian_siswa (IdSiswa, IdKelas, IdTahunAjaran, IdPenilaian, Nilai,
                                    Deskripsi, PenggunaBuat, TerminalBuat, TanggalBuat,
                                    PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
       values (IdSiswa, IdKelas, IdTahunAjaran, Nilai, Deskripsi, PenggunaBuat, TerminalBuat, TanggalBuat,
               PenggunaBuat, TerminalBuat, TanggalBuat);
               
       
       SELECT penilaian_siswa.Id, penilaian_siswa.IdSiswa, siswa.NamaSiswa, penilaian_siswa.IdTahunAjaran, tahun_ajaran.TahunAjaran,
              penilaian_siswa.IdPenilaian, pelajaran.NamaPelajaran, penilaian.NamaPenilaian, penilaian_siswa.Nilai, penilaian_siswa.Deskripsi,
	      penilaian_siswa.PenggunaBuat, penilaian_siswa.TerminalBuat, penilaian_siswa.TanggalBuat, 
	      penilaian_siswa.PenggunaPerbarui, penilaian_siswa.TerminalPerbarui, penilaian_siswa.TanggalPerbarui
       FROM penilaian_siswa 
		 JOIN siswa ON penilaian_siswa.IdSiswa = siswa.Id
		 JOIN kelas ON penilaian_siswa.IdKelas = kelas.Id
		 JOIN tahun_ajaran ON penilaian_siswa.IdTahunAjaran = tahun_ajaran.Id
		 JOIN penilaian ON penilaian_siswa.IdPenilaian = penilaian.Id
		 JOIN pelajaran ON penilaian.IdPelajaran = pelajaran.Id
       WHERE penilaian_siswa.IdSiswa = IdSiswa AND penilaian_siswa.IdKelas = IdKelas And penilaian_siswa.IdTahunAjaran = IdTahunAjaran
             and penilaian_siswa.IdPenilaian = IdPenilaian;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddRaportSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddRaportSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddRaportSiswa`(
 IN IdSiswa LONG, IN IdKelas LONG, IN IdPelajaran LONG, IN IdTahunAjaran LONG, IN Nilai decimal,
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
       insert into raport_siswa (IdSiswa, IdKelas, IdPelajaran, IdTahunAjaran, Nilai,
                                 PenggunaBuat, TerminalBuat, TanggalBuat, 
                                 PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui) 
       values (IdSiswa, IdKelas, IdPelajaran, IdTahunAjaran, Nilai, PenggunaBuat, TerminalBuat, TanggalBuat,
               PenggunaBuat, TerminalBuat, TanggalBuat);
               
       Select raport_siswa.Id, raport_siswa.IdSiswa, siswa.NamaSiswa, raport_siswa.IdKelas, kelas.NamaKelas, 
              raport_siswa.IdPelajaran, pelajaran.NamaPelajaran, raport_siswa.IdTahunAjaran, tahun_ajaran.TahunAjaran,
              raport_siswa.Nilai, raport_siswa.PenggunaBuat, raport_siswa.TerminalBuat, raport_siswa.TanggalBuat,
              raport_siswa.PenggunaPerbarui, raport_siswa.TerminalPerbarui, raport_siswa.TanggalPerbarui
       From raport_siswa 
                     left join siswa on raport_siswa.IdSiswa = siswa.Id
                     left join kelas on raport_siswa.IdKelas = kelas.Id
                     left join pelajaran on raport_siswa.IdPelajaran = pelajaran.Id
                     left join tahun_ajaran on raport_siswa.IdTahunAjaran = tahun_ajaran.Id
       Where raport_siswa.IdSiswa = IdSiswa and raport_siswa.Idkelas = Idkelas 
             and raport_siswa.IdPelajaran = IdPelajaran and raport_siswa.IdTahunAjaran = IdTahunAjaran;
        
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddRole`(
 IN NamaRole VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
	INSERT INTO role (NamaRole, Deskripsi, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat, 
	                       PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
	VALUES (NamaRole, Deskripsi, Aktif,
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT * FROM role
	WHERE role.NamaRole = NamaRole;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddSiswa`(
 IN NomorIndukSiswa VARCHAR(50), IN NamaSiswa VARCHAR(50), IN JenisKelamin VARCHAR(50), IN Alamat VARCHAR(50), 
 IN Agama VARCHAR(50), IN TanggalLahir DATETIME, IN NoHp VARCHAR(50), IN IdKelas LONG, IN IdTahunAjaran LONG,
 IN NamaOrangTua VARCHAR(50), IN AlamatOrangTua VARCHAR(500), IN NoHpOrangTua VARCHAR(500), IN PenghasilanOrangTua LONG,
 IN Aktif BIT, IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	INSERT INTO siswa (NomorIndukSiswa, NamaSiswa, JenisKelamin, Alamat, Agama, TanggalLahir, NoHp, IdKelas, IdTahunAjaran,
	                   NamaOrangTua, AlamatOrangTua, NoHpOrangTua, PenghasilanOrangTua,
	                   Aktif, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                  )
	VALUES (NomorIndukSiswa, NamaSiswa, JenisKelamin, Alamat, Agama, TanggalLahir, NoHp, IdKelas, IdTahunAjaran, 
	        NamaOrangTua, AlamatOrangTua, NoHpOrangTua, PenghasilanOrangTua,
	        Aktif, PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT siswa.Id, siswa.NamaSiswa, siswa.IdKelas, kelas.NamaKelas, siswa.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, siswa.JenisKelamin, siswa.Alamat, siswa.Agama, siswa.TanggalLahir, siswa.NoHp, 
	       siswa.NamaOrangTua,  siswa.AlamatOrangTua,  siswa.NoHpOrangTua,  siswa.PenghasilanOrangTua,
	       siswa.PenggunaBuat, siswa.TerminalBuat, siswa.TanggalBuat, siswa.PenggunaPerbarui, 
	       siswa.TerminalPerbarui, siswa.TanggalPerbarui
	FROM siswa LEFT JOIN kelas ON siswa.IdKelas = kelas.Id 
	           LEFT JOIN tahun_ajaran ON siswa.IdTahunAjaran = tahun_ajaran.Id
	WHERE siswa.NomorIndukSiswa = NomorIndukSiswa;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddSPP` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddSPP` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddSPP`(
 IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN Tahun int, IN Bulan int, IN NamaBulan VARCHAR(50),
 IN NilaiSPP LONG, IN Bayar LONG, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	INSERT INTO spp (IdSiswa, IdKelas, IdTahunAjaran, Tahun, Bulan, NamaBulan, NilaiSPP, Bayar, Kembalian, 
	                 TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                )
	VALUES (IdSiswa, IdKelas, IdTahunAjaran, Tahun, Bulan, NamaBulan, NilaiSPP, Bayar, Bayar - NilaiSPP, 
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT spp.Id, spp.IdSiswa, siswa.NamaSiswa, spp.IdKelas, kelas.NamaKelas, spp.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, spp.Tahun, spp.Bulan, spp.NamaBulan, spp.NilaiSPP, spp.Bayar, spp.Kembalian,
	       spp.PenggunaBuat, spp.TerminalBuat, spp.TanggalBuat, spp.PenggunaPerbarui, 
	       spp.TerminalPerbarui, spp.TanggalPerbarui
	FROM spp left join siswa on spp.IdSiswa = siswa.Id 
	         LEFT JOIN kelas ON spp.IdKelas = kelas.Id 
	         LEFT JOIN tahun_ajaran ON spp.IdTahunAjaran = tahun_ajaran.Id
	WHERE spp.IdSiswa = IdSiswa and spp.IdKelas = IdKelas and spp.IdTahunAjaran = IdTahunAjaran 
	      and spp.Tahun = Tahun and spp.Bulan = Bulan;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddTahunAjaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddTahunAjaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddTahunAjaran`(
 IN TahunAjaran VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
        
	INSERT INTO tahun_ajaran (TahunAjaran, Deskripsi, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat, 
	                       PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui)
	VALUES (TahunAjaran, Deskripsi, Aktif,
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT * FROM tahun_ajaran
	WHERE tahun_ajaran.TahunAjaran = TahunAjaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddToken` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddToken` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddToken`(
 IN NamaPengguna VARCHAR(50), IN NamaGuru VARCHAR(50), IN Email VARCHAR(50), IN Token VARCHAR(500),
 IN ExpiredToken DATETIME, IN TanggalBuat DATETIME
)
BEGIN
	DELETE FROM token WHERE ExpiredTanggal < NOW();
	
	INSERT INTO token (NamaPengguna, NamaGuru, Email, Token, ExpiredToken, TanggalBuat)
	VALUES (NamaPengguna, NamaGuru, Email, Token, ExpiredToken, TanggalBuat);
	
	SELECT NamaPengguna, Token, ExpiredToken FROM token WHERE token.NamaPengguna = NamaPengguna;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddUangBangunan` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddUangBangunan` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddUangBangunan`(
 IN IdSiswa LONG, IN IdTahunAjaran LONG, IN Tanggal DATETIME, IN NilaiUangBangunan LONG, IN Bayar LONG,
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	
	INSERT INTO uang_bangunan (IdSiswa, IdTahunAjaran, Tanggal, NilaiUangBangunan, Tahun, Bayar, SisaBayar,
	                           TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui 
	                          )
	VALUES (IdSiswa, IdTahunAjaran, Tanggal, NilaiUangBangunan, YEAR(CURDATE()), Bayar, SisaBayar, 
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT uang_bangunan.Id, uang_bangunan.IdSiswa, siswa.NamaSiswa, uang_bangunan.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, uang_bangunan.Tanggal, uang_bangunan.NilaiUangBangunan, uang_bangunan.Bayar, uang_bangunan.SisaBayar,
	       uang_bangunan.PenggunaBuat, uang_bangunan.TerminalBuat, uang_bangunan.TanggalBuat, uang_bangunan.PenggunaPerbarui, 
	       uang_bangunan.TerminalPerbarui, uang_bangunan.TanggalPerbarui
	FROM uang_bangunan LEFT JOIN siswa ON uang_bangunan.IdSiswa = siswa.Id 
	                   LEFT JOIN tahun_ajaran ON uang_bangunan.IdTahunAjaran = tahun_ajaran.Id
	WHERE uang_bangunan.IdSiswa = IdSiswa AND uang_bangunan.IdTahunAjaran = IdTahunAjaran
	       AND uang_bangunan.NilaiUangBangunan = NilaiUangBangunan AND uang_bangunan.Bayar = Bayar;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_AddWaliKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_AddWaliKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AddWaliKelas`(
 IN IdGuru LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN Deskripsi VARCHAR(50),
 IN PenggunaBuat VARCHAR(50), IN TerminalBuat VARCHAR(50), IN TanggalBuat DATETIME
)
BEGIN
	INSERT INTO wali_kelas (IdGuru, IdKelas, IdTahunAjaran, Deskripsi, 
	                        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui
	                        )
	VALUES (IdGuru, IdKelas, IdTahunAjaran, Deskripsi, 
	        PenggunaBuat, TerminalBuat, TanggalBuat, PenggunaBuat, TerminalBuat, TanggalBuat);
	
	SELECT wali_kelas.Id, wali_kelas.IdGuru, guru.NamaGuru, wali_kelas.IdKelas, kelas.NamaKelas, wali_kelas.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, wali_kelas.Deskripsi, 
	       wali_kelas.PenggunaBuat, wali_kelas.TerminalBuat, wali_kelas.TanggalBuat, 
	       wali_kelas.PenggunaPerbarui, wali_kelas.TerminalPerbarui, wali_kelas.TanggalPerbarui
	FROM wali_kelas LEFT JOIN guru ON wali_kelas.IdGuru = guru.Id 
	                LEFT JOIN kelas ON wali_kelas.IdKelas = kelas.Id
	                LEFT JOIN tahun_ajaran ON wali_kelas.IdTahunAjaran = tahun_ajaran.Id
	WHERE wali_kelas.IdGuru = IdGuru AND wali_kelas.IdKelas = IdKelas AND wali_kelas.IdTahunAjaran = IdTahunAjaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddAbsenGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddAbsenGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddAbsenGuru`(
 IN IdGuru LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN TanggalAbsen DATETIME
)
BEGIN
        
        SELECT absen_guru.Id, absen_guru.IdGuru, guru.NamaGuru, absen_guru.IdKelas, kelas.NamaKelas, absen_guru.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, absen_guru.NamaAbsen, absen_guru.TanggalAbsen, absen_guru.AbsenMasuk, absen_guru.AbsenKeluar,
	       absen_guru.PenggunaBuat, absen_guru.TerminalBuat, absen_guru.TanggalBuat, absen_guru.PenggunaPerbarui, 
	       absen_guru.TerminalPerbarui, absen_guru.TanggalPerbarui
	FROM absen_guru JOIN guru ON absen_guru.IdGuru = guru.Id 
	                JOIN kelas ON absen_guru.IdKelas = kelas.Id
	                JOIN tahun_ajaran ON absen_guru.IdTahunAjaran = tahun_ajaran.Id
	WHERE absen_guru.IdGuru = IdGuru AND absen_guru.IdKelas = IdKelas AND absen_guru.IdTahunAjaran = IdTahunAjaran
	                                 AND DATE_FORMAT(absen_guru.TanggalAbsen, '%Y%m%d') = DATE_FORMAT(absen_guru, '%Y%m%d');
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddAbsenSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddAbsenSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddAbsenSiswa`(
 IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN TanggalAbsen DATETIME
)
BEGIN
        
        SELECT absen_siswa.Id, absen_siswa.IdSiswa, siswa.NamaSiswa, absen_siswa.IdKelas, kelas.NamaKelas, absen_siswa.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, absen_siswa.NamaAbsen, absen_siswa.TanggalAbsen, absen_siswa.Deskripsi, 
	       absen_siswa.PenggunaBuat, absen_siswa.TerminalBuat, absen_siswa.TanggalBuat, absen_siswa.PenggunaPerbarui, 
	       absen_siswa.TerminalPerbarui, absen_siswa.TanggalPerbarui
	FROM absen_siswa JOIN siswa ON absen_siswa.IdSiswa = siswa.Id 
	                 JOIN kelas ON absen_guru.IdKelas = kelas.Id
	                 JOIN tahun_ajaran ON absen_guru.IdTahunAjaran = tahun_ajaran.Id
	WHERE absen_siswa.IdSiswa = IdSiswa AND absen_siswa.IdKelas = IdKelas AND absen_siswa.IdTahunAjaran = IdTahunAjaran
	                        AND DATE_FORMAT(absen_siswa.TanggalAbsen, '%Y%m%d') = DATE_FORMAT(TanggalAbsen, '%Y%m%d');
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddConfigPembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddConfigPembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddConfigPembayaran`(
 IN NamaPembayaran VARCHAR(50), IN IdTahunAjaran LONG
)
BEGIN
        
        SELECT * FROM config_pembayaran 
	WHERE config_pembayaran.NamaPembayaran = NamaPembayaran AND config_pembayaran.IdTahunAjaran = IdTahunAjaran;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddDaftarUlang` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddDaftarUlang` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddDaftarUlang`(
 IN IdSiswa LONG, IN IdTahunAjaran LONG, IN IdTahunAjaranTo LONG
)
BEGIN
             
    SELECT daftar_ulang.Id, daftar_ulang.IdSiswa, siswa.NamaSiswa, 
	       daftar_ulang.IdTahunAjaran, tahun_ajaran.TahunAjaran, daftar_ulang.IdTahunAjaranTo, TahunAjaranTo.TahunAjaran AS TahunAjaranTo, 
	       daftar_ulang.DariKelas, kelas.NamaKelas AS NamaDariKelas, daftar_ulang.KeKelas, KeKelas.NamaKelas AS NamaKeKelas,
	       daftar_ulang.NilaiDaftarUlang, daftar_ulang.Bayar, daftar_ulang.Kembalian, daftar_ulang.Deskripsi, 
	       daftar_ulang.PenggunaBuat, daftar_ulang.TerminalBuat, daftar_ulang.TanggalBuat, 
	       daftar_ulang.PenggunaPerbarui, daftar_ulang.TerminalPerbarui, daftar_ulang.TanggalPerbarui
	FROM daftar_ulang JOIN siswa ON daftar_ulang.IdSiswa = siswa.Id 
	                  JOIN kelas ON daftar_ulang.DariKelas = kelas.Id
	                  JOIN kelas AS KeKelas ON daftar_ulang.KeKelas = KeKelas.Id
	                  JOIN tahun_ajaran ON daftar_ulang.IdTahunAjaran = tahun_ajaran.Id
	                  JOIN tahun_ajaran AS TahunAjaranTo ON daftar_ulang.IdTahunAjaranTo = TahunAjaranTo.Id
	WHERE daftar_ulang.IdSiswa = IdSiswa AND daftar_ulang.IdTahunAjaran = IdTahunAjaran AND daftar_ulang.IdTahunAjaranTo = IdTahunAjaranTo;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddGuru`(
 IN NoKTP VARCHAR(50), IN IdGuru LONG
)
BEGIN
        
        SELECT * FROM guru 
        WHERE guru.NoKTP = NoKTP;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddJadwalGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddJadwalGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddJadwalGuru`(
 IN IdGuru LONG, IN Hari VARCHAR(50), IN IdKelas LONG, IN IdTahunAjaran LONG, 
 IN DariJam TIME, IN SampaiJam TIME
)
BEGIN
   
    SELECT jadwal_guru.Id, jadwal_guru.IdGuru, guru.NamaGuru, jadwal_guru.IdKelas, kelas.NamaKelas, 
	       jadwal_guru.IdPelajaran, pelajaran.NamaPelajaran, jadwal_guru.DariJam, jadwal_guru.SampaiJam,
	       jadwal_guru.IdTahunAjaran, tahun_ajaran.TahunAjaran, 
	       jadwal_guru.PenggunaBuat, jadwal_guru.TerminalBuat, jadwal_guru.TanggalBuat, jadwal_guru.PenggunaPerbarui, 
	       jadwal_guru.TerminalPerbarui, jadwal_guru.TanggalPerbarui
	FROM jadwal_guru LEFT JOIN guru ON jadwal_guru.IdGuru = guru.Id 
	                         LEFT JOIN kelas ON jadwal_guru.IdKelas = kelas.Id
	                         LEFT JOIN tahun_ajaran ON jadwal_guru.IdTahunAjaran = tahun_ajaran.Id
	                         LEFT JOIN pelajaran ON jadwal_guru.IdPelajaran = pelajaran.Id
	WHERE IdGuru = IdGuru AND Hari = Hari AND IdKelas = IdKelas AND IdTahunAjaran = IdTahunAjaran
	                      AND jadwal_guru.DariJam >= DariJam AND jadwal_guru.SampaiJam <= SampaiJam;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddKelas`(
 IN NamaKelas VARCHAR(50)
)
BEGIN
       
    SELECT * FROM kelas WHERE kelas.NamaKelas = NamaKelas;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddMenuRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddMenuRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddMenuRole`(
 IN IdRole LONG, IN IdMenu LONG
)
BEGIN
       
    SELECT menu_role.Id, menu_role.IdRole, role.NamaRole, menu_role.IdMenu, menu.NamaMenu,
	   menu_role.PenggunaBuat, menu_role.TerminalBuat, menu_role.TanggalBuat, 
	   menu_role.PenggunaPerbarui, menu_role.TerminalPerbarui, menu_role.TanggalPerbarui
    FROM menu_role 
	          LEFT JOIN role ON menu_role.IdRole = role.Id
	          LEFT JOIN menu ON menu_role.IdMenu = menu.Id
    WHERE menu_role.IdRole = IdRole AND menu_role.IdMenu = IdMenu;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddPelajaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddPelajaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddPelajaran`(
 IN NamaPelajaran VARCHAR(50)
)
BEGIN
       
    SELECT * FROM pelajaran WHERE pelajaran.NamaPelajaran = NamaPelajaran;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddPelanggaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddPelanggaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddPelanggaran`(
 IN NamaPelanggaran VARCHAR(50)
)
BEGIN
       
    SELECT * FROM pelanggaran WHERE pelanggaran.NamaPelanggaran = NamaPelanggaran;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddPembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddPembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddPembayaran`(
 IN IdSiswa LONG, IN IdConfigPembayaran LONG
)
BEGIN
             
     SELECT pembayaran.Id, pembayaran.IdSiswa, siswa.NamaSiswa, pembayaran.IdConfigPembayaran, config_pembayaran.NamaPembayaran, 
            pembayaran.NilaiPembayaran, tahun_ajaran.TahunAjaran, pembayaran.Bayar, pembayaran.Kembalian, pembayaran.Deskripsi,
            pembayaran.PenggunaBuat, pembayaran.TerminalBuat, pembayaran.TanggalBuat, 
            pembayaran.PenggunaPerbarui, pembayaran.TerminalPerbarui, pembayaran.TanggalPerbarui
     FROM pembayaran JOIN siswa ON pembayaran.IdSiswa = siswa.Id
                     JOIN config_pembayaran ON pembayaran.IdConfigPembayaran = config_pembayaran.Id
                     JOIN tahun_ajaran ON config_pembayaran.IdTahunAjaran = tahun_ajaran.Id
     WHERE pembayaran.IdSiswa = IdSiswa AND pembayaran.IdConfigPembayaran = IdConfigPembayaran;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddPengguna` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddPengguna` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddPengguna`(
 IN NamaPengguna VARCHAR(50), IN IdGuru LONG
)
BEGIN
        
        SELECT * FROM penguna 
        WHERE pengguna.NamaPengguna = NamaPengguna AND pengguna.IdGuru = IdGuru;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddPenggunaRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddPenggunaRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddPenggunaRole`(
 IN IdPengguna LONG, IN IdRole LONG
)
BEGIN
        
        SELECT pengguna_role.Id, pengguna_role.IdPengguna, pengguna.NamaPengguna, pengguna_role.IdRole, role.NamaRole, pengguna_role.Deskripsi,
               pengguna_role.PenggunaBuat, pengguna_role.TerminalBuat, pengguna_role.TanggalBuat, 
               pengguna_role.PenggunaPerbarui, pengguna_role.TerminalPerbarui, pengguna_role.TanggalPerbarui
        FROM pengguna_role JOIN pengguna ON pengguna_role.IdPengguna = pengguna.Id
                           JOIN role ON pengguna_role.IdRole = role.Id
        WHERE pengguna_role.IdPengguna = IdPengguna AND pengguna_role.IdRole = IdRole;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddPenilaian` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddPenilaian` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddPenilaian`(
 IN IdPelajaran LONG, IN NamaPenilaian VARCHAR(50)
)
BEGIN
    
    SELECT penilaian.Id, penilaian.Idpelajaran, pelajaran.NamaPelajaran, penilaian.NamaPenilaian, penilaian.Deskripsi, penilaian.Aktif,
	   penilaian.PenggunaBuat, penilaian.TerminalBuat, penilaian.TanggalBuat, 
	   penilaian.PenggunaPerbarui, penilaian.TerminalPerbarui, penilaian.TanggalPerbarui
    FROM penilaian 
	  JOIN pelajaran ON penilaian.IdPelajaran = pelajaran.Id
    WHERE penilaian.IdPelajaran = IdPelajaran AND penilaian.NamaPenilaian = NamaPenilaian;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddPenilaianSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddPenilaianSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddPenilaianSiswa`(
 IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN IdPenilaian LONG
)
BEGIN
       
       SELECT penilaian_siswa.Id, penilaian_siswa.IdSiswa, siswa.NamaSiswa, penilaian_siswa.IdTahunAjaran, tahun_ajaran.TahunAjaran,
              penilaian_siswa.IdPenilaian, pelajaran.NamaPelajaran, penilaian.NamaPenilaian, penilaian_siswa.Nilai, penilaian_siswa.Deskripsi,
	      penilaian_siswa.PenggunaBuat, penilaian_siswa.TerminalBuat, penilaian_siswa.TanggalBuat, 
	      penilaian_siswa.PenggunaPerbarui, penilaian_siswa.TerminalPerbarui, penilaian_siswa.TanggalPerbarui
       FROM penilaian_siswa 
		 JOIN siswa ON penilaian_siswa.IdSiswa = siswa.Id
		 JOIN kelas ON penilaian_siswa.IdKelas = kelas.Id
		 JOIN tahun_ajaran ON penilaian_siswa.IdTahunAjaran = tahun_ajaran.Id
		 JOIN penilaian ON penilaian_siswa.IdPenilaian = penilaian.Id
		 JOIN pelajaran ON penilaian.IdPelajaran = pelajaran.Id
       WHERE penilaian_siswa.IdSiswa = IdSiswa AND penilaian_siswa.IdKelas = IdKelas AND penilaian_siswa.IdTahunAjaran = IdTahunAjaran
             AND penilaian_siswa.IdPenilaian = IdPenilaian;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddRaportSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddRaportSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddRaportSiswa`(
 IN IdSiswa LONG, IN IdKelas LONG, IN IdPelajaran LONG, IN IdTahunAjaran LONG
)
BEGIN
       
       SELECT raport_siswa.Id, raport_siswa.IdSiswa, siswa.NamaSiswa, raport_siswa.IdKelas, kelas.NamaKelas, 
              raport_siswa.IdPelajaran, pelajaran.NamaPelajaran, raport_siswa.IdTahunAjaran, tahun_ajaran.TahunAjaran,
              raport_siswa.Nilai, raport_siswa.PenggunaBuat, raport_siswa.TerminalBuat, raport_siswa.TanggalBuat,
              raport_siswa.PenggunaPerbarui, raport_siswa.TerminalPerbarui, raport_siswa.TanggalPerbarui
       FROM raport_siswa 
                     LEFT JOIN siswa ON raport_siswa.IdSiswa = siswa.Id
                     LEFT JOIN kelas ON raport_siswa.IdKelas = kelas.Id
                     LEFT JOIN pelajaran ON raport_siswa.IdPelajaran = pelajaran.Id
                     LEFT JOIN tahun_ajaran ON raport_siswa.IdTahunAjaran = tahun_ajaran.Id
       WHERE raport_siswa.IdSiswa = IdSiswa and raport_siswa.IdKelas = IdKelas and raport_siswa.IdPelajaran = IdPelajaran
              and raport_siswa.IdTahunAjaran = IdTahunAjaran;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddRole`(
 IN NamaRole VARCHAR(50)
)
BEGIN
       
    SELECT * FROM role WHERE role.NamaRole = NamaRole;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddSiswa`(
 IN NamaSiswa VARCHAR(50)
)
BEGIN
       
    SELECT * FROM siswa WHERE siswa.NamaSiswa = NamaSiswa;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddSPP` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddSPP` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddSPP`(
 IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN Tahun INT, IN Bulan INT
)
BEGIN
             
    SELECT spp.Id, spp.IdSiswa, siswa.NamaSiswa, spp.IdKelas, kelas.NamaKelas, spp.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, spp.Tahun, spp.Bulan, spp.NamaBulan, spp.NilaiSPP, spp.Bayar, spp.Kembalian,
	       spp.PenggunaBuat, spp.TerminalBuat, spp.TanggalBuat, spp.PenggunaPerbarui, 
	       spp.TerminalPerbarui, spp.TanggalPerbarui
    FROM spp JOIN siswa ON spp.IdSiswa = siswa.Id 
	     JOIN kelas ON spp.IdKelas = kelas.Id 
	     JOIN tahun_ajaran ON spp.IdTahunAjaran = tahun_ajaran.Id
    WHERE spp.IdSiswa = IdSiswa AND spp.IdKelas = IdKelas AND spp.IdTahunAjaran = IdTahunAjaran 
	  AND spp.Tahun = Tahun AND spp.Bulan = Bulan;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddTahunAjaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddTahunAjaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddTahunAjaran`(
 IN TahunAjaran VARCHAR(50)
)
BEGIN
       
    SELECT * FROM tahun_ajaran WHERE tahun_ajaran.TahunAjaran = TahunAjaran;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckAddWaliKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckAddWaliKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckAddWaliKelas`(
 IN IdGuru LONG, IN IdKelas LONG, IN IdTahunAjaran LONG
)
BEGIN
             
    SELECT wali_kelas.Id, wali_kelas.IdGuru, guru.NamaGuru, wali_kelas.IdKelas, kelas.NamaKelas, wali_kelas.IdTahunAjaran,
	   tahun_ajaran.TahunAjaran, wali_kelas.Deskripsi, 
	   wali_kelas.PenggunaBuat, wali_kelas.TerminalBuat, wali_kelas.TanggalBuat, 
	   wali_kelas.PenggunaPerbarui, wali_kelas.TerminalPerbarui, wali_kelas.TanggalPerbarui
    FROM wali_kelas JOIN guru ON wali_kelas.IdGuru = guru.Id 
	            JOIN kelas ON wali_kelas.IdKelas = kelas.Id
	            JOIN tahun_ajaran ON wali_kelas.IdTahunAjaran = tahun_ajaran.Id
    WHERE wali_kelas.IdGuru = IdGuru AND wali_kelas.IdKelas = IdKelas AND wali_kelas.IdTahunAjaran = IdTahunAjaran;
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckBulanSPPSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckBulanSPPSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckBulanSPPSiswa`(
 IN IdSiswa long, in Tahun int, in Bulan int
)
BEGIN
        Declare CountBulan int unsigned DEFAULT 0;
        DECLARE iBulan INT UNSIGNED DEFAULT 0;
        SET CountBulan = 0;
        SET iBulan = 0;
        SET iBulan = Bulan - 1;
          
        SELECT CountBulan = COUNT(*)  FROM spp WHERE spp.IdSiswa = IdSiswa AND spp.Tahun = Tahun;
        IF ((SELECT COUNT(*) FROM spp where spp.IdSiswa = IdSiswa and spp.Tahun = Tahun and spp.Bulan = iBulan) <= 0) THEN
	    SET CountBulan = CountBulan + 1;
	    SELECT * FROM bulan WHERE bulan.Tahun = Tahun AND bulan.Bulan = CountBulan;
	else
	    SELECT * FROM bulan WHERE bulan.Tahun = Tahun AND bulan.Bulan = Bulan LIMIT 0;
	END IF;
        
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckConfigPembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckConfigPembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckConfigPembayaran`(
 IN NamaPembayaran VARCHAR(50), IN IdTahunAjaran LONG
)
BEGIN
        
        select * from config_pembayaran 
        WHERE config_pembayaran.NamaPembayaran = NamaPembayaran and config_pembayaran.IdTahunAjaran = IdTahunAjaran;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_CheckToken` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_CheckToken` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CheckToken`(
 IN NamaPengguna VARCHAR(50)
)
BEGIN
	SELECT NamaPengguna, Token, ExpiredToken FROM token WHERE token.NamaPengguna = NamaPengguna;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteAbsenGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteAbsenGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteAbsenGuru`(
 IN Id LONG
)
BEGIN
	delete from absen_guru WHERE absen_guru.Id = Id;   

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteAbsenSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteAbsenSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteAbsenSiswa`(
 IN Id LONG
)
BEGIN
	DELETE FROM absen_siswa WHERE absen_siswa.Id = Id;   

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteConfigPembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteConfigPembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteConfigPembayaran`(
 IN Id LONG
)
BEGIN
        
	delete from config_pembayaran where config_pembayaran.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteDaftarUlang` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteDaftarUlang` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteDaftarUlang`(
 IN Id LONG
)
BEGIN
	
	delete from daftar_ulang WHERE daftar_ulang.Id = Id;
	
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteGuru`(
 IN Id long
)
BEGIN
        delete FROM guru WHERE Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteJadwalGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteJadwalGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteJadwalGuru`(
 IN Id LONG
)
BEGIN
	Delete from jadwal_guru where jadwal_guru.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteKelas`(
 IN Id LONG
)
BEGIN
        
	Delete FROM kelas WHERE kelas.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteMenuRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteMenuRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteMenuRole`(
 IN Id LONG
)
BEGIN
	delete from menu_role where menu_role.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeletePelajaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeletePelajaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePelajaran`(
 IN Id long
)
BEGIN
        
	delete from pelajaran where pelajaran.Id = Id;
	
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeletePelanggaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeletePelanggaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePelanggaran`(
 IN Id LONG
)
BEGIN
        
	delete from pelanggaran where pelanggaran.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeletePelanggaranSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeletePelanggaranSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePelanggaranSiswa`(
 IN Id LONG
)
BEGIN
        Delete from pelanggaran_siswa
        WHERE pelanggaran_siswa.Id = Id;         
        
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeletePembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeletePembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePembayaran`(
 IN Id LONG
)
BEGIN
        Delete from pembayaran WHERE pembayaran.Id = Id;
        
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeletePengguna` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeletePengguna` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePengguna`(
 IN Id LONG
)
BEGIN
        Delete from pengguna where pengguna.Id = Id;
      
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeletePenggunaRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeletePenggunaRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePenggunaRole`(
 IN Id LONG
)
BEGIN
        delete from pengguna_role WHERE pengguna_role.Id = Id;
      
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeletePenilaian` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeletePenilaian` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePenilaian`(
 IN Id LONG
)
BEGIN
        
	Delete from penilaian WHERE penilaian.Id = Id;                    
	
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeletePenilaianSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeletePenilaianSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePenilaianSiswa`(
 IN Id LONG
)
BEGIN
        
       Delete from penilaian_siswa where penilaian_siswa.Id = Id;

END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteRaportSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteRaportSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteRaportSiswa`(
 IN Id LONG
)
BEGIN
       delete from raport_siswa Where raport_siswa.Id = Id;
                 
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteRole`(
 IN Id long
)
BEGIN
        
	delete from role where role.NamaRole = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteSiswa`(
 IN Id long
)
BEGIN
	delete from siswa WHERE siswa.Id = Id;
	
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteSPP` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteSPP` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteSPP`(
 IN Id LONG
)
BEGIN
	delete from spp WHERE spp.Id = Id;
	
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteTahunAjaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteTahunAjaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteTahunAjaran`(
 IN Id LONG
)
BEGIN
        
	delete from tahun_ajaran where tahun_ajaran.Id = Id;	
	
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_DeleteWaliKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_DeleteWaliKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteWaliKelas`(
 IN Id LONG
)
BEGIN
	Delete from wali_kelas where wali_kelas.Id = Id;
	
  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditAbsenGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditAbsenGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditAbsenGuru`(
 IN Id LONG, IN IdGuru LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN NamaAbsen VARCHAR(50), IN TanggalAbsen DATETIME,
 IN AbsenMasuk TIME, IN AbsenKeluar TIME,
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
	UPDATE absen_guru SET absen_guru.IdGuru = IdGuru, absen_guru.IdKelas = IdKelas, absen_guru.IdTahunAjaran = IdTahunAjaran,
	       absen_guru.NamaAbsen = NamaAbsen,absen_guru.AbsenKeluar = AbsenKeluar, 
	       absen_guru.PenggunaPerbarui = PenggunaPerbarui, absen_guru.TerminalPerbarui = TerminalPerbarui,
	       absen_guru.TanggalPerbarui = TanggalPerbarui WHERE absen_guru.Id = Id;             
	
	SELECT absen_guru.Id, absen_guru.IdGuru, guru.NamaGuru, absen_guru.IdKelas, kelas.NamaKelas, absen_guru.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, absen_guru.NamaAbsen, absen_guru.TanggalAbsen, absen_guru.AbsenMasuk, absen_guru.AbsenKeluar,
	       absen_guru.PenggunaBuat, absen_guru.TerminalBuat, absen_guru.TanggalBuat, absen_guru.PenggunaPerbarui, 
	       absen_guru.TerminalPerbarui, absen_guru.TanggalPerbarui
	FROM absen_guru LEFT JOIN guru ON absen_guru.IdGuru = guru.Id 
	                         LEFT JOIN kelas ON absen_guru.IdKelas = kelas.Id
	                         LEFT JOIN tahun_ajaran ON absen_guru.IdTahunAjaran = tahun_ajaran.Id
	WHERE absen_guru.Id = Id;   

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditAbsenSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditAbsenSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditAbsenSiswa`(
 IN Id LONG, IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN NamaAbsen VARCHAR(50), IN TanggalAbsen DATETIME,
 IN Deskripsi VARCHAR(50), IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
	Update absen_siswa set absen_siswa.IdSiswa = IdSiswa, absen_siswa.IdKelas = IdKelas, absen_siswa.IdTahunAjaran = IdTahunAjaran,
	                       absen_siswa.NamaAbsen = NamaAbsen, absen_siswa.TanggalAbsen = TanggalAbsen, absen_siswa.Deskripsi = Deskripsi,
	                       absen_siswa.PenggunaPerbarui = PenggunaPerbarui, absen_siswa.TerminalPerbarui = TerminalPerbarui,
	                       absen_siswa.TanggalPerbarui = TanggalPerbarui
	where absen_siswa.Id = Id;
	
	SELECT absen_siswa.Id, absen_siswa.IdSiswa, siswa.NamaSiswa, absen_siswa.IdKelas, kelas.NamaKelas, absen_siswa.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, absen_siswa.NamaAbsen, absen_siswa.TanggalAbsen, absen_siswa.Deskripsi, 
	       absen_siswa.PenggunaBuat, absen_siswa.TerminalBuat, absen_siswa.TanggalBuat, absen_siswa.PenggunaPerbarui, 
	       absen_siswa.TerminalPerbarui, absen_siswa.TanggalPerbarui
	FROM absen_siswa LEFT JOIN siswa ON absen_siswa.IdSiswa = siswa.Id 
	                 LEFT JOIN kelas ON absen_guru.IdKelas = kelas.Id
	                 LEFT JOIN tahun_ajaran ON absen_guru.IdTahunAjaran = tahun_ajaran.Id
	WHERE Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditConfigPembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditConfigPembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditConfigPembayaran`(
 IN Id LONG, IN NamaPembayaran VARCHAR(50), IN IdTahunAjaran LONG, IN NilaiPembayaran LONG, IN Aktif BIT, IN Deskripsi VARCHAR(50), 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        INSERT INTO log_config_pembayaran (NamaPembayaran, IdTahunAjaran, NilaiPembayaran, Aktif, Deskripsi,
	                                   PenggunaBuat, TerminalBuat, TanggalBuat 
	                                  )
	SELECT NamaPembayaran, IdTahunAjaran, NilaiPembayaran, Aktif, 'Data Sebelumnya' As Deskripsi,
	       PenggunaBuat, TerminalBuat, TanggalBuat 
	FROM config_pembayaran WHERE Id = Id;
	        
	UPDATE config_pembayaran SET config_pembayaran.NamaPembayaran = NamaPembayaran, config_pembayaran.IdTahunAjaran = IdTahunAjaran, 
	                             config_pembayaran.NilaiPembayaran = NilaiPembayaran,
	                             config_pembayaran.Aktif = Aktif, config_pembayaran.Deskripsi = Deskripsi, 
	                             config_pembayaran.PenggunaPerbarui = PenggunaPerbarui, config_pembayaran.TerminalPerbarui = TerminalPerbarui, 
	                             config_pembayaran.TanggalPerbarui = TanggalPerbarui
	WHERE config_pembayaran.Id = Id;
	
	SELECT * FROM config_pembayaran WHERE config_pembayaran.Id = Id;

END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditDaftarUlang` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditDaftarUlang` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditDaftarUlang`(
 IN Id LONG, IN IdSiswa LONG, IN IdTahunAjaran LONG, IN IdTahunAjaranTo LONG, IN DariKelas LONG, IN KeKelas LONG, IN NilaiDaftarUlang LONG,
 IN Bayar LONG, IN Kembalian LONG, IN Deskripsi VARCHAR(50), IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
	UPDATE daftar_ulang SET daftar_ulang.IdTahunAjaran = IdTahunAjaran, daftar_ulang.IdTahunAjaranTo = IdTahunAjaranTo,
		                        daftar_ulang.DariKelas = DariKelas, daftar_ulang.KeKelas = KeKelas,
		                        daftar_ulang.NilaiDaftarUlang = NilaiDaftarUlang, daftar_ulang.Bayar = Bayar, daftar_ulang.Kembalian = Kembalian,
		                        daftar_ulang.Deskripsi = Deskripsi, daftar_ulang.PenggunaPerbarui = PenggunaPerbarui, 
		                        daftar_ulang.TerminalPerbarui = TerminalPerbarui, daftar_ulang.TanggalPerbarui = TanggalPerbarui
	WHERE daftar_ulang.Id = Id;
	
	SELECT daftar_ulang.Id, daftar_ulang.IdSiswa, siswa.NamaSiswa, 
	       daftar_ulang.IdTahunAjaran, tahun_ajaran.TahunAjaran, daftar_ulang.IdTahunAjaranTo, TahunAjaranTo.TahunAjaran AS TahunAjaranTo, 
	       daftar_ulang.DariKelas, kelas.NamaKelas AS NamaDariKelas, daftar_ulang.KeKelas, KeKelas.NamaKelas AS NamaKeKelas,
	       daftar_ulang.NilaiDaftarUlang, daftar_ulang.Bayar, daftar_ulang.Kembalian, daftar_ulang.Deskripsi, 
	       daftar_ulang.PenggunaBuat, daftar_ulang.TerminalBuat, daftar_ulang.TanggalBuat, 
	       daftar_ulang.PenggunaPerbarui, daftar_ulang.TerminalPerbarui, daftar_ulang.TanggalPerbarui
	FROM daftar_ulang LEFT JOIN siswa ON daftar_ulang.IdSiswa = siswa.Id 
	                  LEFT JOIN kelas ON daftar_ulang.DariKelas = kelas.Id
	                  LEFT JOIN kelas AS KeKelas ON daftar_ulang.KeKelas = KeKelas.Id
	                  LEFT JOIN tahun_ajaran ON daftar_ulang.IdTahunAjaran = tahun_ajaran.Id
	                  LEFT JOIN tahun_ajaran AS TahunAjaranTo ON daftar_ulang.IdTahunAjaranTo = TahunAjaranTo.Id
	WHERE daftar_ulang.Id = Id;
	

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditGuru`(
 IN Id long, IN NomorIndukPegawai VARCHAR(50), IN NoKTP VARCHAR(50), IN NamaGuru VARCHAR(50), IN JenisKelamin VARCHAR(50), 
 IN StatusGuru VARCHAR(50), IN Agama VARCHAR(50), IN Alamat VARCHAR(50), IN Pendidikan VARCHAR(50),
 IN TanggalLahir DATETIME, IN NoHp VARCHAR(50), In Aktif bit, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        update guru set guru.NamaGuru = NamaGuru, guru.JenisKelamin = JenisKelamin, guru.StatusGuru = StatusGuru, guru.Agama = Agama,
                        guru.Alamat = Alamat, guru.Pendidikan = Pendidikan, guru.TanggalLahir = TanggalLahir,
                        guru.NoHp = NoHp, guru.Aktif = Aktif, guru.PenggunaPerbarui = PenggunaPerbarui,
                        guru.TerminalPerbarui = TerminalPerbarui, guru.TanggalPerbarui = TanggalPerbarui
        where Id = Id;
	
	SELECT NomorIndukPegawai, NoKTP, NamaGuru, JenisKelamin, StatusGuru, Agama, Alamat, Pendidikan, 
	                  TanggalLahir, NoHp, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat, 
	                  PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui
	FROM guru 
	WHERE Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditJadwalGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditJadwalGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditJadwalGuru`(
 IN Id LONG, IN IdGuru LONG, IN Hari VARCHAR(50), IN IdKelas LONG, IN IdPelajaran LONG, IN IdTahunAjaran LONG, 
 IN DariJam TIME, IN SampaiJam TIME, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
	update jadwal_guru set jadwal_guru.Hari = Hari, jadwal_guru.IdKelas = IdKelas, jadwal_guru.IdPelajaran = IdPelajaran, 
	                       jadwal_guru.IdTahunAjaran = IdTahunAjaran,
	                       jadwal_guru.DariJam = DariJam, jadwal_guru.SampaiJam = SampaiJam, 
	                       jadwal_guru.PenggunaPerbarui = PenggunaPerbarui, jadwal_guru.TerminalPerbarui = TerminalPerbarui,
	                       jadwal_guru.TanggalPerbarui = TanggalPerbarui
	where jadwal_guru.Id = Id;
	
	SELECT jadwal_guru.Id, jadwal_guru.IdGuru, guru.NamaGuru, jadwal_guru.Hari, jadwal_guru.IdKelas, kelas.NamaKelas, 
	       jadwal_guru.IdPelajaran, pelajaran.NamaPelajaran, jadwal_guru.IdTahunAjaran, tahun_ajaran.TahunAjaran, 
	       jadwal_guru.DariJam, jadwal_guru.SampaiJam,
	       jadwal_guru.PenggunaBuat, jadwal_guru.TerminalBuat, jadwal_guru.TanggalBuat, jadwal_guru.PenggunaPerbarui, 
	       jadwal_guru.TerminalPerbarui, jadwal_guru.TanggalPerbarui
	FROM jadwal_guru LEFT JOIN guru ON jadwal_guru.IdGuru = guru.Id 
	                         LEFT JOIN kelas ON jadwal_guru.IdKelas = kelas.Id
	                         LEFT JOIN tahun_ajaran ON jadwal_guru.IdTahunAjaran = tahun_ajaran.Id
	                         LEFT JOIN pelajaran ON jadwal_guru.IdPelajaran = pelajaran.Id
	WHERE jadwal_guru.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditKelas`(
 IN Id LONG, IN NamaKelas VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        
	update kelas set kelas.NamaKelas = kelas.NamaKelas, kelas.Aktif = Aktif, kelas.PenggunaPerbarui = PenggunaPerbarui, 
	                 kelas.TerminalPerbarui = TerminalPerbarui, kelas.TanggalPerbarui = TanggalPerbarui
	where kelas.Id = Id;
	
	SELECT * FROM kelas WHERE kelas.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditMenuRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditMenuRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditMenuRole`(
 IN Id LONG, IN IdRole LONG, IN IdMenu LONG, IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
	Update menu_role set menu_role.IdRole = IdRole, menu_role.IdMenu = IdMenu,
	                     menu_role.PenggunaPerbarui = PenggunaPerbarui, menu_role.TerminalPerbarui = TerminalPerbarui,
	                     menu_role.TanggalPerbarui = TanggalPerbarui
	where menu_role.Id = Id;
	
	select menu_role.Id, menu_role.IdRole, role.NamaRole, menu_role.IdMenu, menu.NamaMenu,
	       menu_role.PenggunaBuat, menu_role.TerminalBuat, menu_role.TanggalBuat, 
	       menu_role.PenggunaPerbarui, menu_role.TerminalPerbarui, menu_role.TanggalPerbarui
	from menu_role 
	                        left join role on menu_role.IdRole = role.Id
	                        left join menu on menu_role.IdMenu = menu.Id
	WHERE menu_role.Id = Id;
	                        

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditPelajaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditPelajaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPelajaran`(
 IN Id long, IN NamaPelajaran VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        
	Update pelajaran set pelajaran.NamaPelajaran = NamaPelajaran, pelajaran.Deskripsi = Deskripsi, pelajaran.Aktif = Aktif,
	                     pelajaran.PenggunaPerbarui = PenggunaPerbarui, pelajaran.TerminalPerbarui = TerminalPerbarui,
	                     pelajaran.TanggalPerbarui = TanggalPerbarui
	where pelajaran.Id = Id;
	
	
	SELECT * FROM pelajaran 
	WHERE pelajaran.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditPelanggaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditPelanggaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPelanggaran`(
 IN Id LONG, IN NamaPelanggaran VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        
	update pelanggaran set pelanggaran.NamaPelanggaran = NamaPelanggaran, pelanggaran.Deskripsi = Deskripsi, 
	                       pelanggaran.Aktif = Aktif, pelanggaran.PenggunaPerbarui = PenggunaPerbarui, 
	                       pelanggaran.TerminalPerbarui = TerminalPerbarui, pelanggaran.TanggalPerbarui = TanggalPerbarui
	where pelanggaran.Id = Id;
	
	SELECT * FROM pelanggaran 
	WHERE Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditPelanggaranSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditPelanggaranSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPelanggaranSiswa`(
 IN Id LONG, IN IdSiswa LONG, IN IdPelanggaran LONG, IN Deskripsi VARCHAR(50), 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        UPDATE pelanggaran_siswa SET pelanggaran_siswa.IdSiswa = IdSiswa,
               pelanggaran_siswa.IdPelanggaran = IdPelanggaran,
               pelanggaran_siswa.Deskripsi = Deskripsi,
               pelanggaran_siswa.PenggunaPerbarui = PenggunaPerbarui,
               pelanggaran_siswa.TerminalPerbarui = TerminalPerbarui,
               pelanggaran_siswa.TanggalPerbarui = TanggalPerbarui
        WHERE pelanggaran_siswa.Id = Id;         
        
	SELECT pelanggaran_siswa.Id, pelanggaran_siswa.IdSiswa, siswa.NamaSiswa, 
	       pelanggaran_siswa.IdPelanggaran, pelanggaran.NamaPelanggaran, pelanggaran.Poin, 
	       pelanggaran_siswa.Deskripsi, pelanggaran_siswa.PenggunaBuat, 
	       pelanggaran_siswa.TerminalBuat, pelanggaran_siswa.TanggalBuat,
	       pelanggaran_siswa.PenggunaPerbarui, pelanggaran_siswa.TerminalPerbarui,
	       pelanggaran_siswa.TanggalPerbarui
	FROM pelanggaran_siswa 
	              LEFT JOIN siswa ON pelanggaran_siswa.IdSiswa = siswa.Id
	              LEFT JOIN pelanggaran ON pelanggaran_siswa.IdPelanggaran = pelanggaran.Id
	WHERE pelanggaran_siswa.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditPembayaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditPembayaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPembayaran`(
 IN Id LONG, IN IdSiswa LONG, IN IdConfigPembayaran LONG, IN NilaiPembayaran LONG, IN Bayar LONG, IN Deskripsi VARCHAR(50),
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        update pembayaran set pembayaran.IdSiswa = IdSiswa, pembayaran.IdConfigPembayaran = IdConfigPembayaran,
                              pembayaran.NilaiPembayaran = NilaiPembayaran, pembayaran.Bayar = Bayar,
                              pembayaran.Kembalian = Bayar - NilaiPembayaran, 
                              pembayaran.PenggunaPerbarui = PenggunaPerbarui, pembayaran.TerminalPerbarui = TerminalPerbarui,
                              pembayaran.TanggalPerbarui = TanggalPerbarui
        WHERE pembayaran.Id = Id;
        
        SELECT pembayaran.Id, pembayaran.IdSiswa, siswa.NamaSiswa, pembayaran.IdConfigPembayaran, config_pembayaran.NamaPembayaran, 
               pembayaran.NilaiPembayaran, tahun_ajaran.TahunAjaran, pembayaran.Bayar, pembayaran.Kembalian, pembayaran.Deskripsi,
               pembayaran.PenggunaBuat, pembayaran.TerminalBuat, pembayaran.TanggalBuat, 
               pembayaran.PenggunaPerbarui, pembayaran.TerminalPerbarui, pembayaran.TanggalPerbarui
        FROM pembayaran LEFT JOIN siswa ON pembayaran.IdSiswa = siswa.Id
                        LEFT JOIN config_pembayaran ON pembayaran.IdConfigPembayaran = config_pembayaran.Id
                        LEFT JOIN tahun_ajaran ON config_pembayaran.IdTahunAjaran = tahun_ajaran.Id
        WHERE pembayaran.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditPengguna` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditPengguna` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPengguna`(
 IN Id LONG, IN NamaPengguna VARCHAR(50), IN IdGuru LONG, IN PASSWORD VARCHAR(50), IN Email VARCHAR(50),
 IN StatusPengguna VARCHAR(50), IN ExpiredPassword DATETIME, IN Aktif BIT,
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        UPDATE pengguna SET pengguna.NamaPengguna = NamaPengguna, pengguna.IdGuru = IdGuru, pengguna.PASSWORD = Pass,
                            pengguna.Email = Email, pengguna.StatusPengguna = StatusPengguna, pengguna.ExpiredPassword = ExpiredPassword,
                            pengguna.Aktif = Aktif, pengguna.PenggunaPerbarui = PenggunaPerbarui, pengguna.TerminalPerbarui = TerminalPerbarui,
                            pengguna.TanggalPerbarui = TanggalPerbarui
        WHERE pengguna.Id = Id;

        SELECT pengguna.Id, pengguna.NamaPengguna, pengguna.IdGuru, guru.NamaGuru, pengguna.Pass, 
               pengguna.Email, pengguna.StatusPengguna, pengguna.ExpiredPassword, pengguna.Aktif,
               pengguna.PenggunaBuat, pengguna.TerminalBuat, pengguna.TanggalBuat, 
               pengguna.PenggunaPerbarui, pengguna.TerminalPerbarui, pengguna.TanggalPerbarui
        FROM pengguna LEFT JOIN guru ON pengguna.IdGuru = guru.Id
        WHERE pengguna.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditPenggunaRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditPenggunaRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPenggunaRole`(
 IN Id LONG, IN IdPengguna LONG, IN IdRole LONG, IN Deskripsi VARCHAR(50), IN Aktif BIT,
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        UPDATE pengguna_role SET pengguna_role.IdPengguna = IdPengguna, pengguna_role.IdRole = IdRole, pengguna_role.Deskripsi = Deskripsi,
                                 pengguna_role.PenggunaPerbarui = PenggunaPerbarui, pengguna_role.TerminalPerbarui = TerminalPerbarui,
                                 pengguna_role.TanggalPerbarui = TanggalPerbarui
        WHERE pengguna_role.Id = Id;
        
        SELECT pengguna_role.Id, pengguna_role.IdPengguna, pengguna.NamaPengguna, pengguna_role.IdRole, role.NamaRole, pengguna_role.Deskripsi,
               pengguna_role.PenggunaBuat, pengguna_role.TerminalBuat, pengguna_role.TanggalBuat, 
               pengguna_role.PenggunaPerbarui, pengguna_role.TerminalPerbarui, pengguna_role.TanggalPerbarui
        FROM pengguna_role LEFT JOIN pengguna ON pengguna_role.IdPengguna = pengguna.Id
                           LEFT JOIN role ON pengguna_role.IdRole = role.Id
        WHERE pengguna_role.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditPenilaian` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditPenilaian` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPenilaian`(
 IN Id LONG, IN IdPelajaran long, IN NamaPenilaian VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        
	update penilaian set penilaian.Idpelajaran = Idpelajaran, penilaian.NamaPenilaian = NamaPenilaian, penilaian.Deskripsi = Deskripsi,
	                     penilaian.Aktif = Aktif,
	                     penilaian.PenggunaPerbarui = PenggunaPerbarui, penilaian.TerminalPerbarui = TerminalPerbarui,
	                     penilaian.TanggalPerbarui = TanggalPerbarui
	WHERE penilaian.Id = Id;                    
	
	SELECT penilaian.Id, penilaian.Idpelajaran, pelajaran.NamaPelajaran, penilaian.NamaPenilaian, penilaian.Deskripsi,
	       penilaian.Aktif, penilaian.PenggunaBuat, penilaian.TerminalBuat, penilaian.TanggalBuat, 
	       penilaian.PenggunaPerbarui, penilaian.TerminalPerbarui, penilaian.TanggalPerbarui
	FROM penilaian 
			left join pelajaran on penilaian.IdPelajaran = pelajaran.Id
	WHERE penilaian.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditPenilaianSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditPenilaianSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPenilaianSiswa`(
 IN Id LONG, IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN IdPenilaian LONG, IN Nilai decimal,
 IN Deskripsi VARCHAR(50), IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        
       Update penilaian_siswa Set penilaian_siswa.IdSiswa = IdSiswa, penilaian_siswa.IdKelas = IdKelas, 
              penilaian_siswa.IdTahunAjaran = IdTahunAjaran, penilaian_siswa.IdPenilaian = IdPenilaian, 
              penilaian_siswa.Nilai = Nilai, penilaian_siswa.Deskripsi = Deskripsi, penilaian_siswa.PenggunaPerbarui = PenggunaPerbarui,
              penilaian_siswa.TerminalPerbarui = TerminalPerbarui, penilaian_siswa.TanggalPerbarui = TanggalPerbarui
       where penilaian_siswa.Id = Id;
       
       SELECT penilaian_siswa.Id, penilaian_siswa.IdSiswa, siswa.NamaSiswa, penilaian_siswa.IdTahunAjaran, tahun_ajaran.TahunAjaran,
              penilaian_siswa.IdPenilaian, pelajaran.NamaPelajaran, penilaian.NamaPenilaian, penilaian_siswa.Nilai, penilaian_siswa.Deskripsi,
	      penilaian_siswa.PenggunaBuat, penilaian_siswa.TerminalBuat, penilaian_siswa.TanggalBuat, 
	      penilaian_siswa.PenggunaPerbarui, penilaian_siswa.TerminalPerbarui, penilaian_siswa.TanggalPerbarui
       FROM penilaian_siswa 
		 JOIN siswa ON penilaian_siswa.IdSiswa = siswa.Id
		 JOIN kelas ON penilaian_siswa.IdKelas = kelas.Id
		 JOIN tahun_ajaran ON penilaian_siswa.IdTahunAjaran = tahun_ajaran.Id
		 JOIN penilaian ON penilaian_siswa.IdPenilaian = penilaian.Id
		 JOIN pelajaran ON penilaian.IdPelajaran = pelajaran.Id
       WHERE penilaian_siswa.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditRaportSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditRaportSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditRaportSiswa`(
 IN Id LONG, IN IdSiswa LONG, IN IdKelas LONG, IN IdPelajaran LONG, IN IdTahunAjaran LONG, IN Nilai decimal,
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
       update raport_siswa set raport_siswa.IdSiswa = IdSiswa, raport_siswa.IdKelas = IdKelas, raport_siswa.IdPelajaran = IdPelajaran,
              raport_siswa.IdTahunAjaran = IdTahunAjaran, raport_siswa.Nilai = Nilai, raport_siswa.PenggunaPerbarui = PenggunaPerbarui,
              raport_siswa.TerminalPerbarui = TerminalPerbarui, raport_siswa.TanggalPerbarui = TanggalPerbarui
       Where raport_siswa.Id = Id;
               
       Select raport_siswa.Id, raport_siswa.IdSiswa, siswa.NamaSiswa, raport_siswa.IdKelas, kelas.NamaKelas, 
              raport_siswa.IdPelajaran, pelajaran.NamaPelajaran, raport_siswa.IdTahunAjaran, tahun_ajaran.TahunAjaran,
              raport_siswa.Nilai, raport_siswa.PenggunaBuat, raport_siswa.TerminalBuat, raport_siswa.TanggalBuat,
              raport_siswa.PenggunaPerbarui, raport_siswa.TerminalPerbarui, raport_siswa.TanggalPerbarui
       From raport_siswa 
                     left join siswa on raport_siswa.IdSiswa = siswa.Id
                     left join kelas on raport_siswa.IdKelas = kelas.Id
                     left join pelajaran on raport_siswa.IdPelajaran = pelajaran.Id
                     left join tahun_ajaran on raport_siswa.IdTahunAjaran = tahun_ajaran.Id
       Where raport_siswa.IdSiswa = IdSiswa and raport_siswa.Idkelas = Idkelas 
             and raport_siswa.IdPelajaran = IdPelajaran and raport_siswa.IdTahunAjaran = IdTahunAjaran;
        
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditRole` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditRole` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditRole`(
 IN Id long, IN NamaRole VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        
	update role set role.NamaRole = NamaRole, role.Deskripsi = Deskripsi, role.Aktif = Aktif,
	                role.PenggunaPerbarui = PenggunaPerbarui, role.TerminalPerbarui = TerminalPerbarui,
	                role.TanggalPerbarui = TanggalPerbarui
	where role.NamaRole = Id;
	
	SELECT * from role
	WHERE role.NamaRole = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditSiswa`(
 IN Id LONG, IN NomorIndukSiswa VARCHAR(50), IN NamaSiswa VARCHAR(50), IN JenisKelamin VARCHAR(50), IN Alamat VARCHAR(50), 
 IN Agama VARCHAR(50), IN TanggalLahir DATETIME, IN NoHp VARCHAR(50), IN IdKelas LONG, IN IdTahunAjaran LONG,
 IN NamaOrangTua VARCHAR(50), IN AlamatOrangTua VARCHAR(500), IN NoHpOrangTua VARCHAR(500), IN PenghasilanOrangTua LONG, 
 IN Aktif BIT, IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
	UPDATE siswa SET siswa.NamaSiswa = NamaSiswa, siswa.IdKelas = IdKelas, siswa.IdTahunAjaran = IdTahunAjaran,
	                 siswa.JenisKelamin = JenisKelamin, siswa.Alamat = Alamat, siswa.Agama = Agama, siswa.TanggalLahir = TanggalLahir,
	                 siswa.NoHp = NoHp, siswa.NamaOrangTua = NamaOrangTua, siswa.AlamatOrangTua = AlamatOrangTua, 
	                 siswa.NoHpOrangTua = NoHpOrangTua, siswa.PenghasilanOrangTua = PenghasilanOrangTua,
	                 siswa.Aktif = Aktif, siswa.PenggunaPerbarui = PenggunaPerbarui,
	                 siswa.TerminalPerbarui = TerminalPerbarui, siswa.TanggalPerbarui = TanggalPerbarui
	WHERE siswa.Id = Id;
	
	SELECT siswa.Id, siswa.NamaSiswa, siswa.IdKelas, kelas.NamaKelas, siswa.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, siswa.JenisKelamin, siswa.Alamat, siswa.Agama, siswa.TanggalLahir, siswa.NoHp, 
	        siswa.NamaOrangTua,  siswa.AlamatOrangTua,  siswa.NoHpOrangTua,  siswa.PenghasilanOrangTua,
	       siswa.PenggunaBuat, siswa.TerminalBuat, siswa.TanggalBuat, siswa.PenggunaPerbarui, 
	       siswa.TerminalPerbarui, siswa.TanggalPerbarui
	FROM siswa LEFT JOIN kelas ON siswa.IdKelas = kelas.Id 
	           LEFT JOIN tahun_ajaran ON siswa.IdTahunAjaran = tahun_ajaran.Id
	WHERE siswa.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditSPP` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditSPP` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditSPP`(
 IN Id LONG, IN IdSiswa LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN Tahun INT, IN Bulan INT, IN NamaBulan VARCHAR(50),
 IN NilaiSPP LONG, IN Bayar LONG, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
	UPDATE spp SET spp.IdSiswa = IdSiswa, spp.IdKelas = IdKelas, spp.IdTahunAjaran = IdTahunAjaran,
	               spp.Tahun = Tahun, spp.Bulan = Bulan, spp.NamaBulan = NamaBulan,
	               spp.NilaiSPP = NilaiSPP, spp.Bayar = Bayar, spp.Kembalian = Bayar - NilaiSPP,
	               spp.PenggunaPerbarui = PenggunaPerbarui, spp.TerminalPerbarui = TerminalPerbarui,
	               spp.TanggalPerbarui = TanggalPerbarui
	WHERE spp.Id = Id;
	
	SELECT spp.Id, spp.IdSiswa, siswa.NamaSiswa, spp.IdKelas, kelas.NamaKelas, spp.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, spp.Tahun, spp.Bulan, spp.NamaBulan, spp.NilaiSPP, spp.Bayar, spp.Kembalian,
	       spp.PenggunaBuat, spp.TerminalBuat, spp.TanggalBuat, spp.PenggunaPerbarui, 
	       spp.TerminalPerbarui, spp.TanggalPerbarui
	FROM spp LEFT JOIN siswa ON spp.IdSiswa = siswa.Id 
	         LEFT JOIN kelas ON spp.IdKelas = kelas.Id 
	         LEFT JOIN tahun_ajaran ON spp.IdTahunAjaran = tahun_ajaran.Id
	WHERE spp.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditTahunAjaran` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditTahunAjaran` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditTahunAjaran`(
 IN Id LONG, IN TahunAjaran VARCHAR(50), IN Deskripsi VARCHAR(50), IN Aktif BIT, 
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
        
	update tahun_ajaran set tahun_ajaran.TahunAjaran = TahunAjaran, tahun_ajaran.Deskripsi = Deskripsi,
                                tahun_ajaran.Aktif = Aktif, tahun_ajaran.PenggunaPerbarui = PenggunaPerbarui,
                                tahun_ajaran.TerminalPerbarui = TerminalPerbarui, tahun_ajaran.TanggalPerbarui = TanggalPerbarui
        where tahun_ajaran.Id = Id;	
	
	SELECT * FROM tahun_ajaran WHERE tahun_ajaran.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_EditWaliKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_EditWaliKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditWaliKelas`(
 IN Id LONG, IN IdGuru LONG, IN IdKelas LONG, IN IdTahunAjaran LONG, IN Deskripsi VARCHAR(50),
 IN PenggunaPerbarui VARCHAR(50), IN TerminalPerbarui VARCHAR(50), IN TanggalPerbarui DATETIME
)
BEGIN
	UPDATE wali_kelas SET wali_kelas.IdGuru = IdGuru, wali_kelas.IdKelas = IdKelas, wali_kelas.IdTahunAjaran = IdTahunAjaran, wali_kelas.Deskripsi = Deskripsi,
	                      wali_kelas.PenggunaPerbarui = PenggunaPerbarui, wali_kelas.TerminalPerbarui = TerminalPerbarui,
	                      wali_kelas.TanggalPerbarui = TanggalPerbarui
	WHERE wali_kelas.Id = Id;
	
	SELECT wali_kelas.Id, wali_kelas.IdGuru, guru.NamaGuru, wali_kelas.IdKelas, kelas.NamaKelas, wali_kelas.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, wali_kelas.Deskripsi, 
	       wali_kelas.PenggunaBuat, wali_kelas.TerminalBuat, wali_kelas.TanggalBuat, 
	       wali_kelas.PenggunaPerbarui, wali_kelas.TerminalPerbarui, wali_kelas.TanggalPerbarui
	FROM wali_kelas LEFT JOIN guru ON wali_kelas.IdGuru = guru.Id 
	                LEFT JOIN kelas ON wali_kelas.IdKelas = kelas.Id
	                LEFT JOIN tahun_ajaran ON wali_kelas.IdTahunAjaran = tahun_ajaran.Id
	WHERE wali_kelas.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetAbsenGuruById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetAbsenGuruById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetAbsenGuruById`(IN Id LONG)
BEGIN
	    SELECT absen_guru.Id, absen_guru.IdGuru, guru.NamaGuru, absen_guru.IdKelas, kelas.NamaKelas, absen_guru.IdTahunAjaran,
		   tahun_ajaran.TahunAjaran, absen_guru.NamaAbsen, absen_guru.TanggalAbsen, absen_guru.AbsenMasuk, absen_guru.AbsenKeluar,
		   absen_guru.PenggunaBuat, absen_guru.TerminalBuat, absen_guru.TanggalBuat, absen_guru.PenggunaPerbarui, 
		   absen_guru.TerminalPerbarui, absen_guru.TanggalPerbarui
	    FROM absen_guru 
				     INNER JOIN guru ON absen_guru.IdGuru = guru.Id
				     INNER JOIN kelas ON absen_guru.IdKelas = kelas.Id
				     INNER JOIN tahun_ajaran ON absen_guru.IdTahunAjaran = tahun_ajaran.Id
	    WHERE absen_guru.Id = Id;
    END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetAbsenSiswaById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetAbsenSiswaById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetAbsenSiswaById`(
 IN Id LONG
)
BEGIN
	
	SELECT absen_siswa.Id, absen_siswa.IdSiswa, siswa.NamaSiswa, absen_siswa.IdKelas, kelas.NamaKelas, absen_siswa.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, absen_siswa.NamaAbsen, absen_siswa.TanggalAbsen, absen_siswa.Deskripsi, 
	       absen_siswa.PenggunaBuat, absen_siswa.TerminalBuat, absen_siswa.TanggalBuat, absen_siswa.PenggunaPerbarui, 
	       absen_siswa.TerminalPerbarui, absen_siswa.TanggalPerbarui
	FROM absen_siswa LEFT JOIN siswa ON absen_siswa.IdSiswa = siswa.Id 
	                 LEFT JOIN kelas ON absen_guru.IdKelas = kelas.Id
	                 LEFT JOIN tahun_ajaran ON absen_guru.IdTahunAjaran = tahun_ajaran.Id
	WHERE Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetDaftarUlangById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetDaftarUlangById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetDaftarUlangById`(
 IN Id LONG
)
BEGIN
	
	SELECT daftar_ulang.Id, daftar_ulang.IdSiswa, siswa.NamaSiswa, 
	       daftar_ulang.IdTahunAjaran, tahun_ajaran.TahunAjaran, daftar_ulang.IdTahunAjaranTo, TahunAjaranTo.TahunAjaran AS TahunAjaranTo, 
	       daftar_ulang.DariKelas, kelas.NamaKelas AS NamaDariKelas, daftar_ulang.KeKelas, KeKelas.NamaKelas AS NamaKeKelas,
	       daftar_ulang.NilaiDaftarUlang, daftar_ulang.Bayar, daftar_ulang.Kembalian, daftar_ulang.Deskripsi, 
	       daftar_ulang.PenggunaBuat, daftar_ulang.TerminalBuat, daftar_ulang.TanggalBuat, 
	       daftar_ulang.PenggunaPerbarui, daftar_ulang.TerminalPerbarui, daftar_ulang.TanggalPerbarui
	FROM daftar_ulang LEFT JOIN siswa ON daftar_ulang.IdSiswa = siswa.Id 
	                  LEFT JOIN kelas ON daftar_ulang.DariKelas = kelas.Id
	                  LEFT JOIN kelas AS KeKelas ON daftar_ulang.KeKelas = KeKelas.Id
	                  LEFT JOIN tahun_ajaran ON daftar_ulang.IdTahunAjaran = tahun_ajaran.Id
	                  LEFT JOIN tahun_ajaran AS TahunAjaranTo ON daftar_ulang.IdTahunAjaranTo = TahunAjaranTo.Id
	WHERE daftar_ulang.Id = Id;
	

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetGuruById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetGuruById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetGuruById`(
 IN Id LONG
)
BEGIN
	
	SELECT NomorIndukPegawai, NoKTP, NamaGuru, JenisKelamin, StatusGuru, Agama, Alamat, Pendidikan, 
	                  TanggalLahir, NoHp, Aktif, PenggunaBuat, TerminalBuat, TanggalBuat, 
	                  PenggunaPerbarui, TerminalPerbarui, TanggalPerbarui
	FROM guru 
	WHERE Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetJadwalGuruById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetJadwalGuruById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetJadwalGuruById`(
 IN Id LONG
)
BEGIN
	
	SELECT jadwal_guru.Id, jadwal_guru.IdGuru, guru.NamaGuru, jadwal_guru.Hari, jadwal_guru.IdKelas, kelas.NamaKelas, 
	       jadwal_guru.IdPelajaran, pelajaran.NamaPelajaran, jadwal_guru.IdTahunAjaran, tahun_ajaran.TahunAjaran, 
	       jadwal_guru.DariJam, jadwal_guru.SampaiJam,
	       jadwal_guru.PenggunaBuat, jadwal_guru.TerminalBuat, jadwal_guru.TanggalBuat, jadwal_guru.PenggunaPerbarui, 
	       jadwal_guru.TerminalPerbarui, jadwal_guru.TanggalPerbarui
	FROM jadwal_guru LEFT JOIN guru ON jadwal_guru.IdGuru = guru.Id 
	                         LEFT JOIN kelas ON jadwal_guru.IdKelas = kelas.Id
	                         LEFT JOIN tahun_ajaran ON jadwal_guru.IdTahunAjaran = tahun_ajaran.Id
	                         LEFT JOIN pelajaran ON jadwal_guru.IdPelajaran = pelajaran.Id
	WHERE jadwal_guru.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetKelasById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetKelasById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetKelasById`(
 IN Id LONG
)
BEGIN
	
	SELECT * FROM kelas WHERE kelas.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetMenuHeaderPengguna` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetMenuHeaderPengguna` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetMenuHeaderPengguna`(
 IN IdPengguna LONG
)
BEGIN
	SELECT menu_role.Id, pengguna_role.IdPengguna, pengguna.NamaPengguna, pengguna_role.IdRole, role.NamaRole,
	       menu.IdMenuParent AS IdMenuParent, menu_role.IdMenu, menu.NamaMenu AS NamaMenuParent, 
	       menu.NamaMenu, menu.NamaController, menu.NamaAction, menu.type, menu.Aktif, menu.Sort,
	       menu_role.PenggunaBuat, menu_role.TerminalBuat, menu_role.TanggalBuat,
	       menu_role.PenggunaPerbarui, menu_role.TerminalPerbarui, menu_role.TanggalPerbarui
	FROM pengguna 
	                       LEFT JOIN pengguna_role ON pengguna.Id = pengguna_role.IdPengguna
	                       LEFT JOIN menu_role ON pengguna_role.IdRole = menu_role.IdRole
	                       LEFT JOIN role ON pengguna_role.IdRole = role.Id
	                       LEFT JOIN menu ON menu_role.IdMenu = menu.Id
	WHERE pengguna.Id = IdPengguna AND menu.Aktif = 1 AND menu.IdMenuParent = 0 ORDER BY menu.SortHeader, menu.Sort;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetMenuPengguna` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetMenuPengguna` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetMenuPengguna`(
 IN IdPengguna LONG
)
BEGIN
	SELECT menu_role.Id, pengguna_role.IdPengguna, pengguna.NamaPengguna, pengguna_role.IdRole, role.NamaRole,
	       menu.IdMenuParent AS IdMenuParent, menu_role.IdMenu, IFNULL(menu_parent.NamaMenu,'') AS NamaMenuParent, 
	       menu.NamaMenu, menu.NamaController, menu.NamaAction, menu.type, menu.Aktif, menu.Sort,
	       menu_role.PenggunaBuat, menu_role.TerminalBuat, menu_role.TanggalBuat,
	       menu_role.PenggunaPerbarui, menu_role.TerminalPerbarui, menu_role.TanggalPerbarui
	FROM pengguna 
	                       LEFT JOIN pengguna_role ON pengguna.Id = pengguna_role.IdPengguna
	                       LEFT JOIN menu_role ON pengguna_role.IdRole = menu_role.IdRole
	                       LEFT JOIN role ON pengguna_role.IdRole = role.Id
	                       LEFT JOIN menu ON menu_role.IdMenu = menu.Id
	                       LEFT JOIN menu AS menu_parent ON menu.IdMenuParent = menu_parent.Id
	WHERE pengguna.Id = 1 AND menu.Aktif = 1 ORDER BY menu_parent.SortHeader, menu.Sort;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetMenuRoleById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetMenuRoleById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetMenuRoleById`(
 IN Id LONG
)
BEGIN
	
	select menu_role.Id, menu_role.IdRole, role.NamaRole, menu_role.IdMenu, menu.NamaMenu,
	       menu_role.PenggunaBuat, menu_role.TerminalBuat, menu_role.TanggalBuat, 
	       menu_role.PenggunaPerbarui, menu_role.TerminalPerbarui, menu_role.TanggalPerbarui
	from menu_role 
	                        left join role on menu_role.IdRole = role.Id
	                        left join menu on menu_role.IdMenu = menu.Id
	WHERE menu_role.Id = Id;
	                        

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetPelajaranById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetPelajaranById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPelajaranById`(
 IN Id long
)
BEGIN
	
	SELECT * FROM pelajaran WHERE pelajaran.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetPelanggaranById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetPelanggaranById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPelanggaranById`(
 IN Id LONG
)
BEGIN
	
	SELECT * FROM pelanggaran 
	WHERE Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetPelanggaranSiswaById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetPelanggaranSiswaById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPelanggaranSiswaById`(
 IN Id LONG
)
BEGIN     
        
	SELECT pelanggaran_siswa.Id, pelanggaran_siswa.IdSiswa, siswa.NamaSiswa, 
	       pelanggaran_siswa.IdPelanggaran, pelanggaran.NamaPelanggaran, pelanggaran.Poin, 
	       pelanggaran_siswa.Deskripsi, pelanggaran_siswa.PenggunaBuat, 
	       pelanggaran_siswa.TerminalBuat, pelanggaran_siswa.TanggalBuat,
	       pelanggaran_siswa.PenggunaPerbarui, pelanggaran_siswa.TerminalPerbarui,
	       pelanggaran_siswa.TanggalPerbarui
	FROM pelanggaran_siswa 
	              left join siswa on pelanggaran_siswa.IdSiswa = siswa.Id
	              left join pelanggaran on pelanggaran_siswa.IdPelanggaran = pelanggaran.Id
	WHERE pelanggaran_siswa.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetPembayaranById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetPembayaranById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPembayaranById`(
 IN Id LONG
)
BEGIN

        SELECT pembayaran.Id, pembayaran.IdSiswa, siswa.NamaSiswa, pembayaran.IdConfigPembayaran, config_pembayaran.NamaPembayaran, 
               pembayaran.NilaiPembayaran, tahun_ajaran.TahunAjaran, pembayaran.Bayar, pembayaran.Kembalian, pembayaran.Deskripsi,
               pembayaran.PenggunaBuat, pembayaran.TerminalBuat, pembayaran.TanggalBuat, 
               pembayaran.PenggunaPerbarui, pembayaran.TerminalPerbarui, pembayaran.TanggalPerbarui
        FROM pembayaran LEFT JOIN siswa ON pembayaran.IdSiswa = siswa.Id
                        LEFT JOIN config_pembayaran ON pembayaran.IdConfigPembayaran = config_pembayaran.Id
                        LEFT JOIN tahun_ajaran ON config_pembayaran.IdTahunAjaran = tahun_ajaran.Id
        WHERE pembayaran.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetPenggunaById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetPenggunaById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPenggunaById`(
 IN Id LONG
)
BEGIN
      
        SELECT pengguna.Id, pengguna.NamaPengguna, pengguna.IdGuru, guru.NamaGuru, pengguna.PASSWORD, 
               pengguna.Email, pengguna.StatusPengguna, pengguna.ExpiredPassword, pengguna.Aktif,
               pengguna.PenggunaBuat, pengguna.pengguna, pengguna.TanggalBuat, 
               pengguna.PenggunaPerbarui, pengguna.TerminalPerbarui, pengguna.TanggalPerbarui
        FROM pengguna LEFT JOIN guru ON pengguna.IdGuru = guru.Id
        WHERE pengguna.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetPenggunaRoleById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetPenggunaRoleById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPenggunaRoleById`(
 IN Id LONG
)
BEGIN
        
        select pengguna_role.Id, pengguna_role.IdPengguna, pengguna.NamaPengguna, pengguna_role.IdRole, role.NamaRole, pengguna_role.Deskripsi,
               pengguna_role.PenggunaBuat, pengguna_role.TerminalBuat, pengguna_role.TanggalBuat, 
               pengguna_role.PenggunaPerbarui, pengguna_role.TerminalPerbarui, pengguna_role.TanggalPerbarui
        from pengguna_role left join pengguna on pengguna_role.IdPengguna = pengguna.Id
                           left join role on pengguna_role.IdRole = role.Id
        where pengguna_role.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetPenilaianById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetPenilaianById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPenilaianById`(
 IN Id LONG
)
BEGIN
       
	SELECT penilaian.Id, penilaian.Idpelajaran, pelajaran.NamaPelajaran, penilaian.NamaPenilaian, penilaian.Deskripsi,
	       penilaian.Aktif, penilaian.PenggunaBuat, penilaian.TerminalBuat, penilaian.TanggalBuat, 
	       penilaian.PenggunaPerbarui, penilaian.TerminalPerbarui, penilaian.TanggalPerbarui
	FROM penilaian 
			left join pelajaran on penilaian.IdPelajaran = pelajaran.Id
	WHERE penilaian.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetPenilaianSiswaById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetPenilaianSiswaById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetPenilaianSiswaById`(
 IN Id LONG
)
BEGIN
       
       SELECT penilaian_siswa.Id, penilaian_siswa.IdSiswa, siswa.NamaSiswa, penilaian_siswa.IdTahunAjaran, tahun_ajaran.TahunAjaran,
              penilaian_siswa.IdPenilaian, pelajaran.NamaPelajaran, penilaian.NamaPenilaian, penilaian_siswa.Nilai, penilaian_siswa.Deskripsi,
	      penilaian_siswa.PenggunaBuat, penilaian_siswa.TerminalBuat, penilaian_siswa.TanggalBuat, 
	      penilaian_siswa.PenggunaPerbarui, penilaian_siswa.TerminalPerbarui, penilaian_siswa.TanggalPerbarui
       FROM penilaian_siswa 
		 JOIN siswa ON penilaian_siswa.IdSiswa = siswa.Id
		 JOIN kelas ON penilaian_siswa.IdKelas = kelas.Id
		 JOIN tahun_ajaran ON penilaian_siswa.IdTahunAjaran = tahun_ajaran.Id
		 JOIN penilaian ON penilaian_siswa.IdPenilaian = penilaian.Id
		 JOIN pelajaran ON penilaian.IdPelajaran = pelajaran.Id
       WHERE penilaian_siswa.Id = Id;
	
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetRaportSiswaById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetRaportSiswaById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetRaportSiswaById`(
 IN Id LONG
)
BEGIN
      
       Select raport_siswa.Id, raport_siswa.IdSiswa, siswa.NamaSiswa, raport_siswa.IdKelas, kelas.NamaKelas, 
              raport_siswa.IdPelajaran, pelajaran.NamaPelajaran, raport_siswa.IdTahunAjaran, tahun_ajaran.TahunAjaran,
              raport_siswa.Nilai, raport_siswa.PenggunaBuat, raport_siswa.TerminalBuat, raport_siswa.TanggalBuat,
              raport_siswa.PenggunaPerbarui, raport_siswa.TerminalPerbarui, raport_siswa.TanggalPerbarui
       From raport_siswa 
                     left join siswa on raport_siswa.IdSiswa = siswa.Id
                     left join kelas on raport_siswa.IdKelas = kelas.Id
                     left join pelajaran on raport_siswa.IdPelajaran = pelajaran.Id
                     left join tahun_ajaran on raport_siswa.IdTahunAjaran = tahun_ajaran.Id
       Where raport_siswa.Id = Id;
        
       
END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetRoleById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetRoleById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetRoleById`(
 IN Id long
)
BEGIN
        
	SELECT * from role WHERE role.NamaRole = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetSiswaById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetSiswaById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetSiswaById`(
 IN Id long
)
BEGIN
	
	SELECT siswa.Id, siswa.NamaSiswa, siswa.IdKelas, kelas.NamaKelas, siswa.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, siswa.JenisKelamin, siswa.Alamat, siswa.Agama, siswa.TanggalLahir, siswa.NoHp, siswa.NamaOrangTua,
	       siswa.PenggunaBuat, siswa.TerminalBuat, siswa.TanggalBuat, siswa.PenggunaPerbarui, 
	       siswa.TerminalPerbarui, siswa.TanggalPerbarui
	FROM siswa LEFT JOIN kelas ON siswa.IdKelas = kelas.Id 
	           LEFT JOIN tahun_ajaran ON siswa.IdTahunAjaran = tahun_ajaran.Id
	WHERE siswa.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetSPPById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetSPPById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetSPPById`(
 IN Id LONG
)
BEGIN
	
	SELECT spp.Id, spp.IdSiswa, siswa.NamaSiswa, spp.IdKelas, kelas.NamaKelas, spp.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, spp.Tahun, spp.Bulan, spp.NamaBulan, spp.NilaiSPP, spp.Bayar, spp.Kembalian,
	       spp.PenggunaBuat, spp.TerminalBuat, spp.TanggalBuat, spp.PenggunaPerbarui, 
	       spp.TerminalPerbarui, spp.TanggalPerbarui
	FROM spp left join siswa on spp.IdSiswa = siswa.Id 
	         LEFT JOIN kelas ON spp.IdKelas = kelas.Id 
	         LEFT JOIN tahun_ajaran ON spp.IdTahunAjaran = tahun_ajaran.Id
	WHERE spp.Id = Id;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetTahunAjaranById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetTahunAjaranById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetTahunAjaranById`(
 IN Id LONG
)
BEGIN
	SELECT * FROM tahun_ajaran WHERE tahun_ajaran.Id = Id;

END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_GetWaliKelasById` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_GetWaliKelasById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetWaliKelasById`(
 IN Id LONG
)
BEGIN
	
	SELECT wali_kelas.Id, wali_kelas.IdGuru, guru.NamaGuru, wali_kelas.IdKelas, kelas.NamaKelas, wali_kelas.IdTahunAjaran,
	       tahun_ajaran.TahunAjaran, wali_kelas.Deskripsi, 
	       wali_kelas.PenggunaBuat, wali_kelas.TerminalBuat, wali_kelas.TanggalBuat, 
	       wali_kelas.PenggunaPerbarui, wali_kelas.TerminalPerbarui, wali_kelas.TanggalPerbarui
	FROM wali_kelas LEFT JOIN guru ON wali_kelas.IdGuru = guru.Id 
	                LEFT JOIN kelas ON wali_kelas.IdKelas = kelas.Id
	                LEFT JOIN tahun_ajaran ON wali_kelas.IdTahunAjaran = tahun_ajaran.Id
	WHERE wali_kelas.IdGuru = IdGuru AND wali_kelas.IdKelas = IdKelas AND wali_kelas.IdTahunAjaran = IdTahunAjaran;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_Login` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_Login` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Login`(
 IN NamaPengguna VARCHAR(50), IN Pass VARCHAR(50)
)
BEGIN
	SELECT NamaPengguna, Email, guru.NamaGuru FROM pengguna JOIN guru ON pengguna.IdGuru = guru.Id
	WHERE pengguna.NamaPengguna = NamaPengguna AND pengguna.Password = Pass;

  END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_TotalBayarUangBangunan` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_TotalBayarUangBangunan` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_TotalBayarUangBangunan`(
 IN IdSiswa LONG
)
BEGIN
	select IFNULL(SUM(Bayar),0) AS TotalBayar from uang_bangunan where uang_bangunan.IdSiswa = IdSiswa;

END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_TotalGuru` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_TotalGuru` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_TotalGuru`(
 
)
BEGIN
	SELECT COUNT(*) AS TotalGuru FROM guru WHERE Aktif = 1;

END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_TotalKelas` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_TotalKelas` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_TotalKelas`(
 
)
BEGIN
	select COUNT(*) AS TotalKelas from kelas where Aktif = 1;

END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_TotalSiswa` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_TotalSiswa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_TotalSiswa`(
 
)
BEGIN
	select COUNT(*) AS TotalSiswa from siswa where Aktif = 1;

END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_TotalSPP` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_TotalSPP` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_TotalSPP`(
 
)
BEGIN
	SELECT IFNULL(SUM(Bayar),0) AS TotalSPP FROM spp WHERE Tahun = YEAR(CURDATE()) And Bulan = MONTH(CURDATE());

END */$$
DELIMITER ;

/* Procedure structure for procedure `sp_TotalUangBangunan` */

/*!50003 DROP PROCEDURE IF EXISTS  `sp_TotalUangBangunan` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_TotalUangBangunan`(
 
)
BEGIN
	SELECT IFNULL(SUM(Bayar),0) AS TotalUangBangunan FROM uang_bangunan WHERE Tahun = YEAR(CURDATE());

END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
