<?php
    require_once "empleado.php";
    class Fabrica{
        private $_cantidadMaxima;
        private $_empleados;
        private $_razonSocial;

        public function __construct($razonSocial, $cantidadMaxima = 5){
            $this->_razonSocial = $razonSocial;
            $this->_empleados = array();
            $this->_cantidadMaxima = $cantidadMaxima;
        } 

        public function AgregarEmpleado($empleado){
            $retorno = false;
            if (count($this->_empleados) < $this->_cantidadMaxima){
                // Agrego el empleado al array
                $retorno = array_push($this->_empleados, $empleado);
                if ($retorno){
                    $this->EliminarElementosRepetidos();
                }
            }
            else{
                echo "No se pueden agregar mas empleados a la planta.<br>";
            }
            return $retorno;
        }

        public function EliminarEmpleado($empleado)
        {
            foreach ($this->_empleados as $key => $value) {
                if ($value === $empleado){
                    unset($this->_empleados[$key]);
                }
            }
        }

        private function EliminarElementosRepetidos(){
            $this->_empleados = array_unique($this->_empleados, SORT_REGULAR);
        }

        public function CalcularSueldos()
        {
            $retorno = 0;
            foreach ($this->_empleados as $index => $empleado) {
                if ($empleado != null){
                    $retorno += $empleado->GetSueldo();
                }
            }
            return $retorno;
        }

        public function ToString(){
            $retorno;
            $retorno = "Fabrica: $this->_razonSocial<br>";
            $retorno .= "Cantidad de empleados: ".count($this->_empleados)."<br>";
            foreach ($this->_empleados as $index => $empleado) {
                $retorno .= $empleado->ToString()."<br>";
            }
            return $retorno;
        }
    }
?>