using System.Collections.Generic;
using AutoMapper;
using LiveGameFeed.Data.Abstract;
using LiveGameFeed.Hubs;
using LiveGameFeed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;

namespace LiveGameFeed.Controllers
{
    [Route("api/[controller]")]
    public class MatchesController : ApiHubController<Broadcaster>
    {
        IMatchRepository _matchRepository;
        public MatchesController(IConnectionManager signalRConnectionManager, IMatchRepository matchRepository)
            : base(signalRConnectionManager)
        {
            _matchRepository = matchRepository;
        }

        [HttpGet]
        public IEnumerable<MatchViewModel> Get()
        {
            IEnumerable<Match> _matches = _matchRepository.AllIncluding(m => m.Feeds);
            IEnumerable<MatchViewModel> _matchesVM = Mapper.Map<IEnumerable<Match>, IEnumerable<MatchViewModel>>(_matches);

            return _matchesVM;
        }

        [HttpPut("{id}")]
        public async void Put(int id, [FromBody]MatchScore score)
        {
            Match _match = _matchRepository.GetSingle(id);
            if (score.HostScore == 0 && score.GuestScore == 0)
            {
                _match.Feeds.Clear();
            }

            _match.HostScore = score.HostScore;
            _match.GuestScore = score.GuestScore;

            _matchRepository.Commit();

            MatchViewModel _matchVM = Mapper.Map<Match, MatchViewModel>(_match);
            await Clients.All.UpdateMatch(_match);
        }
    }

}