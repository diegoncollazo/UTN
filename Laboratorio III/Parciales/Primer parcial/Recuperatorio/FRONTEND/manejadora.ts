///<reference path="alien.ts"/>
//tsc --outfile manejadora.js ./FRONTEND/ente.ts ./FRONTEND/alien.ts ./FRONTEND/manejadora.ts
namespace RecuperatorioPrimerParcial
{
    export interface IParte2 {
        EliminarAlien(objetoJson: any): void;
        ModificarAlien(objetoJson: any): void;
    }
    
    export interface IParte3
    {
        FiltrarAliensPorPlaneta() : void;
    }

    export class Manejadora implements IParte2
    {
        //#region AgregarAlien
        public static AgregarAlien() 
        {
            let xhr: XMLHttpRequest = new XMLHttpRequest();

            let cuadrante: string = (<HTMLInputElement>document.getElementById("cuadrante")).value;
            let edad: string = (<HTMLInputElement>document.getElementById("edad")).value;
            let altura: string = (<HTMLInputElement>document.getElementById("altura")).value;
            let raza: string = (<HTMLInputElement>document.getElementById("raza")).value;
            let planeta: string = (<HTMLSelectElement>document.getElementById("cboPlaneta")).value;
            let foto: any = (<HTMLInputElement>document.getElementById("foto"));
            let path: string = (<HTMLInputElement>document.getElementById("foto")).value;
            let pathFoto: string = (path.split('\\'))[2];   //recupero el path porque lo necesito para el nuevo alien
            let Alien = new Entidades.Alien(cuadrante, parseInt(edad), parseFloat(altura), raza, planeta, pathFoto);
            let form: FormData = new FormData();

            form.append('foto', foto.files[0]);
            form.append('cadenaJson', JSON.stringify(Alien.ToJSON()));
            if (localStorage.getItem("modificar") == "true") {
                console.log("MODIFICAR");
                form.append('caso', 'modificar');
            } else {
                console.log("AGREGAR");
                form.append('caso', 'agregar');
            }
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);

            xhr.onreadystatechange = () => 
            {
                if (xhr.readyState == 4 && xhr.status == 200) 
                {
                    let retJSON = JSON.parse(xhr.responseText);

                    if (retJSON.ok) 
                    {
                        console.info("Todo ok");
                    } 
                    
                    else 
                    {
                        console.error("Se produjo un error.");
                    }
                }
            };
        }
        //#endregion

        //#region MostrarAlien
        public static MostrarAliens() 
        {
            let xhr: XMLHttpRequest = new XMLHttpRequest();
            let form: FormData = new FormData();

            form.append('caso', "traer");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);

            xhr.onreadystatechange = () => 
            {
                if (xhr.readyState == 4 && xhr.status == 200) 
                {
                    let arrayJson = JSON.parse(xhr.responseText);

                    let tabla: string = "";
                    tabla += "<table border=1> <thead>";
                    tabla += "<tr>";
                    tabla += "<td>Cuadrante</td>";
                    tabla += "<td>Edad</td>";
                    tabla += "<td>Altura</td>";
                    tabla += "<td>Raza</td>";
                    tabla += "<td>Planeta</td>";
                    tabla += "<td>Foto</td>";
                    tabla += "<td>Acciones</td>";
                    tabla += "</tr> </thead>";

                    for (let i = 0; i < arrayJson.length; i++) 
                    {
                        tabla += "<tr>";
                        tabla += "<td>" + arrayJson[i].cuadrante + "</td>";
                        tabla += "<td>" + arrayJson[i].edad + "</td>";
                        tabla += "<td>" + arrayJson[i].altura + "</td>";
                        tabla += "<td>" + arrayJson[i].raza + "</td>";
                        tabla += "<td>" + arrayJson[i].planetaOrigen + "</td>";
                        tabla += "<td>";
                        var img = new Image();
                        let path: string = arrayJson[i].pathFoto;
                        img.src = "./BACKEND/fotos/" + path;
                        tabla += "<img src='./BACKEND/fotos/" + arrayJson[i].pathFoto + "' height=100 width=100 ></img>";
                        tabla += "</td>";
                        let objJson: string = JSON.stringify(arrayJson[i]); //hay que pasarlo como stringgufy porque si no se pierde el obj
                        tabla += "<td><input type='button' onclick='new RecuperatorioPrimerParcial.Manejadora().EliminarAlien(" + objJson + ")' value='Eliminar'</td>";
                        tabla += "<td><input type='button' onclick='new RecuperatorioPrimerParcial.Manejadora().ModificarAlien(" + objJson + ")' value='Modificar'</td>";
                        tabla += "</tr>";

                    }
                    tabla += "</table>";
                    (<HTMLInputElement>document.getElementById("divTabla")).innerHTML = tabla;
                }
            };
        }
        //#endregion

        //#region GuardarEnLocalStorage
        public static GuardarEnLocalStorage() 
        {
            let xhr: XMLHttpRequest = new XMLHttpRequest();
            let form: FormData = new FormData();
            form.append('caso', "traer");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);

            xhr.onreadystatechange = () =>
            {
                if (xhr.readyState == 4 && xhr.status == 200) 
                {
                    localStorage.setItem("aliens_local_storage", xhr.responseText);
                    console.info("storage ok");
                }
            };
        }
        //#endregion

        //#region VerificarExistencia
        public static VerificarExistencia() 
        {
            let cuadrante: string = (<HTMLInputElement>document.getElementById("cuadrante")).value;
            let raza: string = (<HTMLInputElement>document.getElementById("raza")).value;
            let localSto = localStorage.getItem("aliens_local_storage");     
            let existe = false;

            if(localSto != null)
            { 
                let lsJson:any= JSON.parse(localSto);

                for (let i = 0; i < lsJson.length; i++) 
                {
                    if (lsJson[i].cuadrante == cuadrante && lsJson[i].raza == raza) 
                    {
                        existe = true;
                    }
                }
                console.log(localSto);

                if (existe == true) 
                {
                    console.info("El alien ya existe");
                    alert("El alien ya existe");
                } 
                
                else 
                {
                    Manejadora.AgregarAlien();
                    Manejadora.GuardarEnLocalStorage();
                }    
            }
            
            else
            {
                console.info("VACIO.");
            }
        }
        //#endregion
    
        //#region  ObtenerAlienPorCuadrante
        public static ObtenerAliensPorCuadrante() 
        { 
            var auxContador = new Array();
            var auxLocalStorage = localStorage.getItem("aliens_local_storage");
            if (auxLocalStorage != null) {
                var auxJson = JSON.parse(auxLocalStorage);
                for (var _i = 0, auxJson_1 = auxJson; _i < auxJson_1.length; _i++) {
                    var alien = auxJson_1[_i];
                    if (auxContador[alien.cuadrante] === undefined) {
                        auxContador[alien.cuadrante] = 0;
                    }
                    auxContador[alien.cuadrante]++;
                }
                var auxMax = undefined;
                var auxMin = undefined;
                for (var cuadrante in auxContador) {
                    if (auxMax === undefined && auxMin === undefined) {
                        auxMax = auxContador[cuadrante];
                        auxMin = auxContador[cuadrante];
                    }
                    var cantAliens = auxContador[cuadrante];
                    if (auxMax < cantAliens) {
                        auxMax = cantAliens;
                    }
                    if (auxMin > cantAliens) {
                        auxMin = cantAliens;
                    }
                }
                var cuadrantesMax = new Array();
                var cuadrantesMin = new Array();
                for (var cuadrante in auxContador) {
                    if (auxContador[cuadrante] == auxMax) {
                        cuadrantesMax.push(cuadrante);
                    }
                    else if (auxContador[cuadrante] == auxMin) {
                        cuadrantesMin.push(cuadrante);
                    }
                }
                var mensaje = "Cuadrante/s con mas aliens: ";
                if (cuadrantesMax.length > 0) {
                    for (var _a = 0, cuadrantesMax_1 = cuadrantesMax; _a < cuadrantesMax_1.length; _a++) {
                        var cuadrante: string = cuadrantesMax_1[_a];
                        mensaje += "\n*" + cuadrante;
                    }
                    mensaje += "\nCon " + auxMax;
                    console.log(mensaje);
                }
                if (cuadrantesMin.length > 0) {
                    mensaje = "Cuadrante/s con menos aliens: ";
                    for (var _b = 0, cuadrantesMin_1 = cuadrantesMin; _b < cuadrantesMin_1.length; _b++) {
                        var cuadrante: string = cuadrantesMin_1[_b];
                        mensaje += "\n*" + cuadrante;
                    }
                    mensaje += "\nCon " + auxMin;
                    console.log(mensaje);
                }
            } else {
                console.log("VACIO.");
            }
        }
        //#endregion
    
        //#region EliminarAlien
        public EliminarAlien(objetoJson: any) 
        {
            if (confirm("¿Desea eliminar alien de cuadrante " + objetoJson.cuadrante + " y raza " + objetoJson.raza + "?")) 
            {
                let xhr: XMLHttpRequest = new XMLHttpRequest();
                let form: FormData = new FormData();
                form.append('cadenaJson', JSON.stringify(objetoJson));  
                form.append('caso', "eliminar");
                xhr.open('POST', './BACKEND/administrar.php', true);    //y aca elimina
                xhr.setRequestHeader("enctype", "multipart/form-data");
                xhr.send(form);

                xhr.onreadystatechange = () => 
                {
                    if (xhr.readyState == 4 && xhr.status == 200) 
                    {
                        (<HTMLImageElement>document.getElementById("imgFoto")).src = "./BACKEND/fotos/alien_defecto.jpg";
                        Manejadora.MostrarAliens();
                        Manejadora.GuardarEnLocalStorage();
                    }
                };
            } 

            else 
            {
                alert("Accion cancelada");
            }
        }
        //#endregion

        //#region ModificarAien
        public ModificarAlien(objetoJson: any) 
        {
            (<HTMLInputElement>document.getElementById("cuadrante")).value = objetoJson.cuadrante;
            (<HTMLInputElement>document.getElementById("cuadrante")).readOnly = true;
            (<HTMLInputElement>document.getElementById("edad")).value = objetoJson.edad;
            (<HTMLInputElement>document.getElementById("altura")).value = objetoJson.altura;
            (<HTMLInputElement>document.getElementById("raza")).value = objetoJson.raza;
            (<HTMLInputElement>document.getElementById("cboPlaneta")).value = objetoJson.planetaOrigen;
            (<HTMLSelectElement>document.getElementById("raza")).value = objetoJson.raza;
            let path : string= "./BACKEND/fotos/" + objetoJson.pathFoto;
            (<HTMLImageElement>document.getElementById("imgFoto")).src = path;  
            (<HTMLInputElement>document.getElementById("btn-agregar")).value = "Modificar";


            let xhr: XMLHttpRequest = new XMLHttpRequest();
            let form: FormData = new FormData();
            form.append('cadenaJson', JSON.stringify(objetoJson));  
            form.append('caso', "eliminar");
            xhr.open('POST', './BACKEND/administrar.php', true);    
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);

            xhr.onreadystatechange = () => 
            {
                if (xhr.readyState == 4 && xhr.status == 200) 
                {
                    console.log("Alien eliminado");
                }
            };

            localStorage.setItem("modificar", "true"); 
        }
        //#endregion
    
        //#region FiltrarAliensPorPlaneta
        public static FiltrarAliensPorPlaneta(): void
        {
            let xhr: XMLHttpRequest = new XMLHttpRequest();
            let form: FormData = new FormData();
            let planeta: string = (<HTMLSelectElement>document.getElementById("cboPlaneta")).value;

            form.append('caso', "traer");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);

            xhr.onreadystatechange = () => 
            {
                if (xhr.readyState == 4 && xhr.status == 200) 
                {
                    let arrayJson = JSON.parse(xhr.responseText);

                    let tabla: string = "";
                    tabla += "<table border=1> <thead>";
                    tabla += "<tr>";
                    tabla += "<td>Cuadrante</td>";
                    tabla += "<td>Edad</td>";
                    tabla += "<td>Altura</td>";
                    tabla += "<td>Raza</td>";
                    tabla += "<td>Planeta</td>";
                    tabla += "<td>Foto</td>";
                    tabla += "</tr> </thead>";

                    for (let i = 0; i < arrayJson.length; i++) 
                    {
                        if(planeta == arrayJson[i].planetaOrigen)
                        {
                            tabla += "<tr>";
                            tabla += "<td>" + arrayJson[i].cuadrante + "</td>";
                            tabla += "<td>" + arrayJson[i].edad + "</td>";
                            tabla += "<td>" + arrayJson[i].altura + "</td>";
                            tabla += "<td>" + arrayJson[i].raza + "</td>";
                            tabla += "<td>" + arrayJson[i].planetaOrigen + "</td>";
                            tabla += "<td>";
                            var img = new Image();
                            let path: string = arrayJson[i].pathFoto;
                            img.src = "./BACKEND/fotos/" + path;
                            tabla += "<img src='./BACKEND/fotos/" + arrayJson[i].pathFoto + "' height=100 width=100 ></img>";
                            tabla += "</td>";
                            tabla += "</tr>";
                        }
                    }
                    tabla += "</table>";
                    (<HTMLInputElement>document.getElementById("divTabla")).innerHTML = tabla;
                }
            };
        }
        //#endregion
    
    }
}