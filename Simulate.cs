using PVPNetConnect.RiotObjects.Platform.Broadcast;
using PVPNetConnect.RiotObjects.Platform.Game;
using PVPNetConnect.RiotObjects.Platform.Game.Message;
using PVPNetConnect.RiotObjects.Platform.Matchmaking;
using PVPNetConnect.RiotObjects.Platform.Messaging;
using PVPNetConnect.RiotObjects.Platform.Reroll.Pojo;
using System.Collections.Generic;

namespace PVPNetConnect
{
    public partial class PVPNetConnection
    {
        public void SimulateEogPointChange()
        {
            EogPointChangeBreakdown pointBreakdown = new EogPointChangeBreakdown()
            {
                PointChangeFromChampionsOwned = 115.0,
                PointsUsed = 500.0,
                EndPoints = 145.0,
                PreviousPoints = 500.0,
                PointChangeFromGamePlay = 30.0
            };
            MessageReceived(pointBreakdown);
        }

        public void SimulateBannedFromGame()
        {
            GameNotification notification = new GameNotification()
            {
                MessageCode = "PG-0021",
                Type = "PLAYER_BANNED_FROM_GAME"
            };
            MessageReceived(notification);
        }

        public void SimulatePlayerLeftQueue()
        {
            GameNotification notification = new GameNotification()
            {
                MessageCode = "CG-0001",
                MessageArgument = "318908",
                Type = "PLAYER_QUIT"
            };
            MessageReceived(notification);
        }

        public void SimulateStartedGame()
        {
            PlayerCredentialsDto startedGame = new PlayerCredentialsDto()
            {
                EncryptionKey = "fake",
                GameId = 125432223.0,
                LastSelectedSkinIndex = 0,
                ServerIp = "59.100.95.227",
                Observer = false,
                SummonerId = 222908.0,
                ObserverServerIp = "192.64.169.29",
                DataVersion = 0,
                HandshakeToken = "fake",
                PlayerId = 20006292.0,
                ServerPort = 5129,
                ObserverServerPort = 8088,
                SummonerName = "Snowl",
                ObserverEncryptionKey = "fake",
                ChampionId = 133
            };
            MessageReceived(startedGame);
        }

        public void SimulateBroadcastNotification(string Message, string Severity)
        {
            BroadcastNotification broadcast = new BroadcastNotification()
            {
                BroadcastMessages = new object[1] { 
                    new Dictionary<string, object> () {
                        {"id", 0},
                        {"active", true},
                        {"content", Message},
                        {"messageKey", "generic"},
                        {"severity", Severity}
                    }
                }
            };
            MessageReceived(broadcast);
        }

        public void SimulateStoreAccountBalance(int ip, int rp)
        {
            StoreAccountBalanceNotification newBalance = new StoreAccountBalanceNotification()
            {
                Ip = ip,
                Rp = rp
            };
            MessageReceived(newBalance);
        }

        public void SimulateSimpleDialogMessage()
        {
            SimpleDialogMessage message = new SimpleDialogMessage()
            {
                TitleCode = "leagues",
                AccountId = 200006292.0,
                Type = "leagues",
                Params = new Dictionary<string, object>()
                {
                    {"leagueItem", new Dictionary<string, object>()
                        {
                            {"playerOrTeamId", 222908},
                            {"playerOrTeamName", "Snowl"},
                            {"leagueName", "Urgot's Patriots"},
                            {"queueType", "RANKED_SOLO_5x5"},
                            {"tier", "SILVER"},
                            {"rank", "III"},
                            {"leaguePoints", 95},
                            {"previousDayLeaguePosition", 5},
                            {"wins", 291},
                            {"losses", 278},
                            {"lastPlayed", 1385704806989},
                            {"timeUntilDecay", 8639913599826},
                            {"timeLastDecayMessageShown", 0},
                            {"miniSeries", null},
                            {"displayDecayWarning", false},
                            {"demotionWarning", 0},
                            {"totalPlayed", 569},
                            {"hotStreak", false},
                            {"veteran", true},
                            {"freshBlood", false},
                            {"inactive", false}
                        }
                    },
                    {"notifyReason", "LEAGUE_POINTS_UPDATE"},
                    {"leaguePointsDelta", 18},
                    {"gameId", 125707704}
                }
            };
            MessageReceived(message);
        }
    }
}
