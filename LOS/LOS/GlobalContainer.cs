namespace LOS
{
    internal class GlobalContainer
    {
        internal class Main
        {
            public const string windowName = "League of Legends";
            public const string processName = "LeagueClient";
            public const string thisApplicationName = "LoL Overlay System";

            public const int updateMessageDuration = 2000;                      //ms
            public const int optionsSpawnPointDistanceFromBottom = 245;         //px
            public const int optionsSpawnPointDistanceFromLeft = 5;             //px
            public const int optionsShowHideAnimationSpeed = 50;                //px

            public const int optionsNExitPointDistanceFromBottom = 28;          //px
            public const int optionsNExitPointDistanceFromLeft = 78;            //px

            public const int checkForResolutionChangeInterval = 1000;           //ms
            public const double loadUpOpacityChangePerInterval = .05;           //%inDec

            public const double pictureMatchMinimumPercentageValue = .85;       //%inDec
            public const string communityDragonPicturesWebAddress = @"https://raw.communitydragon.org/latest/plugins/rcp-be-lol-game-data/global/default/v1/champion-icons/";
        }

        internal class Measures
        {
            internal class Capture
            {
                //for default width and height values in cropping switch (should never occur)
                public const int cropWSideImage576 = 15;
                public const int cropHSideImage576 = 33;
            }
            internal class DownScale
            {
                public const int sideImage900 = 86;
                public const int topImage900 = 66;
                public const int sideImage720 = 70;
                public const int topImage720 = 52;
                public const int sideImage576 = 56;
                public const int topImage576 = 42;
            }
        }

        internal class NamesNPaths
        {
            internal class Paths
            {
                public const string graphicDataPath = @"gdata\";
            }
            internal class FullNames
            {
                public const string picChest = "chest.png";
                public const string picPause = "pause.png";
                public const string picResume = "resume.png";

                public const string baseData = "base.txt";
                public const string tempBaseData = "tempBase.txt";
                public const string positionData = "positionData.hz";

                internal class SetupSerilizeImageData
                {
                    public const string res900 = "imageData900.hz";
                    public const string res720 = "imageData720.hz";
                    public const string res576 = "imageData576.hz";
                }
            }
            internal class PartialNames
            {
                public const string championData = "ChampionData";
                public const string imageData = "imageData";
            }
            internal class Extentions
            {
                public const string numberPic = ".png";
                public const string myFiles = ".hz";
            }
        }

        internal class Messages
        {
            public const string riotAPIBasicError =
                "Seems like riot API endpoint is not responding.\n" +
                "Please try again later.";
            public const string communityDragonError =
                "Seems like the official site that cotains LoL icons is down, malfunctioning or changed the domain.\n" +
                "Please contact the developer for possible update or newest reliable image data file.";
            public const string riotAPIchampionMasteryError =
                "Seems like riot API returned an error...\n" +
                "Please make sure API Key is valid and check your internet connection.\n" +
                "If you are sure API Key is valid and your connection is stable and this error persists " +
                "it means that it is a riot endpoint error.\n" +
                "Try again later.";
            public const string deletingTheOnlySummonerEntry = "Please add another summoner before deleting ";
        }
        internal class Warnings
        {
            public const string invalidAPIError = "Your API key might be invalid. Would you like to re-enter API key?";
        }

        internal class PlaceholderMessages
        {
            public const string invalidAPI = "API Key is invalid please enter a new one...";
            public const string summonerNameDefault = "Enter manually...";
            public const string APIKeyDefault = "Enter new API key...";
            public const string APIKeyFirstNullOnSet = "Please enter an API Key...";
            public const string APIKeyNullOnSet = "Please enter a key before setting it...";
            public const string summonerNameOCRFail = "Not found, enter manually...";
        }

        internal class UpdateStatus
        {
            public const string scanSucc = "Scaned";
            public const string scanFail = "Scan Failed";
            public const string APISetSucc = "API Key set";
            public const string LoLClientLocSetSucc = "Location set";
            public const string summonerExistsSucc = "Changed";
            public const string summonerExistsFail = "Added";
            public const string summonerUpdateSucc = "Updated";
            public const string summonerUpdateFail = "Update failed";
            public const string summonerDeleteSucc = "Deleted";
            public const string summonerDeleteFail = "Delete failed";
        }

        internal class OverlayStatus
        {
            public const string ON = "Overlay: ON";
            public const string OFF = "Overlay: OFF";
            public const string STANDBY = "Overlay: STBY";
        }

        internal class OCR
        {
            public const string ARAMGameMode = "AVAILABLE\r\nCHAMPIONS";
        }

    }
}
