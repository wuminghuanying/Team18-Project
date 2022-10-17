-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: team18
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `Fname` varchar(30) DEFAULT NULL,
  `Minit` char(1) DEFAULT NULL,
  `Lname` varchar(30) DEFAULT NULL,
  `CLIENT_ID` varchar(4) NOT NULL,
  `CLIENT_COMPANY` varchar(20) DEFAULT NULL,
  `Project_ID` int DEFAULT NULL,
  PRIMARY KEY (`CLIENT_ID`),
  KEY `Project_ID` (`Project_ID`),
  CONSTRAINT `client_ibfk_1` FOREIGN KEY (`Project_ID`) REFERENCES `projects` (`PROJECT_NUM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `department` (
  `DEPT_NUM` int NOT NULL,
  `DEPT_MANAGER_SSN` int DEFAULT NULL,
  `DEPT_STREET` varchar(30) DEFAULT NULL,
  `DEPT_CITY` varchar(20) DEFAULT NULL,
  `DEPT_STATE` varchar(20) DEFAULT NULL,
  `DEPT_ZIP` char(5) DEFAULT NULL,
  `DEPT_FLOOR` int DEFAULT NULL,
  `DEPT_ROOM_NUM` int DEFAULT NULL,
  PRIMARY KEY (`DEPT_NUM`),
  KEY `DEPT_MANAGER_SSN` (`DEPT_MANAGER_SSN`),
  CONSTRAINT `department_ibfk_1` FOREIGN KEY (`DEPT_MANAGER_SSN`) REFERENCES `employee` (`SSN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `department`
--

LOCK TABLES `department` WRITE;
/*!40000 ALTER TABLE `department` DISABLE KEYS */;
/*!40000 ALTER TABLE `department` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dependent`
--

DROP TABLE IF EXISTS `dependent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dependent` (
  `Fname` varchar(30) DEFAULT NULL,
  `Minit` char(1) DEFAULT NULL,
  `Lname` varchar(30) DEFAULT NULL,
  `DOB` date DEFAULT NULL,
  `Relationship_to_employee` varchar(30) DEFAULT NULL,
  `Sex` char(2) DEFAULT NULL,
  `employee_ssn` int DEFAULT NULL,
  KEY `employee_ssn` (`employee_ssn`),
  CONSTRAINT `dependent_ibfk_1` FOREIGN KEY (`employee_ssn`) REFERENCES `employee` (`SSN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dependent`
--

LOCK TABLES `dependent` WRITE;
/*!40000 ALTER TABLE `dependent` DISABLE KEYS */;
/*!40000 ALTER TABLE `dependent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employee` (
  `Fname` varchar(30) DEFAULT NULL,
  `Minit` char(1) DEFAULT NULL,
  `Lname` varchar(30) DEFAULT NULL,
  `SSN` int NOT NULL,
  `DOB` date DEFAULT NULL,
  `Sex` char(1) DEFAULT NULL,
  `Address` varchar(40) DEFAULT NULL,
  `Zipcode` int DEFAULT NULL,
  `Department_number` int DEFAULT NULL,
  PRIMARY KEY (`SSN`),
  KEY `Department_number` (`Department_number`),
  CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`Department_number`) REFERENCES `department` (`DEPT_NUM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `projects`
--

DROP TABLE IF EXISTS `projects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `projects` (
  `PROJECT_NUM` int NOT NULL,
  `PROJECT_DEPT` int DEFAULT NULL,
  `PROJECT_MANAGER` varchar(30) DEFAULT NULL,
  `PROJECT_BUDGET` decimal(8,2) DEFAULT NULL,
  `CURRENT_EXPENSES` decimal(8,2) DEFAULT NULL,
  `PROJECT_TIME` int DEFAULT NULL,
  PRIMARY KEY (`PROJECT_NUM`),
  KEY `PROJECT_DEPT` (`PROJECT_DEPT`),
  CONSTRAINT `projects_ibfk_1` FOREIGN KEY (`PROJECT_DEPT`) REFERENCES `department` (`DEPT_NUM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `projects`
--

LOCK TABLES `projects` WRITE;
/*!40000 ALTER TABLE `projects` DISABLE KEYS */;
/*!40000 ALTER TABLE `projects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `works_on`
--

DROP TABLE IF EXISTS `works_on`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `works_on` (
  `EMPLOYEE_SSN` int DEFAULT NULL,
  `Project_num` int DEFAULT NULL,
  `Hours_worked` int DEFAULT NULL,
  KEY `EMPLOYEE_SSN` (`EMPLOYEE_SSN`),
  CONSTRAINT `works_on_ibfk_1` FOREIGN KEY (`EMPLOYEE_SSN`) REFERENCES `employee` (`SSN`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `works_on`
--

LOCK TABLES `works_on` WRITE;
/*!40000 ALTER TABLE `works_on` DISABLE KEYS */;
/*!40000 ALTER TABLE `works_on` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-10-16 19:27:18
