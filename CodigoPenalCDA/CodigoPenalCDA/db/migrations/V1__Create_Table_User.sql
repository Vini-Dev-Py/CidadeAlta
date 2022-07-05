CREATE TABLE `codigopenalcda`.`user` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(130) NOT NULL,
  `refresh_token` VARCHAR(500) NULL,
  `refresh_token_expiry_time` DATETIME NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC));

CREATE TABLE `codigopenalcda`.`criminalcode` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(150) NOT NULL,
  `description` LONGTEXT NOT NULL,
  `penalty` DECIMAL(7,2) NOT NULL,
  `prisontime` INT NOT NULL,
  `statusid` INT NOT NULL,
  `createdate` DATETIME NOT NULL,
  `updatedate` DATETIME NULL,
  `createuserid` INT NOT NULL,
  `updateuserid` INT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC));