using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float verticalInput;
    [SerializeField]
    float horizontalInput;

    public GameObject bulletPref;
    private Vector3 pos;

    private void Start()
    {
        StartCoroutine("CreateBullet");
    }

    private void Update()
    {
        Mover();
        pos = transform.position;
    }

    void Mover()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * 10);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * 10);
    }
    IEnumerator CreateBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate<GameObject>(bulletPref, pos, Quaternion.identity);

        }
    }
}
