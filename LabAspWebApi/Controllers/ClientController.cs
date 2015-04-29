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
        public HttpResponseMessage Criar(ViewModel.MVClient data)
        {
            try
            {
                using (var cn = new DataModel.ClientControlEntities())
                {
                    DataModel.Client dbclient = new DataModel.Client();
                    dbclient.FirstName = data.FirstName;
                    dbclient.LastName = data.LastName;
                    dbclient.DateBirth = data.DateBirth;
                    dbclient.State = data.State;
                    dbclient.City = data.City;
                    dbclient.Zip = data.Zip;
                    dbclient.Country = data.Country;
                    dbclient.Phone = data.Phone;
                    dbclient.Email = data.Email;

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
        public HttpResponseMessage Atualizar(ViewModel.MVClient data)
        {
            try
            {
                using (var cn = new DataModel.ClientControlEntities())
                {

                    DataModel.Client dbclient = cn.Client.Where(x => x.ClientID.Equals(data.ClientID)).Single();

                    dbclient.FirstName = data.FirstName;
                    dbclient.LastName = data.LastName;
                    dbclient.DateBirth = data.DateBirth;
                    dbclient.State = data.State;
                    dbclient.City = data.City;
                    dbclient.Zip = data.Zip;
                    dbclient.Country = data.Country;
                    dbclient.Phone = data.Phone;
                    dbclient.Email = data.Email;

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
        public HttpResponseMessage Deletar(ViewModel.MVClient data)
        {
            try
            {
                using (var cn = new DataModel.ClientControlEntities())
                {

                    DataModel.Client dbclient = cn.Client.Where(x => x.ClientID.Equals(data.ClientID)).Single();
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
