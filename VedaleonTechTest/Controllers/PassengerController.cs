using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VedaleonTechTest.Models;

namespace VedaleonTechTest.Controllers
{
    public class PassengerController : ApiController
    {
        List<Passengers> p = new List<Passengers>();

        //constructor
        public PassengerController()
        {
            //read from file
            using (StreamReader sr = File.OpenText("C:\\Users\\Simon\\Dropbox\\VedaleonTechTest\\pnl.txt"))
            {
                string s = String.Empty;

                while ((s = sr.ReadLine()) != null)
                {
                    //ignore records w/out passenger
                    if (s.Contains(".R/"))
                        continue;

                    //initialise passengers instance field with string from file
                    p.Add(new Passengers { Id = s });
                }
            }
        } 

        // GET api/passengers
        public IEnumerable<Passengers> GetAllPassengers()
        {
            return p;
        }

        // GET api/passengers?idx=2
        public Passengers GetRecord(int idx)
        {
            return p.ElementAt(idx);
        }
    }
}
