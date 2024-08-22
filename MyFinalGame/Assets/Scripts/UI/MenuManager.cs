using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class MenuManager : MonoBehaviour
{ 
    public void onStartbuttonClick()
    {
        SceneManager.LoadScene("DungeonScene", LoadSceneMode.Single);

    }
    public void onExitbuttonClick()
    {
        Application.Quit();
    }
}