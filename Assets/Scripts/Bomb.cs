using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    public Player owner;
    public Coroutine timer;
    public GameObject explosion;
    public int force = 2;
    public string dir = "all";
    Transform tr;
    void Start()
    {
        timer = StartCoroutine("AutoDestroy");
        tr = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("BombExplosion"))
        {
            Destroy(other.gameObject);
        }
    }
    IEnumerator Explode()
    {
        Explosion exp = Instantiate(explosion, tr.position, tr.rotation, null).GetComponent<Explosion>();
        exp.Explode("all");
        if (timer != null)
        {
            StopCoroutine(timer);
        }

        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
    void SetOwner(Player p)
    {
        owner = p;
    }
    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Collider>().enabled = false;


        StartCoroutine(Explode());


    }
    private void OnDestroy()
    {
        owner.bombCount++;
    }
}
