using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float initialSpeed = 2f;
    [SerializeField] private float speed;
    [SerializeField] Animator animator;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform positionOfBall;
    [SerializeField] private float ballReadyDelay;
    [SerializeField] private float deathDuration = 1f;
    [SerializeField] private float accelarationWhenWin = 0.001f;
    [SerializeField] private DragAndShoot dragAndShoot;
    private ObstacleSystem currentObstacleSysem;
    private Vector3 positionOnCurrentObstacle;
    private Vector3 startPos;
    private float incrementOfSpeed;
    private Rigidbody rigidbody;
    private GameObject currentBall;
    private bool haveBallNow;
    private bool isGameOver, isWin;



    void Start()
    {
        speed = initialSpeed;
        incrementOfSpeed = 0;
        isWin = false;
        startPos = transform.position;
        currentObstacleSysem = null;
        isGameOver = false;
        rigidbody = GetComponent<Rigidbody>();
        haveBallNow = false;
        InstantiateBall();
    }

    void Update()
    {
        if (!isGameOver)
        {
            ProcessMove();
            MoveBall();
            InstantiateBallIfNull();
        }
    }

    private void ProcessMove()
    {
        if (isWin)
        {
            Accelarate();
        }
        if (!animator.GetBool("isDead"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (speed + incrementOfSpeed));
            Vector3 pos = transform.position;
            pos.x = startPos.x;
            transform.position = pos;
        }
        if (currentObstacleSysem != null && currentObstacleSysem.GetIsCurrentlyRed())
        {
            transform.position = positionOnCurrentObstacle;
        }
    }

    private void InstantiateBallIfNull()
    {
        if(currentBall != null && currentBall.GetComponent<Ball>().GetGotHitByEnemyBall())
        {
            haveBallNow = false;
            StartCoroutine(InstantiateBallCoroutine());
        }
    }

    private void MoveBall()
    {
        if (haveBallNow && currentBall != null && !currentBall.GetComponent<Ball>().GetGotHitByEnemyBall())
        {
            currentBall.transform.position = positionOfBall.transform.position;
        } 
    }

    IEnumerator InstantiateBallCoroutine()
    {
        yield return new WaitForSeconds(ballReadyDelay);
        InstantiateBall();
    }

    private void InstantiateBall()
    {
        if (!haveBallNow)
        {
            currentBall = Instantiate(ballPrefab, positionOfBall.position, ballPrefab.transform.rotation);
            haveBallNow = true;
        }
    }

    public void ThrowBall(Vector3 throwVector, bool isForceModeImpulse)
    {
        if (haveBallNow)
        {
            animator.SetTrigger("shoot");
            currentBall.GetComponent<Ball>().UnfreezePosition();
            if(isForceModeImpulse)
                currentBall.GetComponent<Rigidbody>().AddForce(throwVector,ForceMode.Impulse);
            else
                currentBall.GetComponent<Rigidbody>().AddForce(throwVector);
            currentBall.GetComponent<Ball>().StartDieCoroutine();
            currentBall = null;
            haveBallNow = false;
            StartCoroutine(InstantiateBallCoroutine());
        }
    }

    public void SetCurrentObstacleSystemAndZPos(ObstacleSystem obstacleSystem, float zPos)
    {
        Vector3 pos = transform.position;
        pos.z = zPos;
        positionOnCurrentObstacle = pos;
        this.currentObstacleSysem = obstacleSystem;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Smasher"))
        {
            DieAndSetCurrentPosition(collision.gameObject.GetComponent<Smasher>().GetPosOfAfterSmash().position.z);
        } else if (collision.gameObject.CompareTag("HillObstacle"))
        {
            MoveUpABit();
        } else if(collision.gameObject.CompareTag("FallingBalls"))
        {
            DieAndSetCurrentPosition(transform.position.z + 1);
        } else if (collision.gameObject.CompareTag("EnemyBall") || collision.gameObject.CompareTag("Ball"))
        {
            DieAndSetCurrentPosition(transform.position.z);
        } else if (collision.gameObject.CompareTag("LevelEndCubes"))
        {
            isGameOver = true;
            FindObjectOfType<LevelManager>().OnWin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GameWin"))
        {
            isGameOver = true;
            FindObjectOfType<LevelManager>().OnWin();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("HillObstacle"))
        {
            MoveUpABit();
        }
    }

    private void MoveUpABit()
    {
        rigidbody.AddForce(Time.deltaTime * speed * (Vector3.forward + 100*Vector3.up));
    }

    private void DieAndSetCurrentPosition(float zPos)
    {
        Vector3 pos = transform.position;
        float distance = zPos - pos.z;
        pos.z = zPos;
        transform.position = pos;
        StartCoroutine(DieCoroutine(distance/speed + deathDuration)); ;
    }

    IEnumerator DieCoroutine(float deathDuration)
    {
        animator.SetBool("isDead", true);
        yield return new WaitForSeconds(deathDuration);
        animator.SetBool("isDead", false);
    }

    public void SetIncrementOfSpeedAsPercentage(float incrementOfSpeedAsPercentage)
    {
        incrementOfSpeed = initialSpeed * incrementOfSpeedAsPercentage / 100;
    }

    public void StartWinCondition()
    {
        isWin = true;
        if (dragAndShoot)
        {
            dragAndShoot.StartQuickShots();
        }
        animator.SetTrigger("levelEnd");
    }

    public void StopAndFailDance()
    {
        Stop();
        FailDance();
    }

    public void StopAndWinDance()
    {
        Stop();
        WinDance();
    }

    private void Stop()
    {
        isGameOver = true;
    }

    private void FailDance()
    {
        animator.SetBool("FailDance", true);
    }

    private void WinDance()
    {
        animator.SetBool("WinDance", true);
    }

    private void Accelarate() {
        incrementOfSpeed += (accelarationWhenWin * Time.deltaTime);
    }
}
