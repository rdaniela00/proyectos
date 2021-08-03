<?php
//se manda llamar la conexion
include("../conexion/conexion.php");

$Ncontrol   = $_POST["Ncontrol"];
$idCarrera  = $_POST["idCarrera"];
$idPersona  = $_POST["idPersona"];

$Ncontrol   = trim($Ncontrol);
$idCarrera  = trim($idCarrera);
$idPersona  = trim($idPersona);

$fecha=date("Y-m-d"); 
$hora=date ("H:i:s");

mysql_query("SET NAMES utf8");
 $insertar = mysql_query("INSERT INTO alumnos 
 								(
 								no_control,
 								id_carrera,
 								id_persona,
 								id_registro,
 								fecha_registro,
 								hora_registro,
 								activo
 								)
							VALUES
								(
								'$Ncontrol',
								'$idCarrera',
 								'$idPersona',
 								'1',
 								'$fecha',
 								'$hora',
 								'1'
								)
							",$conexion)or die(mysql_error());

?>