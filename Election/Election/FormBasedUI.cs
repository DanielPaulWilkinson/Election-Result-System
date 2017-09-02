using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Election
{
    public partial class FormBasedUI : Form, IElectionInterface
    {
        /// <summary>
        /// Create variables
        /// </summary>
        public IElectionReader IOhandler { get; set; }
        private ConfigData configData;
        private ConstituencyList conList;
        private String selectedReportType;

        /// <summary>
        /// form constructor
        /// </summary>
        /// <param name="IOhandler"></param>
        public FormBasedUI(IElectionReader IOhandler)
        {
            InitializeComponent();
            this.IOhandler = IOhandler;
        }
        /// <summary>
        /// here we are loading the config data
        /// running the consumner and producer automating this process
        /// we then set up or combo boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormBasedUI_Load(object sender, EventArgs e)
        {
  
                //set up config data i.e xml files
                SetupConfigData();
                //run them, que them and load them into memory
                RunProducerConsumer();
            
        
        }
        /// <summary>
        /// create and read xml
        /// </summary>
        /// 
        public void SetupConfigData()
        {
         
                //create new instance of configdata
                configData = new ConfigData();
                //load the filenames in
                configData.configRecords.Add(new ConfigRecord("Constituency-01.xml"));
                configData.configRecords.Add(new ConfigRecord("Constituency-02.xml"));
                configData.configRecords.Add(new ConfigRecord("Constituency-03.xml"));
                configData.configRecords.Add(new ConfigRecord("Constituency-04.xml"));
                configData.configRecords.Add(new ConfigRecord("Constituency-05.xml"));
            
           
            
        }
     
        public void RunProducerConsumer()
        {
        
        
            //create the constituency
            conList = new ConstituencyList();

            //create the progressmanager with the number of files to process
            ProgressManager progManager = new ProgressManager(configData.configRecords.Count);

            //create a message to show that we are up and running
            lblProgress.Text="Creating and starting all producers and consumers";

            //create the queue and specify that we cannot have more then 4 at one time
            var pcQueue = new PCQueue(4);

            //create consumers and producers which are ready once inisiated, will work on their own threads.
            Producer[] producers = { new Producer("P1", pcQueue, configData, IOhandler),
                                     new Producer("P2", pcQueue, configData, IOhandler) };

            Consumer[] consumers = { new Consumer("C1", pcQueue, conList, progManager),
                                     new Consumer("C2", pcQueue, conList, progManager) };

            // dont stop reading until the count has stopped
            while (progManager.ItemsRemaining > 0) ;

            //give a message to show that they have closed down
            lblProgress.Text = "Shutting down all producers and consumers";

            //deactive the queue
            pcQueue.Active = false;

            //go through all producers and tell them to finish off & consumers
            foreach (var p in producers)
            {
                p.Finished = true;
            }
            foreach (var c in consumers)
            {
                c.Finished = true;
            }

            //make sure all of the running threads can stop ensuring their is no stranded ones.
            for (int i = 0; i < (Producer.RunningThreads + Consumer.RunningThreads); i++)
            {
                lock (pcQueue)
                {
                    // pules to make sure their is no waiting threads 
                    Monitor.Pulse(pcQueue);

                    //short time to make sure the threads can deactivate
                    Thread.Sleep(100);
                }
            }

            //shut down all producer and consumer threads
            while ((Producer.RunningThreads > 0) || (Consumer.RunningThreads > 0)) ;

            Console.WriteLine();
            lblProgress.Text = "All producers and consumers shut down";
        
    }
        /// <summary>
        /// displays all candidates in the constituency list
        /// </summary>
        public void DisplayAll()
        {
            lstResult.Items.Clear();

            foreach (var cons in conList.ReportSelection(selectedReportType))
            {
                lstResult.Items.Add(cons);
            }

            lblReport.Text = String.Format("({0} Report)", selectedReportType);
        }
        /// <summary>
        /// Quits the applaiction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Controls the constituency we look to base 
        /// the candidates from
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConstituencySelectable_Click(object sender, EventArgs e)
        {
            HideListboxResults1();
            lblTalk.Text = "Click a Constituency below to see each candidate within it!: ";
            selectedReportType = "Clickable Constituency";
            DisplayAllConstituncies();
        }
        /// <summary>
        /// this method alows me to display all constituencies
        /// </summary>
        private void DisplayAllConstituncies()
        {
            lstResult.Items.Clear();

            foreach (Constituency constit in conList.DisplayConstituencies())
            {
                lstResult.Items.Add(constit);
                lstResults1.Items.Add(constit);
            }

            lblReport.Text = String.Format("({0} Report)", selectedReportType);
        }
       
        /// <summary>
        /// Nothing...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            
        }
       /// <summary>
        /// shows the election winner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElectionWinner_Click(object sender, EventArgs e)
        {
            HideListboxResults1();
            lblTalk.Text = "You can currently see the winning candidate.";
            selectedReportType = "The Winner";
            DisplayAll();
        }
        /// <summary>
        /// Displays all parties and their votes from the constituency list
        /// </summary>
        private void btnAllPartyAndVotes_Click(object sender, EventArgs e)
        {
            HideListboxResults1();
            lstCans.Items.Clear();
            lblTalk.Text = "You are currently viewing all the parties in the election and their total votes";
            selectedReportType = "Parties And Total Votes";
            DisplayAllPartiesAndVotes();
        }
        /// <summary>
        /// helps us get the constituency candidate with the highest vote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DisplayAllPartiesAndVotes()
        {
            lstResult.Items.Clear();

            foreach (Candidate cons in conList.ReportSelection(selectedReportType))
            {
                lstResult.Items.Add(cons.Party+":  "+cons.Voteamount);
            }

            lblReport.Text = String.Format("({0} Report)", selectedReportType);
        }
        /// <summary>
        /// shows candidates by highest vote
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCandidatesHighestVote_Click(object sender, EventArgs e)
        {
            HideListboxResults1();
            lstCans.Items.Clear();
            lblTalk.Text = "You are currently viewing the elected candidates according to their parties";
            selectedReportType = "Elected Candidates";
            DisplayAll();
        }
        /// <summary>
        /// Nothing..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// stores all information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDifferentConstituencyReport(1);

        }

       public void DisplayDifferentConstituencyReport(int index)
        {
            //depending on the index passed into the function
            switch (index)
            {
                //if the index is 1
                case 1:
                    //chack to make sure somthing is selected within the result list
                    if (lstResult.SelectedIndex >= 0)
                    {
                        //if so make sure that it is a constituency
                        if (lstResult.SelectedItem is Constituency)
                        {
                            //get that constituency 
                            Constituency a = (Constituency)lstResult.SelectedItem;
                            //make sure we clean up before adding in the new cadidate data in the bottom list
                            lstCans.Items.Clear();
                            //add every candidate in the returned list of cadidates where they are equal to that selected
                            //constituency ID -- this will return just the cadidates within the constituencies
                            foreach (Candidate candidate in conList.DisplayCansFromCons(a.Constituencyid))
                            {
                                lstCans.Items.Add(candidate);
                            }
                        }
                    }
                        break;
                    //if the case is 2 simply do exactly the same however with a different method which returns
                    //a single winning candidate within each of the constituencies.
                case 2:
                    if (lstResults1.SelectedIndex >= 0)
                    {

                        if (lstResults1.SelectedItem is Constituency)
                        {
                            Constituency a = (Constituency)lstResults1.SelectedItem;
                            lstCans.Items.Clear();
                            foreach (Candidate candidate in conList.DisplayWinningCansFromCons(a.Constituencyid))
                            {
                                lstCans.Items.Add(candidate);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// basic text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblWelcome_Click(object sender, EventArgs e)
        {
            selectedReportType = "Constituency - Sunderland North";
            DisplayAll();
        }
        /// <summary>
        /// shows the instructions in the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInstructions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click 'View Consitiuency and candidate details'. Then select a constituency in the listbox to view the candiddates in that Constituency.\r\n\r\n"+
                            "Click 'Elected Candidates in each party' to view the candidates with the highest votes in each party."+
                    "\r\n\r\nClick the 'Elected Candidates in each Constituency' to view the candidates with the highest votes in each Constituency, you can click the listbox options to specify that constituency." +
                    "\r\n\r\nClick the 'All Parties and total votes' button to view all of the parties in the election and their total vote amount."+
                     "\r\n\r\nClick the 'Election Winner' to view the party with the most votes over all constituencies."
                            , "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// shows the elected candidates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElectedCandidateInConstituency_Click(object sender, EventArgs e)
        {
            ShowListboxResults1();
            lblTalk.Text = "Click a Constituency below to find the winning candidate within it (the candidate with the most votes.)";
            selectedReportType = "Winning Candidates within a Constituency";
            DisplayAllConstituncies();
        }
        
        private void GroupInformation_Enter(object sender, EventArgs e)
        {

        }
        private void lblTalk_Click(object sender, EventArgs e)
        {

        }
        private void lblProgress_Click(object sender, EventArgs e)
        {

        }
        private void GroupSort_Enter(object sender, EventArgs e)
        {

        }

        private void btnConsss_Click(object sender, EventArgs e)
        {
           
        }

        private void lstCons_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstCans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// this method hides a list box
        /// </summary>
        public void HideListboxResults1()
        {
            lstResults1.Items.Clear();
            lstResults1.Visible = false;
        }
        
        /// <summary>
        /// this method shows it
        /// </summary>
        public void ShowListboxResults1()
        {
            lstResults1.Items.Clear();
            lstResults1.Visible = true;
        }
        /// <summary>
        /// this method calls the switch we seen erlier and passes the index so we can show the single winning candidate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstResults1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDifferentConstituencyReport(2);
        }
    }
}

