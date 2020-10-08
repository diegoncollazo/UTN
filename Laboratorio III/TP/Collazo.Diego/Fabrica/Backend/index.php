<?php
    // require_once "./Classes/empleado.php";
    require_once "./Classes/fabrica.php";
    $empleado1 = new Empleado("Diego", "Collazo", 1234567, "M", 108105, 57000, "Noche");
    $empleado2 = new Empleado("Héctor", "Collazo", 89012345, "M", 108105, 57000, "Noche");
    $empleado3 = new Empleado("Juan Ignacio", "Collazo", 67890123, "M", 108105, 57000, "Noche");
    $empleado4 = new Empleado("Lucía", "Collazo", 67890123, "M", 108105, 57000, "Noche");
    $empleado5 = new Empleado("Nestor", "Collazo", 67890123, "M", 108105, 57000, "Noche");
    $empleado6 = new Empleado("Vanesa", "Collazo", 67890123, "M", 108105, 57000, "Noche");

    echo $empleado1->ToString()."<br>";
    echo $empleado2->ToString()."<br>";
    echo $empleado3->ToString()."<br>";
    echo $empleado4->ToString()."<br>";
    echo $empleado5->ToString()."<br>";
    echo $empleado6->ToString()."<br><hr>";

    $fabrica = new Fabrica("DNC Soft");

    $fabrica->AgregarEmpleado($empleado1);
    $fabrica->AgregarEmpleado($empleado2);
    $fabrica->AgregarEmpleado($empleado3);
    $fabrica->AgregarEmpleado($empleado3);
    $fabrica->AgregarEmpleado($empleado4);
    $fabrica->AgregarEmpleado($empleado5);

    echo $fabrica->ToString()."<br>";
    
    $fabrica->EliminarEmpleado($empleado2);

    echo $fabrica->ToString()."<br>";

    $fabrica->AgregarEmpleado($empleado6);
    $fabrica->AgregarEmpleado($empleado2);

    echo $fabrica->ToString()."<br>";

    echo "Sueldo total: ".$fabrica->CalcularSueldos()."<hr>";