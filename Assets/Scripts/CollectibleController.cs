using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{

    public float riseSpeed = 0.1f;
    public GameObject ParticleEmitter;
    public GameObject particlePrefab;
    public GameObject collectedText;
    private bool collected = false;

    // Update is called once per frame
    void Update()
    {
        if(collected){
            transform.position += new Vector3(0,riseSpeed,0);
        }
    }

    private IEnumerator Kill(){
        yield return new WaitForSeconds(3);
        Destroy(this.transform.parent.gameObject);
    }

    void OnTriggerEnter(Collider other){
        collected = true;
        Instantiate(particlePrefab, ParticleEmitter.transform.position, Quaternion.identity);
        collectedText.SetActive(true);
        StartCoroutine(Kill());
    }
}
