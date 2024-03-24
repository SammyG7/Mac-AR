using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HintButtons : MonoBehaviour
{
    public Button forwardButton;
    public Button backButton;
    public Button dispButton;
    public TextMeshProUGUI hintTexter;
    public TextMeshProUGUI hintCounter;
    List<string> hintList = new List<string>();
    public MultiplayerPuzzleManager multi;
    int counter = 0;
    int hintCount = 0;
    //int activePuzzIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("got hint text");
        hintList.Add("This is the first hint");
        hintList.Add("This is the second hint");
        hintList.Add("This is the third hint");
        hintTexter.text = "hello";
        Button forBtn = forwardButton.GetComponent<Button>();
        Button backBtn = backButton.GetComponent<Button>();
        Button dispBtn = dispButton.GetComponent<Button>();
        forBtn.onClick.AddListener(forwardClick);
        backBtn.onClick.AddListener(backwardClick);
        dispBtn.onClick.AddListener(initialClick);

        //puzzleInstances[activePuzzleIndex].GetComponentInChildren<PuzzleBase>().SetActive(false);
    }

    void initialClick()
    {
        hintList.Clear();
        Debug.Log("Count of multi puzzle instances" + multi.puzzleInstances.Count);
        if (PuzzleConstants.puzzleBatches[multi.activePuzzleBatchIndex][multi.activePuzzleIndex].Item1 == 1)
        {
            Debug.Log("in 0");
            hintList.Add("Your combination entry resets every time you enter an incorrect number");
            hintList.Add("Make sure to coordinate who's entering the combination");

        }
        else if (PuzzleConstants.puzzleBatches[multi.activePuzzleBatchIndex][multi.activePuzzleIndex].Item1 == 2)
        {
            Debug.Log("in 1");
            hintList.Add("The wires should be connected to the correct coloured nodes");
            hintList.Add("The power will be turned on when the lights turn green");
  
        }
        else if (PuzzleConstants.puzzleBatches[multi.activePuzzleBatchIndex][multi.activePuzzleIndex].Item1 == 3)
        {
            Debug.Log("in 2");
            hintList.Add("Communicate regarding the different colours you see");
            hintList.Add("Try to remember the cube colour sequence");

        }
        else if (PuzzleConstants.puzzleBatches[multi.activePuzzleBatchIndex][multi.activePuzzleIndex].Item1 == 0)
        {
            Debug.Log("in 3");
            hintList.Add("Look at the cubes from different angles, they might resemble something familiar");
            hintList.Add("Each set of cubes has one letter and one number, which creates a word");

        }
        else if (PuzzleConstants.puzzleBatches[multi.activePuzzleBatchIndex][multi.activePuzzleIndex].Item1 == 4)
        {
            Debug.Log("in 4");
            hintList.Add("One user has the ability to rotate their phone to rotate the maze");
            hintList.Add("Try to communicate to get the ball to reach the stone plate at the end of the maze");

        }


        counter = 0;
        hintTexter.text = hintList[counter];
        hintCount = counter + 1;
        hintCounter.text = " Hint: " + hintCount + "/" + hintList.Count;
        backButton.gameObject.SetActive(false);
        forwardButton.gameObject.SetActive(true);
        Debug.Log("initial" + counter);
    }

    void forwardClick()
    {
        counter += 1;
        hintCount = counter + 1;

        if (counter > 0)
        {
            backButton.gameObject.SetActive(true);
     
        } else if (counter == 0)
        {
            backButton.gameObject.SetActive(false);
        }

        if (counter == 1)
        {
            forwardButton.gameObject.SetActive(false);
        }

        Debug.Log("counter in front" + counter);
        hintTexter.text = hintList[counter];
        hintCounter.text = " Hint: " + hintCount + "/" + hintList.Count;




    }

    void backwardClick()
    {
        if (counter > 0)
        {
            counter -= 1;
            hintCount = counter + 1;
        }

        if (counter == 0)
        {
            backButton.gameObject.SetActive(false);
        }

        if (counter < 1)
        {
            forwardButton.gameObject.SetActive(true);
        }
        Debug.Log("counter in back" + counter);
        hintTexter.text = hintList[counter];
        hintCounter.text = " Hint: " + hintCount + "/" + hintList.Count;

    }



}
