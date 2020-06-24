using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ENTIDADES.SP
{
    public  class Manzana : Fruta, ISerializar, IDeserializar
    {
        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop.s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true

        protected string _provinciaOrigen;

        public Manzana(string color, double peso, string provincia):base(color, peso)
        {
            this._provinciaOrigen = provincia;
        }

        protected string Nombre
        {
            get
            {
                return "Manzana";
            }
        }

        protected override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public bool Xml(string archivo)
        {
            bool retorno = false;

            try
            {
                XmlSerializer aux = new XmlSerializer(typeof(Manzana));
                StreamWriter auxArchivo = new StreamWriter(archivo);
                aux.Serialize(auxArchivo, this);
                auxArchivo.Close();
                retorno = true;

            }
            catch 
            {
               
            }



            return retorno;
        }

        //public bool Leer(string archivo, out T datos)
        //{
        //    bool retorno = false;

        //    try
        //    {
        //        XmlSerializer aux = new XmlSerializer(typeof(T));
        //        StreamReader auxArchivo = new StreamReader(archivo);
        //        datos = (T)aux.Deserialize(auxArchivo);
        //        auxArchivo.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new ArchivosException(e);
        //    }

        //    retorno = true;

        //    return retorno;
        //}

        bool IDeserializar.Xml(string archivo, out Fruta fruta)
        {

            try
            {
                XmlSerializer aux = new XmlSerializer(typeof(Fruta));
                StreamReader auxArchivo = new StreamReader(archivo);
                fruta = (Fruta)aux.Deserialize(auxArchivo);
                auxArchivo.Close();
                return true;
            }
            catch 
            {
                fruta = null;
            }

            return false;
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString() + " " +this.Nombre + " " + this.TieneCarozo;
        }

       
    }
}
