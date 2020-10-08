<?php
$email = isset($_GET['cookie']) ? $_GET['cookie'] : NULL;

if(isset($_COOKIE[$email])) 
{
    echo $_COOKIE[$email];
}

else
{
    echo "No existe la cookie";
}
