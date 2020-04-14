using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Alumnos
{
  public class MiClase : Entidades.Externa.PersonaExterna
  {
    public MiClase(string nombre, string apellido, int edad, Entidades.Externa.ESexo sexo) : base(nombre, apellido, edad, sexo)
    {

    }

    public string Nombre
    {
      get
      {
        return this._nombre;
      }
      set
      {
        this._nombre = value;
      }
    }
    public string Apellido
    {
      get
      {
        return this._apellido;
      }
      set
      {
        this._apellido = value;
      }
    }
    public int Edad
    {
      get
      {
        return this._edad;
      }
      set
      {
        this._edad = value;
      }
    }

    public Entidades.Externa.ESexo Sexo
    {
      get
      {
        return this._sexo;
      }
      set { this._sexo = value; }
    }
  }
}
