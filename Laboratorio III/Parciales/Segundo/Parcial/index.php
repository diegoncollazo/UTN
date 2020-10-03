<?php
use \Psr\Http\Message\ServerRequestInterface as Request;
use \Psr\Http\Message\ResponseInterface as Response;
use \Firebase\JWT\JWT;

require_once './vendor/autoload.php';

require_once './BACKEND/clases/AccesoDatos.php';
require_once './BACKEND/clases/usuario.php';
require_once './BACKEND/clases/auto.php';
require_once './BACKEND/clases/MW.php';

$config['displayErrorDetails'] = true;
$config['addContentLengthHeader'] = false;

$app = new \Slim\App(["settings" => $config]);

// A nivel de ruta (/usuarios):
// (POST) Alta de usuarios. Se agregará un nuevo registro en la tabla usuarios *.
// Se envía un JSON (correo, clave, nombre, apellido, perfil**) y foto.
// * ID auto-incremental. ** propietario, encargado y empleado.
// Retorna un JSON (éxito: true/false; mensaje: string; status: 200/418)
$app->post('/usuarios', \Usuario::class . ':AltaUsuario')->add(\MW::class . '::VerificarBDCorreo')->add(\MW::class . '::VerificarVacioCorreoClave')->add(\MW::class . ':VerificarSetCorreoClave');;

// A nivel de aplicación:
// (GET) Listado de usuarios. Mostrará el listado completo de los usuarios (array JSON).
// Retorna un JSON (éxito: true/false; mensaje: string; tabla: stringJSON; status: 200/424)
$app->get('[/]', \Usuario::class . ':ListaUsuario');

// A nivel de aplicación:
// (POST) Alta de autos. Se agregará un nuevo registro en la tabla autos *.
// Se envía un JSON (color, marca, precio y modelo).
// * ID auto-incremental.
// Retorna un JSON (éxito: true/false; mensaje: string; status: 200/418)
$app->post('[/]', \Auto::class . ':AltaAuto')->add(\MW::class . '::VerificarPrecioRango');

// A nivel de ruta (/autos):
// (GET) Listado de autos. Mostrará el listado completo de los autos (array JSON).
// Retorna un JSON (éxito: true/false; mensaje: string; tabla: stringJSON; status: 200/424)
$app->get('/autos', \Auto::class . ':ListaAuto');

// A nivel de ruta (/login):
// (POST) Se envía un JSON (correo y clave) y retorna un JSON (éxito: true/false; jwt: JWT (con
// todos los datos del usuario) / null; status: 200/403)
$app->post('/login', \Usuario::class . ':LoginCC')->add(\MW::class . ':VerificarBDCorreoClave')->add(\MW::class . '::VerificarVacioCorreoClave')->add(\MW::class . ':VerificarSetCorreoClave');

// (GET) Se envía el JWT (en el header) y se verifica. En caso exitoso, retorna un JSON con mensaje
// y status 200. Caso contrario, retorna un JSON con mensaje y status 403.
$app->get('/login', \Usuario::class . ':VerificarJWT');

//(DELETE) Borrado de autos por ID.
//Recibe el ID del auto a ser borrado más el JWT (en el header).
//Si el perfil es ‘propietario’ se borrará de la base de datos. Caso contrario, se mostrará el
//mensaje correspondiente (indicando que usuario intentó realizar la acción).
//Retorna un JSON (éxito: true/false; mensaje: string; status: 200/418)
$app->delete('[/]', \Auto::class . ':BorrarAuto')->add(\MW::class . '::VerificarPropietario')->add(\MW::class . ':VerificarToken');

//(PUT) Modificar los autos por ID.
//Recibe el JSON del auto a ser modificado más el JWT (en el header).
//Si el perfil es ‘propietario’ o ‘encargado’ se modificará de la base de datos. Caso
//contrario, se mostrará el mensaje correspondiente (indicando que usuario intentó realizar la
//acción).
//Retorna un JSON (éxito: true/false; mensaje: string; status: 200/418)
$app->put('[/]', \Auto::class . ':ModificarAuto')->add(\MW::class . ':VerificarEncargado')->add(\MW::class . '::VerificarPropietario')->add(\MW::class . ':VerificarToken');

$app->run();


?>