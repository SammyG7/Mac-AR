using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Core;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class ReturnToMain : MonoBehaviour
{

    
    //[SerializeField] private string mainMenuName = "Gameplay";

    // Start is called before the first frame update
    public async void returnToMain()
    {
        
        try
        {
            //Ensure you sign-in before calling Authentication Instance
            //See IAuthenticationService interface
            string playerId = AuthenticationService.Instance.PlayerId;
            await LobbyService.Instance.RemovePlayerAsync(PlayerPrefs.GetString("lobbyID", ""), playerId);
            GameObject.Find("NetworkManager").GetComponent<VivoxPlayer>()._vvm.Logout();
            print(PlayerPrefs.GetString("lobbyID", ""));
            //AuthenticationService.Instance.SignOut();


            //Ensure you sign-in before calling Authentication Instance
            //See IAuthenticationService interface

            //NetworkManager.Shutdown();
            //GameObject networkManager = GameObject.Find("NetworkManager");

            //string playerId = AuthenticationService.Instance.PlayerId;
            /*
            
            //await LobbyService.Instance.RemovePlayerAsync(lobbyID, playerId);
            //NetworkManager.Singleton.Shutdown();
            //Destroy(networkManager);
            //NetworkManager.Singleton.DisconnectClient(NetworkManager.Singleton.LocalClientId);
            //NetworkManager.Singleton.SceneManager.LoadScene(mainMenuName, LoadSceneMode.Single);
            if(NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.ConnectionApprovalCallback = null;
            }
           
            NetworkManager.Singleton.Shutdown();
            */
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.ConnectionApprovalCallback = null;
            }
            SceneManager.LoadScene(4);
            NetworkManager.Singleton.Shutdown();

        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }


    

}
