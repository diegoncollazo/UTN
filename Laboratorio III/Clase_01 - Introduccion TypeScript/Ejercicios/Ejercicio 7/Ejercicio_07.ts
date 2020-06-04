/*Se necesita mostrar por consola los primeros 20 números primos. Para ello realizar una
función.
Nota: Utilizar console.log()*/

function Primo(numero : number) : boolean
{
    var retorno : boolean = true;

    for (var i : number = 2; i <= numero - 1; i++)
    {
        if (numero % i == 0) 
        {
            retorno = false;
        }
    }

    return retorno;
}

for (var i : number = 2; i <= 71; i++) 
{
    if (Primo(i))
    {
        console.log(i);
    } 
}