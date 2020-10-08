<?php

class Ufologo
{
    //atributos privados (país, legajo y clave)
    private $_pais;
    private $_legajo;
    private $_clave;

    //constructor (que inicialice los atributos)
    public function __construct($pais, $legajo, $clave)
    {
        $this->_pais = $pais;
        $this->_legajo = $legajo;
        $this->_clave = $clave;             
    }

    //un método de instancia ToJSON(), que retornará los datos de la instancia (en una cadena con formato JSON).
    public function ToJson()
    {
        $retornoJson = new stdClass();
        $retornoJson->pais = $this->_pais;
        $retornoJson->legajo = $this->_legajo;
        $retornoJson->clave = $this->_clave;

        return json_encode($retornoJson);
    }

    // Método de instancia GuardarEnArchivo(), que agregará al ufólogo en ./archivos/ufologos.json. 
    //Retornará un JSON que contendrá: éxito(bool) y mensaje(string) indicando lo acontecido.
    public function GuardarEnArchivo()
    {
        $retornoJson = new stdClass();
        $retornoJson->exito = false;
        $retornoJson->mensaje = "No se pudo guardar en el archivo";

        $arJson= fopen("./archivos/ufologos.json","a"); //abro archivo Json

        //$arTxt = fopen("./archivos/ufologos.txt", "a"); abro archivo txt
		//$cant = fwrite($arTxt, $obj->ToString()); escribo en archivo txt
		//fclose($ar); tendria que verificar primero y cerrar

        if($arJson != false) 
        {
            //escribo este ufolo por medio del metodo ToJson 
            if(fwrite($arJson, $this->ToJson()."\r\n")) 
            {  
                $retornoJson->exito = true;
                $retornoJson->mensaje = "Se ha guardado ufologos con exito.";
            }
            
            fclose($arJson);    //cierro archivo
        }


        return $retornoJson;
    }

    // Método de clase TraerTodos(), que retornará un array de objetos de tipo Ufólogo.
    public static function TraerTodos()
    {
        $arrayUfologo = array();//creo un array donde voy a cargar los objetos

        $ar = fopen("./archivos/ufologos.json", "r");//abro el archivo 

        while(!feof($ar)) 
        {
            $linea = trim(fgets($ar)); //Lee linea por linea y elimina los espacios
            
            if($linea != "") 
            { //si llegamos a la linea vacia
                $auxJson = json_decode($linea); //convierte la linea en un json para que lo lea y sea guardable en ufologo
                $auxUfologo = new Ufologo($auxJson->pais, $auxJson->legajo, $auxJson->clave);
                array_push($arrayUfologo, $auxUfologo); //agrega el ufolo leido al array
            }
        }
        
        fclose($ar); //cierro el archivo

        return $arrayUfologo;
    }

    // Método de clase VerificarExistencia($ufologo), que recorrerá el array (invocar a TraerTodos) y retornará un JSON
    // que contendrá: existe(bool) y mensaje(string).
    // Si el ufólogo está registrado (legajo y clave), retornará true. Caso contrario, retornará false. En mensaje se
    // indicará lo acontecido, según corresponda.
    public static function VerificarExistencia($ufologo)
    {
        $retorno = false; //creo un booleando para verificar
        $arrayUfologos = Ufologo::TraerTodos(); //invoca al metodo para recorrer

        $retornoJson = new stdClass();//creo la variable json
        $retornoJson->exito = false;
        $retornoJson->mensaje = "Ufologo no se encuentra registrado";

        foreach($arrayUfologos as $item)//recocorro los ufologos
        {
            if($item->_legajo == $ufologo->_legajo && $item->_clave == $ufologo->_clave)//verifico si el ufologo existe segun su legajo y clave
            {
                $retornoJson->exito = true;
                $retornoJson->mensaje = "Ufologo esta registrado";
                break;
            } 
        }

        return $retornoJson;
    }

    /*
    //SI ES CON ARCHIVOS ESTA ESTO
    public function ToString()
	{
	  	return $this->pais."-".$this->legajo."-".$this->_clave."\r\n";
	}*/
}