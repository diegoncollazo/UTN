<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Listado</title>
</head>
<body>
    <?php
    //(GET) Se mostrará el listado completo de los ovnis (obtenidos de la base de datos) en una tabla (HTML con cabecera). 
    require_once "./clases/ovni.php";
    $ovni = new Ovni("t", "p", "po");
    //Invocar al método Traer. 
    $arrayOvnis = $ovni->Traer();
    if($arrayOvnis!==null && count($arrayOvnis)!==0)
    {
        echo "<div>
        <table border=1>
            <thead>
                <tr>
                    <td>Tipo</td>
                    <td>Velocidad</td>
                    <td>Velocidad Con Warp</td> 
                    <td>Planeta de Origen</td>
                    <td>Imagen</td>
                </tr>
            </thead>";

        foreach($arrayOvnis as $item)
        {
            echo "<tr>";
                echo "<td>" . $item->_tipo . "</td>";
                echo "<td>" . $item->_velocidad . "</td>";
                //Mostrar, además, una columna extra con las velocidades Warp incluidas.
                echo "<td>" . $item->ActivarVelocidadWarp() . "</td>";
                echo "<td>" . $item->_planetaOrigen . "</td>";
                echo "<td>";

                if($item->_pathFoto != "")
                {
                    if(file_exists("./ovnis/imagenes/".$item->_pathFoto)) {
                        echo '<img src="./ovnis/imagenes/'.$item->_pathFoto.'" alt=./ovnis/imagenes/"'.$item->_pathFoto . '" height="100px" width="100px">'; 
                    }else{
                        echo 'No hay imagen guardada en '. $item->_pathFoto; 
                    }
                }else{
                    echo "Sin foto";
                }
                echo "</td>";
            echo "</tr>";
        }
    echo "</table>
    </div>";
    }
    ?>
   
</body>
</html>