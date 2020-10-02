using UnityEngine;
using TMPro;

public class MasterScript : MonoBehaviour
{
    [SerializeField]
    public float score = 0;
    public TextMeshProUGUI TMPText;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        TMPText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        TMPText.text = "Score: " + score;
    }

    public void UpdateScore() 
    {
        score += 1;
        Debug.Log(score);
    }
}
