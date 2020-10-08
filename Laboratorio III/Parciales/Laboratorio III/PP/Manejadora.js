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
    var Ropa = /** @class */ (function () {
        //#endregion
        //#region Constructor
        function Ropa(codigo, nombre, precio) {
            this._codigo = codigo;
            this._nombre = nombre;
            this._precio = precio;
        }
        //#endregion
        //#region ToString
        Ropa.prototype.ropaToString = function () {
            return "{\"codigo\":\"" + this._codigo + "\",\"nombre\":\"" + this._nombre + "\",\"precio\":\"" + this._precio + "\",";
        };
        return Ropa;
    }());
    Entidades.Ropa = Ropa;
})(Entidades || (Entidades = {}));
var Entidades;
(function (Entidades) {
    var Campera = /** @class */ (function (_super) {
        __extends(Campera, _super);
        //#endregion
        //#region Constructor
        function Campera(codigo, nombre, precio, talle, color) {
            var _this = _super.call(this, codigo, nombre, precio) || this;
            _this._talle = talle;
            _this._color = color;
            return _this;
        }
        //#endregion
        //#region ToJson
        Campera.prototype.camperaToJson = function () {
            var retornoJson = _super.prototype.ropaToString.call(this) + "\"talle\":\"" + this._talle + "\",\"color\":\"" + this._color + "\"}";
            return JSON.parse(retornoJson);
        };
        return Campera;
    }(Entidades.Ropa));
    Entidades.Campera = Campera;
})(Entidades || (Entidades = {}));
///<reference path="../node_modules/@types/jquery/index.d.ts"/>
///<reference path="campera.ts"/>
//tsc --outfile Manejadora.js ./FRONTEND/ropa.ts ./FRONTEND/campera.ts ./FRONTEND/manejadora.ts
var Test;
(function (Test) {
    var Manejadora = /** @class */ (function () {
        function Manejadora() {
        }
        //#region AgregarCampera
        Manejadora.AgregarCampera = function () {
            //Tomo todos los datos por jQuery
            var codigo = parseInt($("#txtCodigo").val().toString());
            var nombre = ($("#txtNombre").val()).toString();
            var talle = parseInt($("#txtTalle").val().toString());
            var precio = parseFloat($("#txtPrecio").val().toString());
            var color = $("#cboColores").val().toString();
            var pagina = "./BACKEND/administrar.php";
            var campera = new Entidades.Campera(codigo, nombre, precio, talle, color); //Cargo los datos a una nueva campera
            var cadenaJson = JSON.stringify(campera.camperaToJson()); //Lo convierto a un objeto JSON
            var form = new FormData(); //Creo el form y configuro
            if ($("#hdnIdModificacion").val() == "activo") {
                form.append("caso", "modificar");
                form.append("cadenaJson", cadenaJson);
                $.ajax({
                    type: "POST",
                    url: pagina,
                    dataType: "json",
                    data: form,
                    cache: false,
                    contentType: false,
                    processData: false,
                    async: true
                })
                    .done(function (resultado) {
                    console.info("Todo Ok.");
                    Manejadora.MostrarCamperas();
                })
                    .fail(function () {
                    console.error("Se produjo un error.");
                });
            }
            else {
                form.append("caso", "agregar"); //switch de administrar
                form.append("cadenaJson", cadenaJson); // valor del post de administrar
                $.ajax //Realizo ajax
                ({
                    type: "POST",
                    url: pagina,
                    dataType: "json",
                    data: form,
                    cache: false,
                    contentType: false,
                    processData: false,
                    async: true //ASYC?
                })
                    .done(function (resultado) {
                    console.info("Todo Ok.");
                })
                    .fail(function () {
                    console.error("Se produjo un error");
                });
            }
        };
        //#endregion
        //#region MostrarCampera
        Manejadora.MostrarCamperas = function () {
            //Creo el form y configuro
            var form = new FormData();
            form.append("caso", "mostrar"); //swicht de administrar
            var pagina = "./BACKEND/administrar.php"; //url
            $.ajax({
                type: "POST",
                url: pagina,
                dataType: "json",
                data: form,
                cache: false,
                contentType: false,
                processData: false,
                async: true //ASYC?
            })
                .done(function (resultado) {
                var tabla = "";
                tabla += "<table border=1 style='width:100%' text-aling='center'> <thead>";
                tabla += "<tr>";
                tabla += "<th>Codigo</th>";
                tabla += "<th>Nombre</th>";
                tabla += "<th>Precio</th>";
                tabla += "<th>Talle</th>";
                tabla += "<th>Color</th>";
                tabla += "<th colspan='2'>Acciones</th>";
                tabla += "</tr> </thead>";
                var objJson = "";
                resultado.forEach(function (element) {
                    objJson = JSON.stringify(element);
                    tabla += "<tr>";
                    tabla += "<td> " + element.codigo + " </td>";
                    tabla += "<td> " + element.nombre + " </td>";
                    tabla += "<td> " + element.precio + " </td>";
                    tabla += "<td> " + element.talle + " </td>";
                    tabla += "<td> " + element.color + " </td>";
                    tabla += "<td><input type='button' onclick='new Test.Manejadora.EliminarCampera(" + objJson + ")' value='Eliminar'";
                    tabla += "<td><input type='button' onclick='new Test.Manejadora.ModificarCampera(" + objJson + ")' value='Modificar'</td>";
                    tabla += "<tr/>";
                });
                tabla += "<table/>";
                $("#divTabla").html(tabla); //se lo asigno a la tabala
            })
                .fail(function () {
                alert("error ajax");
            });
        };
        //#endregion
        //#region EliminarCampera
        Manejadora.EliminarCampera = function (objetoJson) {
            //Confirmo si quiere eliminar la campera 
            if (confirm("¿Desea eliminar la campera con codigo " + objetoJson.codigo + " y talle " + objetoJson.talle + "?")) {
                var pagina = "./BACKEND/administrar.php";
                var form = new FormData(); //form y configuro
                form.append('cadenaJson', JSON.stringify(objetoJson)); //Post de adminitrar
                form.append('caso', "eliminar"); //caso de php
                $.ajax({
                    type: "POST",
                    url: pagina,
                    dataType: "json",
                    data: form,
                    contentType: false,
                    processData: false,
                    async: true
                })
                    .done(function (resultado) {
                    console.info("Todo Ok.");
                    Manejadora.MostrarCamperas(); //Actualizo tabla
                })
                    .fail(function () {
                    console.error("Se produjo un error.");
                });
            }
            else {
                alert("Accion cancelada");
            }
        };
        //#endregion
        //#region ModificarCampera
        Manejadora.ModificarCampera = function (objJson) {
            //Obtengo los valores de la campera e invoco a agregar
            $("#txtCodigo").val(objJson.codigo);
            $("#txtCodigo").attr("readonly", "readonly");
            $("#txtNombre").val(objJson.nombre);
            $("#txtTalle").val(objJson.talle);
            $("#txtPrecio").val(objJson.precio);
            $("#cboColores").val(objJson.color);
            $("#btn-agregar").val("Modificar");
            $("#btn-agregar").attr("onclick", 'Test.Manejadora.AgregarCampera()');
            $("#hdnIdModificacion").val("activo");
        };
        //#endregion
        //#region FiltrarCamperasPorColor
        Manejadora.FiltrarCamperasPorColor = function () {
            //Creo el form y le asigno el caso
            var form = new FormData();
            form.append("caso", "mostrar"); //caso de adminitrar
            var pagina = "./BACKEND/administrar.php";
            var color = $("#cboColores").val(); //obtengo el valor
            $.ajax({
                type: "POST",
                url: pagina,
                dataType: "json",
                data: form,
                cache: false,
                contentType: false,
                processData: false,
                async: true
            })
                .done(function (resultado) {
                var tabla = "<table>";
                tabla += "<table border=1 style='width:100%' text-aling='center'> <thead>";
                tabla += "<tr>";
                tabla += "<th>Codigo</th>";
                tabla += "<th>Nombre</th>";
                tabla += "<th>Precio</th>";
                tabla += "<th>Talle</th>";
                tabla += "<th>Color</th>";
                tabla += "<th colspan='2'>Acciones</th>";
                tabla += "</tr> </thead>";
                var jsonString = "";
                resultado.forEach(function (element) {
                    if (color == element.color) {
                        jsonString = JSON.stringify(element);
                        tabla += "<tr>";
                        tabla += "<td> " + element.codigo + " </td>";
                        tabla += "<td> " + element.nombre + " </td>";
                        tabla += "<td> " + element.precio + " </td>";
                        tabla += "<td> " + element.talle + " </td>";
                        tabla += "<td> " + element.color + " </td>";
                    }
                });
                tabla += "<table/>";
                $("#divTabla").html(tabla); //Se lo asigno a la tabla
            })
                .fail(function () {
                console.error("Se produjo un error.");
            });
        };
        return Manejadora;
    }());
    Test.Manejadora = Manejadora;
})(Test || (Test = {}));
