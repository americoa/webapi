using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabAspWebApi.Controllers
{
    public class ClientController : ApiController
    {
        [HttpPost]//POST - CREATE               
        public HttpResponseMessage Criar(ViewModel.MVClient postclient)
        {
            try
            {
                using (var cn = new DataModel.ClientControlEntities())
                {
                    DataModel.Client dbclient = new DataModel.Client();
                    dbclient.FirstName = postclient.FirstName;
                    dbclient.LastName = postclient.LastName;
                    dbclient.DateBirth = postclient.DateBirth;
                    dbclient.State = postclient.State;
                    dbclient.City = postclient.City;
                    dbclient.Zip = postclient.Zip;
                    dbclient.Country = postclient.Country;
                    dbclient.Phone = postclient.Phone;
                    dbclient.Email = postclient.Email;

                    cn.Client.Add(dbclient);
                    cn.SaveChanges();
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet] //GET- RETRIEVE
        public IEnumerable<ViewModel.MVClient> Listar()
        {
            using (var cn = new DataModel.ClientControlEntities())
            {
                return cn.Client
                   .ToList()
                   .ConvertAll<ViewModel.MVClient>(x =>
                   {
                       return new ViewModel.MVClient
                       {
                           ClientID = x.ClientID,
                           FirstName = x.FirstName,
                           LastName = x.LastName,
                           DateBirth = x.DateBirth,
                           State = x.State,
                           City = x.City,
                           Zip = x.Zip,
                           Country = x.Country,
                           Phone = x.Phone,
                           Email = x.Email
                       };
                   });
            }
        }

        [HttpPut]//PUT - UPDATE
        public HttpResponseMessage Atualizar(ViewModel.MVClient putclient)
        {
            try
            {
                using (var cn = new DataModel.ClientControlEntities())
                {

                    DataModel.Client dbclient = cn.Client.Where(x => x.ClientID.Equals(putclient.ClientID)).Single();

                    dbclient.FirstName = putclient.FirstName;
                    dbclient.LastName = putclient.LastName;
                    dbclient.DateBirth = putclient.DateBirth;
                    dbclient.State = putclient.State;
                    dbclient.City = putclient.City;
                    dbclient.Zip = putclient.Zip;
                    dbclient.Country = putclient.Country;
                    dbclient.Phone = putclient.Phone;
                    dbclient.Email = putclient.Email;

                    cn.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]//DELETE-DELETE         
        public HttpResponseMessage Deletar(ViewModel.MVClient delclient)
        {
            try
            {
                using (var cn = new DataModel.ClientControlEntities())
                {

                    DataModel.Client dbclient = cn.Client.Where(x => x.ClientID.Equals(delclient.ClientID)).Single();
                    cn.Client.Remove(dbclient);
                    cn.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
