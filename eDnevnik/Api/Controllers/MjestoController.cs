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
            eDnevnikEntities context = new eDnevnikEntities();

            List<Osoba> osobe = context.Osoba.ToList();

            return osobe;
        }
    }
}
