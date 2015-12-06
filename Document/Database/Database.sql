-- MySQL dump 10.13  Distrib 5.6.23, for Win32 (x86)
--
-- Host: localhost    Database: mdw
-- ------------------------------------------------------
-- Server version	5.6.24-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `character`
--

DROP TABLE IF EXISTS `character`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `character` (
  `idCharacter` int(11) NOT NULL,
  `CharacterName` varchar(45) NOT NULL,
  `Lv` int(11) NOT NULL DEFAULT '1',
  `Experience` int(11) NOT NULL DEFAULT '0',
  `Element` enum('water','fire','air','earth') NOT NULL DEFAULT 'water',
  `Class` enum('warrior','wizard','archer') NOT NULL DEFAULT 'warrior',
  `Strength` int(3) NOT NULL DEFAULT '0',
  `Constitution` int(3) NOT NULL DEFAULT '0',
  `Magic` int(3) NOT NULL DEFAULT '0',
  `Wisdom` int(3) NOT NULL DEFAULT '0',
  `Dexterity` int(3) NOT NULL DEFAULT '0',
  `Agility` int(3) NOT NULL DEFAULT '0',
  `AttributePoints` int(11) NOT NULL DEFAULT '0',
  `SkillPoints` int(11) NOT NULL DEFAULT '0',
  `User_idUser` int(11) NOT NULL,
  PRIMARY KEY (`idCharacter`,`User_idUser`),
  UNIQUE KEY `CharacterName_UNIQUE` (`CharacterName`),
  KEY `fk_Character_User_idx` (`User_idUser`),
  CONSTRAINT `fk_Character_User` FOREIGN KEY (`User_idUser`) REFERENCES `user` (`idUser`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `character`
--

LOCK TABLES `character` WRITE;
/*!40000 ALTER TABLE `character` DISABLE KEYS */;
INSERT INTO `character` VALUES (1,'Lexi',12,4554,'fire','warrior',26,32,12,13,15,14,0,2,1),(2,'Lamia',1,0,'fire','wizard',10,10,12,11,10,10,0,0,2),(3,'Grunt',1,0,'air','warrior',12,11,10,10,10,10,0,0,3),(6,'Lex',1,0,'water','archer',10,10,10,10,12,11,0,0,6);
/*!40000 ALTER TABLE `character` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `character_skill`
--

DROP TABLE IF EXISTS `character_skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `character_skill` (
  `character_idCharacter` int(11) NOT NULL,
  `character_User_idUser` int(11) NOT NULL,
  `skill_idPower` int(11) NOT NULL,
  `skillLv` int(2) NOT NULL,
  PRIMARY KEY (`character_idCharacter`,`character_User_idUser`,`skill_idPower`),
  KEY `fk_character_skill_skill1_idx` (`skill_idPower`),
  CONSTRAINT `fk_character_skill_character1` FOREIGN KEY (`character_idCharacter`, `character_User_idUser`) REFERENCES `character` (`idCharacter`, `User_idUser`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_character_skill_skill1` FOREIGN KEY (`skill_idPower`) REFERENCES `skill` (`idPower`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `character_skill`
--

LOCK TABLES `character_skill` WRITE;
/*!40000 ALTER TABLE `character_skill` DISABLE KEYS */;
/*!40000 ALTER TABLE `character_skill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill`
--

DROP TABLE IF EXISTS `skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skill` (
  `idPower` int(11) NOT NULL,
  `PowerName` varchar(45) NOT NULL,
  `Attack` int(11) NOT NULL,
  `Element` enum('water','fire','air','earth') NOT NULL,
  `Effect Description` varchar(45) NOT NULL,
  PRIMARY KEY (`idPower`),
  UNIQUE KEY `idPower` (`idPower`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill`
--

LOCK TABLES `skill` WRITE;
/*!40000 ALTER TABLE `skill` DISABLE KEYS */;
/*!40000 ALTER TABLE `skill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `idUser` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(45) NOT NULL,
  `Password` varchar(45) NOT NULL,
  `Wins` int(11) NOT NULL DEFAULT '0',
  `Loses` int(11) NOT NULL DEFAULT '0',
  `HasChar` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idUser`),
  UNIQUE KEY `Usercol_UNIQUE` (`Username`),
  UNIQUE KEY `idUser_UNIQUE` (`idUser`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Kukix','snow13',5,3,1),(2,'Raditya','2',3,1,1),(3,'Ishant','3',5,3,1),(4,'Lala','1',0,0,0),(5,'Chunny','4',0,0,0),(6,'Sammy','5',0,0,1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-06-11 13:11:36
