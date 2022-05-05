-- Create Driver table
CREATE TABLE `formula1`.`driver` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Number` INT NULL,
  `Team` VARCHAR(100) NULL,
  `CarID` VARCHAR(45) NULL,
  PRIMARY KEY (`id`));

-- Create Car table
CREATE TABLE `formula1`.`car` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `CarID` VARCHAR(45) NOT NULL,
  `Team` VARCHAR(100) NULL,
  `Year` INT NULL,
  PRIMARY KEY (`id`));

-- Add index on Car table
ALTER TABLE `formula1`.`car` 
ADD INDEX `CarID_IDX` (`CarID` ASC) VISIBLE;

-- Add foreign key constraint
ALTER TABLE `formula1`.`driver` 
ADD INDEX `CarID_FK_idx` (`CarID` ASC) VISIBLE;

ALTER TABLE `formula1`.`driver` 
ADD CONSTRAINT `CarID_FK`
  FOREIGN KEY (`CarID`)
  REFERENCES `formula1`.`car` (`CarID`)
  ON DELETE RESTRICT
  ON UPDATE CASCADE;

-- Add trigger to limit car years
DELIMITER $$
CREATE TRIGGER car_year_check
BEFORE INSERT ON `car`
FOR EACH ROW
BEGIN
  IF (NEW.year > YEAR(CURRENT_DATE())) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Car can not be newer than current year!';
  END IF;
END$$

DELIMITER ;

DELIMITER $$
CREATE TRIGGER car_year_check_update
BEFORE UPDATE ON `car`
FOR EACH ROW
BEGIN
  IF (NEW.year > YEAR(CURRENT_DATE())) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Car can not be newer than current year!';
  END IF;
END$$
DELIMITER ;

-- Populate Car Table
INSERT INTO `car` (`CarID`, `Team`, `Year`)
VALUES
    ('C41', 'Alfa Romeo Racing Orlen', '2021'),
    ('AT02', 'Scuderia AlphaTauri Honda', '2021'),
    ('A521', 'Alpine F1 Team', '2021'),
    ('AMR21', 'Aston Martin Cognizant F1 Team', '2021'),
    ('SF21', 'Scuderia Ferrari Mission Winnow', '2021'),
    ('VF21', 'Uralkali Haas F1 Team', '2021'),
    ('MCL35M', 'McLaren F1 Team', '2021'),
    ('F1W12', 'Mercedes-AMG Petronas F1 Team', '2021'),
    ('RB16B', 'Red Bull Racing Honda', '2021'),
    ('FW43B', 'Williams Racing', '2021');

-- Populate Driver Table
INSERT INTO `driver` (`Name`, `Number`, `Team`, `CarID`)
VALUES
    ('Kimi Räikkönen', 7, 'Alfa Romeo Racing Orlen', 'C41'),
    ('Antonio Giovinazzi', 99, 'Alfa Romeo Racing Orlen', 'C41'),
    ('Pierre Gasly', 10, 'Scuderia AlphaTauri Honda', 'AT02'),
    ('Yuki Tsunoda', 22, 'Scuderia AlphaTauri Honda', 'AT02'),
    ('Fernando Alonso', 14, 'Alpine F1 Team', 'A521'),
    ('Esteban Ocon', 31, 'Alpine F1 Team', 'A521'),
    ('Sebastian Vettel', 5, 'Aston Martin Cognizant F1 Team', 'AMR21'),
    ('Lance Stroll', 18, 'Aston Martin Cognizant F1 Team', 'AMR21'),
    ('Charles Leclerc', 16, 'Scuderia Ferrari Mission Winnow', 'SF21'),
    ('Carlos Sainz Jr.', 55, 'Scuderia Ferrari Mission Winnow', 'SF21'),
    ('Nikita Mazepin', 9, 'Uralkali Haas F1 Team', 'VF21'),
    ('Mick Schumacher', 47, 'Uralkali Haas F1 Team', 'VF21'),
    ('McLaren F1 Team', 3, 'Daniel Ricciardo', 'MCL35M'),
    ('McLaren F1 Team', 4, 'Lando Norris', 'MCL35M'),
    ('Mercedes-AMG Petronas F1 Team', 44, 'Lewis Hamilton', 'F1W12'),
    ('Mercedes-AMG Petronas F1 Team', 77, 'Valtteri Bottas', 'F1W12'),
    ('Red Bull Racing Honda', 11, 'Sergio Pérez', 'RB16B'),
    ('Red Bull Racing Honda', 33, 'Max Verstappen', 'RB16B'),
    ('Williams Racing', 6, 'Nicholas Latifi', 'FW43B'),
    ('Williams Racing', 63, 'George Russell', 'FW43B');