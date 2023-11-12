<?php
    $cadena = "Esto es una cadena";
    var_dump($cadena);
    $entero = 10;
    var_dump($entero);
    $flotante = 10.5;
    var_dump($flotante);
    $booleano = true;
    var_dump($booleano);
    $arreglo = array("1","2","3","cuatro");
    var_dump($arreglo);
    //$objeto = new Objeto("Blanco","Azul");
    //var_dump();
    $nulo = null;

    if($nulo == null)
    {
        if($booleano){
            echo '<br/>La variable cadena contiene ' . $cadena . '<br/>';
            echo "<br/>La variable cadena contiene $cadena<br/>";
        }
    }

    var_dump($nulo);
?>?