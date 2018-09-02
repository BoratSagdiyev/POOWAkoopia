using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System.Text;
using UnityEngine;

public class PlayGamesScript : MonoBehaviour
{

    public static PlayGamesScript instance { get; set; }

    const string SAVE_NAME = "Tutorial";
    bool isSaving;
    bool isCloudDataLoaded = false;
    public GameObject connectedMenu;
    //public GameObject disconnectedMenu;
    

    // Use this for initialization

    public void Awake()
    {
        instance = this;
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .EnableSavedGames().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

    }


    public void Start()
    {
        if (!PlayerPrefs.HasKey(SAVE_NAME))
            PlayerPrefs.SetString(SAVE_NAME, string.Empty);
        if (!PlayerPrefs.HasKey("IsFirstTime"))
            PlayerPrefs.SetInt("IsFirstTime", 1);
        LoadLocal();

        OnConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
        SignIn();


    }

    public void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {

            OnConnectionResponse(success);
        });
    }

    public void SignOut()
    {
        PlayGamesPlatform.Instance.SignOut();
    }



    private void OnConnectionResponse(bool authenticated)
    {
        if (authenticated)
        {
            LoadData();
            connectedMenu.SetActive(true);

            //disconnectedMenu.SetActive(false);
            AddScoreToLeaderboard(PGPS.leaderboard_paw_leaderboard, CoinsManager.Coins);
        }
        else
        {
            //disconnectedMenu.SetActive(true);
            connectedMenu.SetActive(false);
        }
    }

    #region Saved Games
    string GameDataToString()
    {
        return JsonUtil.CollectionToJsonString(GameManager2.ImportantValues, "myKey");

    }

    void StringToGameData(string cloudData, string localData)
    {
        if (cloudData == string.Empty)
        {
            StringToGameData(localData);
            isCloudDataLoaded = true;
        }
        int[] cloudArray = JsonUtil.JsonStringToArray(cloudData, "myKey", str => int.Parse(str));

        if (localData == string.Empty)
        {
            GameManager2.ImportantValues = cloudArray;
            PlayerPrefs.SetString(SAVE_NAME, cloudData);
            isCloudDataLoaded = true;
            return;
        }
        int[] localArray = JsonUtil.JsonStringToArray(localData, "myKey", str => int.Parse(str));

        if (PlayerPrefs.GetInt("IsFirstTime") == 1)
        {
            PlayerPrefs.SetInt("IsFirstTime", 0);

            for (int i = 0; i < cloudArray.Length; i++)
                if (cloudArray[i] > localArray[i])
                {
                    PlayerPrefs.SetString(SAVE_NAME, cloudData);
                }
        }
        else
        {

            for (int i = 0; i < cloudArray.Length; i++)
                if (int.Parse(localData) > int.Parse(cloudData))
                {
                    GameManager2.ImportantValues = localArray;

                    isCloudDataLoaded = true;
                    SaveData();
                    return;
                }
        }
        GameManager2.ImportantValues = cloudArray;
        isCloudDataLoaded = true;

    }
    void StringToGameData(string localData)
    {
        if (localData != string.Empty)
            GameManager2.ImportantValues = JsonUtil.JsonStringToArray(localData, "myKey",
                                                                      str => int.Parse(str));
    }

    public void LoadData()
    {
        if (Social.localUser.authenticated)
        {
            isSaving = false;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithManualConflictResolution(SAVE_NAME,
                DataSource.ReadCacheOrNetwork, true, ResolveConflict, OnSaveGameOpened);
        }
        else
        {
            LoadLocal();
        }
    }

    private void LoadLocal()
    {
        StringToGameData(PlayerPrefs.GetString(SAVE_NAME));
    }

    public void SaveData()
    {
        if (!isCloudDataLoaded)
        {
            SaveLocal();
            return;
        }
        if (Social.localUser.authenticated)
        {
            isSaving = true;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithManualConflictResolution(SAVE_NAME,
                DataSource.ReadCacheOrNetwork, true, ResolveConflict, OnSaveGameOpened);
        }
        else
        {
            SaveLocal();
        }
    }

    private void SaveLocal()
    {
        PlayerPrefs.SetString(SAVE_NAME, GameDataToString());
    }

    private void ResolveConflict(IConflictResolver resolver, ISavedGameMetadata original, byte[] originalData,
        ISavedGameMetadata unmerged, byte[] unmergedData)
    {
        if (originalData == null)
            resolver.ChooseMetadata(unmerged);
        else if (unmergedData == null)
            resolver.ChooseMetadata(original);
        else
        {
            string originalStr = Encoding.ASCII.GetString(originalData);
            string unmergedStr = Encoding.ASCII.GetString(unmergedData);

            int[] originalArray = JsonUtil.JsonStringToArray(originalStr, "myKey", str => int.Parse(str));
            int[] unmergedArray = JsonUtil.JsonStringToArray(unmergedStr, "myKey", str => int.Parse(str));

            for (int i = 0; i < originalArray.Length; i++)

                if (originalArray[i] > unmergedArray[i])
                {
                    resolver.ChooseMetadata(original);
                    return;
                }
                else if (unmergedArray[i] > originalArray[i])
                {
                    resolver.ChooseMetadata(unmerged);
                    return;
                }
            resolver.ChooseMetadata(original);
        }
    }

    private void OnSaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            if (!isSaving)
                LoadGame(game);
            else
                SaveGame(game);
        }
        else
        {
            if (!isSaving)
                LoadLocal();
            else
                SaveLocal();
        }
    }

    private void LoadGame(ISavedGameMetadata game)
    {
        ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(game, OnSavedGameDataRead);
    }

    private void SaveGame(ISavedGameMetadata game)
    {
        string stringToSave = GameDataToString();
        PlayerPrefs.SetString(SAVE_NAME, stringToSave);

        byte[] dataToSave = Encoding.ASCII.GetBytes(stringToSave);

        SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().Build();

        ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(game, update, dataToSave,
            OnSavedGameDataWritten);
    }

    private void OnSavedGameDataRead(SavedGameRequestStatus status, byte[] savedData)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            string cloudDataString;
            if (savedData.Length == 0)
                cloudDataString = string.Empty;
            else
                cloudDataString = Encoding.ASCII.GetString(savedData);

            string localDataString = PlayerPrefs.GetString(SAVE_NAME);

            StringToGameData(cloudDataString, localDataString);
        }

    }

    private void OnSavedGameDataWritten(SavedGameRequestStatus status, ISavedGameMetadata game)
    {

    }
    #endregion /Saved Games
    #region Achievements
    public static void UnlockAchievement(string id)
    {
        Social.ReportProgress(id, 100, success => { });
    }

    public static void IncrementAchievement(string id, int stepsToIncrement)
    {

        PlayGamesPlatform.Instance.IncrementAchievement(id, stepsToIncrement, success => { });

    }

    public static void ShowAchievementsUI()
    {
        PlayGamesPlatform.Instance.ShowAchievementsUI();
    }
    #endregion /Achievements

    #region Leaderboards
    public static void AddScoreToLeaderboard(string leaderboardId, long score)
    {
        Social.ReportScore(score, leaderboardId, success => { });
    }

    public static void ShowLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }
    #endregion /Leaderboards
}