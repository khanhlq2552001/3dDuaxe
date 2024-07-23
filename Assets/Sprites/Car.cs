using UnityEngine;

public class Car : MonoBehaviour
{
    public float Speed = 100f;
    public float lucReXe = 100f;
    public float lucPhanh = 50f;
    public GameObject effect;

    private float valueVertical;
    private float valueHorizontal;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        valueVertical = Input.GetAxis("Vertical");
        valueHorizontal = Input.GetAxis("Horizontal");
        
    }
    private void FixedUpdate()
    {
        
        MoveCar();
        MoveCarLeftRight();
        if (Input.GetKey(KeyCode.LeftShift) && valueVertical > 0)
        {
            PhanhXe();
        }
    }

    public void MoveCar()
    {
        rb.AddRelativeForce(Vector3.forward * valueVertical * Speed);
        effect.SetActive(false);
    }
    public void MoveCarLeftRight()
    {
        Quaternion re = Quaternion.Euler(Vector3.up * valueHorizontal * lucReXe * Time.deltaTime);
        rb.MoveRotation(rb.rotation * re);
    }
    public void PhanhXe()
    {
         rb.AddRelativeForce(- Vector3.forward * lucPhanh);
        effect.SetActive(true);
    }
}
