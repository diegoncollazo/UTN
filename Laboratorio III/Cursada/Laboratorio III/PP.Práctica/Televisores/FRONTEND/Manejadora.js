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
    var Producto = /** @class */ (function () {
        //cosntructor que reciba los tres
        function Producto(codigo, marca, precio) {
            this.codigo = codigo;
            this.marca = marca;
            this.precio = precio;
        }
        //ToString():string, que retorne la representación de la clase en formato cadena (preparar la cadena para que, al juntarse con el método ToJSON, forme
        //una cadena JSON válida
        Producto.prototype.ToString = function () {
            return ('"codigo":' + this.codigo + ',"marca":"' + this.marca + '","precio":"' + this.precio + '",');
        };
        return Producto;
    }());
    Entidades.Producto = Producto;
})(Entidades || (Entidades = {}));
//hereda de producto
/// <reference path="producto.ts" />
var Entidades;
(function (Entidades) {
    var Televisor = /** @class */ (function (_super) {
        __extends(Televisor, _super);
        //inciialñiza todos
        function Televisor(codigo, marca, precio, tipo, pais, foto) {
            var _this = _super.call(this, codigo, marca, precio) || this;
            _this.tipo = tipo;
            _this.paisOrigen = pais;
            _this.pathFoto = foto;
            return _this;
        }
        // Un método ToJSON():JSON,
        // que retornará la representación del objeto en formato JSON. Se debe de reutilizar el método
        // ToString de la clase Producto.
        Televisor.prototype.ToJSON = function () {
            var retornoJson = ('{' + _super.prototype.ToString.call(this) + '"tipo":"' + this.tipo + '","pais":"' + this.paisOrigen + '","pathFoto":"' + this.pathFoto + '"}');
            return JSON.parse(retornoJson);
        };
        return Televisor;
    }(Entidades.Producto));
    Entidades.Televisor = Televisor;
})(Entidades || (Entidades = {}));
/// <reference path="./producto.ts" />
/// <reference path="./televisor.ts" />
var PrimerParcial;
(function (PrimerParcial) {
    var Manejadora = /** @class */ (function () {
        function Manejadora() {
        }
        Manejadora.AgregarTelevisor = function () {
            var xhr = new XMLHttpRequest(); //AJAX
            //Tomará los valores ingresados
            var codigo = document.getElementById("codigo").value;
            var marca = document.getElementById("marca").value;
            var precio = document.getElementById("precio").value;
            var tipo = document.getElementById("tipo").value;
            var pais = document.getElementById("pais").value;
            var foto = document.getElementById("foto");
            var path = document.getElementById("foto").value;
            var pathFoto = (path.split('\\'))[2]; //recupero el path porque lo necesito para el nuevo alien
            //y los cargo en un televisor los parseo
            var tele = new Entidades.Televisor(parseInt(codigo), marca, parseFloat(precio), tipo, pais, pathFoto);
            //Creo un form para la foto
            var form = new FormData();
            form.append('foto', foto.files[0]); //Le indico el lugar
            form.append('cadenaJson', JSON.stringify(tele.ToJSON())); //parametro recuperado por POST
            form.append('caso', 'agregar'); //switch
            xhr.open('POST', './BACKEND/administrar.php', true); //METODO; URL; ASINCRONICO
            xhr.setRequestHeader("enctype", "multipart/form-data"); //configuro el form
            xhr.send(form); //dentro de esta se guarda el json de televs y se guarda la imagen
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    console.log(xhr.responseText);
                    var retJSON = JSON.parse(xhr.responseText);
                    if (retJSON.TodoOK) {
                        console.info("Ok.");
                        var path_1 = "./BACKEND/fotos/" + pathFoto;
                        document.getElementById("imgFoto").src = path_1; //cambiamos src porque ahora busca la foto nueva ahi, pisando la vieja
                    }
                    else {
                        console.error("Se produjo un error - No se pudo agregar");
                    }
                }
            };
        };
        ;
        Manejadora.MostrarTelevisores = function () {
            // (por AJAX)
            var xhr = new XMLHttpRequest();
            var form = new FormData();
            //(caso=”traer”)
            form.append('caso', "traer");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    // Recuperará  todos los televs del archivo .json y generará un listado dinámico 
                    var arrayJson = JSON.parse(xhr.responseText);
                    var tabla = "";
                    tabla += "<table border=1 style='width:100%' text-aling='center'> <thead>";
                    tabla += "<tr>";
                    tabla += "<th>Codigo</th>";
                    tabla += "<th>Marca</th>";
                    tabla += "<th>Precio</th>";
                    tabla += "<th>Tipo</th>";
                    tabla += "<th>Pais</th>";
                    tabla += "<th>Foto</th>";
                    tabla += "<th colspan='2'>Acciones</th>";
                    tabla += "</tr> </thead>";
                    for (var i = 0; i < arrayJson.length; i++) {
                        // mostrará toda la información de cada uno de los televisores
                        tabla += "<tr>";
                        tabla += "<td>" + arrayJson[i].codigo + "</td>";
                        tabla += "<td>" + arrayJson[i].marca + "</td>";
                        tabla += "<td>" + arrayJson[i].precio + "</td>";
                        tabla += "<td>" + arrayJson[i].tipo + "</td>";
                        tabla += "<td>" + arrayJson[i].pais + "</td>";
                        // (incluida la foto)
                        tabla += "<td>";
                        var img = new Image();
                        var path = arrayJson[i].pathFoto;
                        if (arrayJson[i].pathFoto !== "undefined") {
                            img.src = "./BACKEND/fotos/" + path;
                            tabla += "<img src='./BACKEND/fotos/" + arrayJson[i].pathFoto + "' height=100 width=100 ></img>";
                        }
                        else {
                            tabla += "No hay foto";
                        }
                        tabla += "</td>";
                        // Agregar una columna (Acciones) al listado de televisores que permita: 
                        // Eliminar y Modificar al televisor elegido. Para ello, 
                        // agregue dos botones (input [type=button]) que invoquen a las funciones 
                        // EliminarTelevisor y ModificarTelevisor, respectivamente.
                        console.log(arrayJson[i]);
                        var objJson = JSON.stringify(arrayJson[i]); //hay que pasarlo como stringgufy porque si no se pierde el obj
                        tabla += "<td colspan='2'><input type='button' onclick='new PrimerParcial.Manejadora().EliminarTelevisor(" + objJson + ")' value='Eliminar'</td>";
                        tabla += "<input type='button' onclick='new PrimerParcial.Manejadora().ModificarAlien(" + objJson + ")' value='Modificar'";
                        tabla += "</tr>";
                    }
                    tabla += "</table>";
                    document.getElementById("divTabla").innerHTML = tabla;
                }
            };
        };
        Manejadora.GuardarEnLocalStorage = function () {
            var xhr = new XMLHttpRequest();
            var form = new FormData();
            // todos los televisores del archivo .json
            //(caso=”traer”)
            form.append('caso', "traer");
            xhr.open('POST', './BACKEND/administrar.php', true);
            xhr.setRequestHeader("enctype", "multipart/form-data");
            xhr.send(form);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    //los guarda en el LocalStorage, con la clave "televisores_local_storage".
                    localStorage.setItem("televisores_local_storage", xhr.responseText);
                    console.log("storage ok");
                }
            };
        };
        Manejadora.VerificarExistencia = function () {
            var codigo = document.getElementById("codigo").value;
            var localSto = localStorage.getItem("televisores_local_storage");
            var existe = false;
            if (localSto != null) { //me fijo si no viene vacio
                var lsJson = JSON.parse(localSto);
                //comparará los códigos de los televisores guardados en el LocalStorage.
                for (var i = 0; i < lsJson.length; i++) {
                    if (lsJson[i].codigo == codigo) {
                        existe = true;
                    }
                }
                console.log(localSto);
                console.log(existe);
                if (existe == true) {
                    //Si el televisor existe, se mostrará (por consola y alert)
                    console.log("El televisor ya existe");
                    alert("El televisor ya existe");
                }
                else {
                    //Caso contrario, agregará el nuevo televisor y se actualizará el LocalStorage
                    Manejadora.AgregarTelevisor();
                    Manejadora.GuardarEnLocalStorage();
                }
            }
            else {
                alert("Storage vacio");
                console.log("Storage vacio");
            }
        };
        return Manejadora;
    }());
    PrimerParcial.Manejadora = Manejadora;
})(PrimerParcial || (PrimerParcial = {}));
//tsc --init
//tsc --outfile ./FRONTEND/Manejadora.js ./FRONTEND/televisor.ts ./FRONTEND/producto.ts ./FRONTEND/manejadora.ts 
