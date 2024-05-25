using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{

    Renderer rend;
    public GameObject Target;

    void Start()
    {
        if(Target == null)
        {
            Target = gameObject;
        }
        rend = Target.GetComponent<Renderer>();
        if(rend == null)
        {
            Debug.Log("No Renderer found in gameObject: " + gameObject.name);
        }
    }

    public void FlashColour(Material changeColour, Material baseColour, float delay)
    {
        StartCoroutine(FlashRoutine(changeColour, baseColour, delay));
    }
    public void FlashColour(Material changeColour,  float delay)
    {
        Material baseColour = rend.material;
        StartCoroutine(FlashRoutine(changeColour, baseColour, delay));
    }

    public void ChangeColour (Material changeColour)
    {
        rend.material = changeColour;
    }

    IEnumerator FlashRoutine(Material changeColour, Material baseColour, float delay)
    {
        // Change the colour to the specified changeColour Material
        rend.material = changeColour;

        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Change the colour back to the baseColour Material
        rend.material = baseColour;
    }
}
