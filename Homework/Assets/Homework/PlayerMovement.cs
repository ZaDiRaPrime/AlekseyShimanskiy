using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _firstLetter, _secondLetter;
    [SerializeField] private Rigidbody _rigibody;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _jumpCount;
    [SerializeField] private int _speed;
    [SerializeField] private Mass _mass;
    private void Start()
    {
       
    }
     public void Update()
    { 
       if(Input.GetKey(KeyCode.W))
        {
            _rigibody.velocity = new Vector3(0, 0, _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigibody.velocity = new Vector3(0, 0, -_speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigibody.velocity = new Vector3(-_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rigibody.velocity = new Vector3(_speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _rigibody.velocity = new Vector3(0, _speed, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }
   
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
        if (_mass.Amount > collision.gameObject.GetComponent<Mass>().Amount)
        {
            Debug.Log("Столкнулся и съел,а сколько съел и кого? Тут он не скажет, он гордон фримен");
        }
        else
        {
            Debug.Log("не твой уровень дорогой");
        }
    }
}
