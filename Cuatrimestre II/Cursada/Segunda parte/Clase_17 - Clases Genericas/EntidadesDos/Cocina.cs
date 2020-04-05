using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace EntidadesDos
{
    public class Cocina
    {
    private int _codigo;
    private bool _esIndustrial;
    private double _precio;

    public int Codigo
    {
      get
      {
        return this._codigo;
      }

    }
    public bool EsIndustrial
    {
      get
      {
        return this._esIndustrial;
      }
    }
    public double Precio
    {
      get
      {
        return this._precio;
      }
    }

    public Cocina(int codigo, double precio, bool esIndustrial)
    {
      this._codigo = codigo;
      this._esIndustrial = esIndustrial;
      this._precio = precio;
    }

    public static bool operator ==(Cocina a, Cocina b)
    {
      bool retorno = false;
      if (a.Codigo == b.Codigo)
      {
        retorno = true;
      }
      return retorno;
    }

    public static bool operator !=(Cocina a, Cocina b)
    {
      return !(a == b);
    }

    public override bool Equals(Object obj)
    {
      bool retorno = false;
      if (obj is Cocina)
      {
        if ((Cocina)obj == this)
        {
          retorno = true;
        }
      }

      return retorno;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("Codigo: {0} ", this.Codigo);
      sb.AppendFormat("Industrial: {0} ", this.EsIndustrial);
      sb.AppendFormat("Precio: {0}\n", this.Precio);

      return sb.ToString();
    }

  }
}
