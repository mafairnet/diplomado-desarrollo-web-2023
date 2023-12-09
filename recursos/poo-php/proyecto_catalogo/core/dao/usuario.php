<?php

$db_server = $GLOBALS['db_server'];
$db_username = $GLOBALS['db_username'];
$db_password = $GLOBALS['db_password'];
$db_name = $GLOBALS['db_name'];

function userDao($job,$id,$data){

    global $db_server,$db_username,$db_password,$db_name;

    $result = "N/A";
    $message = "N/A";

    $mysql_data = array();

    if(
        $job == "get_all" ||
        $job == "get" ||
        $job == "add" ||
        $job == "edit" ||
        $job == "delete"
    ){
        if(isset($id)){
            if(!is_numeric($id)){
                $id=0;
            }
        }
    } else {
        $job = "";
    }

    if($job!=""){
        $db_connection = mysqli_connect($db_server,$db_username,$db_password,$db_name);

        if(mysqli_connect_errno()){
            $result = "error";
            $message = "Failed to cconnect to database: " . mysqli_connect_error();
        } else {

            if($job == "get_all"){
                $query_string = "select * from user order by id";
                $query = mysqli_query($db_connection, $query_string);

                if(!$query){
                    $result = "error";
                    $message = "Query error " . $query_string;
                } else{
                    $result = "success";
                    $message = "Query success";
                    while($sqldata = mysqli_fetch_array($query)){
                        $mysql_data[] = array(
                            "id" => $sqldata['id'],
                            "first_name" => $sqldata["first_name"],
                            "second_name" => $sqldata['second_name'],
                            "username" => $sqldata['username'],
                            "password" => $sqldata['password'],
                            "user_type" => $sqldata['password']
                        );
                    }
                }
            }

            if($job == "get"){
                $query_string = "select * from user where id =" . mysqli_real_escape_string($db_connection,$id);
                //die($query_string);
                $query = mysqli_query($db_connection, $query_string);

                if(!$query){
                    $result = "error";
                    $message = "Query error " . $query_string;
                } else{
                    $result = "success";
                    $message = "Query success";
                    while($sqldata = mysqli_fetch_array($query)){
                        $mysql_data[] = array(
                            "id" => $sqldata['id'],
                            "first_name" => $sqldata["first_name"],
                            "second_name" => $sqldata['second_name'],
                            "username" => $sqldata['username'],
                            "password" => $sqldata['password'],
                            "user_type" => $sqldata['user_type']
                        );
                    }
                }
            }

            if($job == "add"){

                //die(print_r($data));

                $query_string = "insert into user set ";

                if($data['first_name']!= ""){ $query_string .= "first_name = '".mysqli_real_escape_string($db_connection,$data['first_name'])."',";}
                if($data['second_name']!= ""){ $query_string .= "second_name = '".mysqli_real_escape_string($db_connection,$data['second_name'])."',";}
                if($data['username']!= ""){ $query_string .= "username = '".mysqli_real_escape_string($db_connection,$data['username'])."',";}
                if($data['password']!= ""){ $query_string .= "password = '".mysqli_real_escape_string($db_connection,$data['password'])."',";}
                if($data['user_type']!= ""){ $query_string .= "user_type = '".mysqli_real_escape_string($db_connection,$data['user_type'])."'";}

                //die($query_string);

                $query = mysqli_query($db_connection, $query_string);

                if(!$query){
                    $result = "error";
                    $message = "Query error " . $query_string;
                } else{
                    $result = "success";
                    $message = "Query success";
                }
            }

            if($job == "edit"){

                $query_string = "update user set ";
                
                if($data['first_name']!= ""){ $query_string .= "first_name = '".mysqli_real_escape_string($db_connection,$data['first_name'])."',";}
                if($data['second_name']!= ""){ $query_string .= "second_name = '".mysqli_real_escape_string($db_connection,$data['second_name'])."',";}
                if($data['username']!= ""){ $query_string .= "username = '".mysqli_real_escape_string($db_connection,$data['username'])."',";}
                if($data['password']!= ""){ $query_string .= "password = '".mysqli_real_escape_string($db_connection,$data['password'])."',";}
                if($data['user_type']!= ""){ $query_string .= "user_type = '".mysqli_real_escape_string($db_connection,$data['user_type'])."'";}

                $query_string .= " where id = '".mysqli_real_escape_string($db_connection,$id)."'";

                //die($query_string);

                $query = mysqli_query($db_connection, $query_string);

                if(!$query){
                    $result = "error";
                    $message = "Query error " . $query_string;
                } else{
                    $result = "success";
                    $message = "Query success";
                }
            }

            if($job == "delete"){

                $query_string = "delete from user where id = '".mysqli_real_escape_string($db_connection,$id)."'";
                
                $query = mysqli_query($db_connection, $query_string);

                if(!$query){
                    $result = "error";
                    $message = "Query error " . $query_string;
                } else{
                    $result = "success";
                    $message = "Query success";
                }

            }
            
            
        }

        mysqli_close($db_connection);

    }

    if(!isset($mysql_data)){$mysql_data = array();}
    
    $data = array(
        "result" => $result,
        "message" => $message,
        "data" => $mysql_data
    );

    return $data;

}

?>