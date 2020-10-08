<?php

use Firebase\JWT\JWT;

class Usuario
{
    public $correo;
    public $clave;
    public $nombre;
    public $apellido;
    public $perfil; 
    public $foto;

    //------------------------------------------------------
    //                         API
    //------------------------------------------------------
    public function AltaUsuario($request, $response, $args)
    { 
        $ArrayDeParametros = $request->getParsedBody();
        $parametro = $ArrayDeParametros['usuario'];
        $parametro = json_decode($parametro);
        $archivos = $request->getUploadedFiles(); 
        $foto=$archivos['foto']->getClientFilename();
        $destino ="./BACKEND/fotos/";    
        
        //Cargo el usuario
        $usuario = new usuario();
        $usuario->correo = $parametro->correo;
        $usuario->clave = $parametro->clave;
        $usuario->nombre = $parametro->nombre;
        $usuario->apellido = $parametro->apellido;
        $usuario->perfil = $parametro->perfil;
        $usuario->foto = $foto;

        $std= new stdclass();
        if($usuario->AltaUsuBD($usuario))
        {
            //Retorna un JSON (éxito: true/false; mensaje: string; status: 200/418)
            $std->exito = true;
            $std->mensaje = "Todo Ok.";
            $archivos['foto']->moveTo($destino . $foto);
            $retorno = $response->withJson($std, 200);
        }
        else
        {
            $std->exito = false;
            $std->mensaje = "ERROR!";
            $retorno = $response->withJson($std, 418);
        }

        return $retorno;
    }

    public function ListaUsuario($request, $response, $args)
    {
        $stringJSON= Usuario::TraerTodosUsuBD(); 
        $std= new stdclass(); 

        if($stringJSON)
        {
            //Retorna un JSON (éxito: true/false; mensaje: string; tabla: stringJSON; status: 200/424)
            $std->exito = true;
            $std->mensaje = "Todo Ok.";
            $std->tabla = $stringJSON;          
            $retorno = $response->write(json_encode($std), 200);
        }
        
        else
        {
            $std->exito = false;
            $std->mensaje = "ERROR!";
            $retorno = $response->withJson($std, 424);
        }

        return $retorno;
    }

    //------------------------------------------------------
    //                         JWT
    //------------------------------------------------------
    public function LoginCC($request, $response, $next)
    {
        $arrayDeParametros = $request->getParsedBody();
        $login = $arrayDeParametros['usuario'];
        $login = json_decode($login);
        $correo = $login->correo;
        $clave = $login->clave;
        $std = new stdclass();
        $login = Usuario::ValidarUsu($correo, $clave);
        $bandera = false;

        try
        {
            $tiempo = time();
            $payload = array(
                'iat' => $tiempo,
                'exp' => $tiempo + (30),
                'data' => $login,
            );

            $token = JWT::encode($payload, "claveSecreta");
            $bandera = true;
        }
        catch(Exception $e)
        {
            $std->mensaje = $e->getMessage();
        }

        if($bandera == true && $login != false)
        {
            $std->exito = true;
            $std->jwt = $token;
            $retorno = $response->withJson($std, 200);
        }
        else
        {
            $std->exito=false;
            $std->jwt=null;
            $retorno = $response->withJson($std, 403);
        }

        return $retorno;
    }

    public function VerificarJWT($request, $response, $next)
    {
        $token = $request->getHeader('token')[0];
        $bandera = false;
        $std= new stdClass();

        try
        {
            $decodificado=JWT::decode(
                $token,
                "claveSecreta",
                ['HS256']
            );
            $bandera = true;
        }
        catch(Exception $e)
        {
            $std = "Token no valido!!! --> " . $e->getMessage();
        }

        if($bandera == true)
        {
           $std->mensaje="Todo Ok";
           $std->token=$decodificado;
           $retorno = $response->withJson($std, 200);
        }
        else
        {
            $std->mensaje="Error";
            $retorno = $response->withJson($std, 403);
        }

        return $retorno;
    }

    //------------------------------------------------------
    //                    BASE DE DATOS
    //------------------------------------------------------
    public static function AltaUsuBD($usuario)
    {
        $retorno = false;
        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();    

        $consulta =$objetoAccesoDato->RetornarConsulta ("INSERT INTO `usuarios`(`correo`, `clave`, `nombre`, `apellido`, `perfil`, `foto`)
        VALUES (:correo, :clave, :nombre, :apellido, :perfil, :foto)");
                                                        
        $consulta->bindValue(':correo', $usuario->correo, PDO::PARAM_STR);
        $consulta->bindValue(':clave', $usuario->clave, PDO::PARAM_STR);
        $consulta->bindValue(':nombre', $usuario->nombre, PDO::PARAM_STR);
        $consulta->bindValue(':apellido', $usuario->apellido, PDO::PARAM_STR);
        $consulta->bindValue(':perfil', $usuario->perfil, PDO::PARAM_STR);
        $consulta->bindValue(':foto', $usuario->foto, PDO::PARAM_STR);
        $consulta->execute();   

        if ($consulta->rowCount()>0) {
            $retorno = true;
        }
        return $retorno;
    }

    public static function TraerTodosUsuBD()
    {    
        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();        
        $consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM usuarios");    
        $consulta->execute();   
        $usuarios = $consulta->fetchAll(PDO::FETCH_CLASS, "Usuario");
        return $usuarios;         
    }

    public static function ValidarUsu($correo, $clave)
    {
        $objetoAccesoDato = AccesoDatos::DameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM usuarios WHERE correo=:correo AND clave=:clave");

        $consulta->bindValue(':correo', $correo, PDO::PARAM_STR);
        $consulta->bindValue(':clave', $clave, PDO::PARAM_STR);
        $consulta->execute();

        $usuario = false;

        if ($consulta->rowCount()>0) {
            $usuario= $consulta->fetchObject('Usuario');
        }

        return $usuario;
    }
}

?>