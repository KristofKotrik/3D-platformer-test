using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupBeh : MonoBehaviour
{
    public Animator animator;
    public MasterScript MS;

    [SerializeField]
    private bool scored = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !scored)
        {
            scored = true;
            //MS.UpdateScore();
            MS.score++;
            animator.SetTrigger("Bloated");
            Destroy(gameObject, 1.5f);
        }
    }
}
