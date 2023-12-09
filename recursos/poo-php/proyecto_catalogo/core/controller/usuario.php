<?php

    $url = $_SERVER['REQUEST_URI']; 
    //die($url);
    
    if(strpos($url, '?request=') !== false){
        include '../../core/config/db.php';
        include '../../core/model/usuario.php';
        include '../../core/business/usuario.php';
        include '../../core/dao/usuario.php';
    } else{
        include 'core/config/db.php';
        //include 'core/dao/user.php';*/
        //include 'core/business/user.php';
    }
    
    function getUsersData(){
        $users = getUsers();
        return $users;
    }

    $request ='';

    if(isset($_GET['request'])){
        
        $request = $_GET['request'];

        if ($request == 'get_extended' ||
            $request == 'get_extended_functions' ||
            $request == 'get'   ||
            $request == 'add'   ||
            $request == 'edit'  ||
            $request == 'delete'){
            if (isset($_GET['id'])){
                $id = $_GET['id'];
                if (!is_numeric($id)){
                    $id = '';
                }
            }
        } else {
            $request = '';
        }

        //die($request);

        // Valid job found

        if ($request != '')
        {
            $result  = 'success';
            $message = 'query success';
            $full_data = Array();

            if ($request == 'get_extended_functions'){

                

                //Get Users
                $users = getUsers();
                //Get Users Type
                
                //print_r($users);
                foreach($users as $user){

                    $userType = "Agent";
                    
                    $functions  = '<div class="btn-group" role="group" aria-label="actions">
                                        <button class="btn btn-lightbox btn-default btn-sm function_edit" id="details-test" style="width:80px!important;" data-id="'   . $user->id . '" data-name="' . $user->id.'">
                                            <small><span class="glyphicon glyphicon-file" aria-hidden="true"></span></small>
                                                Edit
                                        </button>
                                        <button class="btn btn-lightbox btn-default btn-sm function_delete" id="details-test" style="width:80px!important;" data-id="'   . $user->id . '" data-name="' . $user->username.'">
                                            <small><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></small>
                                                Delete
                                        </button>
                                    </div>';

                    if($user->userType==1){
                        $userType = "Admin";
                    } else {
                        $userType = "Other";
                    }


                    $full_data[] = array(
                        "user_id" => $user->id,
                        "username"  => $user->username,
                        "first_name"  => $user->firstName,
                        "second_name"  => $user->secondName,
                        "password"  => $user->password,
                        "admin"  => $userType,
                        "functions"  => $functions
                    );
                }
            }

            if ($request == 'get_extended'){

                //Get Users
                $users = getUsers();
                //Get Users Type
                
                //print_r($users);
                foreach($users as $user){
                        
                    $full_data[] = array(
                        "user_id" => $user['user_id'],
                        "username"  => $user['username'],
                        "first_name"  => $user['first_name'],
                        "second_name"  => $user['second_name'],
                        "password"  => $user['password'],
                        "admin"  => $user['admin']
                    );
                }
            }

            if ($request == 'get'){

                $id = '';
                if (isset($_GET['user_id'])) { $id = $_GET['user_id']; }
                $full_data = getUser($id);

            }

            if ($request == 'add'){
                //die("Agreando");
                $username = "";
                $firstName = "";
                $secondName= "";
                $password="";
                $userType="";
                
                if (isset($_GET['user_username'])) { $username = $_GET['user_username']; }
                if (isset($_GET['user_first_name'])) { $firstName = $_GET['user_first_name']; }
                if (isset($_GET['user_second_name'])) { $secondName = $_GET['user_second_name']; }
                if (isset($_GET['user_password'])) { $password = md5($_GET['user_password']); }
                if (isset($_GET['user_type'])) { $userType = $_GET['user_type']; }
                
                $opResult = insertUser($username,$firstName,$secondName,$password,$userType);

                // Add 
                if ($opResult == "error"){
                  $result  = 'error';
                  $message = 'query error';
                } else {
                  $result  = 'success';
                  $message = 'query success';
                }
              
            }

            if ($request == 'edit'){

                $userId = "";
                $username = "";
                $firstName = "";
                $secondName= "";
                $password="";
                $user_type="";
                $passwordChanged="";
                
                if (isset($_GET['user_id'])) { $userId = $_GET['user_id']; }
                if (isset($_GET['user_username'])) { $username = $_GET['user_username']; }
                if (isset($_GET['user_first_name'])) { $firstName = $_GET['user_first_name']; }
                if (isset($_GET['user_second_name'])) { $secondName = $_GET['user_second_name']; }
                if (isset($_GET['user_password'])) { $password = $_GET['user_password']; }
                if (isset($_GET['user_type'])) { $user_type = $_GET['user_type']; }
                if (isset($_GET['user_password_changed'])) { $passwordChanged = $_GET['user_password_changed']; }
                
                
                $opResult = editUser($userId,$username,$firstName,$secondName,$password,$user_type,$passwordChanged);

                // Add 
                if ($opResult == "error"){
                  $result  = 'error';
                  $message = 'query error';
                } else {
                  $result  = 'success';
                  $message = 'query success';
                }
              
            }

            if ($request == 'delete'){

                $id = '';
                if (isset($_GET['user_id'])) { $id = $_GET['user_id']; }
                $full_data = deleteUser($id);
                
            }

            $data = array(
                "result"  => $result,
                "message" => $message,
                "data"    => $full_data
              );

            $json_data = json_encode($data);
            print $json_data;
        }
    }
?>