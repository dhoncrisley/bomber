using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    bool freeUp, freeRight, freeDown, freeLeft;
    void Start()
    {
        StartCoroutine("AutoDestroy");

    }
    public void Explode(string direction)
    {
        switch (direction)
        {
            case "up":
                break;
            case "right":
                break;
            case "down":
                break;
            case "left":
                break;
            case "all":
            default:
                break;
        }
    }
    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

}
