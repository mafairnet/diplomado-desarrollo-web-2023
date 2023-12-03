<?php

class Usuario{

    public $id;
    public $firstName;
    public $secondName;
    public $username;
    public $password;
    public $userType;

    public function __construct($id,$firstName,$secondName,$username,$password,$userType){
        $this->id=$id;
        $this->firstName=$firstName;
        $this->secondName=$secondName;
        $this->username=$username;
        $this->password=$password;
        $this->userType=$userType;
    }

    public function getId(){
        return $this->id;
    }

    public function setId($id){
        $this->id=$id;
    }

    public function getFirstName(){
        return $this->firstName;
    }

    public function setFirstName($firstName){
        $this->firstName=$firstName;
    }

    public function getSecondName(){
        return $this->secondName;
    }

    public function setSecondName($secondName){
        $this->secondName=$secondName;
    }


    public function getUsername(){
        return $this->username;
    }

    public function setUsername($username){
        $this->username=$username;
    }

    public function getPassword(){
        return $this->password;
    }

    public function setPassword($password){
        $this->password=$password;
    }


    public function getUserType(){
        return $this->userType;
    }

    public function setUserType($userType){
        $this->userType=$userType;
    }
}

?>