using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InteligenciaDigital.SAJ.Domain.Entidades;
using InteligenciaDigital.SAJ.Domain.Validations;
using InteligenciaDigital.SAJ.Service;
using InteligenciaDigital.SAJ.Web.Models;

namespace InteligenciaDigital.SAJ.Web.Controllers
{
    public class ServidorTEFController : BaseApiController<ServidorTEF>
    {
        public ServidorTEFController(IServidorTEFService servidorTEFService) : base(servidorTEFService)
        {
        }
    }
}
