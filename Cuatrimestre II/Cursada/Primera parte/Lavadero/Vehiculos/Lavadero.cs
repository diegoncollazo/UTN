using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehiculos
{
    public class Lavadero
    {
        private List<Vehiculo> _vehiculos;
        private float _precioAuto;
        private float _precioMoto;
        private float _precioCamion;
        //Constructores
        //Con parametros
        public Lavadero(float precioAuto, float precioMoto, float precioCamion) : this()
        {
            this._precioAuto = precioAuto;
            this._precioCamion = precioCamion;
            this._precioMoto = precioMoto;
        }
        //Por default
        private Lavadero()
        {
            this._vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Informacion completa del lavadero [Precios y Vehiculos]
        /// </summary>
        public string MiLavadero
        {
            get
            {
                string retorno = "";
                retorno += "Precio auto: $ " + this._precioAuto.ToString() + " / Precio camion: $ " + this._precioCamion.ToString() + " / Precio moto: $ " + this._precioMoto.ToString() + "\n\n";
                foreach (Vehiculo vehiculo in this._Vehiculos)
                {
                    if (vehiculo is Auto)
                    {
                        retorno += (Auto)vehiculo + "\n";
                    }
                    else if (vehiculo is Camion)
                    {
                        retorno += (Camion)vehiculo + "\n";
                    }
                    else if (vehiculo is Moto)
                    {
                        retorno += (Moto)vehiculo + "\n";
                    }
                }
                return retorno;
            }
        }
        public List<Vehiculo> _Vehiculos {
            get
            {//Información completa del lavadero
                return this._vehiculos;
            }
        }
        /// <summary>
        /// Sobrecarga [==]
        /// Verifica si el vehiculo se encuentra en el lavadero
        /// </summary>
        /// <param name="lavadero"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static bool operator ==(Lavadero lavadero, Vehiculo vehiculo)
        {
            bool retorno = false;
            foreach(Vehiculo item in lavadero._vehiculos)
            {
                if (item == vehiculo)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga [!=]
        /// Verifica si el vehiculo no se encuentra en el lavadero
        /// </summary>
        /// <param name="lavadero"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static bool operator !=(Lavadero lavadero, Vehiculo vehiculo)
        {
            return !(lavadero == vehiculo);
        }
        /// <summary>
        /// Sobrecarga [+]
        /// Agrega un vehiculo al lavadero, previa verificacion.
        /// </summary>
        /// <param name="lavadero"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static Lavadero operator +(Lavadero lavadero, Vehiculo vehiculo)
        {
            if (lavadero != vehiculo)
            {
                lavadero._vehiculos.Add(vehiculo);
            }
            return lavadero;
        }
        /// <summary>
        /// Sobrecarga [-]
        /// Quita un vehiculo al lavadero, previa verificacion.
        /// </summary>
        /// <param name="lavadero"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static Lavadero operator -(Lavadero lavadero, Vehiculo vehiculo)
        {
            if (lavadero == vehiculo)
            {
                lavadero._vehiculos.Remove(vehiculo);
            }
            return lavadero;
        }
        /// <summary>
        /// Facturacion total del lavadero.
        /// </summary>
        /// <returns></returns>
        public double MostrarTotalFacturado()
        {
            double facturado = 0;
            foreach (Vehiculo vehiculo in this._Vehiculos)
            {
                if (vehiculo is Auto)
                    facturado += (double) this._precioAuto;
                else if (vehiculo is Camion)
                    facturado += this._precioCamion;
                else if (vehiculo is Moto)
                    facturado += this._precioMoto;
            }
            return facturado;
        }
        /// <summary>
        /// Facturacion parcial tomando parametros EVehiculos.
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        public double MostrarTotalFacturado(EVehiculos marca)
        {
            double facturado = 0;
            foreach (Vehiculo vehiculo in this._Vehiculos)
            {
                if (vehiculo is Auto && marca == EVehiculos.Auto)
                    facturado += (double)this._precioAuto;
                else if (vehiculo is Camion && marca == EVehiculos.Camion)
                    facturado += this._precioCamion;
                else if (vehiculo is Moto && marca == EVehiculos.Moto)
                    facturado += this._precioMoto;
            }
            return facturado;
        }
        /// <summary>
        /// Metodo de ordenamiento por Patente
        /// </summary>
        /// <param name="vehiculo1"></param>
        /// <param name="vehiculo2"></param>
        /// <returns></returns>
        public static int OrdenarVehiculosPorPatente(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return string.Compare(vehiculo1.GetPatente, vehiculo2.GetPatente);
        }
        /// <summary>
        /// Metodo de ordenamiento por Marca
        /// </summary>
        /// <param name="vehiculo1"></param>
        /// <param name="vehiculo2"></param>
        /// <returns></returns>
        public static int OrdenarVehiculosPorMarca(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return string.Compare(vehiculo1.GetMarca.ToString(), vehiculo2.GetMarca.ToString());
        }
    }
}
