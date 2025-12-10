using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    void Start()
    {
        int childCount = transform.childCount;

        // Deactivate all children
        for (int i = 0; i < childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Choose one at random and activate it
        int chosenIndex = Random.Range(0, childCount);
        transform.GetChild(chosenIndex).gameObject.SetActive(true);
    }

}
