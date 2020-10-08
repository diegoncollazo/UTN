<?php
    require_once "persona.php";
    class empleado extends Persona{
        protected $_legajo;
        protected $_sueldo;
        protected $_turno;

        public function __construct($nombre, $apellido, $dni, $sexo, $legajo, $sueldo, $turno){
            parent::__construct($nombre, $apellido, $dni, $sexo);
            $this->_legajo = $legajo;
            $this->_sueldo = $sueldo;
            $this->_turno = $turno;
        }
        // Propiedades
        public function GetLegajo(){
            return $this->_legajo;
        }
        public function GetSueldo(){
            return $this->_sueldo;
        }
        public function GetTurno(){
            return $this->_turno;
        }
        // Metodos
        public function Hablar($idiomas){
            $retorno = "El empleado habla: ";
            foreach ($idiomas as $idioma) {
                $retorno .= ",$idioma ";
            }
            return $retorno;
        }

        public function ToString(){
           return parent::ToString()." - $this->_legajo - $this->_sueldo - $this->_turno";
        }
    }

?>
