<?php

    include 'core/business/auth.php';

    if(isset($_GET['view'])){
        switch($_GET['view']){
            case "calculadora":
                $view = "calculadora";
            break;
            case "inicio":
                $view = "inicio";
            break;
            case "usuarios":
                $view = "user";
            break;
            default:
                $view = "inicio";
            break;
        }
    } else {
        $view = "inicio";
    }

    $path = "core/view/".$view.".php";
    include $path;
?>