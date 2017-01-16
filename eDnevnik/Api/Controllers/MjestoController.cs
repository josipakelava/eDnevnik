﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Models
{
    public class MjestoController : ApiController
    {
        public List<Osoba> Get()
        {
            eDnevnik context = new eDnevnik();

            List<Osoba> osoba = context.Osoba.ToList();

            return osoba;
        }
    }
}
