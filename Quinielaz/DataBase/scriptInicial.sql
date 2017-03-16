CREATE DATABASE `quinielazdb` /*!40100 
DEFAULT CHARACTER SET latin1 COLLATE latin1_spanish_ci */;

use quinielazDB;
set global optimizer_switch='derived_merge=OFF';

CREATE TABLE `tbl_usuarios` (
  `intUsuarioID` int(11) NOT NULL,
  `vchNombre` varchar(100) COLLATE latin1_spanish_ci DEFAULT NULL,
  `vchUsuario` varchar(100) COLLATE latin1_spanish_ci DEFAULT NULL,
  `vchPassword` varchar(100) COLLATE latin1_spanish_ci DEFAULT NULL,
  `vchEmail` varchar(100) COLLATE latin1_spanish_ci DEFAULT NULL,
  `bitActivo` bit(1) NOT NULL DEFAULT b'1',
  `datFecha` datetime DEFAULT NULL,
  PRIMARY KEY (`intUsuarioID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci COMMENT='Tabla que contiene el catálogo de usuarios.';