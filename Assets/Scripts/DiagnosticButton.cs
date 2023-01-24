using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnosticButton : MonoBehaviour
{
    // <summary>
    //	Project Name: Lights Out
    //	Contribution: Creator
    //	Feature: Handles click events on grid
    //	Start Date:	3/10/2021
    //	End Date: 3/12/2021
    //	References:
    //	Links:	ENTERTUTORIAL USED (do not plagiarize any code)
    // </summary>


    public bool haveIBeenClicked;

    public DiagnosticGameManager myGameManager;

    private void OnMouseDown()
    {
        if (haveIBeenClicked == false)
        {
            int row = Int32.Parse(this.name.Substring(4, 1));
            int column = Int32.Parse(this.name.Substring(5, 1));
            print("GridPosition: " + row + "," + column);
            interactiveFunction(row, column);
        }

    }

    public void interactiveFunction(int _rowIndex = -1, int _columnIndex = -1)
    {

        if (_rowIndex >= 0 && _columnIndex >= 0 && haveIBeenClicked == false)
        {
            myGameManager.GetComponent<DiagnosticGameManager>().enterMove(_rowIndex, _columnIndex);
        }
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
