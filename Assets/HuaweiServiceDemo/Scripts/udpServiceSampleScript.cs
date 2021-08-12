using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.HuaweiAppGallery;
using UnityEngine.HuaweiAppGallery.Listener;
using UnityEngine.HuaweiAppGallery.Model;

public class udpServiceSampleScript : MonoBehaviour
{
    private static ILoginListener _loginListener = new MyLoginListener();
    private static ICancelAuthListener _cancelAuthListener = new MyCancelAuthListener();
    private static IStartReadSmsListener _startReadSmsListener = new MyStartReadSmsListener();
    private static ISMSReceive _SMSReceive = new MySMSReceive();
    private static ICheckUpdateListener _checkUpdateListener = new MyCheckUpdateListener();
    private static IGetAchievementListListener _getAchievementListListener = new MyGetAchievementListListener();
    private static IGetAchievementsIntentListener _getAchievementsIntentListener = new MyGetAchievementIntentListener();
    private static IRevealListener _revealListener = new MyRevealListener();
    private static IIncrementListener _incrementListener = new MyIncrementListener();
    private static ISetStepsListener _setStepsListener = new MySetStepsListener();
    private static IUnlockListener _unlockListener = new MyUnlockListener();

    private static ILeaderboardSwitchStatusListener _leaderboardSwitchStatusListener =
        new MyLeaderboardSwitchStatusListener();

    private static ISubmitScoreListener _submitScoreListener = new MySubmitScoreListener();
    private static IGetLeaderboardIntentListener _getLeaderboardIntentListener = new MyGetLeaderboardIntentListener();
    private static IGetLeaderboardsListener _getLeaderboardsListener = new MyGetLeaderboardsListener();
    private static IGetLeaderboardListener _getLeaderboardListener = new MyGetLeaderboardListener();
    private static IGetLeaderboardScoresListener _getLeaderboardScoresListener = new MyGetLeaderboardScoresListener();
    private static IGetLeaderboardScoreListener _getLeaderboardScoreListener = new MyGetLeaderboardScoreListener();
    private static IGetEventListListener _getEventListListener = new MyGetEventListListener();
    private static IGetGameListener _getGameListener = new MyGetGameListener();
    private static IGetPlayerListener _getPlayerListener = new MyGetPlayerListener();
    private static IGetPlayerListener _getGamePlayerListener = new MyGetGamePlayerListener();
    private static IGetPlayerStatisticsListener _getPlayerStatisticsListener = new MyGetPlayerStatisticsListener();
    private static IGetCachePlayerIdListener _getCachePlayerIdListener = new MyGetCachePlayerIdListener();
    private static ISubmitPlayerEventListener _submitPlayerEventListener = new MySubmitPlayerEventListener();
    private static ISubmitPlayerEventListener _submitGameBeginEventListener = new MySubmitGameBeginEventListener();
    private static IGetPlayerExtraInfoListener _getPlayerExtraInfoListener = new MyGetPlayerExtraInfoListener();
    private static ISavePlayerInfoListener _savePlayerInfoListener = new MySavePlayerInfoListener();
    private static IGameTrialProcessListener _gameTrialProcessListener = new MyGameTrialProcessListener();
    private static ILimitSizeListener _limitSizeListener = new MyLimitSizeListener();
    private static IGetSnapshotDataListener _getSnapshotDataListener = new MyGetSnapshotDataListener();
    private static IGetAllSnapshotDataListener _getAllSnapshotDataListener = new MyGetAllSnapshotDataListener();
    private static IGetShowSnapshotListIntentListener _getShowSnapshotListIntentListener = new MyGetShowSnapshotListIntentListener();
    private static IGetCoverImageListener _getCoverImageListener = new MyGetCoverImageListener();
    private static IGetSnapshotResultListener _getSnapshotResultListener = new MyGetSnapshotResultListener();
    private static IGetSnapshotResultListener _updateSnapshotResultListener = new UpdateGetSnapshotResultListener();
    private static IDeleteSnapshotListener _deleteSnapshotListener = new MyDeleteSnapshotListener();


    // local variables
    private static List<string> achievementIds = new List<string>();
    private static List<string> eventIds = new List<string>();
    private static string rankingId = "";
    private static string snapshotId = "";
    private static SnapshotData tempSnapshotData;
    private static Snapshot tempSnapshot;
    private static AndroidJavaObject apkUpgradeInfo;
    private static string playerId = "";
    private static string openId = "";
    private static string transactionId = "";

    private static Text info_panel;
    private static Button init_button;
    private static Button login_button;
    private static Button current_player_button;
    private static Button check_update_button;
    private static Button achievement_button;
    private static Button event_button;
    private static Button ranking_button;
    private static Button game_button;
    private static Button gameSave_button;
    private static Button player_button;
    private static Button anti_addiction_button;
    private static Button float_button;
    private static Transform subaction_panel;

    public GameObject prefabButton;

    private readonly List<string> accountFunctionNames = new List<string>()
    {
        "login", "silentSignIn", "signOut", "cancelAuthorization", "startReadSms", "registerSMSBroadcastReceiver", "unregisterSMSBroadcastReceiver"
    };

    private readonly List<Action> accountFunctions = new List<Action>()
    {
        () =>
        {
            Show("starting login");
            AccountAuthParamsHelper authParamsHelper = new AccountAuthParamsHelper();
            authParamsHelper.SetAuthorizationCode().SetAccessToken().SetIdToken().SetUid().SetId().SetEmail().CreateParams();
            HuaweiGameService.Login(_loginListener);
        },
        () =>
        {
            Show("starting silentSignIn");
            HuaweiGameService.SilentSignIn(_loginListener);
        },
        () =>
        {
            Show("starting SignOut");
            HuaweiGameService.SignOut(_loginListener);
        },
        () =>
        {
            Show("starting cancelAuthorization");
            HuaweiGameService.CancelAuthorization(_cancelAuthListener);
        },
        () =>
        {
            Show("starting startReadSms");
            HuaweiGameService.StartReadSms(_startReadSmsListener);
        },
        () =>
        {
            Show("starting registerSMSBroadcastReceiver");
            HuaweiGameService.RegisterSMSBroadcastReceiver(_SMSReceive);
        },
        () =>
        {
            Show("starting unregisterSMSBroadcastReceiver");
            HuaweiGameService.UnregisterSMSBroadcastReceiver();
            Show("unregisterSMSBroadcastReceiver end");
        },
    };
    
    private readonly List<string> checkUpdateFunctionNames = new List<string>()
    {
        "CheckUpdate", "ReleaseCallBack"
    };

    private readonly List<Action> checkUpdateFunctions = new List<Action>()
    {
        () =>
        {
            Show("start check update.");
            HuaweiGameService.CheckUpdate(_checkUpdateListener);
        },
//        () =>
//        {
//            Show("start show update dialog.");
//            HuaweiGameService.ShowUpdateDialog(appUpdateInfo,true);
//        },
        () =>
        {
            Show("start release callback.");
            HuaweiGameService.ReleaseCallBack();
            Show("release callback end.");
        },
    };
        
    private readonly List<string> achievementFunctionNames = new List<string>()
    {
        "achievementList", "achievementsIntent", "reveal", "asyncReveal", "increment", "asyncIncrement", "setSteps",
        "asyncSetSteps", "unlock", "asyncUnlock"
    };

    private readonly List<Action> achievementFunctions = new List<Action>()
    {
        () =>
        {
            Show("start getting achievement list");
            HuaweiGameService.GetAchievementList(true, _getAchievementListListener);
        },
        () =>
        {
            Show("start getting achievement intent");
            HuaweiGameService.GetAchievementsIntent(_getAchievementsIntentListener);
        },
        () =>
        {
            Show("start revealing achievement.");
            if (achievementIds.Count == 0)
            {
                Show("no achievement found, please get list first.");
                return;
            }

            string id = achievementIds[0];
            Show("revealing achievement with id: " + id);
            HuaweiGameService.Reveal(id);
        },
        () =>
        {
            Show("start revealing achievement.");
            if (achievementIds.Count == 0)
            {
                Show("no achievement found, please get list first.");
                return;
            }

            string id = achievementIds[0];
            Show("async revealing achievement with id: " + id);
            HuaweiGameService.AsyncReveal(id, _revealListener);
        },
        () =>
        {
            int step = 3;
            Show("start increase achievement with step " + step);
            if (achievementIds.Count == 0)
            {
                Show("no achievement found, please get list first.");
                return;
            }

            string id = achievementIds[0];
            Show("increase achievement by " + step + " steps with id: " + id);
            HuaweiGameService.Increment(id, step);
        },
        () =>
        {
            int step = 3;
            Show("start async increase achievement with step " + step);
            if (achievementIds.Count == 0)
            {
                Show("no achievement found, please get list first.");
                return;
            }

            string id = achievementIds[0];
            Show("async increase achievement by " + step + " steps with id: " + id);
            HuaweiGameService.AsyncIncrement(id, step, _incrementListener);
        },
        () =>
        {
            int step = 3;
            Show("start set achievement with step " + step);
            if (achievementIds.Count == 0)
            {
                Show("no achievement found, please get list first.");
                return;
            }

            string id = achievementIds[0];
            Show("set achievement by " + step + " steps with id: " + id);
            HuaweiGameService.SetSteps(id, step);
        },
        () =>
        {
            int step = 3;
            Show("start async set achievement with step " + step);
            if (achievementIds.Count == 0)
            {
                Show("no achievement found, please get list first.");
                return;
            }

            string id = achievementIds[0];
            Show("set async achievement by " + step + " steps with id: " + id);
            HuaweiGameService.AsyncSetSteps(id, step, _setStepsListener);
        },
        () =>
        {
            Show("start unlock achievement");
            if (achievementIds.Count == 0)
            {
                Show("no achievement found, please get list first.");
                return;
            }

            string id = achievementIds[0];
            Show("start unlock achievement with id: " + id);
            HuaweiGameService.Unlock(id);
        },
        () =>
        {
            Show("start async unlock achievement");
            if (achievementIds.Count == 0)
            {
                Show("no achievement found, please get list first.");
                return;
            }

            string id = achievementIds[0];
            Show("start async unlock achievement with id: " + id);
            HuaweiGameService.AsyncUnlock(id, _unlockListener);
        },
    };

    private readonly List<string> eventFunctionNames = new List<string>()
    {
        "GetEventList", "GetEventListForceReload", "GetEventListByIds", "GetEventListByIdsForceReload", "EventIncrement"
    };

    private readonly List<Action> eventFunctions = new List<Action>()
    {
        () =>
        {
            Show("start getting event list forcereload false.");
            HuaweiGameService.GetEventList(false, _getEventListListener);
        },
        () =>
        {
            Show("start getting event list. forcereload true");
            HuaweiGameService.GetEventList(true, _getEventListListener);
        },
        () =>
        {
            Show("start getting event list by ids. forcereload false");
            if (eventIds.Count == 0)
            {
                Show("no event ids found, please get event list first");
                return;
            }

            HuaweiGameService.GetEventListByIds(false, eventIds.ToArray(), _getEventListListener);
        },
        () =>
        {
            Show("start getting event list by ids. forcereload true");
            if (eventIds.Count == 0)
            {
                Show("no event ids found, please get event list first");
                return;
            }

            HuaweiGameService.GetEventListByIds(true, eventIds.ToArray(), _getEventListListener);
        },
        () =>
        {
            Show("start EventIncrement with amount 1");
            if (eventIds.Count == 0)
            {
                Show("no event ids found, please get event list first");
                return;
            }

            string eventId = eventIds[0];
            HuaweiGameService.EventIncrement(eventId, 1);
        }
    };

    private readonly List<string> rankingFunctionNames = new List<string>()
    {
        "GetRankingsData", "GetRankingSwitchStatus", "SetRankingSwitchStatusClose", "SetRankingSwitchStatusOpen",
        "SubmitScore", "AsyncSubmitScore", "SubmitScoreWithTag", "AsyncSubmitScoreWithTag",
        "GetAllRankingIntent", "GetRankingIntent", "GetRankingIntent(timeSpan)", "GetRankingData",
        "GetRankingTopScores", "GetRankingTopScores(offsetPlayerRank)", "GetCurrentPlayerRankingScore", "GetPlayerCenteredRankingScores",
        "GetPlayerCenteredRankingScores(offsetPlayerRank)", "GetMoreRankingScores"
    };

    private readonly List<Action> rankingFunctions = new List<Action>()
    {
        () =>
        {
            Show("start GetRankingsData");

            HuaweiGameService.GetLeaderboardsData(true, _getLeaderboardsListener);
        },
        () =>
        {
            Show("start GetRankingSwitchStatus.");
            HuaweiGameService.GetLeaderboardSwitchStatus(_leaderboardSwitchStatusListener);
        },
        () =>
        {
            Show("start SetRankingSwitchStatus with status close");
            HuaweiGameService.SetLeaderboardSwitchStatus(0, _leaderboardSwitchStatusListener);
        },
        () =>
        {
            Show("start SetRankingSwitchStatus with status open");
            HuaweiGameService.SetLeaderboardSwitchStatus(1, _leaderboardSwitchStatusListener);
        },
        () =>
        {
            Show("start SubmitScore");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            Show("start SubmitScore with ranking id: " + rankingId + " score: " + 2);
            HuaweiGameService.SubmitScore(rankingId, 2);
        },
        () =>
        {
            Show("start AsyncSubmitScore");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            Show("start AsyncSubmitScore with ranking id: " + rankingId + " score: " + 2);
            HuaweiGameService.AsyncSubmitScore(rankingId, 2, _submitScoreListener);
        },
        () =>
        {
            Show("start SubmitScoreWithTag");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            Show("start SubmitScoreWithTag with ranking id: " + rankingId + " score: " + 2 +
                 " score tag: testScoreTag");
            HuaweiGameService.SubmitScore(rankingId, 2, "testScoreTag");
        },
        () =>
        {
            Show("start AsyncSubmitScoreWithTag");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            Show("start AsyncSubmitScoreWithTag with ranking id: " + rankingId + " score: " + 2 +
                 " score tag: testScoreTag");
            HuaweiGameService.AsyncSubmitScore(rankingId, 2, "testScoreTag", _submitScoreListener);
        },
        () =>
        {
            Show("start GetAllRankingIntent");

            HuaweiGameService.GetAllLeaderboardsIntent(_getLeaderboardIntentListener);
        },
        () =>
        {
            Show("start GetRankingIntent");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            HuaweiGameService.GetLeaderboardIntent(rankingId, _getLeaderboardIntentListener);
        },        
        () =>
        {
            Show("start GetRankingIntent, timeSpan==1");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            HuaweiGameService.GetLeaderboardIntent(rankingId,1, _getLeaderboardIntentListener);
        },
        () =>
        {
            Show("start GetRankingData");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            HuaweiGameService.GetLeaderboardData(rankingId, true, _getLeaderboardListener);
        },
        () =>
        {
            Show("start GetRankingTopScores");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }
            
            HuaweiGameService.GetLeaderboardTopScores(rankingId, 2, 10, true, _getLeaderboardScoresListener);
        },
        () =>
        {
            Show("start GetRankingTopScores-String rankingId, int timeDimension, int maxResults, long offsetPlayerRank");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }
            
            HuaweiGameService.GetLeaderboardTopScores(rankingId, 2, 10, 1, 0, _getLeaderboardScoresListener);
        },
        () =>
        {
            Show("start GetCurrentPlayerRankingScore");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            HuaweiGameService.GetCurrentPlayerLeaderboardScore(rankingId, 2, _getLeaderboardScoreListener);
        },
        () =>
        {
            Show("start GetPlayerCenteredRankingScores");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            HuaweiGameService.GetPlayerCenteredLeaderboardScores(rankingId, 2, 10, true, _getLeaderboardScoresListener);
        },
        () =>
        {
            Show("start GetPlayerCenteredRankingScores-String rankingId, int timeDimension,int maxResults, long offsetPlayerRank, int pageDirection");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            HuaweiGameService.GetPlayerCenteredLeaderboardScores(rankingId, 2, 10, 1, 0, _getLeaderboardScoresListener);
        },
        () =>
        {
            Show("start GetMoreRankingScores");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            //todo timespan field
            HuaweiGameService.GetMoreLeaderboardScores(rankingId, 0, 10, 0, 2, _getLeaderboardScoresListener);
        }
    };

    private readonly List<string> gameFunctionNames = new List<string>()
    {
        "GetGame", "GetLocalGame"
    };

    private readonly List<Action> gameFunctions = new List<Action>()
    {
        () =>
        {
            Show("start getting game.");
            HuaweiGameService.GetGame(_getGameListener);
        },
        () =>
        {
            Show("start getting local game.");
            HuaweiGameService.GetLocalGame(_getGameListener);
        },
    };

    private readonly List<string> playerFunctionNames = new List<string>()
    {
        "getGamePlayer","getGamePlayer(isRequirePlayerId)","getGamePlayerStatistics","getCachePlayerId","savePlayerInfo","setGameTrialProcess"
    };

    private readonly List<Action> playerFunctions = new List<Action>()
    {
        () =>
        {
            Show("start getGamePlayer.");
            HuaweiGameService.GetGamePlayer(_getGamePlayerListener);
        },
        () =>
        {
            Show("start getGamePlayer(isRequirePlayerId),isRequirePlayerId == true");
            HuaweiGameService.GetGamePlayer(true, _getGamePlayerListener);
        },
        () =>
        {
            Show("start getGamePlayerStatistics.");
            HuaweiGameService.GetGamePlayerStatistics(true, _getPlayerStatisticsListener);
        },
        () =>
        {
            Show("start getCachePlayerId");
            HuaweiGameService.GetCachePlayerId(_getCachePlayerIdListener);
        },
        () =>
        {
            Show("start savePlayerInfo");
            if (string.IsNullOrEmpty(playerId) || string.IsNullOrEmpty(openId))
            {
                Show("playerId or openId is empty, please get the playerId or openId first");
            }
            else
            {
                AppPlayerInfo appPlayerInfo = new AppPlayerInfo();
                appPlayerInfo.Rank = "test rank";
                appPlayerInfo.Area = "test area";
                appPlayerInfo.Role = "test role";
                appPlayerInfo.Sociaty = "test sociaty";
                appPlayerInfo.PlayerId = playerId;
                appPlayerInfo.OpenId = openId;
                HuaweiGameService.SavePlayerInfo(appPlayerInfo.ConvertToJavaObject(), _savePlayerInfoListener);
            }
        },
        () =>
        {
            Show("start setGameTrialProcess");
            HuaweiGameService.SetGameTrialProcess(_gameTrialProcessListener);
        },
    };
    
    private readonly List<string> antiAddictionFunctionNames = new List<string>()
    {
        "submitPlayerEvent(GAMEBEGIN)","submitPlayerEvent(GAMEEND)","getPlayerExtraInfo"
    };

    private readonly List<Action> antiAddictionFunctions = new List<Action>()
    {
        () =>
        {
            Show("start submitPlayerEvent(GAMEBEGIN)");
            if (string.IsNullOrEmpty(playerId))
            {
                Show("playerId is empty, please get the playerId first");
            }
            else
            {
                HuaweiGameService.SubmitPlayerEvent(playerId,System.Guid.NewGuid().ToString(),"GAMEBEGIN",_submitGameBeginEventListener);
            }
        },
        () =>
        {
            Show("start submitPlayerEvent(GAMEEND)");
            if (string.IsNullOrEmpty(playerId))
            {
                Show("playerId is empty, please get the playerId first");
            } 
            else if (string.IsNullOrEmpty(transactionId))
            {
                Show("transactionId is empty, please get the transactionId first");
            }
            else
            {
                HuaweiGameService.SubmitPlayerEvent(playerId,transactionId,"GAMEEND",_submitPlayerEventListener);
            }
        },
        () =>
        {
            Show("start getPlayerExtraInfo");
            if (string.IsNullOrEmpty(transactionId))
            {
                Show("transactionId is empty, please get the transactionId first");
            }
            else
            {
                HuaweiGameService.GetPlayerExtraInfo(transactionId, _getPlayerExtraInfoListener);
            }
        },   
    };   

    private readonly List<string> gameSaveFunctionNames = new List<string>()
    {
        "GrantDriveAccess", "GetLimitThumbnailSize", "GetLimitDetailsSize", "AddSnapshot", "GetSnapshotDataList",
        "GetShowArchiveListIntent", "GetThumbnail", "LoadSnapshotContents", "LoadSnapshotContents(snapshotData)",
        "LoadSnapshotContents(snapshotData,conflictPolicy)","UpdateSnapshot","UpdateSnapshot(conflict)", "DeleteSnapshot"
    };

    private readonly List<Action> gameSaveFunctions = new List<Action>()
    {
        () =>
        {
            Show("start GrantDriveAccess.");
            HuaweiGameService.GrantDriveAccess();
        },
        () =>
        {
            Show("start GetLimitThumbnailSize.");
            HuaweiGameService.GetLimitThumbnailSize(_limitSizeListener);
        },
        () =>
        {
            Show("start GetLimitDetailsSize.");
            HuaweiGameService.GetLimitDetailsSize(_limitSizeListener);
        },
        () =>
        {
            Show("start AddSnapshot. with fake img and description: " + "demo description");
            SnapshotContent content = new SnapshotContent();
            content.Content = System.Text.Encoding.UTF8.GetBytes("test add snapshot content");
            SnapshotChange snapshotChange = new SnapshotChange();
            snapshotChange.Description = "demo add snapshot description";
            snapshotChange.PlayedTimeMillis = 600;
            snapshotChange.CurrentProgress = 50;
            snapshotChange.CoverImage = bitmap_bytes;
            snapshotChange.ImageMimeType = "png";

            HuaweiGameService.AddSnapshot(content, snapshotChange, true, _getSnapshotDataListener);
        },
        () =>
        {
            Show("start GetSnapshotDataList.");
            HuaweiGameService.GetSnapshotDataList(true, _getAllSnapshotDataListener);
        },        
        () =>
        {
            Show("start GetShowArchiveListIntent.");
            HuaweiGameService.GetShowArchiveListIntent("archive title",true,true,-1, _getShowSnapshotListIntentListener);
        },
        () =>
        {
            Show("start GetThumbnail.");
            if (snapshotId == "" || tempSnapshotData == null)
            {
                Show("no snapshot id found, GetSnapshotDataList or AddOne first.");
            }

            HuaweiGameService.GetThumbnail(tempSnapshotData.SnapshotId, _getCoverImageListener);
        },
        () =>
        {
            Show("start LoadSnapshotContents.");
            if (snapshotId == "")
            {
                Show("no snapshot id found, GetSnapshotDataList or AddOne first.");
                return;
            }

            HuaweiGameService.LoadSnapshotContents(snapshotId, 1, _getSnapshotResultListener);
        },
        () =>
        {
            Show("start LoadSnapshotContents(snapshotData).");
            if (tempSnapshotData == null)
            {
                Show("no snapshot found, GetSnapshotDataList or AddOne first.");
                return;
            }

            HuaweiGameService.LoadSnapshotContents(tempSnapshotData, _getSnapshotResultListener);
        },
        () =>
        {
            Show("start LoadSnapshotContents(snapshotData,conflictPolicy), conflictPolicy == 1.");
            if (tempSnapshotData == null)
            {
                Show("no snapshot found, GetSnapshotDataList or AddOne first.");
                return;
            }

            HuaweiGameService.LoadSnapshotContents(tempSnapshotData, 1, _getSnapshotResultListener);
        },
        () =>
        {
            Show("start UpdateSnapshot.");
            if (snapshotId == "")
            {
                Show("no snapshot id found, GetSnapshotDataList or AddOne first.");
                return;
            }

            SnapshotContent content = new SnapshotContent();
            content.Content = System.Text.Encoding.UTF8.GetBytes("test update snapshot content");
            SnapshotChange snapshotChange = new SnapshotChange();
            snapshotChange.Description = "updated demo description";
            snapshotChange.PlayedTimeMillis = 2000;
            snapshotChange.CurrentProgress = 100;

            HuaweiGameService.UpdateSnapshot(snapshotId, snapshotChange, content, _updateSnapshotResultListener);
        },
        () =>
        {
            Show("try to update the conflicting snapshot. start UpdateSnapshot.");
            if (snapshotId == "")
            {
                Show("no snapshot id found, GetSnapshotDataList or AddOne first.");
                return;
            }

            SnapshotContent content = new SnapshotContent();
            content.Content = System.Text.Encoding.UTF8.GetBytes("try to update the conflicting snapshot");
            SnapshotChange snapshotChange = new SnapshotChange();
            snapshotChange.Description = "updated conflicting description";
            snapshotChange.PlayedTimeMillis = 600;
            snapshotChange.CurrentProgress = 50;

            HuaweiGameService.UpdateSnapshot(snapshotId, snapshotChange, content, _updateSnapshotResultListener);
        },
        () =>
        {
            Show("start DeleteSnapshot.");
            if (snapshotId == "" || tempSnapshotData == null)
            {
                Show("no snapshot found, GetSnapshotDataList or AddOne first.");
                return;
            }

            HuaweiGameService.DeleteSnapshot(tempSnapshotData, _deleteSnapshotListener);
        },
    };

    private readonly List<string> floatFunctionNames = new List<string>()
    {
        "ShowFloatWindow", "HideFloatWindow"
    };

    private readonly List<Action> floatFunctions = new List<Action>()
    {
        () =>
        {
            Show("start ShowFloatWindow.");
            HuaweiGameService.ShowFloatWindow();
        },
        () =>
        {
            Show("start HideFloatWindow.");
            HuaweiGameService.HideFloatWindow();
        },
    };

    // Use this for initialization
    void Start()
    {
        initUI();
        initListeners();
        appInit();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void appInit()
    {
        Show("starting appInit");
        HuaweiGameService.AppInit();
        Show("appInit finished");
    }

    private void initUI()
    {
        info_panel = GameObject.Find("Information").GetComponent<Text>();
        subaction_panel = GameObject.Find("SubActionPanel").GetComponent<Transform>();
        init_button = GameObject.Find("initBtn").GetComponent<Button>();
        login_button = GameObject.Find("loginBtn").GetComponent<Button>();
        current_player_button = GameObject.Find("currentPlayerBtn").GetComponent<Button>();
        check_update_button = GameObject.Find("CheckUpdateBtn").GetComponent<Button>();
        achievement_button = GameObject.Find("Achievement").GetComponent<Button>();
        event_button = GameObject.Find("Event").GetComponent<Button>();
        ranking_button = GameObject.Find("Ranking").GetComponent<Button>();
        game_button = GameObject.Find("Game").GetComponent<Button>();
        gameSave_button = GameObject.Find("GameSave").GetComponent<Button>();
        player_button = GameObject.Find("Player").GetComponent<Button>();
        anti_addiction_button = GameObject.Find("AntiAddictionBtn").GetComponent<Button>();
        float_button = GameObject.Find("Float").GetComponent<Button>();

        clearSubActionPanel();
    }

    private void initListeners()
    {
        init_button.onClick.AddListener(() =>
        {
            Show("starting init");
            HuaweiGameService.Init();
            Show("init finished");

        });
        login_button.onClick.AddListener(onAccountBtnClick);
        current_player_button.onClick.AddListener(() =>
        {
            Show("start getCurrentPlayer.");
            HuaweiGameService.GetCurrentPlayer(true, _getPlayerListener);
        });
        check_update_button.onClick.AddListener(onCheckUpdateBtnClick);
        achievement_button.onClick.AddListener(onAchievementBtnClick);
        event_button.onClick.AddListener(onEventBtnClick);
        ranking_button.onClick.AddListener(onRankingBtnClick);
        game_button.onClick.AddListener(onGameBtnClick);
        gameSave_button.onClick.AddListener(onGameSaveBtnClick);
        player_button.onClick.AddListener(onPlayerBtnClick);
        anti_addiction_button.onClick.AddListener(onAntiAddictionBtnClick);
        float_button.onClick.AddListener(onFloatBtnClick);
    }

    private void onAccountBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < accountFunctionNames.Count; i++)
        {
            var name = accountFunctionNames[i];
            var handler = accountFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.GetComponentInChildren<Text>().fontSize = 36;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }
    
    private void onCheckUpdateBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < checkUpdateFunctionNames.Count; i++)
        {
            var name = checkUpdateFunctionNames[i];
            var handler = checkUpdateFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.GetComponentInChildren<Text>().fontSize = 36;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }

    private void onAchievementBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < achievementFunctionNames.Count; i++)
        {
            var name = achievementFunctionNames[i];
            var handler = achievementFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }

    private void onEventBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < eventFunctionNames.Count; i++)
        {
            var name = eventFunctionNames[i];
            var handler = eventFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.GetComponentInChildren<Text>().fontSize = 36;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }

    private void onRankingBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < rankingFunctionNames.Count; i++)
        {
            var name = rankingFunctionNames[i];
            var handler = rankingFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.GetComponentInChildren<Text>().fontSize = 36;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }

    private void onGameSaveBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < gameSaveFunctionNames.Count; i++)
        {
            var name = gameSaveFunctionNames[i];
            var handler = gameSaveFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.GetComponentInChildren<Text>().fontSize = 36;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }

    private void onGameBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < gameFunctionNames.Count; i++)
        {
            var name = gameFunctionNames[i];
            var handler = gameFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }

    private void onPlayerBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < playerFunctionNames.Count; i++)
        {
            var name = playerFunctionNames[i];
            var handler = playerFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.GetComponentInChildren<Text>().fontSize = 36;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }

    private void onAntiAddictionBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < antiAddictionFunctionNames.Count; i++)
        {
            var name = antiAddictionFunctionNames[i];
            var handler = antiAddictionFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.GetComponentInChildren<Text>().fontSize = 36;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        } 
    }

    private void onFloatBtnClick()
    {
        clearSubActionPanel();
        for (int i = 0; i < floatFunctionNames.Count; i++)
        {
            var name = floatFunctionNames[i];
            var handler = floatFunctions[i];
            GameObject goButton = (GameObject) Instantiate(prefabButton);
            goButton.transform.SetParent(subaction_panel, false);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = name;
            tempButton.name = name;
            tempButton.onClick.AddListener(() => handler());
            tempButton.gameObject.SetActive(true);
        }
    }

    private void clearSubActionPanel()
    {
        foreach (Transform child in subaction_panel)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public class MyLoginListener : ILoginListener
    {
        public void OnSuccess(SignInAccountProxy signInAccountProxy)
        {
            if (signInAccountProxy == null)
            {
                Show("signInAccountProxy == null");
                return;
            }
            string msg = "get login success with signInAccountProxy info: \n";
            msg += String.Format("displayName:{0}, email:{1}, uid:{2}, openId:{3}, unionId:{4}, accessToken:{5}, serverAuthCode:{6}, idToken:{7}",
            signInAccountProxy.DisplayName, signInAccountProxy.Email, signInAccountProxy.Uid, signInAccountProxy.OpenId, signInAccountProxy.UnionId,
            signInAccountProxy.AccessToken, signInAccountProxy.ServerAuthCode, signInAccountProxy.IdToken);
            Show(msg);
        }

        public void OnSignOut()
        {
            string msg = "sign out success.";
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            string msg = "account method failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyCancelAuthListener : ICancelAuthListener
    {
        public void OnSuccess()
        {
            string msg = "cancelAuthorization success.";
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            string msg = "cancelAuthorization failed, code:" + code + " message:" + message;
            Show(msg);
        } 
    }

    public class MyStartReadSmsListener : IStartReadSmsListener
    {
        public void OnSuccess()
        {
            string msg = "startReadSms success.";
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            string msg = "startReadSms failed, code:" + code + " message:" + message;
            Show(msg);
        } 
    }

    public class MySMSReceive : ISMSReceive
    {
        public void OnMessage(string message)
        {
            string msg = "get SMS message: " + message;
            Show(msg);
        }

        public void OnTimeOut()
        {
            string msg = "get SMS message timeout";
            Show(msg); 
        }
    }

    public class MyCheckUpdateListener : ICheckUpdateListener
    {
       public  void OnUpdateInfo(AndroidJavaObject intent)
        {
            if (intent !=null)
            {
                int status = intent.Call<int>("getIntExtra", "status", 0);
                Show("OnUpdateInfo status: " + status);
                if (status==0)
                {
                    return;
                }

                if (status == 7)
                {
                    apkUpgradeInfo = intent.Call<AndroidJavaObject>("getSerializableExtra", "updatesdk_update_info");
                    Show("start ShowUpdateDialog");
                    HuaweiGameService.ShowUpdateDialog(apkUpgradeInfo, false);
                }
            }
        }

       public void OnMarketInstallInfo(AndroidJavaObject intent)
       {
           
       }

       public void OnMarketStoreError(int responseCode)
       {
           
       }

       public void OnUpdateStoreError(int responseCode)
       {
           
       }
    }

    // listeners
    public class MyGetAchievementListListener : IGetAchievementListListener
    {
        public void OnSuccess(List<Achievement> achievementList)
        {
            if (achievementList == null)
            {
                Show("achievementList == null");
                return;
            }
            string message = "get achievement list success with count :" + achievementList.Count + "\n";
            achievementIds = new List<string>();

            foreach (var ach in achievementList)
            {
                message += string.Format(
                    "id:{0}, type:{1}, name:{2}, description:{3}, totalSteps:{4}, currentStep:{5}, state:{6}, LocaleReachedSteps:{7}, LocaleAllSteps:{8}, playerId:{9} \n",
                    ach.AchievementId,
                    ach.Type,
                    ach.Name,
                    ach.Description,
                    ach.TotalSteps,
                    ach.CurrentSteps,
                    ach.State,
                    ach.LocaleReachedSteps,
                    ach.LocaleAllSteps,
                    ach.GamePlayer.PlayerId
                );
                achievementIds.Add(ach.AchievementId);
            }

            Show(message);
        }

        public void OnFailure(int code, string message)
        {
            string msg = "get achievement list failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetAchievementIntentListener : IGetAchievementsIntentListener
    {
        public void OnSuccess(AndroidJavaObject intent)
        {
            if (intent == null)
            {
                Show("intent == null");
                return;
            }
            string msg = "get achievement intent success.";
            Show(msg);
            if (intent != null)
            {
                startIntent(intent, 3000);
            }
        }

        public void OnFailure(int code, string message)
        {
            string msg = "get achievement intent failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyRevealListener : IRevealListener
    {
        public void OnSuccess()
        {
            string msg = "reveal success.";
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            string msg = "reveal failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyIncrementListener : IIncrementListener
    {
        public void OnSuccess(bool isSuccess)
        {
            string msg = "AsyncIncrement success with success status: " + isSuccess;
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            string msg = "AsyncIncrement failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MySetStepsListener : ISetStepsListener
    {
        public void OnSuccess(bool isSuccess)
        {
            string msg = "AsyncSetSteps success with success status: " + isSuccess;
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "AsyncSetSteps failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyUnlockListener : IUnlockListener
    {
        public void OnSuccess()
        {
            string msg = "AsyncUnlock success";
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "AsyncUnlock failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    // Leader board
    public class MyLeaderboardSwitchStatusListener : ILeaderboardSwitchStatusListener
    {
        public void OnSuccess(int statusValue)
        {
            string msg = "success with statusValue: " + statusValue;
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "switch status failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MySubmitScoreListener : ISubmitScoreListener
    {
        public void OnSuccess(ScoreSubmission scoreSubmission)
        {
            if (scoreSubmission == null)
            {
                Show("socreSubmission == null");
                return;
            }
            string msg = "success submitted.";
            msg += string.Format("leaderboard id:{0}, playerId:{1}, scoreResults: \n", scoreSubmission.LeaderboardId,
                scoreSubmission.PlayerId);

            foreach (KeyValuePair<int, ScoreSubmission.Result> r in scoreSubmission.ScoreResults)
            {
                msg += string.Format("key: {0}, rawScore:{1}, formattedScore:{2}, scoreTag:{3}, isBest:{4}; \n", r.Key,
                    r.Value.RawScore, r.Value.FormattedScore, r.Value.ScoreTag, r.Value.IsBest);
            }

            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "subscore failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetLeaderboardIntentListener : IGetLeaderboardIntentListener
    {
        public void OnSuccess(AndroidJavaObject intent)
        {
            if (intent == null)
            {
                Show("intent == null");
                return;
            }
            var msg = "get leader board intent succeed";
            Show(msg);
            if (intent!=null)
            {
                startIntent(intent, 100);
            }
        }

        public void OnFailure(int code, string message)
        {
            var msg = "get leaderboard failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetLeaderboardsListener : IGetLeaderboardsListener
    {
        public void OnSuccess(List<LeaderboardProxy> leaderboards)
        {
            if (leaderboards == null)
            {
                Show("leaderboards == null");
                return;
            }
            var msg = "get leader board data succeed with count: " + leaderboards.Count + "\n";
            foreach (var l in leaderboards)
            {
                msg += string.Format("leaderBoardId: {0}, display name:{1}, score order:{2} \n", l.LeaderboardId,
                    l.LeaderboardDisplayName, l.LeaderboardScoreOrder);
                if (rankingId == "")
                {
                    rankingId = l.LeaderboardId;
                }
            }

            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "get leader board data failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetLeaderboardListener : IGetLeaderboardListener
    {
        public void OnSuccess(LeaderboardProxy leaderboardProxy)
        {
            if (leaderboardProxy == null)
            {
                Show("leaderboard == null");
                return;
            }
            var msg = "get leader board data succeed. \n";
            msg += string.Format("leaderboard Id: {0}, display name: {1}, score order:{2}",
                leaderboardProxy.LeaderboardId, leaderboardProxy.LeaderboardDisplayName,
                leaderboardProxy.LeaderboardScoreOrder);
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "get leader board data failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetLeaderboardScoresListener : IGetLeaderboardScoresListener
    {
        public void OnSuccess(LeaderboardScores leaderboardScores)
        {
            if (leaderboardScores == null)
            {
              Show("get succeed, but leaderboardScores == null");
              return;
            }
            var msg = "get succeed. \n";
            msg += string.Format("leaderboard id: {0}, display name:{1} \n",
                leaderboardScores.LeaderboardProxy.LeaderboardId,
                leaderboardScores.LeaderboardProxy.LeaderboardDisplayName);

            foreach (var score in leaderboardScores.LeaderboardScoreList)
            {
                msg += string.Format("rank:{0}, score:{1}, timespan:{2}, player rank:{3}, scoreTag:{4}, \n",
                    score.DisplayRank,
                    score.PlayerRawScore, score.TimeSpan, score.PlayerRank, score.ScoreTag);
            }

            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "get leaderboard scores failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetLeaderboardScoreListener : IGetLeaderboardScoreListener
    {
        public void OnSuccess(LeaderboardScore score)
        {
            if (score == null)
            {
                Show("leaderboardScore == null");
                return;
            }
            var msg = "get currentplayer leaderboard succeed. \n";
            msg += string.Format("rank:{0}, score:{1}, timespan:{2}, player rank:{3}, scoreTag:{4}, \n",
                score.DisplayRank,
                score.PlayerRawScore, score.TimeSpan, score.PlayerRank, score.ScoreTag);
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "get currentplayer leaderboard score failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    // Event
    public class MyGetEventListListener : IGetEventListListener
    {
        public void OnSuccess(List<EventProxy> eventList)
        {
            if (eventList == null)
            {
                Show("eventList == null");
                return;
            }
            var msg = "get event list succeed. \n";
            eventIds.Clear();
            foreach (var e in eventList)
            {
                msg += string.Format(
                    "event id:{0}, name:{1}, description:{2}, value:{3}, isvisiable:{4}, \n player info: player name:{5}, player id:{6} \n",
                    e.EventId, e.Name, e.Description, e.Value, e.IsVisible, e.Player.DisplayName, e.Player.PlayerId
                );
                eventIds.Add(e.EventId);
            }

            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "get event list failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    // player
    public class MyGetPlayerListener : IGetPlayerListener
    {
        public void OnSuccess(Player player)
        {
            if (player == null)
            {
                Show("player == null");
                return;
            }
            var msg = "getCurrentPlayer succeed. \n";
            msg += string.Format(
                "displayName:{0}, playerId:{1}, signTimestamp:{2}, playerSign:{3}, level:{4}, openId:{5}, unionId:{6}",
                player.DisplayName, player.PlayerId, player.SignTimestamp, player.PlayerSign, player.Level, player.OpenId, player.UnionId
            );
            Show(msg);
            playerId = player.PlayerId;
        }

        public void OnFailure(int code, string message)
        {
            var msg = "getCurrentPlayer failed, code:" + code + " message:" + message;
            Show(msg); 
        }
    }
    
    public class MyGetGamePlayerListener : IGetPlayerListener
    {
        public void OnSuccess(Player player)
        {
            if (player == null)
            {
                Show("player == null");
                return;
            }
            var msg = "getGamePlayer succeed. \n";
            msg += string.Format(
                "displayName:{0}, playerId:{1}, playerSign:{2}, openId:{3}, unionId:{4}, openIdSign:{5}, accessToken:{6}",
                player.DisplayName, player.PlayerId, player.PlayerSign, player.OpenId, player.UnionId, player.OpenIdSign, player.AccessToken
            );
            Show(msg);
            playerId = player.PlayerId;
            openId = player.OpenId;
        }

        public void OnFailure(int code, string message)
        {
            var msg = "getCurrentPlayer failed, code:" + code + " message:" + message;
            Show(msg); 
        }
    }
    
    public class MyGetPlayerStatisticsListener : IGetPlayerStatisticsListener
    {
        public void OnSuccess(PlayerStatistics playerStatistics)
        {
            if (playerStatistics == null)
            {
                Show("playerStatistics == null");
                return;
            }
            var msg = "GetGamePlayerStatistics succeed. \n";
            msg += string.Format(
                "average session length:{0}, day since played:{1}, num of sessions:{2}, num of purchases:{3}, total purchase:{4}",
                playerStatistics.AverageSessionLength, playerStatistics.DaysSinceLastPlayed,
                playerStatistics.NumberOfSessions, playerStatistics.NumberOfPurchases,
                playerStatistics.TotalPurchasesAmountRange
            );
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "GetGamePlayerStatistics failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetCachePlayerIdListener : IGetCachePlayerIdListener
    {
        public void OnSuccess(string cachePlayerId)
        {
            var msg = "GetCachePlayerId succeed. \n cachePlayerId: "+cachePlayerId;
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "GetCachePlayerId failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }
    
    public class MySubmitGameBeginEventListener : ISubmitPlayerEventListener
    {
        public void OnSuccess(string jsonRequest)
        {
            var msg = "SubmitPlayerEvent succeed. \n jsonRequest: "+jsonRequest;
            Show(msg);
            try
            {
                AndroidJavaObject jo = new AndroidJavaObject("org.json.JSONObject",jsonRequest);
                transactionId = jo.Call<string>("getString", "transactionId");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
 
        }

        public void OnFailure(int code, string message)
        {
            var msg = "SubmitPlayerEvent failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MySubmitPlayerEventListener : ISubmitPlayerEventListener
    {
        public void OnSuccess(string jsonRequest)
        {
            var msg = "SubmitPlayerEvent succeed. \n jsonRequest: "+jsonRequest;
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "SubmitPlayerEvent failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MySavePlayerInfoListener : ISavePlayerInfoListener
    {
        public void OnSuccess()
        {
            var msg = "SavePlayerInfo succeed.";
            Show(msg);
        }
        
        public void OnFailure(int code, string message)
        {
            var msg = "SavePlayerInfo failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGameTrialProcessListener : IGameTrialProcessListener
    {
        public void OnTrialTimeout()
        {
            var msg = "The trial ends.";
            Show(msg);
        }

        public void OnCheckRealNameResult(bool hasRealName)
        {
            if (hasRealName)
            {
                Show("The player has performed identity verification. Proceed with sign-in processing.");
                return;
            }

            Show(
                "The player has not performed identity verification. You are advised to display a message to the player and make the player exit the game, or instruct the player to sign in again and perform identity verification.");
        }
    }

    public class MyGetPlayerExtraInfoListener : IGetPlayerExtraInfoListener
    {
        public void OnSuccess(PlayerExtraInfo playerExtraInfo)
        {
            if (playerExtraInfo == null)
            {
                Show("playerExtraInfo == null");
                return;
            }
            var msg = "GetPlayerExtraInfo succeed. \n";
            msg += string.Format(
                "isAdult:{0}, playerId:{1}, playerDuration:{2}, isRealName:{3}, openId:{4}",
                playerExtraInfo.IsAdult, playerExtraInfo.PlayerId, playerExtraInfo.PlayerDuration, playerExtraInfo.IsRealName, playerExtraInfo.OpenId
            );
            Show(msg); 
        }

        public void OnFailure(int code, string message)
        {
            var msg = "GetPlayerExtraInfo failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }
    
    public class MyGetGameListener : IGetGameListener
    {
        public void OnSuccess(Game game)
        {
            if (game == null)
            {
                Show("game == null");
                return;
            }
            var msg = "GetGamePlayerStatistics succeed. \n";
            msg += string.Format(
                "AchievementTotalCount:{0}, application id:{1}, description:{2}, display name:{3}, leaderboard count:{4}, primary category:{5}, seconday category:{6}",
                game.AchievementTotalCount, game.ApplicationId, game.Description, game.DisplayName,
                game.LeaderboardCount, game.PrimaryCategory, game.SecondaryCategory
            );
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "get game failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyLimitSizeListener : ILimitSizeListener
    {
        public void OnSuccess(int limitSize)
        {
            var msg = "GetLimitSize succeed. with limit size: " + limitSize + "\n";
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "GetLimitSize failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetSnapshotDataListener : IGetSnapshotDataListener
    {
        public void OnSuccess(SnapshotData snapshotData)
        {
            if (snapshotData == null)
            {
                Show("snapshotData == null");
                return;
            }
            var msg = "AddSnapshot succeed. \n";
            msg += string.Format(
                "snapshot id{0}, unique name{1}, player name:{2}, played time:{3}, progress value:{4}, desc:{5}, gameName:{6}",
                snapshotData.SnapshotId, snapshotData.UniqueName, snapshotData.Player != null ? snapshotData.Player.DisplayName : "", snapshotData.PlayedTime,
                snapshotData.ProgressValue, snapshotData.Description, snapshotData.Game != null ? snapshotData.Game.DisplayName : "");
            Show(msg);

            snapshotId = snapshotData.SnapshotId;
            tempSnapshotData = snapshotData;
        }

        public void OnFailure(int code, string message)
        {
            var msg = "AddSnapshot failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetShowSnapshotListIntentListener : IGetShowSnapshotListIntentListener
    {
        public void OnSuccess(AndroidJavaObject intent)
        {
            if (intent == null)
            {
                Show("intent == null");
                return;
            }
            var msg = "GetShowArchiveListIntent intent succeed";
            Show(msg);
            if (intent!=null)
            {
                startIntent(intent, 100);
            }
        }

        public void OnFailure(int code, string message)
        {
            var msg = "GetShowArchiveListIntent failed, code:" + code + " message:" + message;
            Show(msg);
        } 
    }

    public class MyGetAllSnapshotDataListener : IGetAllSnapshotDataListener
    {
        public void OnSuccess(List<SnapshotData> allSnapshotData)
        {
            if (allSnapshotData == null)
            {
                Show("allSnapshotData == null");
                return;
            }
            var msg = "AddSnapshot succeed. \n";

            foreach (var snapshotData in allSnapshotData)
            {
                msg += string.Format(
                    "snapshot id:{0}, unique name:{1}, player name:{2}, played time:{3}, progress value:{4}, desc:{5}, gameName:{6} \n",
                    snapshotData.SnapshotId, snapshotData.UniqueName, snapshotData.Player != null ? snapshotData.Player.DisplayName : "", snapshotData.PlayedTime,
                    snapshotData.ProgressValue, snapshotData.Description, snapshotData.Game != null ? snapshotData.Game.DisplayName : "");
            }
            if (allSnapshotData!=null && allSnapshotData.Count >0)
            {
                SnapshotData sd = allSnapshotData[0];
                snapshotId = sd.SnapshotId;
                tempSnapshotData = sd;
            }

            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "GetSnapshotDataList failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetCoverImageListener : IGetCoverImageListener
    {
        public void OnSuccess(string coverImage)
        {
            if (coverImage == null)
            {
                Show("coverImage == null");
                return;
            }
            var msg = "LoadCoverImage succeed. coverImg: " + coverImage;
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "LoadCoverImage failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetSnapshotResultListener : IGetSnapshotResultListener
    {
        public void OnSuccess(SnapshotResult snapshotResult)
        {
            if (snapshotResult == null)
            {
                Show("snapshotResult == null");
                return;
            }
            var msg = "snapshot operation success. \n";
            msg += string.Format("id: {0}, description:{1}", snapshotResult.Snapshot.SnapshotData.SnapshotId,
                snapshotResult.Snapshot.SnapshotData.Description);
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "snapshot operation failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }
    
    public class UpdateGetSnapshotResultListener : IGetSnapshotResultListener
    {
        public void OnSuccess(SnapshotResult snapshotResult)
        {
            var msg = "update snapshot operation success.";
            if (snapshotResult.IsDifference())
            {
                msg += "There is a data conflict. \n start handleConflict... \n";
                msg += "chose server archive... \n";
                Snapshot serverSnapshot = snapshotResult.SnapshotConflict.ServerSnapshot;
//                demo selects the archive on the server side, you can try to get the archive to be modified when conflict occurs
//                Snapshot conflictSnapshot = snapshotResult.SnapshotConflict.ConflictSnapshot;
                if (serverSnapshot == null)
                {
                    msg += "serverSnapshot == null.";
                    Show(msg);
                    return;
                }

                msg += "start UpdateSnapshot(snapshot)...";
                HuaweiGameService.UpdateSnapshot(serverSnapshot, _updateSnapshotResultListener);
            }
            else
            {
                msg += "There is no data conflict. \n";
                msg += string.Format("id: {0}, playedTime:{1}, progressValue:{2}, description:{3}", snapshotResult.Snapshot.SnapshotData.SnapshotId,
                    snapshotResult.Snapshot.SnapshotData.PlayedTime, snapshotResult.Snapshot.SnapshotData.ProgressValue, snapshotResult.Snapshot.SnapshotData.Description);
                Show(msg);
            }
        }

        public void OnFailure(int code, string message)
        {
            var msg = "snapshot operation failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyDeleteSnapshotListener : IDeleteSnapshotListener
    {
        public void OnSuccess(string snapshotId)
        {
            if (snapshotId == null)
            {
                Show("snapshotId == null");
                return;
            }
            var msg = "snapshot delete success. id: " + snapshotId;
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "DeleteSnapshot failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    // Helper func
    private Button GetButton(string buttonName)
    {
        GameObject obj = GameObject.Find(buttonName);
        if (obj != null)
        {
            return obj.GetComponent<Button>();
        }

        return null;
    }

    private static void Show(string message, bool append = false)
    {
        TaskProcess.tasks.AddFirst(() =>
        {
            info_panel.text = append ? string.Format("{0}\n{1}", info_panel.text, message) : message;
            Log(message);
        });
    }

    private static void Log(string message)
    {
        string prefix = "[UDPService]";
        Debug.Log(prefix + " " + message);
    }

    private static void startIntent(AndroidJavaObject intent, int requestCode)
    {
        AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = player.GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call("startActivityForResult", intent, requestCode);
    }
    
    private static sbyte[] bitmap_bytes = new sbyte[]{-119, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 48, 0, 0, 0, 48, 8, 6, 0, 0, 0, 87, 2, -7, -121, 0, 0, 0, 1, 115, 82, 71, 66, 0, -82, -50, 28, -23, 0, 0, 0, 4, 115, 66, 73, 84, 8, 8, 8, 8, 124, 8, 100, -120, 0, 0, 8, -80, 73, 68, 65, 84, 104, -127, -19, -103, 93, -116, 36, 85, 21, -57, 127, -73, -22, -42, 87, -9, -52, -12, 116, -49, 14, -18, -78, -20, -110, 93, 100, -119, -77, -80, 100, 33, 68, 52, 66, 48, 46, -122, 4, 52, -111, -56, 24, -116, 68, 125, 16, -94, -113, 126, -60, -56, -117, 77, -120, -128, -119, 65, -94, 79, -6, 68, -116, 38, -78, 107, 80, 36, 36, 104, 92, 3, 9, -120, 47, 60, -112, 13, -117, 10, 27, -123, -80, -61, 126, -12, -50, -50, 76, 79, -9, 116, 125, -36, 123, 125, -88, -2, -88, -22, -86, -39, 101, -122, -35, -80, 15, -100, -92, -46, 85, -89, -49, -71, -9, 127, -18, 61, -25, -36, 115, -86, -32, 35, -6, 112, 73, -100, -13, -33, -125, -9, -40, 28, -35, 123, 110, -103, -117, 77, 115, -81, 27, -26, 15, -87, -115, 41, 53, -101, 22, -51, -90, 117, 113, 16, 109, -126, -50, -127, -89, -72, -70, -87, -80, 6, -32, -111, 31, -51, 96, -23, 42, -119, 52, 0, -115, 32, 96, 113, 109, 45, 39, -34, 8, 96, 49, -49, 34, 0, -126, 18, 126, -71, 126, -111, 23, 4, -23, -17, 90, -100, 8, -76, -43, -31, -63, 71, -49, 20, -80, -11, 73, -106, -126, 111, 54, 43, 91, 106, -30, 103, -83, 78, -9, 110, -108, 118, 32, 2, -64, -62, 1, 19, -27, 84, -76, -87, 32, 69, 68, -94, -109, 33, 47, 113, 28, -108, 113, -64, 116, 115, -78, 101, -6, 101, 60, 91, -5, 36, 90, 67, -84, 65, 16, -13, -109, 31, 62, 77, 28, 124, -97, 102, -77, 59, 110, 68, -34, -128, 62, 109, -103, -28, -15, -122, 23, 60, -128, -55, -13, 119, 78, -43, 64, -28, 55, 109, 107, 117, -126, 69, -71, 70, -92, 71, 110, -22, -37, -110, 41, -49, -61, -79, -84, -13, -22, -105, -15, -22, 126, 64, -94, 20, 109, 103, 104, -40, -73, -79, 66, -89, 5, -9, -113, 99, 29, 105, 30, -68, -57, 102, -2, -112, -94, -7, -67, 45, 72, -5, -24, -106, 74, 117, -74, -43, -23, 68, 8, -28, -64, -112, -113, -41, 103, 120, -21, -20, -103, -36, 0, 59, -90, -90, 56, -35, -19, -46, 75, 70, 59, 80, 113, 28, -22, -66, -49, -15, 118, 59, 39, 91, -90, 95, -58, -101, -83, 84, -120, -107, 102, 41, -22, -127, 33, 65, 8, 87, -60, 113, 43, 88, 94, -35, -41, 125, -30, -41, -17, 13, -79, 2, -93, 37, 26, 100, -101, -59, 51, 117, -76, 118, -6, 92, 9, 88, -120, -12, 18, 66, 12, -17, 71, 87, 25, -81, -100, 95, -90, 127, -50, 49, 83, 124, 3, 47, 113, -84, -27, 78, 61, -121, 53, 103, -64, -128, -42, -76, -64, -78, 76, -127, 127, 41, -112, -42, -123, -92, 83, -98, 42, 75, 4, 47, 9, 42, -63, 85, 8, -30, 73, -41, -61, -85, 86, -39, 57, 85, 99, -38, -11, 17, -103, 0, -69, -78, 86, 47, -116, -71, 109, 98, -110, -102, -25, 19, 38, -103, 32, -106, -110, -102, -25, 83, -111, 110, 78, -74, 76, -65, -116, -41, 8, 2, 98, -83, 105, -121, 33, -58, 24, -124, 16, -104, 40, 38, 116, 79, -77, 122, 62, 3, -38, 81, 72, -69, -45, 1, 97, -47, -22, 116, 10, 39, -59, -101, 103, 91, -71, -25, -98, -118, 57, -35, -19, -108, 4, 113, -64, -15, -10, 74, 1, -36, -72, 126, 25, 111, 54, -84, 18, 43, -59, 82, -40, 3, 3, 8, -127, -120, 99, -86, 81, 84, -48, -67, 116, 78, -37, 77, -46, 71, 6, 124, -40, 84, 18, -60, 96, 7, 21, -74, 86, 39, 8, 108, 59, 119, 74, 110, -101, -104, -92, -89, 98, 0, 2, -23, -16, -101, 47, -50, -13, -17, -42, 105, 30, 123, -27, 69, 86, -29, 112, 40, 23, 72, -121, -102, -25, 99, -115, -99, -80, 89, -3, -127, -36, -125, -97, -2, 44, -69, -22, 13, -66, -7, -20, 33, -30, -2, 105, 62, 19, -92, 49, 48, -23, 121, 96, 76, -118, 33, -116, -120, 92, -9, -3, 4, 49, -56, -80, -57, -30, -102, -53, -30, 90, 55, 23, -60, 53, -49, -25, 116, -73, 3, 64, 69, 58, -20, -100, -86, 115, -29, -42, 43, -24, -87, -124, 7, 95, -8, 11, -99, 56, 26, 2, 83, -58, 16, 107, -115, 103, -37, -12, 18, -59, 74, -40, -53, -23, -41, 60, -97, -57, 110, -69, -125, -7, -71, -21, 121, 103, 101, -119, 83, -35, -43, -76, -2, 1, 48, 16, 105, -59, 114, 38, -120, -119, 99, -126, -110, 32, 46, -83, -123, 18, -83, -119, -76, 74, 51, 75, -58, -128, 48, 81, -61, 108, -45, 75, 18, -18, -5, -13, 83, 60, -7, -123, 123, -8, -6, -66, 27, -23, 37, 9, 63, -3, -25, -117, -20, -99, -35, -54, -99, -69, -9, -16, -103, -99, -69, -104, 114, 61, 108, -53, 66, 105, -51, -87, 110, -121, 55, 90, 39, 121, -22, -115, 35, -4, -85, 117, -118, -26, 45, 7, -8, -14, 39, -10, 113, -78, -45, -26, 107, -49, -4, -98, -43, 12, -72, -98, 74, -120, 85, 127, -82, 65, 22, 74, -110, 82, -80, -91, 6, -68, 95, 58, -4, -65, -73, -8, -18, -33, -98, -29, -25, 7, -18, -30, -2, -3, -97, -28, -13, -69, -9, -80, 125, 114, -118, -86, -29, 22, 100, -81, -86, -49, -16, -87, -19, 59, -7, -54, -36, -11, 44, -76, 87, -40, 53, -35, -32, -19, -27, 37, 30, 126, -7, 48, -81, 28, 127, 103, -45, 24, 62, 112, 16, -65, 118, 114, -127, -41, 78, 46, -32, -38, 54, 123, 26, 91, 74, -63, 103, -87, -22, -72, 92, -35, -40, -126, -76, 44, 94, 61, -15, 46, 71, 78, -99, -8, 64, -13, 23, 118, -64, 3, -76, -19, -32, -37, -110, -118, -29, -28, 92, -56, -105, 125, 94, -97, 2, -23, -16, -125, -101, 111, -27, -10, -35, 87, 111, 106, -14, -69, -81, -71, 22, 41, 44, 30, 120, -2, -113, -12, -110, 124, 112, 75, -53, 74, 75, -12, -127, 11, 1, 78, -55, 24, 5, 3, 92, 23, 44, -41, 97, -54, -13, 48, 70, -25, -78, 80, -51, -13, -87, -5, 105, -69, 36, 16, 60, 124, -21, -19, -36, 119, -35, 13, -71, 114, 99, 35, 36, 45, -117, 47, 93, -77, -105, -91, -34, 26, 15, -67, 116, 24, -45, -81, -37, -89, -3, -128, 88, -87, 52, -117, 13, -78, -112, -80, 73, -36, -30, -18, -106, 102, 33, -42, -70, 56, -74, 93, 40, 37, 42, -46, 29, -106, 7, -73, -20, -40, -59, 87, -81, -35, 63, 4, 111, -128, 48, 73, -80, 45, -127, 99, -39, -21, -126, -114, -75, 66, 105, -125, 39, 37, 2, 16, 66, 112, -33, -66, 27, 120, -14, -56, -85, -68, -4, -18, -37, 0, 68, 74, 93, -36, 82, -62, -105, -110, -57, 15, -36, -119, -52, 116, 92, 71, 78, 44, -80, -9, 23, -113, -14, -83, 63, 61, -123, 49, -27, -43, -72, 49, -122, -5, -97, 57, -56, -34, 95, 62, -54, -111, -109, 11, 67, -66, 99, -39, 60, 113, -32, 46, 124, 107, -29, 112, 54, 101, -64, 77, -37, 118, -80, 127, -21, -10, 28, -49, -109, -110, -53, -86, 19, -52, 84, -86, -21, -70, -108, 16, -126, 70, 80, -31, -78, -22, 36, -98, -99, -33, -4, -3, -37, -82, -32, -90, -53, 46, 7, -83, 75, 117, -41, -93, 13, -89, 81, -37, -78, -72, 119, 110, 95, -31, 117, -58, -98, -103, 89, -2, -6, -115, -17, -32, -38, -21, -69, 15, -64, 35, 7, -18, 36, 82, -118, -119, 49, 127, 22, -64, -67, -41, -35, -64, 63, -34, 125, 27, -76, 30, 111, -57, -41, -91, 13, -9, 3, 19, -82, -53, -51, -37, -81, 44, 12, 36, -124, 72, -113, -2, -13, -112, 39, 37, -98, 44, 95, -73, -101, -81, -72, -110, 107, 103, 63, -122, 107, 75, 18, 33, 88, 77, -30, 11, -33, 15, -100, 13, -41, -104, -18, 103, -94, 11, 77, -45, 65, -64, -15, -43, 21, 4, 16, 105, -51, 114, 28, -9, 51, -48, -6, 65, -68, -15, -109, -40, 24, -2, -69, -40, 98, 97, 101, 9, 0, -41, -74, 73, -76, 70, 103, 2, -41, 18, 2, 41, -84, -36, -85, 22, 72, -125, 63, -37, -8, 32, -64, -73, 29, 122, 42, -27, -123, -61, -77, -96, -65, 106, 90, -125, -80, -64, 94, 63, 77, 111, -40, -128, -42, 90, -105, -49, -3, -10, 87, 16, -89, -109, 110, -97, -100, -94, -43, -19, 18, -86, 17, -80, 64, 58, 76, -5, 1, -17, -83, -82, -28, -50, -111, -85, -22, 13, -114, 45, 45, -90, 0, -59, -128, 55, -61, -79, -77, -117, -103, -99, 22, -52, 86, -86, -93, 9, -115, 6, 35, 88, 47, 40, 54, 87, 74, 72, 9, -50, 121, 108, 79, -109, 124, -2, 57, 101, -26, -64, 22, -98, 69, 70, 118, -64, -41, 38, 61, -48, -54, -96, -116, 51, 54, -46, -44, -101, 36, 102, -42, -15, -103, 116, 61, 34, -107, 109, -22, 29, 106, -66, 79, 69, 102, 74, 17, 33, -40, 49, 85, 31, 25, -43, 7, -71, -77, 54, 61, -78, -77, 127, -45, -16, 43, -60, 70, -45, -114, 6, 77, -67, -123, -119, 18, 34, -73, 117, 17, -102, -6, 32, -31, -12, -54, 50, 97, -58, -73, 3, -57, -91, 30, -6, 44, -84, -74, 11, -85, 125, 108, -23, 12, 67, 102, 26, -97, -68, 85, 112, -95, 48, -45, 15, -12, -125, 56, -71, 72, 77, -67, 112, 36, 34, -21, 78, -93, -27, 44, -70, -58, -48, 16, -14, 11, 83, -22, 66, -29, -78, -27, -127, 124, 97, 122, 98, 41, -63, 113, -14, -18, 81, 6, 126, -4, 119, -80, 5, -29, 114, -39, 1, -50, 1, 30, 46, 100, 83, 47, -19, 52, -80, 115, 115, -67, -113, -128, 45, -107, 35, 99, -61, -71, 43, -35, 98, 63, -32, -126, -29, -89, 101, -77, 24, -108, -78, 125, 106, 4, 1, -77, 97, 53, 39, 63, 19, 84, -63, 48, -52, -27, 40, -123, -113, -96, -26, -7, 68, 90, -25, 64, 52, -126, 10, 43, 81, 47, 7, -78, -31, 87, -104, -83, -124, 57, -71, -103, -96, 74, 108, 20, -82, 45, -45, -20, 99, -91, 39, -79, -19, 114, -2, 32, 6, 72, -110, -60, 36, 74, 17, 43, -99, 91, -128, 88, 107, 98, -107, 63, -100, 98, -91, -120, -76, 26, -14, 13, 96, 11, -111, -54, 106, 69, 118, 117, 99, -83, -120, 114, 99, 10, 98, -93, 51, 7, 94, 42, 27, -101, 116, -18, 97, 67, 99, 44, 48, 26, 93, -14, -46, -71, 96, 64, 24, -57, 22, 73, 34, -38, 113, -108, -42, -29, 25, 3, -38, 97, -104, -14, 50, 52, -23, 121, 44, -121, -67, -36, 9, 27, 75, 7, -37, -78, 88, 14, -61, 33, 46, -128, -43, 40, 100, 57, 26, -24, -89, 96, -37, 81, -104, 102, -101, -52, -82, -72, -74, 44, 102, -95, 56, -90, 18, 39, 5, -105, 31, 25, 48, -9, 122, 106, 93, 39, 92, 69, -120, -63, -110, 36, 48, -6, -64, 97, -116, 41, -98, -120, 3, -34, 56, -33, 18, 96, -37, -96, -6, -85, -120, 72, 127, -52, 8, 60, 102, 48, 102, -58, -17, -115, 24, -115, -103, 26, -107, 32, 112, 49, 90, -87, -107, -2, 59, 25, 94, 24, 77, 51, -68, -101, 63, -92, 104, 54, 45, 126, -9, 116, -117, -77, -53, 127, 71, 107, -80, -124, 11, -62, -62, 74, 47, 97, 89, -61, -5, -47, 85, -58, -21, -13, -91, 109, -31, -56, -12, -34, 30, -24, -89, -9, -93, 49, -19, -12, -34, -50, -116, 101, -9, -27, -46, -71, 93, -76, -126, -77, -53, 47, -10, -98, 126, -18, -67, -12, 27, -39, 11, -61, -19, 46, -117, -127, -104, 63, 60, -1, 80, 114, -9, 29, -98, -88, 122, -73, 96, -37, 54, 90, 24, 44, 35, 116, -81, -121, 8, -61, -68, 116, 47, -124, 94, -120, -56, -44, 66, 66, 105, -116, -74, 70, -78, -38, -128, -42, -24, 110, -120, 8, -93, -47, 106, 35, -48, 97, -120, -120, 34, -78, -66, 106, -124, 4, -93, -116, -120, 66, -127, -42, -118, -59, -27, -105, -52, -77, -121, 127, -52, -32, 107, 99, -122, -118, 57, 42, -3, 10, -24, 1, 91, -27, -36, -98, -35, 118, 117, -94, 66, -33, -95, 42, 46, 116, -93, 36, 39, -18, -38, 18, -91, 18, -78, -95, 109, 3, -74, 45, -119, 84, 86, 86, 81, -79, 61, -70, 42, -65, 0, 41, 47, 43, 39, 113, 93, 80, -92, -34, -89, 86, -37, 107, -55, 27, 111, 30, 3, 78, -48, 108, -122, -29, -97, 89, -53, -109, 108, -77, 105, 113, -16, -96, -28, -24, 81, -89, -113, -25, -61, 36, -59, -36, 92, -52, -4, 124, 50, 14, 30, -50, 119, 74, 52, 111, -109, 44, -20, -39, -36, 59, -109, 11, 69, -105, -1, -57, 100, 125, -2, 35, -70, -44, -24, -1, -61, -111, -52, 58, 77, 71, 7, -71, 0, 0, 0, 0, 73, 69, 78, 68, -82, 66, 96, -126};
}