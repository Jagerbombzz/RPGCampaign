﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    public CharacterInput InputSystem;

    public override void Activate(Character actor)
    {
        base.Activate(actor);

        InputSystem.Selected = actor;
        actor.FinishedMovement += Actor_FinishedMovement;
    }

    private void Actor_FinishedMovement(object sender, CharacterMovementEventArgs e)
    {
        current.FinishedMovement -= Actor_FinishedMovement;
        EndTurn();
    }
}