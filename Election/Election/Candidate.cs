using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public class Candidate
    {
        /// <summary>
        /// get and sets for Party, Firstname, Secondname & Vote amount for all read in candidates
        /// </summary>
        public String Party { get; private set; }
        public String Firstname { get; private set; }
        public String Secondname { get; private set; }
        public int Voteamount { get; private set; }
        /// <summary>
        /// Constructor of candidates
        /// </summary>
        /// <param name="party">Holds the party the candidat belongs to</param>
        /// <param name="firstname">Holds the firstname of the candidate</param>
        /// <param name="secondname">Holds the lastname of the candidate</param>
        /// <param name="voteamount">Holds the vote amount in that party</param>
        public Candidate(String party, String firstname, String secondname, int voteamount)
        {
            this.Party = party;
            this.Firstname = firstname;
            this.Secondname = secondname;
            this.Voteamount = voteamount;
        }
        /// <summary>
        /// toString method returns a string from each class level object
        /// </summary>
        /// <returns>A string based on the results</returns>
        public override string ToString()
        {
            return String.Format("({3})The Candidate of: {0} {1} Has: {2} votes.", Firstname, Secondname, Voteamount,Party);
        }
    }
}
