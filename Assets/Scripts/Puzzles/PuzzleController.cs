using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject puzzleResult;

    public int puzzlePiecesNeeded;

    public int activatedPuzzlePieces = 0;

    public bool platesStayOn = false;

    public bool multipleUsePlates = false;

    public bool orderPuzzle = false;

    public string correctOrder;

    private string inputOrder = "";

    private bool puzzleComplete = false;

    private bool puzzleFinished = false;

    private PressurePlate[] pressurePlates;

    private void Awake()
    {
        pressurePlates = GetComponentsInChildren<PressurePlate>();
    }

    //Win conditions van alle varianten van de puzzle.
    private void Update()
    {

        if(puzzleComplete && platesStayOn && !puzzleFinished)
        {
            PuzzleFinished();
        }

        if (activatedPuzzlePieces >= puzzlePiecesNeeded && !puzzleComplete)
        {
            if (orderPuzzle)
            {
                if (inputOrder == correctOrder)
                {
                    puzzleComplete = true;
                }
                else
                {
                    ResetCharacters();
                }
            }
            else
            {
                puzzleComplete = true;
            }
        }

        if (activatedPuzzlePieces < puzzlePiecesNeeded)
        {
            puzzleComplete = false;
        }


        //Testing only, vervang dit door een daadwerkelijke deur ofzo
        if (puzzleComplete)
        {
            puzzleResult.GetComponent<Rigidbody>().velocity = Vector3.left * 5;
            activatedPuzzlePieces = 0;
        }
    }

    //Voegt letter toe
    public void AddCharacter(char input)
    {
        inputOrder += input;
    }

    //Verwijdert de bijbehorende letter
    public void RemoveCharacter(char input)
    {
        for (int i = 0; i < inputOrder.Length; i++)
        {
            if (inputOrder[i] == input)
            {
                inputOrder.Remove(i);
            }
        }
    }

    //Gaat aan als een "permanente puzzel" klaar is
    public void PuzzleFinished()
    {
        puzzleFinished = true;

        foreach (PressurePlate plate in pressurePlates)
        {
            plate.PuzzleFinished();
            plate.locked = true;
        }

    }

    //Reset de letters bij een verkeerd woord
    public void ResetCharacters()
    {
        inputOrder = "";

        foreach (PressurePlate plate in pressurePlates)
        {
            plate.ResetButton();
        }
    }

}
