SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `mdw` DEFAULT CHARACTER SET utf8 ;
USE `mdw` ;

-- -----------------------------------------------------
-- Table `mdw`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdw`.`user` (
  `idUser` INT(11) NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL,
  `Wins` INT(11) NOT NULL DEFAULT '0',
  `Loses` INT(11) NOT NULL DEFAULT '0',
  `HasChar` TINYINT(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idUser`),
  UNIQUE INDEX `Usercol_UNIQUE` (`Username` ASC),
  UNIQUE INDEX `idUser_UNIQUE` (`idUser` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 1
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mdw`.`character`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdw`.`character` (
  `idCharacter` INT(11) NOT NULL,
  `CharacterName` VARCHAR(45) NOT NULL,
  `Lv` INT(11) NOT NULL,
  `Experience` INT(11) NOT NULL,
  `Element` ENUM('water','fire','air','earth') NOT NULL DEFAULT 'water',
  `Class` ENUM('warrior','wizard','archer') NOT NULL DEFAULT 'warrior',
  `Strength` INT(3) NOT NULL,
  `Constitution` INT(3) NOT NULL,
  `Magic` INT(3) NOT NULL,
  `Wisdom` INT(3) NOT NULL,
  `Dexterity` INT(3) NOT NULL,
  `Agility` INT(3) NOT NULL,
  `AttributePoints` INT(11) NOT NULL DEFAULT '0',
  `SkillPoints` INT(11) NOT NULL,
  `User_idUser` INT(11) NOT NULL,
  PRIMARY KEY (`idCharacter`, `User_idUser`),
  UNIQUE INDEX `CharacterName_UNIQUE` (`CharacterName` ASC),
  INDEX `fk_Character_User_idx` (`User_idUser` ASC),
  CONSTRAINT `fk_Character_User`
    FOREIGN KEY (`User_idUser`)
    REFERENCES `mdw`.`user` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mdw`.`skill`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdw`.`skill` (
  `idPower` INT(11) NOT NULL,
  `PowerName` VARCHAR(45) NOT NULL,
  `Attack` INT(11) NOT NULL,
  `Element` ENUM('water','fire','air','earth') NOT NULL,
  `Effect Description` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idPower`),
  UNIQUE INDEX `idPower` (`idPower` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `mdw`.`character_skill`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mdw`.`character_skill` (
  `character_idCharacter` INT(11) NOT NULL,
  `character_User_idUser` INT(11) NOT NULL,
  `skill_idPower` INT(11) NOT NULL,
  `skillLv` INT(2) NOT NULL,
  PRIMARY KEY (`character_idCharacter`, `character_User_idUser`, `skill_idPower`),
  INDEX `fk_character_skill_skill1_idx` (`skill_idPower` ASC),
  CONSTRAINT `fk_character_skill_character1`
    FOREIGN KEY (`character_idCharacter` , `character_User_idUser`)
    REFERENCES `mdw`.`character` (`idCharacter` , `User_idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_character_skill_skill1`
    FOREIGN KEY (`skill_idPower`)
    REFERENCES `mdw`.`skill` (`idPower`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
