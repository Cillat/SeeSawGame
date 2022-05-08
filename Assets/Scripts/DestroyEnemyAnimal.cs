using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyAnimal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeathFloor"))
        {
            this.gameObject.GetComponent<EnemyAnimalWeight>().minus();
            Destroy(gameObject);
            Debug.Log("Destroy");
        }
    }
}
