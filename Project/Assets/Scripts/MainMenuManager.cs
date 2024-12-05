using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Game1 sahnesine geçiş
    public void LoadGame1()
    {
        SceneManager.LoadScene("Game1"); // "Game1" sahne ismini kendi projenize göre düzenleyin
    }

    // Game2 sahnesine geçiş
    public void LoadGame2()
    {
        SceneManager.LoadScene("Game2"); // "Game2" sahne ismini kendi projenize göre düzenleyin
    }

    // Oyundan çıkış
    public void ExitGame()
    {
        Debug.Log("Oyun kapatılıyor...");
        Application.Quit(); // Oyunu kapatır (Editörde çalışmaz, sadece build'de çalışır)
    }
}
