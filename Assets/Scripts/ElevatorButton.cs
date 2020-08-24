using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public Elevator elevator;
    public int floor;

    public void Move()
    {
        elevator.Elevate(floor);
    }
}
