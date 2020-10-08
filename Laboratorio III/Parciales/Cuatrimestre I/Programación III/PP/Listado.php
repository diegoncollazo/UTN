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
    require_once "./clases/Televisor.php";
    $televisor = new Televisor();
    $arrayTele = $televisor->Traer();

    if($arrayTele!==null && count($arrayTele)!==0)
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

        foreach($arrayTele as $tele)
        {
            echo "<tr>";
                echo "<td>" . $tele->tipo . "</td>";
                echo "<td>" . $tele->precio . "</td>";
                echo "<td>" . $tele->CalcularIva() . "</td>";
                echo "<td>" . $tele->paisOrigen . "</td>";
                echo "<td>";

                if($tele->path != "")
                {
                    if(file_exists("./televisores/imagenes/".$tele->path)) 
                    {
                        echo '<img src="./televisores/imagenes/'.$tele->path.'" alt=./televisores/imagenes/"'.$tele->path.'" height="100px" width="100px">'; 
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
