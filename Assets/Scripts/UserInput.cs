using System.Collections;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class UserInput : MonoBehaviour
{
    // <summary>
    //	Project Name: Lights Out
    //	Contribution: Creator
    //	Feature: Handles custom functions for Buttons
    //	Start Date:	3/10/2021
    //	End Date: 3/12/2021
    //	References:
    //	Links:	ENTERTUTORIAL USED (do not plagiarize any code)
    // </summary>

    public DiagnosticGameManager myGameManager;

    //public GameObject CheckBoxGameObject;

    public void ResetBoard()
    {
        //Reset scoring & tracking variables
        myGameManager.gridArray = new bool[5,5];
        foreach (var grid in myGameManager.gameObjectArray)
        {
            grid.GetComponent<MeshRenderer>().material = myGameManager.GridOffMaterial;
            grid.GetComponent<DiagnosticButton>().haveIBeenClicked = false;
        }
        myGameManager.ShuffleBoard();
        myGameManager.turnCounter = 1;
        myGameManager.playerTurnText.text = "Turn: 1";
        myGameManager.playerWinText.SetActive(false);
    }
}