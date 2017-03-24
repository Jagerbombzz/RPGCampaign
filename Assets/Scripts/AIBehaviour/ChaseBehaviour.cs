﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ChaseBehaviour : AIBehaviour
{
    private Character target;
    private HexPath path;

    public ChaseBehaviour(AIPlayer ai) 
        : base(ai)
    {
        target = GameManager.Characters.Where(c => !Characters.Contains(c)).Single();
    }

    public override void Activate()
    {
        base.Activate();

        // Listen for when character has finished moving
        Current.FinishedMovement += Current_FinishedMovement;

        // If not in range of target...
        if (!Current.InAttackRange(target.Cell))
        {
            // Get quickest path to a cell within range of target
            path = Pathfind.ToWithinRange(Current.Cell, target.Cell, Current.Attack.range, Current.Stats.Traverser, Current.Attack.traverser);

            // If there is no path...
            if (path == null)
                EndTurn();   // End turn

            else
            {
                // Move along the amount of path that can be traversed this turn
                HexPath inRangePath = path.To(Current.Stats.TimeUnits.Current);
                Current.Move(inRangePath);
            }
        }

        // Already in range, end turn.
        else
            EndTurn();
    }

    public override void EndTurn()
    {
        // Stop listening for when character has finished moving
        Current.FinishedMovement -= Current_FinishedMovement;

        base.EndTurn();
    }

    private void Current_FinishedMovement(object sender, CharacterMovementEventArgs e)
    {
        // End turn when character has finished moving
        EndTurn();
    }
}
