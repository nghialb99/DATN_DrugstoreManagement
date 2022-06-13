using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugstoreManagement.Utilities.Exceptions
{
    public class DrugstoreException : System.Exception
    {
        public DrugstoreException()
        {
        }

        public DrugstoreException(string message)
            : base(message)
        {
        }

        public DrugstoreException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
