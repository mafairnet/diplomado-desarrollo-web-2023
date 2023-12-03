<?php

function getUserTypes(){

    $tipoUsuariosData = userTypeDao("get_all","","");
    $tipoUsuarios = Array();

    if($tipoUsuariosData["result"] == "success"){
        foreach($tipoUsuariosData["data"] as $tipoUsuarioData){
            $tipoUsuario = new TipoUsuario(
                $tipoUsuarioData["id"],
                $tipoUsuarioData["description"]
            );


            $tipoUsuarios[] = $tipoUsuario;
        }
    }

    return $tipoUsuarios;
}

function getUserType($id){}

function insertUserType($tipoUsuario){}

function editUserType($tipoUsuario){}

function deleteUserType($tipoUsuario){}
?>