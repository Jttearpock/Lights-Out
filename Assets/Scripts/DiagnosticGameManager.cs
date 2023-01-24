using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DiagnosticGameManager : MonoBehaviour
{
    // <summary>
    //	Project Name: Lights Out
    //	Contribution: Creator
    //	Feature: Holds the core game data and runs the game
    //	Start Date:	3/10/2021
    //	End Date: 3/12/2021
    //	References:
    //	Links:	ENTERTUTORIAL USED (do not plagiarize any code)
    // </summary>

    public bool[,] gridArray;
    public int turnCounter = -1;
    public GameObject[] GridTilesArrayGameObjects;
    public GameObject[,] gameObjectArray;
    public Text playerTurnText;
    public GameObject playerWinText;

    public Material GridOnMaterial;

    public Material GridOffMaterial;


    //Check if player has won & print win message
    public bool checkWinFunction()
    {
        bool hasWon = true;
        foreach (var grid in gridArray)
        {
            if (grid == true)
            {
                hasWon = false;
                break;
            }
        }
        return hasWon;
    }

    // Start is called before the first frame update
    void Start()
    {
        gridArray = new bool[5,5];
        gameObjectArray = new GameObject[5,5];
        int i = 0;
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                gameObjectArray[row, col] = GridTilesArrayGameObjects[i];
                i++;
                //print(gameObjectArray[row,col].name);
            }
        }
        ShuffleBoard();
        turnCounter = 1;
        playerTurnText.text = "Turn: 1";
    }

    public void ShuffleBoard()
    {
        //Take several random moves, guarantees a winnable game
        for (int i = 0; i < 12; i++)
        {
            turnCounter = -1;
            int randomRow = Random.Range(0, 5);
            int randomcolumn = Random.Range(0, 5);
            enterMove(randomRow,randomcolumn);
        }
    }

    public void enterMove(int row, int column)
    {
        //Update both Arrays & Visuals with their new values
        FlipGridStates(row, column);

        bool checkIfPlayerWon = checkWinFunction();

        //Check that turnCounter is greater than zero to avoid an accidental win while shuffling board
        if (checkIfPlayerWon == true && turnCounter > 0)
        {
            foreach (var grid in gameObjectArray)
            {
                grid.GetComponent<DiagnosticButton>().haveIBeenClicked = true;
            }
            playerWinText.SetActive(true);
        }
        else
        {
            //Update the turnCounter && Text
            turnCounter++;
            playerTurnText.text = "Turn: " + turnCounter;
        }

    }

    public void FlipGridStates(int row, int column)
    {
        GameObject currentGrid = gameObjectArray[row, column];

        //Flip State of the Clicked grid, if false set true, if true set false
        if (gridArray[row, column] == false)
        {
            gridArray[row, column] = true;
            currentGrid.GetComponent<MeshRenderer>().material = GridOnMaterial;
        }
        else
        {
            gridArray[row, column] = false;
            currentGrid.GetComponent<MeshRenderer>().material = GridOffMaterial;
        }

        //Flip Tile Above
        if (row > 0)
        {
            currentGrid = gameObjectArray[row - 1, column];
            if (gridArray[row - 1, column] == false)
            {
                gridArray[row - 1, column] = true;
                currentGrid.GetComponent<MeshRenderer>().material = GridOnMaterial;
            }
            else
            {
                gridArray[row - 1, column] = false;
                currentGrid.GetComponent<MeshRenderer>().material = GridOffMaterial;
            }
        }
        //Flip Tile Below
        if (row < 4)
        {
            currentGrid = gameObjectArray[row + 1, column];
            if (gridArray[row + 1, column] == false)
            {
                gridArray[row + 1, column] = true;
                currentGrid.GetComponent<MeshRenderer>().material = GridOnMaterial;
            }
            else
            {
                gridArray[row + 1, column] = false;
                currentGrid.GetComponent<MeshRenderer>().material = GridOffMaterial;
            }
        }        
        //Flip Tile to the Right
        if (column < 4)
        {
            currentGrid = gameObjectArray[row, column + 1];
            if (gridArray[row, column + 1] == false)
            {
                gridArray[row, column + 1] = true;
                currentGrid.GetComponent<MeshRenderer>().material = GridOnMaterial;
            }
            else
            {
                gridArray[row, column + 1] = false;
                currentGrid.GetComponent<MeshRenderer>().material = GridOffMaterial;
            }
        }        
        //Flip Tile to the Left
        if (column > 0)
        {
            currentGrid = gameObjectArray[row, column - 1];
            if (gridArray[row, column - 1] == false)
            {
                gridArray[row, column - 1] = true;
                currentGrid.GetComponent<MeshRenderer>().material = GridOnMaterial;
            }
            else
            {
                gridArray[row, column - 1] = false;
                currentGrid.GetComponent<MeshRenderer>().material = GridOffMaterial;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
