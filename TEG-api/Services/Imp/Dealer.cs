using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TEG_api.Common.DTOs;
using TEG_api.Common.Enums;
using TEG_api.Common.Models;
using TEG_api.Common.Response;
using TEG_api.Data;
using TEG_api.Middleware.Exceptions;
using TEG_api.Services.Interface;

namespace TEG_api.Services.Imp
{
    public class Dealer : IDealer
    {
        private readonly TEGContext _db;
        private readonly ILogger<Dealer> _logger;
        private readonly IMapper _mapper;

        public Dealer(TEGContext db, ILogger<Dealer> logger, IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task DealingCountries(int MatchId)
        {
            if (MatchId <= 0)
            {
                throw new KeyNotFoundException("MATCH_ID_EMPTY");
            }

            var MatchDb = await _db.Matches
                .Where(m => m.Id.Equals(MatchId))
                .Include(m => m.MatchConfig)
                .Include(m => m.PlayerGameSetups)
                .Include(m => m.Map)
                    .ThenInclude(c => c.Continents)
                        .ThenInclude(co => co.Countries)
                .FirstAsync();

            Validation(MatchDb);

            var Countries = MatchDb.Map.Continents.SelectMany(x => x.Countries).ToList();
            var Players = MatchDb.PlayerGameSetups.ToList();

            var QuantityOfDeal = Countries.Count() / Players.Count();
            Random random = new Random(); 
            
            foreach ( var player in Players )
            {
                var i = 0;
                while(i < QuantityOfDeal)
                {
                    var rIndex = random.Next(0, Countries.Count);

                    if (Countries[rIndex].PlayerId == null)
                    {
                        Countries[rIndex].PlayerId = player.PlayerId;
                        i++;
                    }
                }
            }


            //Thread - For Countries with out owners & SaveChanges
            Thread checkLeftOver = new Thread(new ParameterizedThreadStart(LeftOverCountries));
            object parameters = new object[] { Countries, Players.Select(p => p.PlayerId).ToList() };
            checkLeftOver.Start(parameters);

            var response = await FormatResponse(MatchDb.MapId, checkLeftOver);
        }

        private void Validation(Match matchDb)
        {
            if(matchDb == null)
            {
                _logger.LogError("MATCH_NOT_FOUND | " + matchDb);
                throw new KeyNotFoundException("MATCH_NOT_FOUND");
            }
            if (matchDb.MatchConfig == null)
            {
                _logger.LogError("MATCH_CONFIG_NOT_FOUND | " + matchDb);
                throw new KeyNotFoundException("MATCH_CONFIG_NOT_FOUND");
            }
            if (matchDb.PlayerGameSetups == null)
            {
                _logger.LogError("PLAYERGAMESETUP_NOT_FOUND |" + matchDb);
                throw new KeyNotFoundException("PLAYERGAMESETUP_NOT_FOUND");
            }
            if(matchDb.Map.Continents == null)
            {
                _logger.LogError("CONTINENTS_NOT_FOUND | " + matchDb);
                throw new KeyNotFoundException("CONTINENTS_NOT_FOUND");
            }
            if(matchDb.Map.Continents.SelectMany(x => x.Countries).ToList() == null)
            {
                _logger.LogError("COUNTRIES_NOT_FOUND | " + matchDb);
                throw new KeyNotFoundException("COUNTRIES_NOT_FOUND");
            }
        }

        private async Task<DealingCountriesResponse> FormatResponse(int? mapId, Thread checkLeftOver)
        {
            DealingCountriesResponse response = new DealingCountriesResponse()
            {
                MapId = (int)mapId,
                Map = new MapDealingResponse()
                {
                    Continents = new List<ContinentDealingResponse>()
                }
            };

            checkLeftOver.Join();

            var map = await _db.Maps
                .Where(m => m.Id == mapId)
                .Include(m => m.Continents)
                .ThenInclude(c => c.Countries)
                .FirstAsync();

            var continentsDb = map.Continents.ToList();

            foreach(var continent in continentsDb)
            {
                var countriesDb = map.Continents
                    .SelectMany(c => c.Countries)
                    .Where(c => c.ContinentId == continent.Id)
                    .ToList();

                var countriesOfContinent = _mapper.Map<List<CountryDTO>>(countriesDb);

                ContinentDealingResponse continentDealing = new ContinentDealingResponse()
                {
                    ContinentId = continent.Id,
                    Name = continent.Name,
                    ValueOfTroops = continent.ValueOfTroops,
                    Countries = countriesOfContinent,
                };
            }

            return response;
        }

        private async void LeftOverCountries(object parameters)
        {
            var parametersArray = (object[])parameters;
            var countries = (List<Country>)parametersArray[0];
            var playersIds = (List<Guid>)parametersArray[1];

            Random random = new Random();
            var CountriesWithOutPlayer = countries.Where(c => c.PlayerId == null).ToList();

            var i = 0;
            while( i < CountriesWithOutPlayer.Count)
            {
                var rIndex = random.Next(0, playersIds.Count);

                if (CountriesWithOutPlayer[i].PlayerId == null)
                {
                    CountriesWithOutPlayer[i].PlayerId = playersIds[rIndex];
                    i++;
                }
            }

            await _db.SaveChangesAsync();
        }

        public async Task<bool> ChangeCard(List<TypeOfCard> cards, Guid playerId, Guid MatchId)
        {
            if (cards.Count != 3)
            {
                throw new ExceptionBadRequestClient("INVALID_NUMBER_CARDS");
            }

            var playerGameSetups = await _db.PlayerGameSetups
                .Where(p => p.PlayerId == playerId && p.MatchId == MatchId)
                .FirstAsync();

            if (playerGameSetups == null)
            {
                _logger.LogError($"PLAYER_NOT_FOUND | {playerId} {MatchId}");
                throw new KeyNotFoundException("PLAYER_NOT_FOUND");
            }

            bool checkCards = cards.All(c => playerGameSetups.CardsInHand.Contains(c));

            if (checkCards)
            {
                foreach (var card in cards)
                {
                    playerGameSetups.CardsInHand.Remove(card);
                }

                await _db.SaveChangesAsync();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
