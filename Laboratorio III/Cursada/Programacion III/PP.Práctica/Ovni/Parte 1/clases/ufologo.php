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

    //metodo tostring
    public function ToString()
	{
	  	return $this->pais."-".$this->legajo."-".$this->_clave."\r\n";
	}

    //guarda los ofulogos en un txt
    public function GuardarEnArchivo()
    {
        $retorno = false;
        $ar = fopen("./archivos/juguetes_sin_foto.txt", "a");

        if($ar != false)
        {
            $escrito = fwrite($ar, $this->ToString() . "\r\n");

            if($escrito>0)
            { 
                $retorno =true;
            }

            fclose($ar);
        }
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
}