///<reference path="../node_modules/@types/jquery/index.d.ts"/>
///<reference path="campera.ts"/>
//tsc --outfile Manejadora.js ./FRONTEND/ropa.ts ./FRONTEND/campera.ts ./FRONTEND/manejadora.ts

namespace Test
{
    export class Manejadora
    {
        //#region AgregarCampera
        public static AgregarCampera() : void
        {
            //Tomo todos los datos por jQuery
            let codigo=parseInt($("#txtCodigo").val().toString());
            let nombre=($("#txtNombre").val()).toString();
            let talle=parseInt($("#txtTalle").val().toString());
            let precio=parseFloat($("#txtPrecio").val().toString());
            let color=$("#cboColores").val().toString();
            let pagina="./BACKEND/administrar.php";
            
            let campera = new Entidades.Campera(codigo, nombre, precio, talle, color); //Cargo los datos a una nueva campera
            let cadenaJson=JSON.stringify(campera.camperaToJson()); //Lo convierto a un objeto JSON
            
            let form =new FormData();//Creo el form y configuro

            if($("#hdnIdModificacion").val() == "activo")
            {
                form.append("caso","modificar");
                form.append("cadenaJson",cadenaJson);
                    
                $.ajax({
                    type : "POST",
                    url : pagina,
                    dataType : "json",
                    data: form,
                    cache: false,
                    contentType: false,
                    processData: false,
                    async:true
                })
                .done(function(resultado)
                {
                    console.info("Todo Ok.");
                    Manejadora.MostrarCamperas();
                })
                .fail(function()
                {
                    console.error("Se produjo un error.");
                })   
            }

            else
            {
                form.append("caso","agregar"); //switch de administrar
                form.append("cadenaJson",cadenaJson); // valor del post de administrar
                
                $.ajax //Realizo ajax
                ({
                    type : "POST", //METODO
                    url : pagina, //URL
                    dataType : "json", //TIPO
                    data: form, //ENVIO
                    cache: false,
                    contentType: false,
                    processData: false,
                    async:true //ASYC?
                })
                .done(function(resultado) //Si todo salio bien muestro por pantalla y agrego
                {
                    console.info("Todo Ok.");
                })
                .fail(function() //De lo contrario tiro error
                {
                    console.error("Se produjo un error");
                });
            }
        }
        //#endregion
    
        //#region MostrarCampera
        public static MostrarCamperas() : void
        {
            //Creo el form y configuro
            let form =new FormData();
            form.append("caso","mostrar"); //swicht de administrar
            let pagina="./BACKEND/administrar.php"; //url

            $.ajax
            ({
                type : "POST", //METODO
                url : pagina, //URL
                dataType : "json", //TIPO
                data: form, //ENVIO
                cache: false,
                contentType: false,
                processData: false,
                async:true //ASYC?
            })
            .done(function(resultado)//Si todo salio bien creo la tabla
            {
                let tabla: string = "";
                    tabla += "<table border=1 style='width:100%' text-aling='center'> <thead>";
                    tabla += "<tr>";
                    tabla += "<th>Codigo</th>";
                    tabla += "<th>Nombre</th>";
                    tabla += "<th>Precio</th>";
                    tabla += "<th>Talle</th>";
                    tabla += "<th>Color</th>";
                    tabla += "<th colspan='2'>Acciones</th>";
                    tabla += "</tr> </thead>";
                let objJson:string="";

                resultado.forEach(element => //Recorro para elemento y lo cargo con sus respectivos valores
                {
                    objJson=JSON.stringify(element);
                    tabla+="<tr>";
                    tabla+="<td> "+ element.codigo +" </td>";
                    tabla+="<td> "+ element.nombre +" </td>";
                    tabla+="<td> "+ element.precio +" </td>";
                    tabla+="<td> "+ element.talle +" </td>";
                    tabla+="<td> "+ element.color +" </td>";
                    tabla += "<td><input type='button' onclick='new Test.Manejadora.EliminarCampera(" + objJson + ")' value='Eliminar'";
                    tabla += "<td><input type='button' onclick='new Test.Manejadora.ModificarCampera(" + objJson + ")' value='Modificar'</td>";              
                    tabla+="<tr/>";                    
                })
                tabla+="<table/>";

                $("#divTabla").html(tabla); //se lo asigno a la tabala
            })
            .fail(function()
            {
                alert("error ajax");
            });
        }
        //#endregion
    
        //#region EliminarCampera
        public static EliminarCampera(objetoJson: any) :void
        {
            //Confirmo si quiere eliminar la campera 
            if (confirm("¿Desea eliminar la campera con codigo " + objetoJson.codigo + " y talle " + objetoJson.talle + "?")) 
            {
                let pagina = "./BACKEND/administrar.php";
                let form: FormData = new FormData();//form y configuro

                form.append('cadenaJson', JSON.stringify(objetoJson)); //Post de adminitrar
                form.append('caso', "eliminar"); //caso de php

                $.ajax
                ({
                    type: "POST",
                    url: pagina,
                    dataType: "json",
                    data: form,
                    contentType: false,
                    processData: false,
                    async: true
                })
                .done(function(resultado)
                {
                    console.info("Todo Ok.");
                    Manejadora.MostrarCamperas(); //Actualizo tabla
                })
                .fail(function()
                {
                    console.error("Se produjo un error.");
                })
            } 
            
            else 
            {
                alert("Accion cancelada");
            }
        }
        //#endregion

        //#region ModificarCampera
        public static ModificarCampera(objJson : any) : void
        {
            //Obtengo los valores de la campera e invoco a agregar
            $("#txtCodigo").val(objJson.codigo);
            $("#txtCodigo").attr("readonly","readonly");
            $("#txtNombre").val(objJson.nombre);
            $("#txtTalle").val(objJson.talle);
            $("#txtPrecio").val(objJson.precio);
            $("#cboColores").val(objJson.color);
            $("#btn-agregar").val("Modificar");
            $("#btn-agregar").attr("onclick",'Test.Manejadora.AgregarCampera()');
            $("#hdnIdModificacion").val("activo");
        }
        //#endregion

        //#region FiltrarCamperasPorColor
        public static FiltrarCamperasPorColor() : void
        {
            //Creo el form y le asigno el caso
            let form =new FormData();
            form.append("caso","mostrar"); //caso de adminitrar
            let pagina="./BACKEND/administrar.php";
            let color= $("#cboColores").val(); //obtengo el valor

            $.ajax
            ({
                type : "POST", //metodo
                url : pagina, //url
                dataType : "json", //tipo
                data: form, 
                cache: false,
                contentType: false,
                processData: false,
                async:true
            })
            .done(function(resultado)
            {
                let tabla="<table>";
                    tabla += "<table border=1 style='width:100%' text-aling='center'> <thead>";
                    tabla += "<tr>";
                    tabla += "<th>Codigo</th>";
                    tabla += "<th>Nombre</th>";
                    tabla += "<th>Precio</th>";
                    tabla += "<th>Talle</th>";
                    tabla += "<th>Color</th>";
                    tabla += "</tr> </thead>";
                let jsonString:string="";
                resultado.forEach(element => 
                {
                    if(color == element.color)
                    {
                        jsonString=JSON.stringify(element);
                        tabla+="<tr>";
                        tabla+="<td> "+ element.codigo +" </td>";
                        tabla+="<td> "+ element.nombre +" </td>";
                        tabla+="<td> "+ element.precio +" </td>";
                        tabla+="<td> "+ element.talle +" </td>";
                        tabla+="<td> "+ element.color +" </td>";                   
                    }
                    
                })

                tabla+="<table/>";
                $("#divTabla").html(tabla); //Se lo asigno a la tabla
            })
            .fail(function()
            {
                console.error("Se produjo un error.")
            });
        }
        //#endregion

        //#region CargarColoresJSON
        public static CargarColoresJSON() : void
        {
            //Creo el form y le asigno el caso
            let form =new FormData();
            form.append("caso","colores"); //caso de adminitrar
            let pagina="./BACKEND/administrar.php";
        }
        //#endregion
    }
}