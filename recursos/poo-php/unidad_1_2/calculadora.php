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

    //Constructores
    public function __construct($color){
            $this->color = $color;
    }

    public function __call($name,$arguments){
        echo "Dentro del metodo: ".$name."<br/>";
        echo "Marca:" .$arguments[0]."<br/>";
        echo "Color:" .$arguments[1]."<br/>";
        if(sizeof($arguments>2)){
            echo "Tamaño:" .$arguments[2]."<br/>";
        }
    }
 }

 $miCalculadora = new Calculadora("Verde");

 echo "<br/> El color intanciado en la construccion de de mi calculadora es " .$miCalculadora->getColor();

 $miCalculadora->color = "Morado";
 $miCalculadora->tamaño = "Maediana";
 $miCalculadora->marca = "Casio";

 echo "<br/> La marca de mi calculadora es ". $miCalculadora->marca;
 echo "<br/> El color original de mi calculadora es " .$miCalculadora->getColor(); 
 $miCalculadora->setColor("Negro");
 echo "<br/> El color modificado de mi calculadora es " .$miCalculadora->getColor();

 $miCalculadora->informacionCalculadora("Generica","Morada");
 $miCalculadora->informacionCalculadora("Generica","Morada","Grande");

?>