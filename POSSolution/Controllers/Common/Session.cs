using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSSolution.Controllers.Common
{
    class Session
    {

        private int id;
        private string name, type;

        private static Session session;

        public static Session Instance
        {
            set
            {
                session = value;
            }
            get
            {
                if (session == null)
                    session = new Session();

                return session;
            }
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
    }
}
