using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(deathDelay());
    }

    public IEnumerator deathDelay(){
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
