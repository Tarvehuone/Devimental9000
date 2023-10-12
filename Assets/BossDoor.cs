using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    private List<bool> roomCompletion = new List<bool>();

    public void CheckRooms(bool isCompleted)
    {
        roomCompletion.Add(isCompleted);

        if (roomCompletion.Count == 5)
        {
            Destroy(gameObject);
        }
    }
}
