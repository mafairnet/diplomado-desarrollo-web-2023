<?php

interface Gadget {
    public function getTipo();
    public function getColor();
}

interface Herramienta {
    public function getFuncionalidad();
}

class Calculadora implements Gadget , Herramienta{
    public $color = "Morado";
    protected $marca = "Generica";
    public $modelo = "Generica";

    public $tipo = "Calculadora";
    public $funcionalidad = "Realizar operaciones matematicas";
 
    public function sumar($numA, $numB){
        return $numA + numB;
    }

    public function getTipo(){
        return $this->tipo;
    }

    public function getColor(){
        return $this->color;
    }

    public function getFuncionalidad(){
        return $this->funcionalidad;
    }
}

class Reloj implements Gadget{
    public $color;
    public $tipo = "reloj";
    public function getHora(){
        return date("h:i:sa");
    }

    public function getTipo(){
        return $this->tipo;
    }

    public function getColor(){
        return $this->color;
    }
    
}



class CalculadoraCientifica extends Calculadora{
    
    public function getColor(){
        return $this->color;
    }

    public function getMarca(){
        return $this->marca;
    }

    public function getModelo(){
        return $this->modelo;
    }
}

/*class RelojCalculadora implements Reloj, Calculadora{
    public $cantidadBotones;
}*/

$calculadoraCientifica = new CalculadoraCientifica();

echo "<br/>Color calculadora:" . $calculadoraCientifica->getColor();
echo "<br/>Marca calculadora:" . $calculadoraCientifica->getMarca();
echo "<br/>Modelo calculadora:" . $calculadoraCientifica->getModelo();
echo "<br/>Mi gadget 'calculadora' es de tipo " . $calculadoraCientifica->getTipo(); 
echo "<br/>Mi herramienta 'calculadora' sirve para: " . $calculadoraCientifica->getFuncionalidad(); 

abstract class CalculadoraAbstract{
    public function suma($a, $b){
        return $a + $b;
    }

    abstract public function setColor($color);
    abstract public function getMarca();
}

class Casio extends CalculadoraAbstract{
    public $marca  = "Casio";
    public $color;

    public function setColor($color){
        $this->color = $color;
    }

    public function getMarca(){
        return $this->marca;
    }

}

echo "<br/><br/><br/>";

$reloj = new Reloj();

echo "<br/>Mi gadget 'reloj' es de tipo " . $reloj->getTipo(); 



$casio = new Casio();

$totalSuma = $casio->suma(10,11);
$casio->setColor("Morado");
$marca = $casio->getMarca();

echo "</br/> Calculadora" . $marca . ", color: " . $casio->color . ". El resultado de la suma de 10 y 11 es:" . $totalSuma ."!";

echo "<br/><br/><br/>";

$relojCalculadora = new RelojCalculadora();

echo "La hora de mi reloj calculdora es: ". $relojCalculadora->getHora();

echo "<br/><br/><br/>";

?>