using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float rotateSpeedRandomInterval;
    [SerializeField] private Transform childTransform;
    [SerializeField] private float liveDuration = 5f;
    protected bool gotHitByEnemyBall;
    private Rigidbody rigidbody; 

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        gotHitByEnemyBall = false;
    }

    IEnumerator DieCoroutine(){
        yield return new WaitForSeconds(liveDuration);
        Destroy(gameObject);
    }

    void Update()
    {
        Rotate();   
    }

    public void StartDieCoroutine()
    {
        StartCoroutine(DieCoroutine());
    }

    private void Rotate()
    {
        childTransform.Rotate(new Vector3(rotateSpeed + Random.Range(-rotateSpeedRandomInterval, rotateSpeedRandomInterval),
            rotateSpeed + Random.Range(-rotateSpeedRandomInterval, rotateSpeedRandomInterval),
            rotateSpeed + Random.Range(-rotateSpeedRandomInterval, rotateSpeedRandomInterval)) * Time.deltaTime);
    }

    public void UnfreezePosition()
    {
        if(rigidbody)
            rigidbody.constraints = RigidbodyConstraints.None;
    }

    public bool GetGotHitByEnemyBall()
    {
        return gotHitByEnemyBall;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBall"))
        {
            print("hit enemu ball");
            gotHitByEnemyBall = true;
            UnfreezePosition();
        }
    }
}
