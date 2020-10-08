namespace Entidades
{
    export class Ropa
    {
        //#region Atributos
        public _codigo : number;
        public _nombre : string;
        public _precio : number;
        //#endregion

        //#region Constructor
        public constructor (codigo : number, nombre : string, precio : number)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._precio = precio;
        }
        //#endregion

        //#region ToString
        public ropaToString():string
        {
            return `{"codigo":"${this._codigo}","nombre":"${this._nombre}","precio":"${this._precio}",`;
        } 
        //#endregion
    }
}