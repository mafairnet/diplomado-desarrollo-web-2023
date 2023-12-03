<?php
  include 'core/config/db.php';
  include 'core/business/usuario.php';
  include 'core/model/tipoUsuario.php';
  include 'core/dao/tipoUsuario.php';
  include 'core/business/tipoUsuario.php';

  $userTypesData = getUserTypes();

  $userTypesArray = array();

  foreach($userTypesData as $userType){
    $userTypesArray[] = array(
      "id" => $userType->id,
      "text" => $userType->description
    );
  }

  $jsonUserTypes = json_encode($userTypesArray);

  
  
  //die("STOP");

  //var userType = [{"id":"0","text":"Asesor"},{"id":"1","text":"Admin"}];

  //die(print_r($userTypesData));
  
?>
<!doctype html>
<html lang="en">
  <head>
  <?php include "core/view/styles_libraries.php";?>
  <script>
    var userType = <?php print $jsonUserTypes;?>;

    $( document ).ready(function(){
      $(".select-type").select2({
            data: userType
          });
      });
  </script>
  </head>
  <body>

<div class="b-example-divider"s tyle="width: 1%;"></div>

<div class="container" style="width: 75%;">

  
  <br>
  <div class="row">
    <h1>Catalago de Usuarios</h1>
    <hr>
  </div>
  
  <div class="container">

      <p align="right">
        <button type="button" class="btn btn-primary" id="add_user">
            <small><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></small> Add User(s)
        </button>
      </p>

    <div class="row">
    <div class="my-3 p-3 bg-body rounded shadow-sm">
      
    <div id="users">
        <?php
          /*foreach($users as $user){
            echo "User: ". $user['mail'] . "<br/>";
          }*/
          //echo "User: ". $users[0]['mail'];
          //print_r($users);
        ?>
        <div class="table-responsive col-md-12">
            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title">Users Data</h3>
              </div>
                <div class="panel-body">
                  <table id="table_<?php echo $view;?>" class="table table-striped" cellspacing="0" width="100%">
                    <thead>
                      <tr>
                        <th>ID</th>
                        <th>Username</th>
                        <th>First Name</th>
                        <th>Second Name</th>
                        <th>User Type</th>
                        <th>Functions</th>
                      </tr>
                    </thead>
                    <tbody>
                    </tbody>
                  </table>
                </div>
            </div>
          </div>
      </div>
      
      <div id="calls">
      </div>
        
    </div>
    
      
    </div>
  </div>
  
  <div class="lightbox_bg"></div>

<div class="lightbox_container">
  <!--<div class="lightbox_close"></div>-->
  <div class="lightbox_content">
    
    <h2>Number Form</h2>
    <form class="form add" id="form_<?php echo $view;?>" data-id="" novalidate>

      <div class="input_container">
        <label for="<?php echo $view;?>_type">User Type: <span class="required">*</span></label>
        <div class="field_container">
          <select style="width:100%" class="select-type" name="<?php echo $view;?>_type" id="<?php echo $view;?>_type" required>
            <option value="" selected="selected">Select an option</option>
          </select>
        </div>
      </div>
      
      <div class="input_container">
        <label for="<?php echo $view;?>_username">Username: <span class="required">*</span></label>
        <div class="field_container">
          <input type="text" class="text" name="<?php echo $view;?>_username" id="<?php echo $view;?>_username" value="" required>
        </div>
      </div>

      <div class="input_container">
        <label for="<?php echo $view;?>_first_name">First Name: <span class="required">*</span></label>
        <div class="field_container">
          <input type="text" class="text" name="<?php echo $view;?>_first_name" id="<?php echo $view;?>_first_name" value="" required>
        </div>
      </div>

      <div class="input_container">
        <label for="<?php echo $view;?>_second_name">Second Name: <span class="required">*</span></label>
        <div class="field_container">
          <input type="text" class="text" name="<?php echo $view;?>_second_name" id="<?php echo $view;?>_second_name" value="" required>
        </div>
      </div>

      <div class="input_container">
        <label for="<?php echo $view;?>_password">Password: <span class="required">*</span></label>
        <div class="field_container">
          <input type="password" class="text" name="<?php echo $view;?>_password" id="<?php echo $view;?>_password" value="" required>
        </div>
      </div>
      
      <input type="hidden" class="text" name="<?php echo $view;?>_password_changed" id="<?php echo $view;?>_password_changed" value="no" required>
      
      <!--<div class="button_container">-->
      
        <div class="btn-group pull-right" role="group">
          <button type="submit" class="btn btn-lightbox btn-default action" style="width:120px!important;">
            Add <?php echo $view;?>
          </button>
          <!--<button type="button" class="test btn btn-lightbox btn-default bootstrap_lightbox_close" style="width:120px!important;">
            Test
          </button>-->
          <button type="button" class="btn btn-lightbox btn-default bootstrap_lightbox_close" style="width:120px!important;">
            Cancel
          </button>
        </div>
      <!--</div>-->
    </form>
    
  </div>
</div>

<noscript id="noscript_container">
  <div id="noscript" class="error">
    <p>JavaScript support is needed to use this page.</p>
  </div>
</noscript>

<div id="message_container">
  <div id="message" class="success">
    <p>This is a success message.</p>
  </div>
</div>

<div id="loading_container">
  <div id="loading_container2">
    <div id="loading_container3">
      <div id="loading_container4">
        Loading, please wait...
      </div>
    </div>
  </div>
</div>


    <script src="assets/dist/js/bootstrap.bundle.min.js"></script>

      <script src="assets/dist/js/sidebars.js"></script>
      <script src="assets/js/popper.min.js"></script>
      <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>-->
      <script src="assets/js/bootstrap.min_4_5_2.js"></script>
  </body>
</html>
