
///<reference path="./Alien.ts"/>
//tsc --outfile .\FRONTEND\Manejadora.js .\FRONTEND\Ente.ts .\FRONTEND\Alien.ts .\FRONTEND\Manejadora.ts
namespace RecuperatorioPrimerParcial 
{
    export class Manejadora 
    {
        public static AgregarAlien() 
        {
            //Creo variables Ajax
            let xhr: XMLHttpRequest = new XMLHttpRequest();

            //Tomará los valores desde la página
            let cuadrante: string = (<HTMLInputElement>document.getElementById("cuadrante")).value;
            let edad: string = (<HTMLInputElement>document.getElementById("edad")).value;
            let altura: string = (<HTMLInputElement>document.getElementById("altura")).value;
            let raza: string = (<HTMLInputElement>document.getElementById("raza")).value;
            let planeta: string = (<HTMLSelectElement>document.getElementById("cboPlaneta")).value;
            let foto: any = (<HTMLInputElement>document.getElementById("foto"));
            let path: string = (<HTMLInputElement>document.getElementById("foto")).value;
            let pathFoto: string = (path.split('\\'))[2];   //recupero el path porque lo necesito para el nuevo alien

            //objeto de tipo Alien
            let Alien = new Entidades.Alien(cuadrante, parseInt(edad), parseFloat(altura), raza, planeta, pathFoto);

            //Creo un form para la foto
            let form: FormData = new FormData();
            form.append('foto', foto.files[0]); //Indico la foto
            form.append('cadenaJson', JSON.stringify(Alien.ToJSON())); //POST de administrar y valor
            form.append('caso', 'agregar'); //POST de switch

            //que se enviará (por AJAX) hacia “./BACKEND/adminstrar.php”.
            xhr.open('POST', './BACKEND/administrar.php', true); //METODO; URL; ASYN
            xhr.setRequestHeader("enctype", "multipart/form-data"); //Formato para las fotos
            xhr.send(form); //dentro de esta se guarda el json de aliens y se guarda la imagen

            xhr.onreadystatechange = () => 
            {
                if (xhr.readyState == 4 && xhr.status == 200) //Verifico Ajax
                {
                    let retJSON = JSON.parse(xhr.responseText);//Lo paso a obj para saber si guardo todo bien

                    if (retJSON.ok) 
                    {
                        console.info("Todo ok");
                        let path: string = "./BACKEND/fotos/" + pathFoto;
                        (<HTMLImageElement>document.getElementById("imgFoto")).src = path;  //cambiamos src porque ahora busca la foto nueva ahi, pisando la vieja
                        console.log(path);
                    } 
                    
                    else 
                    {
                        console.error("Se produjio un error");
                    }
                }
            };
        }

        public static MostrarAliens() 
        {
            let xhr: XMLHttpRequest = new XMLHttpRequest(); //Ajax
            let form: FormData = new FormData(); //Creo el form y le agrego las caracteristicas

            //(caso=”traer”)
            form.append('caso', "traer"); //codigo y valor
            xhr.open('POST', './BACKEND/administrar.php', true); //METODO; URL; ASYN
            xhr.setRequestHeader("enctype", "multipart/form-data");//Para la foto
            xhr.send(form); //Al ser post le mando el string por parametro

            xhr.onreadystatechange = () => 
            {
                if (xhr.readyState == 4 && xhr.status == 200) //Verifico Ajax
                {
                    //Creo un objeto json con los valores recuperados
                    let arrayJson = JSON.parse(xhr.responseText); 

                    //Armo la tabla para mostrar
                    let tabla: string = "";
                    tabla += "<table border=1> <thead>";
                    tabla += "<tr>";
                    tabla += "<td> Cuadrante </td>";
                    tabla += "<td>Edad</td>";
                    tabla += "<td>Altura</td>";
                    tabla += "<td>Raza</td>";
                    tabla += "<td>Planeta</td>";
                    tabla += "<td>Foto</td>";
                    tabla += "</tr> </thead>";

                    for (let i = 0; i < arrayJson.length; i++) 
                    {
                        //Muetsro cada darto por el indice 
                        tabla += "<tr>";
                        tabla += "<td>" + arrayJson[i].cuadrante + "</td>";
                        tabla += "<td>" + arrayJson[i].edad + "</td>";
                        tabla += "<td>" + arrayJson[i].altura + "</td>";
                        tabla += "<td>" + arrayJson[i].raza + "</td>";
                        tabla += "<td>" + arrayJson[i].planetaOrigen + "</td>";
                        tabla += "<td>";

                        //Verifico si tiene un foto
                        if (arrayJson[i].pathFoto !== "undefined") //Si tiene cargo las imagen en un img
                        {
                            tabla += "<img src='./BACKEND/fotos/" + arrayJson[i].pathFoto + "' height=100 width=100 ></img>";
                        } 
                        
                        else //Si no tiene
                        {
                            tabla += "No hay foto";
                        }
                        tabla += "</td>";
                        tabla += "</tr>";

                    }

                    tabla += "</table>";

                    //Establezco donde quiere que coloque la tabla
                    (<HTMLInputElement>document.getElementById("divTabla")).innerHTML = tabla;
                }
            };
        }

        /*El objeto Storage (API de almacenamiento web) nos permite almacenar datos 
        de manera local en el navegador y sin necesidad de realizar 
        alguna conexión a una base de datos.*/
        public static GuardarEnLocalStorage() 
        {
            //Recuperará (por AJAX)
            let xhr: XMLHttpRequest = new XMLHttpRequest();
            let form: FormData = new FormData(); //creo el form

            // todos los aliens del archivo .json
            form.append('caso', "traer"); //codigo y clave
            xhr.open('POST', './BACKEND/administrar.php', true); //METODO; URL; ASYNC
            xhr.setRequestHeader("enctype", "multipart/form-data"); //Para la foto
            xhr.send(form);//POST

            xhr.onreadystatechange = () => 
            {
                if (xhr.readyState == 4 && xhr.status == 200) //Verifico Ajax
                {
                    localStorage.setItem("aliens_local_storage", xhr.responseText); //Lo guardo en el local storage
                    console.log("storage ok"); 
                }
            };
        }

        public static VerificarExistencia() 
        {
            //Verifico exitencia por raza y cuadrante
            let cuadrante: string = (<HTMLInputElement>document.getElementById("cuadrante")).value;
            let raza: string = (<HTMLInputElement>document.getElementById("raza")).value;
            //Leo lo que hay en el localstorage
            let localSto = localStorage.getItem("aliens_local_storage"); 

            if(localSto != null)
            { //me fijo si no viene vacio
                let lsJson:any= JSON.parse(localSto); //Lo paso a objeto para poder comparar

                for (let i = 0; i < lsJson.length; i++) 
                {
                    if (lsJson[i].cuadrante == cuadrante && lsJson[i].raza == raza) 
                    {//Si exite aviso
                        console.log("El alien ya existe");
                        alert("El alien ya existe");
                        break;
                    }

                    else //Caso contrario, agregará el nuevo alien y se actualizará el LocalStorage
                    {
                        Manejadora.AgregarAlien();
                        Manejadora.GuardarEnLocalStorage();
                    }
                }  
            }
            
            else
            {
                alert("No se encuentra");
                console.log("No se encuentra");
            }
        }

        public static ObtenerAliensPorCuadrante() 
        { 
            var auxContador = new Array();
            //Recupero los aliens que hay cargados
            var auxLocalStorage = localStorage.getItem("aliens_local_storage");

            if (auxLocalStorage != null) //verifico que no este vacio
            {
                var auxJson = JSON.parse(auxLocalStorage);//lo paso a objeto

                for (var _i = 0, auxJson_1 = auxJson; _i < auxJson_1.length; _i++) 
                {
                    var alien = auxJson_1[_i];

                    if (auxContador[alien.cuadrante] === undefined) 
                    {
                        auxContador[alien.cuadrante] = 0;
                    }
                    auxContador[alien.cuadrante]++;
                }

                var auxMax = undefined;
                var auxMin = undefined;

                for (var cuadrante in auxContador) 
                {
                    if (auxMax === undefined && auxMin === undefined) 
                    {
                        auxMax = auxContador[cuadrante];
                        auxMin = auxContador[cuadrante];
                    }

                    var cantAliens = auxContador[cuadrante];
                    if (auxMax < cantAliens) 
                    {
                        auxMax = cantAliens;
                    }

                    if (auxMin > cantAliens) 
                    {
                        auxMin = cantAliens;
                    }
                }

                var cuadrantesMax = new Array();
                var cuadrantesMin = new Array();
                for (var cuadrante in auxContador) 
                {
                    if (auxContador[cuadrante] == auxMax) 
                    {
                        cuadrantesMax.push(cuadrante);
                    }
                    else if (auxContador[cuadrante] == auxMin) 
                    {
                        cuadrantesMin.push(cuadrante);
                    }
                }
                var mensaje = "Cuadrante con mas aliens: ";

                if (cuadrantesMax.length > 0) 
                {
                    for (var _a = 0, cuadrantesMax_1 = cuadrantesMax; _a < cuadrantesMax_1.length; _a++) 
                    {
                        var cuadrante: string = cuadrantesMax_1[_a];
                        mensaje += "\n*" + cuadrante;
                    }

                    mensaje += "\nCon " + auxMax;
                    console.log(mensaje);
                }

                if (cuadrantesMin.length > 0) 
                {
                    mensaje = "Cuadrante/s con menos aliens: ";

                    for (var _b = 0, cuadrantesMin_1 = cuadrantesMin; _b < cuadrantesMin_1.length; _b++) 
                    {
                        var cuadrante: string = cuadrantesMin_1[_b];
                        mensaje += "\n*" + cuadrante;
                    }
                    mensaje += "\nCon " + auxMin;
                    console.log(mensaje);
                }
            }
            
            else
            {
                console.log("storage vacio");
            }
        }
    }
}