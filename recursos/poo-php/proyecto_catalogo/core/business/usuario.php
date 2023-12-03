<?php

function getUsers(){

    $usuariosData = userDao("get_all","","");
    $usuarios = Array();

    if($usuariosData["result"] == "success"){
        foreach($usuariosData["data"] as $usuarioData){
            $usuario = new Usuario(
                $usuarioData["id"],
                $usuarioData["first_name"],
                $usuarioData["second_name"],
                $usuarioData["username"],
                $usuarioData["password"],
                $usuarioData["user_type"]
            );


            $usuarios[] = $usuario;
        }
    }

    return $usuarios;
}

function getUser($id){}

function insertUser($username,$firstName,$secondNAme,$password,$userType){
    $usuario = array(
        "id" => 0,
        "username"  => $username,
        "first_name"  => $firstName,
        "second_name"  => $secondNAme,
        "password"  => $password,
        "user_type"  => $userType
    );
    $result = userDao("add","",$usuario);
}

function editUser($usuario){}

function deleteUser($usuario){}
?>