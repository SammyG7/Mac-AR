//using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameSceneChange : MonoBehaviour
{
    //[SerializeField] private string mainMenuScene = "MainMenu";
    public void ChangeScene(){
        SceneManager.LoadScene(1);
        Debug.Log("Returning to main menu");
    }
}
