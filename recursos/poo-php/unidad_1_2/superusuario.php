<!DOCTYPE html>
<html>
    <head>
        <title>Hello World Program!</title>
    </head>
    <body>
        <?php
        $empleados = array("Miguel","Erasto","Carlos");
        $nombre = "erasto";
        foreach($empleados as $empleado){
            if($empleado == $nombre){
                echo "<p>Hola " . $empleado . ", eres un super usuario</p>";
            } else {
                echo "<p>Hola " . $empleado . ", eres un usuario normal</p>";
            }
        }
        ?>
    </body>
</html>