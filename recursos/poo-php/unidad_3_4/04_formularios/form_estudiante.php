<?php
    function filtrado($datos){
        $datos = trim($datos);
        $datos = stripslashes($datos);
        $datos = htmlspecialchars($datos);
        return $datos;
    }

    if(isset($_POST["submit"]) && $_SERVER["REQUEST_METHOD"] == "POST"){

        if(empty($_POST["nombre"])){
            $errores[] = "El nombre es requerido";
        }

        if(empty($_POST["password"]) || strlen($_POST["password"] > 5)){
            $tamPass = strlen($_POST["password"]);
            $errores[] = "La contraseña es requrida y debe ser mayor a cinco caracteres. (PASSLEN:$tamPass)";
        }

        if(empty($_POST["email"]) || !filter_var($_POST["email"],FILTER_VALIDATE_EMAIL)){
            $errores[] = "No se indicado algun correo o el formato no es valido";
        }

        if(!isset($errores)){

            $nombre = "";
            $password = "";
            $educacion = "";
            $nacionalidad = "";
            $idiomas = "";
            $email = "";

            if(isset($_POST["nombre"])){ $nombre = filtrado($_POST["nombre"]); }
            if(isset($_POST["password"])){ $password = filtrado($_POST["password"]);}
            if(isset($_POST["educacion"])){ $educacion = filtrado($_POST["educacion"]);}
            if(isset($_POST["nacionalidad"])){ $nacionalidad = filtrado($_POST["nacionalidad"]);}
            if(isset($_POST["idiomas"])){ $idiomas = filtrado(implode(", ", $_POST["idiomas"]));}
            if(isset($_POST["email"])){ $email = filtrado($_POST["email"]);}

            echo "Procesado por el server <br/>" ;
        }
    }
?>
<html>
    <body>
        <?php if(!isset($_POST["submit"]) || isset($errores)){?>
            <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post">

                <?php if(isset($errores)){
                    echo "<ul>";
                    foreach ($errores as $error){
                        echo "<li> $error</li>";
                    }
                    echo "</ul>";
                }
                ?>


                Nombre : <input type="text" name="nombre" maxlength="50"><br/>
                Contraseña: <input type="password" name="password"><br/>
                Educacion:
                <select name="educacion">
                    <option value="sin-estudios">Sin estudios</option>
                    <option value="primaria">Primaria</option>
                    <option value="secundaria">Secundaria</option>
                    <option value="universidad">Universidad</option>
                </select><br/>
                Nacionalidad:
                <input type="radio" name="nacionalidad" value="hispana">Hispana</input>
                <input type="radio" name="nacionalidad" value="otra">Otra</input><br/>
                Idiomas:
                <input type="checkbox" name="idiomas[]" value="español">Español</input>
                <input type="checkbox" name="idiomas[]" value="ingles">Ingles</input>
                <input type="checkbox" name="idiomas[]" value="frances">Frances</input>
                <input type="checkbox" name="idiomas[]" value="aleman">Aleman</input><br/>
                Email : <input type="text" name="email"><br/>
                <input type="submit" name="submit" value="Enviar">
            </form>
        <?php } else {?>
            <h2>Mostrar datos enviados:</h2>
            Nombre: <?php echo isset($nombre) ?  $nombre : "";?> <br/>
            Contraseña: <?php echo isset($password) ?  $password : "";?> <br/>
            Educacion: <?php echo isset($educacion) ?  $educacion : "";?> <br/>
            Nacionalidad: <?php  echo isset($nacionalidad) ?  $nacionalidad : "";?> <br/>
            Idiomas: <?php echo isset($idiomas) ?  $idiomas : "";?> <br/>
            Email: <?php echo isset($email) ?  $email : "";?> <br/>
        <?php }?>
    </body>
</html>