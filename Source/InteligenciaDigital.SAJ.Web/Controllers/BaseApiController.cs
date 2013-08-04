using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InteligenciaDigital.SAJ.Service.Interfaces;

namespace InteligenciaDigital.SAJ.Web.Controllers
{
    public abstract class BaseApiController<T> : ApiController
    {
        protected readonly IService<T> Service;

        protected BaseApiController(IService<T> service)
        {
            Service = service;
        }

        // GET api/servidortef
        public IEnumerable<T> Get()
        {
            var lista = Service.GetAll();
            return lista.ToList();
        }

        // GET api/servidortef/5
        public T Get(int id)
        {
            return Service.GetById(id);
        }

        // POST api/servidortef
        public HttpResponseMessage Post([FromBody]T value)
        {
            var result = Service.SaveOrUpdate(value);
            if (result.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, value);
            }

            var lista = result.Errors.Select(x => x.ErrorMessage);

            return Request.CreateResponse(HttpStatusCode.BadRequest, lista);
        }

        // PUT api/servidortef/5
        public HttpResponseMessage Put(int id, [FromBody]T value)
        {
            var result = Service.SaveOrUpdate(value);
            if (result.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.OK, value);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, result);
        }

        // DELETE api/servidortef/5
        public HttpResponseMessage Delete(int id)
        {
            var entidade = Service.GetById(id);

            if (entidade == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Service.Delete(entidade);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
