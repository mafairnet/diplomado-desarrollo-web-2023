<?php

$db_server = $GLOBALS['db_server'];
$db_username = $GLOBALS['db_username'];
$db_password = $GLOBALS['db_password'];
$db_name = $GLOBALS['db_name'];

function userTypeDao($job,$id,$data){

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
                $query_string = "select * from user_type order by id";
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
                            "description" => $sqldata["description"]
                        );
                    }
                }
            }

            if($job == "get"){
                $query_string = "select * from user_type where id =" . mysqli_real_escape_string($db_connection,$id);
                $query = mysqli_query($db_connection, $query_string);

                if(!query){
                    $result = "error";
                    $message = "Query error " . $query_string;
                } else{
                    $result = "success";
                    $message = "Query success";
                    while($sqldata = mysqli_fetch_array($query)){
                        $mysql_data[] = array(
                            "id" => $sqldata['id'],
                            "description" => $sqldata["description"]
                        );
                    }
                }
            }

            if($job == "add"){

                $query_string = "insert into user_type set";

                if($data['description']!= ""){ $query_string .= "description = '".mysqli_real_escape_string($db_connection,$data['description'])."'";}
                
                $query = mysqli_query($db_connection, $query_string);

                if(!query){
                    $result = "error";
                    $message = "Query error " . $query_string;
                } else{
                    $result = "success";
                    $message = "Query success";
                }
            }

            if($job == "edit"){

                $query_string = "update user_type set";
                
                if($data['description']!= ""){ $query_string .= "description = '".mysqli_real_escape_string($db_connection,$data['description'])."'";}
                
                $query_string .= "where id = '".mysqli_real_escape_string($db_connection,$id)."'";

                $query = mysqli_query($db_connection, $query_string);

                if(!query){
                    $result = "error";
                    $message = "Query error " . $query_string;
                } else{
                    $result = "success";
                    $message = "Query success";
                }
            }

            if($job == "delete"){

                $query_string = "delete from user_type where id = '".mysqli_real_escape_string($db_connection,$id)."'";
                
                $query = mysqli_query($db_connection, $query_string);

                if(!query){
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