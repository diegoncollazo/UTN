using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_55
{
    public class Local : Llamada, IGuardar<Local>
    {
        //Atributos
        protected float costo;
        //Propiedades
        public float Costo
        {
            get
            {
                return this.costo;
            }
        }
        public override float CostoLlamada
        {
            get
            {
                return CalcularCosto();
            }
        }

        public string RutaDeArchivo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //Constructores
        public Local(Llamada llamada, float costo) 
            : this(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen, costo)
        {
            
        }
        public Local(float duracion, string destino, string origen, float costo) 
            : base(duracion, destino, origen)
        {
            this.costo = costo;
        }
        //Metodos
        protected override string Mostrar()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("*** Llamada local ***\n");
            retorno.Append(base.Mostrar());
            retorno.AppendFormat("Costo:                        {0}\n", this.Costo);
            retorno.AppendFormat("Costo de la llamada:          {0}\n", this.CostoLlamada);

            return retorno.ToString();
        }
        public override string ToString()
        {
            return Mostrar();
        }
        public override bool Equals(object objeto)
        {
            return objeto is Local;
        }
        private float CalcularCosto()
        {
            return this.costo * this.duracion;
        }

        public bool Guardar(Local obj)
        {
            throw new NotImplementedException();
        }

        public Local Leer()
        {
            throw new NotImplementedException();
        }


    }
}
