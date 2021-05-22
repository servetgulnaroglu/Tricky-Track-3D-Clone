using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class to implement any type of obstacle
 */
public class ObstacleSystem : MonoBehaviour
{
    [SerializeField] private bool isCurrentlyRed;
    [SerializeField] private MeshRenderer[] body;
    [SerializeField] private Material greenColor;
    [SerializeField] private Material redColor;
    [SerializeField] private Obstacle obstacle;

    void Start()
    {
        SetMaterials();
        obstacle.ChangeState(isCurrentlyRed);
    }

    public void ChangeState()
    {
        isCurrentlyRed = !isCurrentlyRed;
        obstacle.ChangeState(isCurrentlyRed);
        SetMaterials();
    }

    public bool GetIsCurrentlyRed()
    {
        return isCurrentlyRed;
    }


    //sets color to green or red according to currenState
    private void SetMaterials()
    {
        if (isCurrentlyRed && redColor)
        {
            for (int i = 0; i < body.Length; i++)
            {
                body[i].material = redColor;
            }
        }
        else if(greenColor)
        {
            for (int i = 0; i < body.Length; i++)
            {
                body[i].material = greenColor;
            }
        }
    }
}

