<?php

$ubicacion_log = "c:\\xampp\\php\\logs\\php_error_log";

//$ubicacion_log = "/home/usuario";

class Calculadora{
    public $color;
    public $tamaño;
    public $marca;
    public $modelo;

    public function __construct($color,$tamaño,$marca,$modelo){
        $this->color=$color;
        $this->tamaño=$tamaño;
        $this->marca=$marca;
        $this->modelo=$modelo;
    }

    public function sumar($valorOriginal,$valorASumar){
        $result = 0;
        $result = $valorOriginal + $valorASumar;
        return $result;
    }

    public function restar($valorOriginal,$valorARestar){
        $result = 0;
        $result = $valorOriginal - $valorARestar;
        return $result;
    }

    public function multiplicar($valorOriginal,$valorParaMultiplicar){
        $result = 0;
        $result = $valorOriginal * $valorParaMultiplicar;
        return $result;
    }

    public function dividir($valorOriginal,$valorParaDividir){
        $result = 0;
        $result = $valorOriginal / $valorParaDividir;
        return $result;
    }
}


function writeToLog($string){
    global $ubicacion_log;
    $dia = date("d");
    $mes = date("F");
    $mes = substr($mes,0,3);
    $anio = date("Y");
    $hora = date("H:i:s");

    $string = "[" . $dia ."-". $mes. "-" . $anio . " " . $hora . " Europe/Berlin] FILE: " . basename($_SERVER["PHP_SELF"]) . " LOG INFO:  " . $string ."";

    $fp = fopen($ubicacion_log,"a") or die("No se puede guardar informacion en disco!");

    fwrite($fp,$string . "\n");

    fclose($fp);

}

function debugObjectToLog($object){
    ob_start();
    var_dump($object);
    $result = ob_get_clean();
    writeToLog($result);
}

$calculadora = new Calculadora("Negra","Pocket","Casio","Basic");

$valorFinalSuma = $calculadora->sumar(10,11);

$resultado = array(
    "resultado" => "success",
    "operacion" => "suma",
    "value" => $valorFinalSuma
);

debugObjectToLog($calculadora);
debugObjectToLog($valorFinalSuma);
debugObjectToLog($resultado);

$valorFinalMultiplicacion = $calculadora->multiplicar(5,5);

$resultado = array(
    "resultado" => "success",
    "operacion" => "multiplicacion",
    "value" => $valorFinalMultiplicacion
);

debugObjectToLog($resultado);

?>