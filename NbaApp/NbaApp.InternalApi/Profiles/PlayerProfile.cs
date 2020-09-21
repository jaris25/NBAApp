using AutoMapper;
using NbaApp.Data.Models.PlayersModels;
using NbaApp.InternalApi.Models;

namespace NbaApp.InternalApi.Profiles
{
    public class PlayerProfile:Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<PlayerForUpdatingDto, Player>().ReverseMap();
        }
    }
}
