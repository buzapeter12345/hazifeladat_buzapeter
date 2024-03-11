using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vizsgagyakKonyvesWinform
{
    internal class Book
    {
        public int id;
        public string kategoria;
        public string cim;
        public int ar;
        public int db;

        public Book(string id, string kategoria, string cim, string ar, string db)
        {
            this.id = int.Parse(id);
            this.kategoria = kategoria;
            this.cim = cim;
            this.ar = int.Parse(ar);
            this.db = int.Parse(db);
        }
    }
}
