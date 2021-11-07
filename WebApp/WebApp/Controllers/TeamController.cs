using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TeamController : Controller
    {
        private static List<Teams> Teams;
        private static List<TeamDetails> EditedDetails;
        public TeamController()
        {
            if(Teams==null)
            {

            Teams = GetTeams();
                EditedDetails = new List<TeamDetails>();
            }
        }
        public IActionResult Index()
        {
            var TeamsToShow = Teams.Where(a => a.IsDeleted == false).ToList();
            return View(TeamsToShow);
        }
        private List<Teams> GetTeams()
        {
            var client = new RestClient("https://football-web-pages1.p.rapidapi.com/teams.json?comp=1");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "football-web-pages1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "a91b833d1emshabb5448c048a3f9p184701jsn1f9c7b7fe25a");
            IRestResponse response = client.Execute(request);
            DataApi<Teams> root = JsonConvert.DeserializeObject<DataApi<Teams>>(response.Content);
            return root.teams;
        }

        private TeamDetails GetTeamDetails(int id)
        {
            var client = new RestClient("https://football-web-pages1.p.rapidapi.com/team.json?team="+id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "football-web-pages1.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "a91b833d1emshabb5448c048a3f9p184701jsn1f9c7b7fe25a");
            IRestResponse response = client.Execute(request);
            DataApi<TeamDetails> root = JsonConvert.DeserializeObject<DataApi<TeamDetails>>(response.Content);
            return root.team;
        }
        public IActionResult Details(int id)
        {
            var details = new  TeamDetails();
            details = GetTeamDetails(id);
            return View(details);
        }
      
        public IActionResult Delete(int id)
        {
            var Deleted = Teams.FirstOrDefault(a => a.Id == id);
            if(Deleted!=null)
            {
                Deleted.IsDeleted = true;
            }
            return Redirect("Index");
        }
        public IActionResult Edit(int id)
        {
            var Team = Teams.FirstOrDefault(a => a.Id == id);
            var TeamToShow = new TeamDetails();
            if(Team!=null)
            {
                if(Team.Edited==false)
                {
                    TeamToShow = GetTeamDetails(id);
                }
                else
                {
                    TeamToShow = EditedDetails.FirstOrDefault(a => a.Id == id);
                }
            }
            return View(TeamToShow);
        }
        public IActionResult Save(TeamDetails vm )
        {
            var EditTeam = Teams.FirstOrDefault(a => a.Id == vm.Id);
            if (EditTeam != null)
            {
                if(EditTeam.Edited==false)
                {

                     EditTeam.Edited = true;

                    var Team = new TeamDetails()
                    {
                        Id = vm.Id,
                        Address = vm.Address,
                        Name = vm.Name,
                        Postcode = vm.Postcode,
                        Ground = vm.Ground,
                        Capacity = vm.Capacity,
                        Twitter = vm.Twitter

                    };
                    
                    EditedDetails.Add(Team);
                }
                else
                {
                    var Team = EditedDetails.FirstOrDefault(a => a.Id==vm.Id);
                    Team.Address = vm.Address;
                    Team.Name = vm.Name;
                    Team.Postcode = vm.Postcode;
                    Team.Ground = vm.Ground;
                    Team.Capacity = vm.Capacity;
                    Team.Twitter = vm.Twitter;
                }
            }
            return Redirect("Index");
        }
    }
}
