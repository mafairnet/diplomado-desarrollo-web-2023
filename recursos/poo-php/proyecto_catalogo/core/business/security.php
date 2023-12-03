<?php

function check_user_auth(){
    session_start();
    if(isset($_SESSION["ddw-auth-user"]) && $_SESSION["ddw-auth-user"] === TRUE ){
        return TRUE;
    } else{
        return FALSE;
    }
}

function set_user_auth($username){
    session_start();
    $_SESSION["ddw-auth-user"]=TRUE;
    $_SESSION["ddw-username"] = $username;
    session_commit();
    header("Location: index.php");
    exit();
}

function auth_user($username,$password){
    $usuarios = getUsers();
    foreach($usuarios as $usuario){
        if($usuario->getUsername() == $username && $usuario->password == md5($password)){
            return TRUE;
        }
    }
    return FALSE;
}

function validate_user($username,$password){
    //die("Usuario:" . $username);
    if(auth_user($username,$password)){
        set_user_auth($username);
    } else {
        $message = "Not Valid Credentials";
    }
    return $message;
}

function logout(){
    session_start();
    $_SESSION = array();

    if(ini_get("session.use_cookies")){
        $params = session_get_cookie_params();
        setcookie(session_name(),'',time()-420000,
            $params["path"], $params["domain"],
            $params["secure"],$params["httponly"]
        );
    }

    session_destroy();
    header("Location: index.php");
}

?>