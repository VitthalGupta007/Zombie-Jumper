using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void PlayGame()
    {
        // Debug.Log("Button is pressed");

        int selectedCharacter =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            GameManager.instance.CharIndex = selectedCharacter;

            SceneManager.LoadScene("Gameplay");


        // int [] a = new int[10];
        // a[selectedCharacter] = 10;

        

        // Debug.Log("Index: " + clickedObj);
        

    }



}//class
