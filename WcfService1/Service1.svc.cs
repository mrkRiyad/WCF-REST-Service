using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.Models;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private Library db = new Library();
        public int Delete(string id)
        {
            int bid = Convert.ToInt32(id);
            db.Books.Remove(db.Books.Find(bid));
            return db.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books.ToList();
        }

        public Book GetById(string id)
        {
            int bid = Convert.ToInt32(id);
            return db.Books.Find(bid);
        }

        public int Save(Book book)
        {
            db.Books.Add(book);
            return db.SaveChanges();
        }

        public int Update(Book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
