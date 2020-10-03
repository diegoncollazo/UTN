namespace Entidades
{
    export class Campera extends Ropa
    {
        //#region  Atributos
        public _talle : number;
        public _color : string;
        //#endregion

        //#region Constructor
        public constructor(codigo:number,nombre:string,precio:number,talle:number,color:string)
        {
            super(codigo,nombre,precio);
            this._talle = talle;
            this._color = color;
        }
        //#endregion

        //#region ToJson
        public camperaToJson():JSON
        {
            let retornoJson = `${super.ropaToString()}"talle":"${this._talle}","color":"${this._color}"}`;
            return JSON.parse(retornoJson);
        }
        //#endregion
    } 
}