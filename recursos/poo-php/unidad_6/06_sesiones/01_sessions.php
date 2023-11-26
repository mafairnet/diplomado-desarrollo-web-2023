<?php
session_start();

$_SESSION["usuario"] = "Alex";
$_SESSION["var1"] = "Hola";
$_SESSION["var3"] = "Holas";
$_SESSION["var4"] = "Holass";
$_SESSION["var5"] = "Holass";

echo "Datos de la sesion al incio: </br>";

print_r($_SESSION);

echo "</br>";

unset($_SESSION["var1"]);

$_SESSION["var2"] = "Mundo";
echo "Hola, buen dia " . $_SESSION["usuario"] . "! <br/>";


echo "Datos de la sesion despues de solo unset var1: </br>";
print_r($_SESSION);
echo "</br>";

session_unset();

echo "Datos de la sesion despues de session unset: </br>";

print_r($_SESSION);

echo "</br>";

echo "Datos de la sesion despues del session destroy: </br>";

session_destroy();

print_r($_SESSION);

echo "</br>";

echo "Hola, buen dia " . $_SESSION["usuario"] . "! <br/>";

?>