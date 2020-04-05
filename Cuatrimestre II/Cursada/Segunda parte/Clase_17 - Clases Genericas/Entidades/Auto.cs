using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Auto
  {
    private string _color;
    private string _marca;

    public string Color
    {
      get { return this._color; }
    }

    public string Marca
    {
      get { return this._marca; }
    }

    public Auto(string color, string marca)
    {
      this._color = color;
      this._marca = marca;
    }

    public static bool operator ==(Auto a, Auto b)
    {
      if(a.Color == b.Color && a.Marca == b.Marca)
      {
        return true;
      }

      return false;
    }

    public static bool operator !=(Auto a, Auto b)
    {
      return !(a == b);
    }

    public override bool Equals(object obj)
    {
      bool retorno = false;
      if(obj is Auto)
      {
        if ((Auto)obj == this)
        {
          retorno = true;
        }
        else
        {
          retorno = false;
        }
      }

      return retorno;
    }

    public override string ToString()
    {
      string retorno = "";

      retorno += "Marca: " + this.Marca + " - Color: " + this.Color;  
      return retorno;
      //return base.ToString();
    }

  }
}
