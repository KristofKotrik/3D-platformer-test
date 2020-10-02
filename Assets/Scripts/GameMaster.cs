using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKey)
        {
            Debug.Log("wadwadwadw");
            Application.Quit();
        }
    }
}
