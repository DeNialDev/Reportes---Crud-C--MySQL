-- CREACIÓN DE LA BASE DE DATOS
CREATE DATABASE `saveimage` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
use saveimage;

-- CREACIÓN DE LA TABLA PARA IMAGENES
CREATE TABLE `students` (
  `StudentID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `LastName` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL,
  `Image` longblob NOT NULL,
  `Address` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL,
  PRIMARY KEY (`StudentID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='tabla de ejemplo para almacenar imagenes.';
select * from students;
delete from students where StudentID = 10;
delete from students where StudentID = 11;
describe students;