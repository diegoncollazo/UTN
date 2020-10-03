<?php
    abstract class Persona{
        private $_apellido;
        private $_dni;
        private $_nombre;
        private $_sexo;
        // Constructor
        public function __constructor($nombre, $apellido, $dni, $sexo){
            $this->_nombre = $nombre;
            $this->_apellido = $apellido;
            $this->_dni = $dni;
            $this->_sexo = $sexo;
        }
        // Propiedades
        public function GetApellido(){
            return $this->_apellido;
        }
        public function GetDNI(){
            return $this->_dni;
        }
        public function GetNombre(){
            return $this->_nombre;
        }
        public function GetSexo(){
            return $this->_sexo;
        }
        // Metodos
        public abstract function Hablar($idioma);

        public function ToString()
        {
            return "$this->_nombre - $this->_apellido - $this->_sexo - $this->_dni";
        }
    }
?>