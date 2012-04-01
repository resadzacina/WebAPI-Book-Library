using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Txtr.Platform.Data.Core.Dependency;
using Txtr.Platform.Data.DomainModel.Model;
using Txtr.Platform.Data.DomainModel.Services;

namespace Txtr.Platform.Data.WebService.Web.Controllers
{
    public class BooksController : ApiController, IController
    {
        private IBookService service;

        public BooksController()
        {
            this.service = IoC.Resolve<IBookService>();
        }

        // GET /api/books
        public IQueryable<Book> Get()
        {
            return service.FindAll().AsQueryable();
        }

        // GET /api/books/5
        public Book Get( int id )
        {
            return service.FindByID( id );
        }

        // POST /api/books
        public void Post( Book value )
        {
            service.Add( value );
        }

        // PUT /api/books/5
        public void Put( int id, Book value )
        {
            service.Update( value );
        }

        // DELETE /api/books/5
        //public void Delete( int id )
        //{
        //    service.Delete( id );
        //}

        public void Execute( System.Web.Routing.RequestContext requestContext )
        {
        }
    }
}
