var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Entidades;
(function (Entidades) {
    var Ente = /** @class */ (function () {
        function Ente(cuadrante, edad, altura) {
            this.cuadrante = cuadrante;
            this.edad = edad;
            this.altura = altura;
        }
        Ente.prototype.ToString = function () {
            return "{\"cuadrante\":\"" + this.cuadrante + "\",\"edad\":\"" + this.edad + "\",\"altura\":\"" + this.altura + "\",";
        };
        return Ente;
    }());
    Entidades.Ente = Ente;
})(Entidades || (Entidades = {}));
///<reference path="ente.ts"/>
var Entidades;
(function (Entidades) {
    var Alien = /** @class */ (function (_super) {
        __extends(Alien, _super);
        function Alien(cuadrante, edad, altura, raza, planeta, path) {
            var _this = _super.call(this, cuadrante, edad, altura) || this;
            _this.raza = raza;
            _this.planetaOrigen = planeta;
            _this.pathFoto = path;
            return _this;
        }
        Alien.prototype.ToJSON = function () {
            var retornoJson = _super.prototype.ToString.call(this) + "\"raza\":\"" + this.raza + "\",\"planetaOrigen\":\"" + this.planetaOrigen + "\",\"pathFoto\":\"" + this.pathFoto + "\"}";
            return JSON.parse(retornoJson);
        };
        return Alien;
    }(Entidades.Ente));
    Entidades.Alien = Alien;
})(Entidades || (Entidades = {}));
///<reference path="alien.ts"/>
//tsc --outfile manejadora.js ./FRONTEND/ente.ts ./FRONTEND/alien.ts ./FRONTEND/manejadora.ts
var RecuperatorioPrimerParcial;
(function (RecuperatorioPrimerParcial) {
    var Manejadora = /** @class */ (function () {
        function Manejadora() {
        }
        //#region AgregarAlien
        Manejadora.AgregarAlien = function () {
            var xhr = new XMLHttpRequest();
            var cuadrante = document.getElementById("cuadrante").value;
            var edad = document.getElementById("edad").value;
            var altura = document.getElementById("altura").value;
            var raza = document.getElementById("raza").value;
            var planeta = document.getElementById("cboPlaneta").value;
            var foto = document.getElementById("foto");
            var path = document.getElementById("foto").value;
            var pathFoto = (path.split('\\'))[2]; //recupero el path porque lo necesito para el nuevo alien
            var Alien = new Entidades.Alien(cuadrante, parseInt(edad), parseFloat(altura), raza, planeta, pathFoto);
            var form = new FormData();
            form.append('foto', foto.files[0]);
            form.append('cadenaJson', JSON.stringify(Alien.ToJSON()));
            if (localStorage.getItem("modificar") == "true") {
                console.log("MODIFICAR");
                form.append('caso', 'modificar');
            }
            else {
                console.log("AGREGAR");
                form.append('caso', 'agregar');
            }
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var retJSON = JSON.parse(xhr.responseText);
                    if (retJSON.ok) {
                        console.info("Todo ok");
                    }
                    else {
                        console.error("Se produjo un error.");
                    }
                }
            };
        };
        //#endregion
        //#region MostrarAlien
        Manejadora.MostrarAliens = function () {
            var xhr = new XMLHttpRequest();
            var form = new FormData();
            form.append('caso', "traer");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var arrayJson = JSON.parse(xhr.responseText);
                    var tabla = "";
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
                    for (var i = 0; i < arrayJson.length; i++) {
                        tabla += "<tr>";
                        tabla += "<td>" + arrayJson[i].cuadrante + "</td>";
                        tabla += "<td>" + arrayJson[i].edad + "</td>";
                        tabla += "<td>" + arrayJson[i].altura + "</td>";
                        tabla += "<td>" + arrayJson[i].raza + "</td>";
                        tabla += "<td>" + arrayJson[i].planetaOrigen + "</td>";
                        tabla += "<td>";
                        var img = new Image();
                        var path = arrayJson[i].pathFoto;
                        img.src = "./BACKEND/fotos/" + path;
                        tabla += "<img src='./BACKEND/fotos/" + arrayJson[i].pathFoto + "' height=100 width=100 ></img>";
                        tabla += "</td>";
                        var objJson = JSON.stringify(arrayJson[i]); //hay que pasarlo como stringgufy porque si no se pierde el obj
                        tabla += "<td><input type='button' onclick='new RecuperatorioPrimerParcial.Manejadora().EliminarAlien(" + objJson + ")' value='Eliminar'</td>";
                        tabla += "<td><input type='button' onclick='new RecuperatorioPrimerParcial.Manejadora().ModificarAlien(" + objJson + ")' value='Modificar'</td>";
                        tabla += "</tr>";
                    }
                    tabla += "</table>";
                    document.getElementById("divTabla").innerHTML = tabla;
                }
            };
        };
        //#endregion
        //#region GuardarEnLocalStorage
        Manejadora.GuardarEnLocalStorage = function () {
            var xhr = new XMLHttpRequest();
            var form = new FormData();
            form.append('caso', "traer");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    localStorage.setItem("aliens_local_storage", xhr.responseText);
                    console.info("storage ok");
                }
            };
        };
        //#endregion
        //#region VerificarExistencia
        Manejadora.VerificarExistencia = function () {
            var cuadrante = document.getElementById("cuadrante").value;
            var raza = document.getElementById("raza").value;
            var localSto = localStorage.getItem("aliens_local_storage");
            var existe = false;
            if (localSto != null) {
                var lsJson = JSON.parse(localSto);
                for (var i = 0; i < lsJson.length; i++) {
                    if (lsJson[i].cuadrante == cuadrante && lsJson[i].raza == raza) {
                        existe = true;
                    }
                }
                console.log(localSto);
                if (existe == true) {
                    console.info("El alien ya existe");
                    alert("El alien ya existe");
                }
                else {
                    Manejadora.AgregarAlien();
                    Manejadora.GuardarEnLocalStorage();
                }
            }
            else {
                console.info("VACIO.");
            }
        };
        //#endregion
        //#region  ObtenerAlienPorCuadrante
        Manejadora.ObtenerAliensPorCuadrante = function () {
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
                        var cuadrante = cuadrantesMax_1[_a];
                        mensaje += "\n*" + cuadrante;
                    }
                    mensaje += "\nCon " + auxMax;
                    console.log(mensaje);
                }
                if (cuadrantesMin.length > 0) {
                    mensaje = "Cuadrante/s con menos aliens: ";
                    for (var _b = 0, cuadrantesMin_1 = cuadrantesMin; _b < cuadrantesMin_1.length; _b++) {
                        var cuadrante = cuadrantesMin_1[_b];
                        mensaje += "\n*" + cuadrante;
                    }
                    mensaje += "\nCon " + auxMin;
                    console.log(mensaje);
                }
            }
            else {
                console.log("VACIO.");
            }
        };
        //#endregion
        //#region EliminarAlien
        Manejadora.prototype.EliminarAlien = function (objetoJson) {
            if (confirm("¿Desea eliminar alien de cuadrante " + objetoJson.cuadrante + " y raza " + objetoJson.raza + "?")) {
                var xhr_1 = new XMLHttpRequest();
                var form = new FormData();
                form.append('cadenaJson', JSON.stringify(objetoJson));
                form.append('caso', "eliminar");
                xhr_1.open('POST', './BACKEND/administrar.php', true); //y aca elimina
                xhr_1.setRequestHeader("enctype", "multipart/form-data");
                xhr_1.send(form);
                xhr_1.onreadystatechange = function () {
                    if (xhr_1.readyState == 4 && xhr_1.status == 200) {
                        document.getElementById("imgFoto").src = "./BACKEND/fotos/alien_defecto.jpg";
                        Manejadora.MostrarAliens();
                        Manejadora.GuardarEnLocalStorage();
                    }
                };
            }
            else {
                alert("Accion cancelada");
            }
        };
        //#endregion
        //#region ModificarAien
        Manejadora.prototype.ModificarAlien = function (objetoJson) {
            document.getElementById("cuadrante").value = objetoJson.cuadrante;
            document.getElementById("cuadrante").readOnly = true;
            document.getElementById("edad").value = objetoJson.edad;
            document.getElementById("altura").value = objetoJson.altura;
            document.getElementById("raza").value = objetoJson.raza;
            document.getElementById("cboPlaneta").value = objetoJson.planetaOrigen;
            document.getElementById("raza").value = objetoJson.raza;
            var path = "./BACKEND/fotos/" + objetoJson.pathFoto;
            document.getElementById("imgFoto").src = path;
            document.getElementById("btn-agregar").value = "Modificar";
            var xhr = new XMLHttpRequest();
            var form = new FormData();
            form.append('cadenaJson', JSON.stringify(objetoJson));
            form.append('caso', "eliminar");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    console.log("Alien eliminado");
                }
            };
            localStorage.setItem("modificar", "true");
        };
        //#endregion
        //#region FiltrarAliensPorPlaneta
        Manejadora.prototype.FiltrarAliensPorPlaneta = function () {
            var xhr = new XMLHttpRequest();
            var form = new FormData();
            var planeta = document.getElementById("cboPlaneta").value;
            form.append('caso', "traer");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    var arrayJson = JSON.parse(xhr.responseText);
                    var tabla = "";
                    tabla += "<table border=1> <thead>";
                    tabla += "<tr>";
                    tabla += "<td>Cuadrante</td>";
                    tabla += "<td>Edad</td>";
                    tabla += "<td>Altura</td>";
                    tabla += "<td>Raza</td>";
                    tabla += "<td>Planeta</td>";
                    tabla += "<td>Foto</td>";
                    tabla += "</tr> </thead>";
                    for (var i = 0; i < arrayJson.length; i++) {
                        if (planeta == arrayJson[i].planetaOrigen) {
                            tabla += "<tr>";
                            tabla += "<td>" + arrayJson[i].cuadrante + "</td>";
                            tabla += "<td>" + arrayJson[i].edad + "</td>";
                            tabla += "<td>" + arrayJson[i].altura + "</td>";
                            tabla += "<td>" + arrayJson[i].raza + "</td>";
                            tabla += "<td>" + arrayJson[i].planetaOrigen + "</td>";
                            tabla += "<td>";
                            var img = new Image();
                            var path = arrayJson[i].pathFoto;
                            img.src = "./BACKEND/fotos/" + path;
                            tabla += "<img src='./BACKEND/fotos/" + arrayJson[i].pathFoto + "' height=100 width=100 ></img>";
                            tabla += "</td>";
                            tabla += "</tr>";
                        }
                    }
                    tabla += "</table>";
                    document.getElementById("divTabla").innerHTML = tabla;
                }
            };
        };
        return Manejadora;
    }());
    RecuperatorioPrimerParcial.Manejadora = Manejadora;
})(RecuperatorioPrimerParcial || (RecuperatorioPrimerParcial = {}));
