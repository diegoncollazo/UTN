﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Banana : Fruta
    {
        protected string _paisOrigen;

        public Banana(string color, double peso, string pais) : base(color, peso)
        {
            this._paisOrigen = pais;
        }

        protected string Nombre
        {
            get
            {
                return "Banana";
            }
        }

        protected override bool TieneCarozo
        {
            get
            {
                return false;
            }
        }

        protected override string FrutaToString()
        {
            return base.FrutaToString() + " " + this.Nombre + " " + this.TieneCarozo;
        }
    }
}
