using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    private PuzzleController puzzleController;
    private bool remainPressed;
    private bool multiUse;
    public char puzzleInput;

    public bool locked = false;
    private bool pressed = false;
    private int thingsOnPlate = 0;

    private void Awake()
    {
        puzzleController = GetComponentInParent<PuzzleController>();
    }

    public void ActivateButton()
    {
        pressed = true;
        puzzleController.activatedPuzzlePieces++;

        if (puzzleController.orderPuzzle)
        {
            //Debug.Log(puzzleInput);
            puzzleController.AddCharacter(puzzleInput);
        }
    }

    public void DeactivateButton()
    {
        pressed = false;
        puzzleController.activatedPuzzlePieces--;

        if (puzzleController.orderPuzzle)
        {
            puzzleController.RemoveCharacter(puzzleInput);
        }
    }

    public void ResetButton()
    {
        if (pressed) puzzleController.activatedPuzzlePieces--;
        pressed = false;
    }

    public void PuzzleFinished()
    {

    }
}
