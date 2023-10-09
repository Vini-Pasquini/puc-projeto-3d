using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Core
{
    // levelState
    private static LEVEL_STATE currentLevelState = LEVEL_STATE.Stopped;
    public static LEVEL_STATE GetLevelState() { return currentLevelState; }
    public static void SetLevelState(LEVEL_STATE newState) { currentLevelState = newState; }

    private static float playerFuel = 0f;
    public static float GetPlayerFuel() { return playerFuel; }
    public static void SetPlayerFuel(float newValue) { playerFuel = newValue; UpdateDisplays(); }
    public static void IncrementPlayerFuel(float increment) { playerFuel += increment; if (playerFuel < 0f) playerFuel = 0f; UpdateDisplays(); }

    private static float playerHealth = 0f;
    public static float GetPlayerHealth() { return playerHealth; }
    public static void SetPlayerHealth(float newValue) { playerHealth = newValue; UpdateDisplays(); }
    public static void IncrementPlayerHealth(float increment) { playerHealth += increment; if (playerHealth < 0f) playerHealth = 0f; UpdateDisplays(); }

    private static float playerGold = 0f;
    public static float GetPlayerGold() { return playerGold; }
    public static void SetPlayerGold(float newValue) { playerGold = newValue; UpdateDisplays(); }
    public static void IncrementPlayerGold(float increment) { playerGold += increment; if (playerGold < 0f) playerGold = 0f; UpdateDisplays(); }

    private static Vector3 playerPosition = Vector3.zero;
    public static Vector3 GetPlayerPosition() { return playerPosition; }
    public static void SetPlayerPosition(Vector3 position) { playerPosition = position; }

    private static Quaternion playerRotation = Quaternion.identity;
    public static Quaternion GetPlayerRotation() { return playerRotation; }
    public static void SetPlayerRotation(Quaternion rotation) { playerRotation = rotation; }

    // flags
    private static bool playerLoadStaged = false;
    public static bool IsPlayerLoadStaged() { return playerLoadStaged; }
    public static void StagePlayerLoad(bool newValue) { playerLoadStaged = newValue; }
    
    private static bool isOnRescue = false;
    public static bool GetIsOnRescue() { return isOnRescue; }
    public static void SetIsOnRescue(bool newValue) { isOnRescue = newValue; }

    // gameState
    private static string lastActiveSceneName = null;
    public static string GetLastActiveScene() { return lastActiveSceneName; }
    public static void SetLastActiveScene(string sceneName) { lastActiveSceneName = sceneName; }

    public static void Reset(LEVEL_STATE levelStateOverride = LEVEL_STATE.Stopped)
    {
        playerFuel = 100f;
        playerHealth = 100f;
        playerGold = 0f;
        playerPosition = Vector3.zero;
        playerRotation = Quaternion.identity;
        currentLevelState = levelStateOverride;
    }

    // util
    
    public static bool UpdateDisplays()
    {
        LevelDisplayController levelDisplayController = GameObject.Find("Canvas").GetComponent<LevelDisplayController>();
        if (levelDisplayController == null) return false;
        levelDisplayController.UpdateFuelDisplay();
        levelDisplayController.UpdateHealthDisplay();
        levelDisplayController.UpdateGoldDisplay();
        return true;
    }
}
