using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesDos
{
  public class DepositoDeCocinas
  {
    private int _capacidadMaxima;
    private List<Cocina> _lista;

    public DepositoDeCocinas(int capacidadMaxima)
    {
      this._lista = new List<Cocina>();
      this._capacidadMaxima = capacidadMaxima;
    }


    public static bool operator +(DepositoDeCocinas d, Cocina a)
    {
      bool retorno = false;
      //if (d._lista.Count < d._capacidadMaxima)
      //{
      foreach (Cocina aux in d._lista)
      {
        if (aux == a)
        {
          retorno = false;
        }

      }

      if (d._lista.Count < d._capacidadMaxima)
      {
        d._lista.Add(a);
        retorno = true; //Fijarme bien
      }

      return retorno;
    }

    private int GetIndice(Cocina a)
    {
      int indice = -1; //Declaramos una variable indice que devuelve -1 si no funciona
      int i = -1;

      foreach (Cocina t in this._lista) //Recorremos todas las temperas y tomamos el valor en t
      {
        //i++;  //Se va incrementando
        if (object.Equals(t, a)) //Comprobamos que parte del vector es null 
        {
          indice = i;//Si es true, nos devolvera el indice que se encontro
          break; //Si no le pongo el break seguira iterando
        }
        i++;
      }

      return indice;

    }

    public static bool operator -(DepositoDeCocinas d, Cocina a)
    {
      int aux = d.GetIndice(a);
      // aux = d.GetIndice(a);
      if (aux != -1)
      {
        d._lista.RemoveAt(aux);//Remuevo basandome en el item
                               //d._lista.Remove(a);
        return true;
      }

      return false;
    }

    public bool Agregar(Cocina a)
    {
      bool retorno = false;
      if (this + a)
      {
        //this._lista.Add(a);
        retorno = true;
      }
      else
      {
        retorno = false;
      }

      return retorno;
    }

    public bool Remover(Cocina a)
    {
      bool retorno = false;
      if (this - a)
      {
        //this._lista.Remove(a);
        retorno = true;
      }
      else
      {
        retorno = false;
      }

      return retorno;
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "Capacidad maxima: " + this._capacidadMaxima + "\nListado de Cocinas: \n";

      foreach (Cocina au in this._lista)
      {
        retorno += au + "\n";
      }

      return retorno;
    }

  }
}
