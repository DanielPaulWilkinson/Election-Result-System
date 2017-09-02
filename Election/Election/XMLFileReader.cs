using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Election
{

    /// <summary>
    /// This class reads the xml data from the file, queries it and passes the information to the 
    /// reports to be queried again for the user interface.
    /// </summary>
    public class XMLFileReader : IElectionReader
    {
        /// <summary>
        /// this method reads the data from file
        /// </summary>
        /// <param name="configRecord"></param>
        /// <returns></returns>
        public Constituency ReadTheElectionDataFromFile(ConfigRecord configRecord)
        {
            try {
                //If the file does not exist
                if (!File.Exists(configRecord.Filename))
                {
                    //then stop here and return a null value
                    return null;
                }



                //however if it does, continue get  the configrecord filename and
                //load all the information in to the memory
                XDocument xmlDoc = XDocument.Load(configRecord.Filename);
                //get and create the first constituency
                var ConstituencyName = (from c in xmlDoc.Descendants("Constituency")
                                        select c.Attribute("name").Value).First();
                Constituency Constituency = new Constituency(ConstituencyName);
                //create a report for a contituency
                Constituency.ReportConstituencyCandidates = new ConstituencyReport("Constituency");
                //select all the candidates using a helper method to get them with LINQ
                Constituency.ReportConstituencyCandidates.AllCandidates = SelectAllCandidates(xmlDoc);
                return Constituency;
            }
            catch
            {
                return null;
                //do nothing i.e skip the file if corupt.
            }
        }
       /// <summary>
       /// this method  is used to find all the candidates
       /// </summary>
       /// <param name="xmlDoc"></param>
       /// <returns>A list of candidates</returns>
        private List<Candidate> SelectAllCandidates(XDocument xmlDoc)
        {
            //save this query in this variable from the document where the decendenets are from candidate
            var QuearyCadidate = from can in xmlDoc.Descendants("Candidate")
                                 //create a new xandidate form this
                                 select new Candidate(can.Attribute("party").Value,//get the value of the party nodes
                                                       can.Element("Firstname").Value,//get the value of the
                                                       can.Element("Lastname").Value,//name nodes
                                                       (int)can.Element("Votes"));// get the vote and cast them as int 
            return QuearyCadidate.ToList();
        }
    }
}

