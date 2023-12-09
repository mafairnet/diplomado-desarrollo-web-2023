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

function getUser($id){
    $usuario = userDao("get",$id,"");
    /*$usuario = new Usuario(
        $usuarioData["id"],
        $usuarioData["first_name"],
        $usuarioData["second_name"],
        $usuarioData["username"],
        $usuarioData["password"],
        $usuarioData["user_type"]
    );*/
    return $usuario;
}

function insertUser($username,$firstName,$secondName,$password,$userType){
    $usuario = array(
        "id" => 0,
        "username"  => $username,
        "first_name"  => $firstName,
        "second_name"  => $secondName,
        "password"  => $password,
        "user_type"  => $userType
    );
    $result = userDao("add","",$usuario);
}

function editUser($userId,$username,$firstName,$secondName,$password,$userType){
    $usuario = array(
        "id" => $userId,
        "username"  => $username,
        "first_name"  => $firstName,
        "second_name"  => $secondName,
        "password"  => $password,
        "user_type"  => $userType
    );
    $result = userDao("edit",$userId,$usuario);
}

function deleteUser($userId){
    $result = userDao("delete",$userId,"");
}
?>