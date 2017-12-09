using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baseball.Model;
using HtmlAgilityPack;
using Infrastructure;

namespace FB.Services.Yahoo
{  
    internal class TransactionServices : ITransactionServices
    {
        //* Helper Members

        private const string YahooNonParameterTransactionUrl = "http://baseball.fantasysports.yahoo.com/b1/buzzindex";
        
        internal FBPlayers GetTransactions(string url)
        {
            Console.WriteLine(url);

            var players = new FBPlayers();

            //PlayerTrends playerTrends = new PlayerTrends();

            //* Get the URL specified

            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument document = htmlWeb.Load(url);

            //* Get <table> tags

            HtmlNodeCollection tableTags = document.DocumentNode.SelectNodes("//table");

            if (tableTags != null)
            {
                int index_td = 0, index_tr = 0;

                foreach (HtmlNode tableTag in tableTags)
                {
                    if (tableTag.Attributes["class"] == null)
                        continue;

                    if (tableTag.Attributes["class"].Value == "Tst-table Table")
                    {
                        #region Found the table; find rows to work

                        //PlayerTrend playerTrend;

                        index_tr = 0;

                        foreach (HtmlNode trNode in tableTag.ChildNodes["tbody"].ChildNodes)
                        {
                            index_td = 0;

                            //playerTrend = new PlayerTrend();

                            var player = new FBPlayer();
                            var trend = new TransactionTrend();

                            foreach (HtmlNode tdNode in trNode.ChildNodes)
                            {
                                if (index_td == 0)
                                {
                                    #region Parse into name, team and positions

                                    foreach (HtmlNode descendant in tdNode.Descendants())
                                    {
                                        if (descendant.Name == "div")
                                        {
                                            if (descendant.Attributes["class"] != null)
                                            {
                                                if (descendant.Attributes["class"].Value.Contains("ysf-player-name"))
                                                {
                                                    string[] allData = descendant.InnerText.Split('-');

                                                    //playerTrend.PlayerName = allData[0].Trim();
                                                    player.Name = allData[0].Trim();

                                                    var aux = player.Name.Split(' ');

                                                    //playerTrend.Team = aux[aux.Length - 1].Trim();

                                                    player.Team = aux[aux.Length - 1].Trim();

                                                    player.Name = player.Name.Remove(
                                                        player.Name.Length - 1 - player.Team.Length);

                                                    //* Position

                                                    string positions = allData[1].Trim();

                                                    foreach (string pos in positions.Split(','))
                                                    {
                                                        player.Positions.Add(pos.Trim());
                                                    }

                                                    break;
                                                }
                                            }
                                        }
                                    }

                                    #endregion

                                }
                                else if (index_td == 1)
                                    trend.Drops = Convert.ToInt32(tdNode.InnerText.Trim());
                                else if (index_td == 2)
                                    trend.Adds = Convert.ToInt32(tdNode.InnerText.Trim());

                                index_td += 1;
                            }

                            trend.DateOfSample = DateTime.Now;

                            player.TransactionTrends.Add(trend);

                            players.Add(player);

                            //playerTrends.Add(playerTrend);

                            index_tr += 1;
                        }

                        #endregion
                    }
                }
            }

            //* Store in a JSON file

            if (players.Count > 0)
            {
                string json = players.ToJson();
                string filename = string.Format("FBPlayerTransaction_{0:yyyy-MM-dd_hhmmss}.json", DateTime.Now);

                Infrastructure.IO.FileServices.CreateTextFile(filename, json);
            }

            return players;
        }

        #region ITransactionServices Members

        //* ITransactionServices Members

        public FBPlayers GetTransactions()
        {
            string urlDate = string.Format("{0:yyyy-MM-dd}", DateTime.Now);

            string url = string.Format(
                    "{0}?date={0}&pos=ALL&src=combined&sort=BI_A&sdir=1"
                    , YahooNonParameterTransactionUrl, urlDate
                );

            return this.GetTransactions(url);
        }
        public FBPlayers GetTransactions(DateTime dateOfSample)
        {
            string urlDate = string.Format("{0:yyyy-MM-dd}", dateOfSample);

            string url = string.Format(
                    "{0}?date={1}&pos=ALL&src=combined&sort=BI_A&sdir=1"
                    , YahooNonParameterTransactionUrl, urlDate
                );

            return this.GetTransactions(url);
        }

        #endregion
    }
}
