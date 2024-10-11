using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem part;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "PlayerOne")
        {
            Debug.Log("Death1");

        }
        else if (other.tag == "PlayerTwo")
        {
            Debug.Log("Death2");
        }
    }
}
