using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [Tooltip("What needs to hit the button for it to activate")]
    public enum activationCondition { Hammer,Hand,Any}

    public activationCondition Condition;
    public GameObject ButtonPart;
    public Material correctColour;
    public Material incorrectColour;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(Condition)
        {
            case activationCondition.Hand:
                break;
           
            case activationCondition.Hammer:
            break;
            case activationCondition.Any:
            break;
            default:
            Debug.Log("No activation Condition");
                break;

        }
    }

    public void HammerCollide(Collision collision)
    {
        if (collision.gameObject.tag == "HammerHead")//Check if hammer head 
        {
            SocketCombine hammer = collision.gameObject.GetComponent<SocketCombine>();
            ColourManager colour = gameObject.GetComponent<ColourManager>();
            if (hammer.hammerCombined)
            {
                SmoothMovement move = gameObject.GetComponent<SmoothMovement>();
               
                move.MoveAndReturn(Vector3.down, ButtonPart.transform.localScale.y / 2, ButtonPart.transform.localScale.y);
                colour.ChangeColour(correctColour);

                //TODO open door and play sound 
            }
            else
            {
                colour.FlashColour(incorrectColour, 3);
            }



        }
    }
}
