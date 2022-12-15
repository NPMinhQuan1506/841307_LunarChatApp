using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Server.DAO
{
    class ConnectDatabase
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "GVWjpxRtSCP44fGbXTx8ZRWgWpbnUzvhiWaCHKLi",
            BasePath = "https://lunarchatapp-53568-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient Client;

        public ConnectDatabase()
        {
            Client = new FireSharp.FirebaseClient(config);
            if (Client != null)
            {
                Console.WriteLine("Connected Successfully");
            }
            else
            {
                Console.WriteLine("Error Connected! Please check your internet!");
            }
        }

        private static ConnectDatabase instance;
        public static ConnectDatabase Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConnectDatabase();
                return instance;
            }
        }

        public IFirebaseClient getClient()
        {
            return this.Client;
        }
    }
}
