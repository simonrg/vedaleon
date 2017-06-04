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
        string file = AppDomain.CurrentDomain.BaseDirectory + "pnl.txt";

        //constructor
        public PassengerController()
        {
            //read from file
            using (StreamReader sr = File.OpenText(file))
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

        // GET api/passenger
        public IEnumerable<Passengers> GetAllRecords()
        {
            return p;
        }

        // GET api/passenger?idx=
        public Passengers GetRecord(int idx)
        {
            return p.ElementAt(idx);
        }

        // POST
        public void Post(Passengers item)
        {
            //write to file
            using (StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine("\n" + item.Id);
            }

            //add to Passengers list
            p.Add(item);
        }
    }
}
