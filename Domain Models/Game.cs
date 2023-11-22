using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    enum genre
    {
        Action,
        Adventure,
        Arcade,
        BeatEmAll,
        CloudGaming,
        Coaching,
        Cooperation,
        CrossPlatformMultiplayer,
        EarlyAccess,
        FPS,
        Fighting,
        FreetoPlay,
        Indies,
        LocalCoOp,
        MMO,
        Management,
        Multiplayer,
        OnlineCoOp,
        OnlinePVP,
        Platforms,
        RPG,
        Racing,
        RemotePlayTogether,
        ShootEmUp,
        Simulation,
        Singleplayer,
        Sport,
        Strategy,
        VR,
        VROnly,
        WarGame,
    }
    enum gamePlatform
    {
        PC,
        Nintendo,
        Xbox,
        Playstaion,
    }
    internal class Game
    {
        public string name;         
        public string publisher;
        public string developer;
        public string description;
        public int numPlayers;
        public int ageRating;
        public DateTime releaseDate;
        public List<genre> genres;
        public List<gamePlatform> gamePlatforms;

        public void UpdateGameData(string Name,
                                   string Publisher,
                                   string Developer,
                                   string Description,
                                   int NumPlayers,
                                   int AgeRating,
                                   DateTime ReleaseDate,
                                    List<genre> Genres,
                                    List<gamePlatform>GamePlatforms)
        {
            name = Name;
            publisher = Publisher;
            developer = Developer;
            description = Description;
            numPlayers = NumPlayers;
            ageRating = AgeRating;
            releaseDate = ReleaseDate;
            genres = Genres;
            gamePlatforms = GamePlatforms;

        }
    }
}
