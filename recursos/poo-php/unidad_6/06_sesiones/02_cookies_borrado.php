<?php
    $nombre = "usuario";
    $valor = "bryan";

    $expiracion = time() - 3600;

    $ruta = '/aztlan_2023/06_sesiones/';
    $dominio = "localhost";

    $encriptar = false;

    $manejar_http = true;

    setcookie($nombre, $valor, $expiracion, $ruta, $dominio, $encriptar, $manejar_http);

    echo "Cookie establecida!";

    echo "<br/>";

    $valorDeCookie = $_COOKIE["usuario"];
    echo $valorDeCookie; //Bryan
?>