///<reference path="ente.ts"/>

namespace Entidades 
{
    export class Alien extends Ente 
    {
        public raza: string;
        public planetaOrigen: string;
        public pathFoto: string;

        public constructor(cuadrante: string, edad: number, altura: number, raza: string, planeta: string, path: string) 
        {
            super(cuadrante, edad, altura);
            this.raza = raza;
            this.planetaOrigen = planeta;
            this.pathFoto = path;
        }

        public ToJSON(): any 
        {
            let retornoJson = `${super.ToString()}"raza":"${this.raza}","planetaOrigen":"${this.planetaOrigen}","pathFoto":"${this.pathFoto}"}`;
            return JSON.parse(retornoJson);
        }
    }
}