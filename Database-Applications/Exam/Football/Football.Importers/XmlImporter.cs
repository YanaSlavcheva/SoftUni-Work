namespace Football.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using Football.Data;
    using Football.DataTransferObjects;

    public class XmlImporter : IImporter
    {
        public void Import(XDocument file, FootballEntities context)
        {
            var leaguesNodes = file.XPathSelectElements("leagues-and-teams/league");

            foreach (var leagueNode in leaguesNodes)
            {
                // parse league info
                // all optional
                var tempLeague = new Leagues();
                string leagueName = null;

                // check if there is a league
                if (leagueNode.Element("league-name") != null)
                {
                    leagueName = leagueNode.Element("league-name").Value;

                    var league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);

                    // league exists + add league
                    if (league != null)
                    {
                        Console.WriteLine("Existing league: " + leagueName);
                        AddTeamsToLeagueAndDb(context, leagueNode, league);
                    }

                    // league doesn't exist - create it
                    else
                    {
                        var newLeague = new Leagues();
                        newLeague.LeagueName = leagueName;
                        context.Leagues.Add(newLeague);
                        context.SaveChanges();
                        Console.WriteLine("Created league: " + leagueName);
                        AddTeamsToLeagueAndDb(context, leagueNode, newLeague);
                    }
                }

                //AddTeamsToLeagueAndDb(context, leagueNode, tempLeague);

                // Add the league to the DB
                // context.Leagues.Add(tempLeague);

                else
                {
                    AddTeamsToDb(context, leagueNode);
                }

                context.SaveChanges();
            }
        }

        private static void AddTeamsToLeagueAndDb(FootballEntities context, XElement leagueNode, Leagues tempLeague)
        {
            // parse teams info and add to league
            var teamNodes = leagueNode.XPathSelectElements("teams/team");
            foreach (var teamNode in teamNodes)
            {
                var tempTeam = new Teams();
                var teamName = teamNode.Attributes("name").FirstOrDefault().Value;
                string teamCountry = null;
                if (teamNode.Attributes("country").FirstOrDefault() != null)
                {
                    teamCountry = teamNode.Attributes("country").FirstOrDefault().Value;
                }

                var team = context.Teams.FirstOrDefault(t => t.TeamName == teamName);
                var country = context.Countries.FirstOrDefault(c => c.CountryName == teamCountry);


                var teamCountryCode =
                    context.Countries.Where(c => c.CountryName == teamCountry).Select(c => c.CountryCode).FirstOrDefault();
                var teamCountryCodeInDb =
                        context.Teams.Where(t => t.TeamName == teamName).Select(t => t.CountryCode).FirstOrDefault();


                bool sameCountry = true;
                if (teamCountryCode != null && teamCountryCodeInDb != null)
                {
                    sameCountry = teamCountryCode.Equals(teamCountryCodeInDb);
                }
                

                // team exists + add team to league
                if (team != null && country != null && sameCountry)
                {
                    Console.WriteLine("Existing team: " + teamName);
                    tempLeague.Teams.Add(team);
                    context.SaveChanges();
                    Console.WriteLine("Added team to league: " + tempLeague.LeagueName);
                }

                // missing team name
                else if (teamName == string.Empty)
                {
                    Console.WriteLine("Team name is mandatory!");
                }

                // creating new team + add team
                else
                {
                    var newTeam = new Teams();
                    newTeam.TeamName = teamName;
                    newTeam.CountryCode = teamCountryCode;
                    context.Teams.Add(newTeam);
                    Console.WriteLine("Created team: " + teamName);
                    tempLeague.Teams.Add(newTeam);
                    Console.WriteLine("Added team to league: " + tempLeague.LeagueName);
                }
            }
        }

        private static void AddTeamsToDb(FootballEntities context, XElement leagueNode)
        {
            // parse teams info and add to league
            var teamNodes = leagueNode.XPathSelectElements("teams/team");
            foreach (var teamNode in teamNodes)
            {
                var teamName = teamNode.Attributes("name").FirstOrDefault().Value;
                string teamCountry = null;
                if (teamNode.Attributes("country").FirstOrDefault() != null)
                {
                    teamCountry = teamNode.Attributes("country").FirstOrDefault().Value;
                }

                var team = context.Teams.FirstOrDefault(t => t.TeamName == teamName);
                var country = context.Countries.FirstOrDefault(c => c.CountryName == teamCountry);


                var teamCountryCode =
                    context.Countries.Where(c => c.CountryName == teamCountry).Select(c => c.CountryCode).FirstOrDefault();
                var teamCountryCodeInDb =
                        context.Teams.Where(t => t.TeamName == teamName).Select(t => t.CountryCode).FirstOrDefault();


                bool sameCountry = true;
                if (teamCountryCode != null && teamCountryCodeInDb != null)
                {
                    sameCountry = teamCountryCode.Equals(teamCountryCodeInDb);
                }


                // team exists + add team
                if (team != null && country != null && sameCountry)
                {
                    Console.WriteLine("Existing team: " + teamName);
                    context.Teams.Add(team);
                    Console.WriteLine("Added team to database.");
                }

                // missing team name
                else if (teamName == string.Empty)
                {
                    Console.WriteLine("Team name is mandatory!");
                }

                // creating new team + add team
                else
                {
                    var newTeam = new Teams();
                    newTeam.TeamName = teamName;
                    newTeam.CountryCode = teamCountryCode;
                    Console.WriteLine("Created team: " + teamName);
                    context.Teams.Add(newTeam);
                    Console.WriteLine("Added team to database.");
                }
            }
        }
    }
}
