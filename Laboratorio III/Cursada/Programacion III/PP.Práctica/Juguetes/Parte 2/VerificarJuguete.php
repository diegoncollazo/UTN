<?php

require_once "./clases/Juguete.php";

// Se recibe por GET el tipo y el paisOrigen
$tipo = isset($_GET['tipo']) ? $_GET['tipo'] : NULL;
$pais = isset($_GET['pais']) ? $_GET['pais'] : NULL;

$juguete= new Juguete($tipo,"150",$pais);
//(invocar al método Traer) 
$arrayJuguetes = $juguete->Traer();

//si coincide con algún registro de la base de datos 
foreach($arrayJuguetes as $jugue)
{
    if($jugue->GetTipo() == $tipo && $jugue->GetPais() == $pais)
    {
        // retornar los datos del objeto (invocar al ToString)
        // más su precio con Iva incluído. 
        echo $jugue->ToString() ." - " . $jugue->CalcularIva();
        break;
    }

    //Caso contrario informar: si no coincide el tipo o el paisOrigen o ambos.
    else
    {
        $coinTipo = false;
        $coinPais = false;

        foreach($arrayJuguetes as $jugue)
        {
            if($jugue->GetTipo() == $tipo)
            {
                echo "Solo coincide el tipo.";
            }
            
            else if($jugue->GetPais() == $pais)
            {
                echo "Solo coincide el pais.";
            }

            else
            {
                echo "No coincide ni tipo ni pais.";
            }
        }

    }
}
