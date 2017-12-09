using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Baseball.Model
{
    public class Player
    {
        private Positions m_Positions;

        public string Name;
        public string Team;
        public Positions Positions
        {
            get
            {
                if (this.m_Positions == null)
                    this.m_Positions = new Positions();

                return this.m_Positions;
            }
        }

        public override string ToString()
        {
            string auxName = "Unknown";

            if (!string.IsNullOrEmpty(this.Name))
                auxName = this.Name;

            string auxTeam = "";

            if (!string.IsNullOrEmpty(this.Team))
                auxTeam = this.Team;

            return string.Format("{0} {1} ({2})", auxName, auxTeam, Positions);
        }
    }

    public class FBPlayer : Player
    {
        private TransactionTrends m_TransactionTrends;

        public TransactionTrends TransactionTrends
        {
            get
            {
                if (this.m_TransactionTrends == null)
                    this.m_TransactionTrends = new TransactionTrends();

                return this.m_TransactionTrends;
            }
        }
    }
    public class FBPlayers : Collection<FBPlayer>
    {

    }
    
}
