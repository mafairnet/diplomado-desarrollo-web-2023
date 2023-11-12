<?php
 class Calculadora{
    //Atributos
    public $color;
    public $tamaño;
    public $marca;

    //Metodos
    public function getColor(){
        return $this->color;
    }

    public function setColor($color){
        $this->color  = $color;
    }

    public function getTamaño(){
        return $this->tamaño;
    }

    public function setTamaño($tamaño){
        $this->color  = $tamaño;
    }

    public function getMarca(){
        return $this->marca;
    }

    public function setMarca($marca){
        $this->color  = $marca;
    }

    //Constructores
    public function __construct(){
        
        $params = func_get_args();
        $num_params = func_num_args();

        $function_constructor = '__construct'.$num_params;
   
        if(method_exists($this,$function_constructor)){
            call_user_func_array(array($this,$function_constructor),$params);
        }
    }

    function __construct0(){
        $this->__construct1("");
    }

    function __construct1($color){
        $this->__construct2($color,"");
    }

    function __construct2($color,$tamaño){
        $this-> __construct3($color,$tamaño,"");
    }

    function __construct3($color,$tamaño,$marca){
        $this->color = $color;
        $this->tamaño = $tamaño;
        $this->marca = $marca;
    }
    
 }

 $miCalculadora0 = new Calculadora();

echo "Calculadora 0 [Color:". $miCalculadora0->getColor() . ",Tamaño:". $miCalculadora0->getTamaño() .", Marca:" . $miCalculadora0->getMarca()."]";
echo "<br/>";

 $miCalculadora1 = new Calculadora("Verde");

 echo "Calculadora 1 [Color:".$miCalculadora1->color.",Tamaño:".$miCalculadora1->tamaño.",Marca: ".$miCalculadora1->marca."]";
 echo "<br/>";
 $miCalculadora2 = new Calculadora("Azul","Pequeña");

 echo "Calculadora 2 [Color:".$miCalculadora2->color.",Tamaño:".$miCalculadora2->tamaño.",Marca: ".$miCalculadora2->marca."]";
 echo "<br/>";
 $miCalculadora3 = new Calculadora("Amarilla","Mediana","Casio");

 echo "Calculadora 3 [Color:".$miCalculadora3->color.",Tamaño:".$miCalculadora3->tamaño.",Marca: ".$miCalculadora3->marca."]";
 echo "<br/>";
 
?>