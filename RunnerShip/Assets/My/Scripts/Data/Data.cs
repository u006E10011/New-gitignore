using UnityEngine;

[System.Serializable]
public class Data
{
    #region Upgrade
    // Player
    public int Speed = 700;
    public float Rotate = 75;
    public int MaxHealth = 3;

    // Baff
    public float DurationUpSpeed = 3;
    public float DurationDownSpeed = 3;

    public float PercentUpSpeed = 15;
    public float PercentDownSpeed = 15;

    public float DurationInvincibility = 3;
    #endregion

    #region UpgradeLevel
    public int LevelSpeed;
    public int LevelRotate;
    public int LevelMaxHealth;

    // Baff
    public int LevelDurationUpSpeed;
    public int LevelDurationDownSpeed;

    public int LevelPercentUpSpeed;
    public int LevelPercentDownSpeed;

    public int LevelDurationInvincibility;

    public int LevelMultiplierCoin;
    #endregion

    #region Economy
    public int Bank;
    [Min(1)] public float MultiplierCoin = 1;
    #endregion

    #region Game
    public int MaxScore;
    #endregion

    #region Settings
    public float SoundVolume = 1f;
    #endregion
}