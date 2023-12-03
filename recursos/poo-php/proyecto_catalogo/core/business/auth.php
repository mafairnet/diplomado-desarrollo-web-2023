<?php
    include "core/business/security.php";

    if(!check_user_auth()){
        header("Location: /aztlan_2023/proyecto_catalogo/login.php");
        exit();
    }/* else{
        $url = $_SERVER['REQUEST_URI'];
        if(!strpos($url, 'index.php')){
            header("Location: index.php");
        }
    }*/
?>