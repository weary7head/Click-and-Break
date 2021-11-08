using UnityEngine;

public class SaveSystem
{
    public void SaveResult(int result)
    {
        PlayerPrefs.SetInt("SavedResult", result);
        PlayerPrefs.Save();
    }

    public int LoadResult()
    {
        return PlayerPrefs.GetInt("SavedResult", 0);
    }
}
