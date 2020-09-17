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
    private static IGetPlayerStatisticsListener _getPlayerStatisticsListener = new MyGetPlayerStatisticsListener();
    private static ILimitSizeListener _limitSizeListener = new MyLimitSizeListener();
    private static IGetSnapshotDataListener _getSnapshotDataListener = new MyGetSnapshotDataListener();
    private static IGetAllSnapshotDataListener _getAllSnapshotDataListener = new MyGetAllSnapshotDataListener();
    private static IGetCoverImageListener _getCoverImageListener = new MyGetCoverImageListener();
    private static IGetSnapshotResultListener _getSnapshotResultListener = new MyGetSnapshotResultListener();
    private static IDeleteSnapshotListener _deleteSnapshotListener = new MyDeleteSnapshotListener();


    // local variables
    private static List<string> achievementIds = new List<string>();
    private static List<string> eventIds = new List<string>();
    private static string rankingId = "";
    private static string snapshotId = "";
    private static SnapshotData tempSnapshotData;


    private static Text info_panel;
    private static Button init_button;
    private static Button login_button;
    private static Button achievement_button;
    private static Button event_button;
    private static Button ranking_button;
    private static Button game_button;
    private static Button player_button;
    private static Button gameSave_button;
    private static Button float_button;
    private static Transform subaction_panel;

    public GameObject prefabButton;

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
        "SubmitScore",
        "AsyncSubmitScore", "SubmitScoreWithTag", "AsyncSubmitScoreWithTag",
        "GetAllRankingIntent", "GetRankingIntent", "GetRankingData",
        "GetRankingTopScores", "GetCurrentPlayerRankingScore", "GetPlayerCenteredRankingScores", "GetMoreRankingScores"
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

            //todo timespan field
            HuaweiGameService.GetLeaderboardTopScores(rankingId, 2, 10, true, _getLeaderboardScoresListener);
        },
        () =>
        {
            Show("start GetCurrentPlayerRankingScore");
            if (rankingId == "")
            {
                Show("please get ranking id first.");
                return;
            }

            //todo timespan field
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

            //todo timespan field
            HuaweiGameService.GetPlayerCenteredLeaderboardScores(rankingId, 2, 10, true, _getLeaderboardScoresListener);
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
        "GetGamePlayerStatistics"
    };

    private readonly List<Action> playerFunctions = new List<Action>()
    {
        () =>
        {
            Show("start GetGamePlayerStatistics.");
            HuaweiGameService.GetGamePlayerStatistics(false, _getPlayerStatisticsListener);
        },
    };

    private readonly List<string> gameSaveFunctionNames = new List<string>()
    {
        "GrantDriveAccess", "GetLimitThumbnailSize", "GetLimitDetailsSize", "AddSnapshot", "GetSnapshotDataList",
        "LoadCoverImage", "LoadSnapshotContents", "UpdateSnapshot", "DeleteSnapshot",
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

            HuaweiGameService.AddSnapshot(content, snapshotChange, true, _getSnapshotDataListener);
        },
        () =>
        {
            Show("start GetSnapshotDataList.");
            HuaweiGameService.GetSnapshotDataList(true, _getAllSnapshotDataListener);
        },
        () =>
        {
            Show("start LoadCoverImage.");
            if (snapshotId == "" || tempSnapshotData == null)
            {
                Show("no snapshot id found, GetSnapshotDataList or AddOne first.");
            }

            HuaweiGameService.LoadCoverImage(tempSnapshotData, _getCoverImageListener);
        },
        () =>
        {
            Show("start LoadSnapshotContents.");
            if (snapshotId == "")
            {
                Show("no snapshot id found, GetSnapshotDataList or AddOne first.");
            }

            HuaweiGameService.LoadSnapshotContents(snapshotId, 1, _getSnapshotResultListener);
        },
        () =>
        {
            Show("start UpdateSnapshot.");
            if (snapshotId == "")
            {
                Show("no snapshot id found, GetSnapshotDataList or AddOne first.");
            }

            SnapshotContent content = new SnapshotContent();
            content.Content = System.Text.Encoding.UTF8.GetBytes("test update snapshot content");
            SnapshotChange snapshotChange = new SnapshotChange();
            snapshotChange.Description = "updated demo description";
            snapshotChange.PlayedTimeMillis = 800;
            snapshotChange.CurrentProgress = 60;

            HuaweiGameService.UpdateSnapshot(snapshotId, snapshotChange, content, _getSnapshotResultListener);
        },
        () =>
        {
            Show("start DeleteSnapshot.");
            if (snapshotId == "" || tempSnapshotData == null)
            {
                Show("no snapshot id found, GetSnapshotDataList or AddOne first.");
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
        achievement_button = GameObject.Find("Achievement").GetComponent<Button>();
        event_button = GameObject.Find("Event").GetComponent<Button>();
        ranking_button = GameObject.Find("Ranking").GetComponent<Button>();
        game_button = GameObject.Find("Game").GetComponent<Button>();
        gameSave_button = GameObject.Find("GameSave").GetComponent<Button>();
        player_button = GameObject.Find("Player").GetComponent<Button>();
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
        login_button.onClick.AddListener(() =>
        {
            Show("starting login");
            HuaweiGameService.Login(_loginListener);

        });
        achievement_button.onClick.AddListener(onAchievementBtnClick);
        event_button.onClick.AddListener(onEventBtnClick);
        ranking_button.onClick.AddListener(onRankingBtnClick);
        game_button.onClick.AddListener(onGameBtnClick);
        gameSave_button.onClick.AddListener(onGameSaveBtnClick);
        player_button.onClick.AddListener(onPlayerBtnClick);
        float_button.onClick.AddListener(onFloatBtnClick);
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
            string msg = "get login success with signInAccountProxy info: \n";
            msg += String.Format("displayName:{0}, uid:{1}, openId:{2}, unionId:{3}, idToken:{4}, accessToken:{5}, serverAuthCode:{6}, countryCode:{7}",
            signInAccountProxy.DisplayName, signInAccountProxy.Uid, signInAccountProxy.OpenId, signInAccountProxy.UnionId,
            signInAccountProxy.IdToken, signInAccountProxy.AccessToken, signInAccountProxy.ServerAuthCode, signInAccountProxy.CountryCode);
            Show(msg);
        }

        public void OnSignOut()
        {
            throw new NotImplementedException();
        }

        public void OnFailure(int code, string message)
        {
            string msg = "login failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    // listeners
    public class MyGetAchievementListListener : IGetAchievementListListener
    {
        public void OnSuccess(List<Achievement> achievementList)
        {
            string message = "get achievement list success with count :" + achievementList.Count + "\n";
            achievementIds = new List<string>();

            foreach (var ach in achievementList)
            {
                message += string.Format(
                    "id:{0}, type:{1}, name:{2}, description:{3}, totalSteps:{4}, currentStep:{5}, state:{6} \n",
                    ach.AchievementId,
                    ach.Type,
                    ach.Name,
                    ach.Description,
                    ach.TotalSteps,
                    ach.CurrentSteps,
                    ach.State
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
            string msg = "get achievement intent success.";
            Show(msg);
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
            var msg = "get leader board intent succeed";
            Show(msg);
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
    public class MyGetPlayerStatisticsListener : IGetPlayerStatisticsListener
    {
        public void OnSuccess(PlayerStatistics playerStatistics)
        {
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

    public class MyGetGameListener : IGetGameListener
    {
        public void OnSuccess(Game game)
        {
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
            var msg = "GetLimitDetailsSize succeed. with limit size: " + limitSize + "\n";
            Show(msg);
        }

        public void OnFailure(int code, string message)
        {
            var msg = "GetLimitDetailsSize failed, code:" + code + " message:" + message;
            Show(msg);
        }
    }

    public class MyGetSnapshotDataListener : IGetSnapshotDataListener
    {
        public void OnSuccess(SnapshotData snapshotData)
        {
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

    public class MyGetAllSnapshotDataListener : IGetAllSnapshotDataListener
    {
        public void OnSuccess(List<SnapshotData> allSnapshotData)
        {
            var msg = "AddSnapshot succeed. \n";

            foreach (var snapshotData in allSnapshotData)
            {
                msg += string.Format(
                    "snapshot id{0}, unique name{1}, player name:{2}, played time:{3}, progress value:{4}, desc:{5}, gameName:{6} \n",
                    snapshotData.SnapshotId, snapshotData.UniqueName, snapshotData.Player != null ? snapshotData.Player.DisplayName : "", snapshotData.PlayedTime,
                    snapshotData.ProgressValue, snapshotData.Description, snapshotData.Game != null ? snapshotData.Game.DisplayName : "");

                if (snapshotId == "")
                {
                    snapshotId = snapshotData.SnapshotId;
                    tempSnapshotData = snapshotData;
                }
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

    public class MyDeleteSnapshotListener : IDeleteSnapshotListener
    {
        public void OnSuccess(string snapshotId)
        {
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
        info_panel.text = append ? string.Format("{0}\n{1}", info_panel.text, message) : message;
        Log(message);
    }

    private static void Log(string message)
    {
        string prefix = "[UDPService]";
        Debug.Log(prefix + " " + message);
    }
}