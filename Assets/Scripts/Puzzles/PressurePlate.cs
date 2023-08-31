using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
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
        remainPressed = puzzleController.platesStayOn;
        multiUse = puzzleController.multipleUsePlates;
    }

    //De knop aanzetten als er objecten op staan
    private void OnTriggerEnter(Collider other)
    {
        thingsOnPlate++;
        if (!pressed && !locked)
        {
            pressed = true;
            puzzleController.activatedPuzzlePieces++;

            GetComponentsInChildren<ParticleSystem>()[0].Play();


            if (puzzleController.orderPuzzle)
            {
                puzzleController.AddCharacter(puzzleInput);
            }
        }
    }

    //De knop uitzetten als er niks meer op staat
    private void OnTriggerExit(Collider other)
    {
        thingsOnPlate--;
        if(pressed && thingsOnPlate <= 0 && !remainPressed && !locked)
        {
            pressed = false;
            puzzleController.activatedPuzzlePieces--;

            GetComponentsInChildren<ParticleSystem>()[0].Stop();

            if (puzzleController.orderPuzzle && !multiUse)
            {
                puzzleController.RemoveCharacter(puzzleInput);
            }
        }
    }

    //Reset de knop
    public void ResetButton()
    {
        if(pressed) puzzleController.activatedPuzzlePieces--;
        pressed = false;
        //maybe eject the things on the plate
        GetComponentsInChildren<ParticleSystem>()[0].Stop();
        GetComponentsInChildren<ParticleSystem>()[2].Play();
    }

    //Particles als de bijbehorende puzzel klaar is
    public void PuzzleFinished()
    {
        GetComponentsInChildren<ParticleSystem>()[1].Play();
        GetComponentsInChildren<ParticleSystem>()[0].Stop();
    }
}
