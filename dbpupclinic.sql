-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 27, 2019 at 08:43 AM
-- Server version: 10.1.34-MariaDB
-- PHP Version: 7.2.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbpupclinic`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbcategory`
--

CREATE TABLE `tbcategory` (
  `id` int(11) NOT NULL,
  `category` varchar(100) CHARACTER SET ascii COLLATE ascii_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbcategory`
--

INSERT INTO `tbcategory` (`id`, `category`) VALUES
(1, 'ANTI-PYRETIC'),
(2, 'ANALGESIC/ANTI-INFLAM'),
(3, 'COUGH/COLDS'),
(4, 'ANTI-EMETIC'),
(5, 'ANTI-HISTAMINE'),
(6, 'ANTI-HYPERTENSIVE'),
(7, 'ANTI-SPASMODIC'),
(8, 'ANTIDIARREAL'),
(9, 'ANTI-BACTERIAL'),
(10, 'ANTI-ACIDS'),
(11, 'ORAL REHYDRATION'),
(12, 'ANTI-VERTIGO'),
(13, 'MEDICAL SUPPLIES');

-- --------------------------------------------------------

--
-- Table structure for table `tbmedicineandsupplies`
--

CREATE TABLE `tbmedicineandsupplies` (
  `id` int(11) NOT NULL,
  `CATEGORY` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `DATE` date NOT NULL,
  `MedAndMat` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `QUANTITY` int(10) NOT NULL,
  `CONSUMED` int(10) NOT NULL,
  `BALANCE` int(100) NOT NULL,
  `UNIT` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbmedicineandsupplies`
--

INSERT INTO `tbmedicineandsupplies` (`id`, `CATEGORY`, `DATE`, `MedAndMat`, `QUANTITY`, `CONSUMED`, `BALANCE`, `UNIT`) VALUES
(1, 'ANTI-PYRETIC', '2018-09-29', 'PARACETAMOL(MYREMOL)', 274, 62, 212, 'tabs'),
(2, 'ANALGESIC/ANTI-INFLAM', '2018-08-24', 'MEFENAMIC ACID', 298, 40, 258, 'caps'),
(3, 'ANALGESIC/ANTI-INFLAM', '2017-02-22', 'MOBIC', 90, 20, 70, 'caps'),
(4, 'COUGH/COLDS', '2019-01-23', 'CARBOCISTIENE', 100, 0, 100, 'caps'),
(5, 'COUGH/COLDS', '2019-01-23', 'AMBROXOL', 200, 89, 111, 'tabs'),
(6, 'COUGH/COLDS', '2019-01-23', 'COLVAN', 50, 50, 0, 'caps'),
(7, 'COUGH/COLDS', '2018-08-29', 'SALBUTAMOL', 60, 60, 0, 'nebs.'),
(8, 'COUGH/COLDS', '2017-02-22', 'SALBUTAMOL nebules', 4, 4, 0, 'nebs.'),
(9, 'COUGH/COLDS', '2018-03-05', 'SALBUTAMOL nebules', 30, 0, 30, 'nebs.'),
(10, 'ANTI-EMETIC', '2019-01-29', 'DOMPERIDOME', 40, 3, 37, 'tabs'),
(11, 'ANTI-HISTAMINE', '2019-01-23', 'CETERIZINE', 50, 0, 50, 'tabs'),
(12, 'ANTI-HISTAMINE', '2018-08-24', 'DIPHENHYDRAMINE', 10, 2, 8, 'amps'),
(13, 'ANTI-HISTAMINE', '2017-02-27', 'DIPHENHYDRAMINE', 9, 0, 9, 'amps'),
(14, 'ANTI-HISTAMINE', '2018-08-29', 'CELESTAMINE', 20, 20, 0, 'tabs'),
(15, 'ANTI-BACTERIAL', '2017-02-22', 'CEFALEXIN', 200, 94, 106, 'caps'),
(16, 'ANTI-BACTERIAL', '2017-02-22', 'CEFUROXIME', 10, 0, 10, 'caps'),
(17, 'ANTI-BACTERIAL', '2017-06-30', 'CO AMOXICLAV', 10, 0, 10, 'caps'),
(18, 'ANTI-BACTERIAL', '2017-06-30', 'CEFUROXIME', 6, 0, 6, 'tabs'),
(19, 'ANTI-BACTERIAL', '2017-11-09', 'CIPROFLOXACIN', 100, 10, 90, 'tabs'),
(20, 'ANTI-BACTERIAL', '2017-11-09', 'CO AMOXICLAV', 4, 0, 4, 'tabs'),
(21, 'ANTI-BACTERIAL', '2018-08-28', 'CEFUROXIME', 10, 0, 10, 'tabs'),
(22, 'ANTI-BACTERIAL', '2018-08-28', 'AMOXICILLIN', 160, 30, 130, 'caps'),
(23, 'ANTI-BACTERIAL', '2018-01-14', 'CO AMOXICLAV', 14, 0, 14, 'tabs'),
(24, 'ANTI-BACTERIAL', '2018-01-14', 'CO AMOXICLAV', 12, 0, 12, 'tabs'),
(25, 'ANTI-BACTERIAL', '2018-01-14', 'CEFIXIME', 25, 0, 25, 'tabs'),
(26, 'ANTI-ACIDS', '2019-08-29', 'MAALOX', 120, 120, 0, 'ml'),
(27, 'ANTI-ACIDS', '2018-08-29', 'OMEPRAZOLE', 18, 18, 0, 'tabs'),
(28, 'ANTI-ACIDS', '2017-02-22', 'MAALOX', 18, 0, 18, 'ml'),
(29, 'ANTI-ACIDS', '2017-11-09', 'MAALOX', 2, 0, 2, 'bottle'),
(30, 'MEDICAL SUPPLIES', '2018-08-29', 'MICROPORE', 1, 0, 1, 'pc'),
(31, 'MEDICAL SUPPLIES', '2018-08-29', 'ALCOHOL', 1, 0, 1, '500ml'),
(32, 'MEDICAL SUPPLIES', '2018-08-29', 'MUPIROCIN', 1, 0, 1, '5g'),
(33, 'MEDICAL SUPPLIES', '0000-00-00', 'HOT WATER BAG', 2, 0, 2, 'pcs'),
(34, 'MEDICAL SUPPLIES', '0000-00-00', 'BANDAGE SCISSORS', 1, 0, 1, 'pc'),
(35, 'MEDICAL SUPPLIES', '0000-00-00', 'THUMB FORCEP', 1, 0, 1, 'pc'),
(36, 'MEDICAL SUPPLIES', '0000-00-00', 'BED SHEET', 4, 3, 1, 'pcs'),
(37, 'MEDICAL SUPPLIES', '0000-00-00', 'NEBULIZER KIT', 1, 0, 1, 'pc'),
(38, 'MEDICAL SUPPLIES', '0000-00-00', 'STAINLESS TRAY', 1, 0, 1, 'pc'),
(39, 'MEDICAL SUPPLIES', '0000-00-00', 'ICE CAP', 2, 0, 2, 'pcs'),
(40, 'MEDICAL SUPPLIES', '0000-00-00', 'OLTEN SHEET', 1, 0, 1, 'pc'),
(41, 'MEDICAL SUPPLIES', '0000-00-00', 'OXYGEN TANK', 1, 0, 1, 'pc'),
(42, 'MEDICAL SUPPLIES', '0000-00-00', 'OXYGEN REGULATOR', 1, 0, 1, 'pc'),
(43, 'MEDICAL SUPPLIES', '0000-00-00', '(ANEROID SPHYGMO)', 1, 0, 1, 'pc'),
(44, 'MEDICAL SUPPLIES', '0000-00-00', 'NEEDLE', 25, 0, 25, 'pcs'),
(45, 'MEDICAL SUPPLIES', '0000-00-00', 'LEUKOPLAST', 1, 0, 1, 'pc., 7.5cm'),
(46, 'MEDICAL SUPPLIES', '0000-00-00', 'GAUZE BANDAGE', 1, 0, 1, 'pc'),
(47, 'MEDICAL SUPPLIES', '2017-07-02', 'HOT WATER BAG', 1, 0, 1, 'pc'),
(48, 'MEDICAL SUPPLIES', '2015-07-02', 'BAND AID', 10, 0, 10, 'pcs'),
(49, 'MEDICAL SUPPLIES', '2015-10-01', 'BANDAGE', 2, 0, 2, 'pcs'),
(50, 'MEDICAL SUPPLIES', '2015-10-01', 'GAUZE BANDAGE', 2, 0, 2, 'pcs'),
(51, 'MEDICAL SUPPLIES', '2015-10-01', 'COTTON', 400, 0, 400, 'gm'),
(52, 'MEDICAL SUPPLIES', '2016-01-29', 'ELASTIC BANDAGE', 1, 0, 1, 'pc'),
(53, 'MEDICAL SUPPLIES', '2016-01-29', 'COTTON 400mg', 1, 0, 1, 'pc'),
(54, 'MEDICAL SUPPLIES', '2016-01-29', 'VISINE 10ml', 6, 0, 6, 'ml'),
(55, 'MEDICAL SUPPLIES', '2016-01-29', 'HYDROGEN PEROXIDE', 500, 0, 500, 'ml'),
(56, 'MEDICAL SUPPLIES', '2016-01-29', 'VISINE', 6, 0, 6, 'ml'),
(57, 'MEDICAL SUPPLIES', '2016-01-29', 'ELASTIC BANDAGE', 1, 0, 1, 'pc'),
(58, 'MEDICAL SUPPLIES', '2016-01-29', 'GAUZE BANDAGE', 2, 0, 2, 'pcs'),
(59, 'MEDICAL SUPPLIES', '2016-08-31', 'ALLEERSINE', 5, 0, 5, 'ml'),
(60, 'MEDICAL SUPPLIES', '2016-08-31', 'ELASTIC BANDAGE', 1, 0, 1, 'pc'),
(61, 'MEDICAL SUPPLIES', '2017-01-30', 'ROLL BY SPHYGMO', 1, 0, 1, 'pc'),
(62, 'MEDICAL SUPPLIES', '2017-02-22', 'POCKET ANEROID', 1, 0, 1, 'pc'),
(63, 'MEDICAL SUPPLIES', '2017-01-30', 'WHEELCHAIR', 1, 0, 1, 'pc'),
(64, 'MEDICAL SUPPLIES', '2017-02-22', 'SILVER SULFADIAZINE', 10, 0, 10, 'mg'),
(65, 'MEDICAL SUPPLIES', '2017-02-22', 'ICE CAP', 1, 0, 1, 'pc'),
(66, 'MEDICAL SUPPLIES', '2018-08-28', 'LORNASONE', 1, 0, 1, '5g'),
(67, 'MEDICAL SUPPLIES', '2018-03-05', 'SUTURE PACK', 2, 0, 2, 'pcs'),
(68, 'MEDICAL SUPPLIES', '2017-02-22', 'GAUZE BANDAGE', 12, 0, 12, 'rolls'),
(69, 'MEDICAL SUPPLIES', '2017-02-22', 'HOT WATER BAG', 2, 0, 2, 'pcs'),
(70, 'MEDICAL SUPPLIES', '2017-02-22', 'ELASTIC BANDAGE', 17, 0, 17, 'pcs'),
(71, 'MEDICAL SUPPLIES', '2017-02-22', 'POVIDONE', 120, 0, 120, 'ml'),
(72, 'MEDICAL SUPPLIES', '2017-06-30', 'THERMOMETER', 3, 1, 2, 'pcs'),
(73, 'MEDICAL SUPPLIES', '2017-06-30', 'FACE MASK', 48, 3, 45, 'pcs'),
(74, 'MEDICAL SUPPLIES', '2017-06-30', 'ELASTIC BANDAGE', 10, 0, 10, 'pcs'),
(75, 'MEDICAL SUPPLIES', '2017-06-30', 'SLING BANDAGE', 2, 1, 1, 'pcs');

-- --------------------------------------------------------

--
-- Table structure for table `tbpatient`
--

CREATE TABLE `tbpatient` (
  `id` int(11) NOT NULL,
  `DATETIME` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `NAME` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `YEARSECTION` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `COMPLAINTSIMPRESSION` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `TREATMENTMEDICINES` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `tbpatient`
--

INSERT INTO `tbpatient` (`id`, `DATETIME`, `NAME`, `YEARSECTION`, `COMPLAINTSIMPRESSION`, `TREATMENTMEDICINES`) VALUES
(1, '2019-03-26 07:57:24', 'Sherwin Malveda', 'BSIT 4-1', 'Cough', 'Ambroxol'),
(3, '2019-04-26 09:43:03', 'Anyone', '', '', ''),
(4, '2019-04-26 10:49:42', 'Sherwin Malveda', 'OTHER', 'Fever', 'Paracetamol'),
(5, '2019-04-26 10:52:29', 'Sherwin Malveda', 'BSIT 4-1', 'Cough/Fever', 'Ambroxol'),
(9, '2019-04-26 11:12:14', 'Malveda, Sherwin', 'BSA 3-2', '', 'Paracetamol'),
(10, '2019-04-27 05:09:39', '', 'BSIT 1-1', '', 'AMBROXOL'),
(11, '2019-04-27 05:14:14', 'Win', 'BSIT 1-1', 'Fever', 'AMBROXOL'),
(12, '2019-04-27 05:15:02', 'WInwin', 'BSIT 1-1', 'Cough', 'AMBROXOL'),
(13, '2019-04-27 05:15:30', '', 'BSIT 1-1', '', 'AMBROXOL'),
(14, '2019-04-27 05:17:42', '', 'BSIT 1-1', '', 'AMBROXOL'),
(15, '2019-04-27 05:20:53', 'aa', 'BSIT 1-1', 'aa', 'AMBROXOL'),
(16, '2019-04-27 05:42:08', 'win', 'BSIT 1-1', 'ANTI-BACTERIAL', 'CEFALEXIN'),
(17, '2019-04-27 05:46:44', 'Sherwin', 'BSIT 1-1', '', ''),
(18, '2019-04-27 05:47:18', 'Sherwin', 'BSIT 1-1', 'BP', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbcategory`
--
ALTER TABLE `tbcategory`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbmedicineandsupplies`
--
ALTER TABLE `tbmedicineandsupplies`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbpatient`
--
ALTER TABLE `tbpatient`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbcategory`
--
ALTER TABLE `tbcategory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `tbmedicineandsupplies`
--
ALTER TABLE `tbmedicineandsupplies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=76;

--
-- AUTO_INCREMENT for table `tbpatient`
--
ALTER TABLE `tbpatient`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
