using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Mass _mass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Mass>())
        {
            if (_mass.Amount > collision.gameObject.GetComponent<Mass>().Amount)
            {
                _mass.Amount += collision.gameObject.GetComponent<Mass>().Amount;
                transform.localScale = new Vector3(_mass.Amount, _mass.Amount, _mass.Amount);

                Destroy(collision.gameObject);
            }
        }


        Debug.Log("не ну ты конечно лохозавр))))");
    }
}

