using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAO
{
    public class PackageModule
    {

            private string kind;
            private string content;

            public PackageModule(string kind, string content)
            {
                this.kind = kind;
                this.content = content;
            }

            public string Kind { get => kind; set => kind = value; }
            public string Content { get => content; set => content = value; }

    }

    public class Response
    {
        private string content;

        public Response(string content)
        {
            this.content = content;
        }

        public string Content { get => content; set => content = value; }
    }
}
