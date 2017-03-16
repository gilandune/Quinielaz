CREATE DATABASE `quinielazdb` /*!40100 
DEFAULT CHARACTER SET latin1 COLLATE latin1_spanish_ci */;

use quinielazDB;
set global optimizer_switch='derived_merge=OFF';

CREATE TABLE tbl_usuarios ( -- drop table tbl_usuarios
  intUsuarioID int PRIMARY KEY AUTO_INCREMENT,
  vchNombre varchar(100) NOT NULL,
  vchUsuario varchar(100) NOT NULL,
  vchPassword varchar(100) NOT NULL,
  vchEmail varchar(100) NOT NULL,
  bitActivo bit(1) NOT NULL DEFAULT TRUE,
  datFecha datetime DEFAULT NULL
);