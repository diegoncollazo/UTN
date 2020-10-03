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
    //Se mostrará el listado completo de los juguetes (obtenidos de la base de datos) en una tabla (con cabecera). 
    require_once "./clases/Juguete.php";
    $juguete = new Juguete("t", "p", "po");
    //Invocar al método Traer. 
    $arrayJuguetes = $juguete->Traer();

    if($arrayJuguetes!==null && count($arrayJuguetes)!==0)
    {
        echo "<div>
        <table border=1>
            <thead>
                <tr>
                    <td>Tipo</td>
                    <td>Precio</td>
                    <td>Precio con IVA</td> 
                    <td>Pais</td>
                    <td>Imagen</td>
                </tr>
            </thead>";

        foreach($arrayJuguetes as $item)
        {
            echo "<tr>";
                echo "<td>" . $item->GetTipo() . "</td>";
                echo "<td>" . $item->GetPrecio() . "</td>";
                //Mostrar además, una columna extra con los precios con IVA incluido.
                echo "<td>" . $item->CalcularIva() . "</td>";
                echo "<td>" . $item->GetPais() . "</td>";
                echo "<td>";

                if($item->GetPath() != "")
                {
                    if(file_exists("./juguetes/imagenes/".$item->GetPath())) 
                    {
                        echo '<img src="./juguetes/imagenes/'.$item->GetPath().'" alt=./juguetes/imagenes/"'.$item->GetPath() . '" height="100px" width="100px">'; 
                    }

                    else
                    {
                        echo 'no hay imagen guardada '. $item->GetPath(); 
                    }
                }

                else
                {
                    echo "sin foto";
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