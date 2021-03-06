﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCarRental
{
    public class RespuestaAPI
    {
        public int totalElementos{ get; set; }
        public string error { get; set; }
        public List<Coche> data { get; set; }
        public List<Marca> dataMarca { get; set; }
        public List<TipoCombustible> dataCombu { get; set; }
    }
}