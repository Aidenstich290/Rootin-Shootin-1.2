using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
   private void Awake() // Runs when game starts
    {
        StartCoroutine(waiter()); // Starts Waiter Routine
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(90); // Won't Run the next line of code unitl 90 sec
        
        Object.Destroy(this.gameObject); // Deletes GameObject
    }

}
