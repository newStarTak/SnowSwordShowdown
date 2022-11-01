using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public bool isPlayer1;
    public bool isPlayer2;

    private Transform selfTr;

    public float moveSpeed;
    private float h;
    private float v;
    public Vector2 moveDir;
    public bool isLeft;
    public bool isUp;
    public bool isRight;
    public bool isDown;

    public GameObject waterLeft;
    public GameObject waterRight;
    public GameObject waterUp;
    public GameObject waterDown;
    public GameObject Knife;
    public GameObject upgradeKnife;
    public GameObject iceBlock;
    public GameObject HardBlock;
    public Transform firePos;

    public int bucketCount;
    public int bladeRangeCount;
    public float waterTime;

    public bool Stack;

    private Animator anim;

    public GameObject frozen1;
    public GameObject frozen2;
    public GameObject frozen3;
    public GameObject frozen4;
    public GameObject frozen5;
    public GameObject e1;
    public GameObject e2;
    private bool isIced = false;
    private bool isAttackDelayed = false;

    public bool isKnifeUpgraded = false;
    public bool gameFin = false;

    // Sound
    public AudioSource auSrc = null;
    public AudioClip water;
    public AudioClip block;
    public AudioClip blade;
    public AudioClip frozen;

    // Start is called before the first frame update
    void Start()
    {
        selfTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        bucketCount = 0;
        bladeRangeCount = 0;
        waterTime = 0.05f;
        Stack = false;

        // 사운드 관련
        auSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isIced && !isAttackDelayed && !gameFin)
        {
            // player 1
            if (isPlayer1)
            {
                // �̵� �ڵ�
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        v = 1;
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        v = -1;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {
                        h = -1;
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        h = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        anim.SetTrigger("RU");
                        anim.SetBool("RI", false);
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        anim.SetTrigger("RD");
                        anim.SetBool("RI", false);
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        anim.SetTrigger("RL");
                        anim.SetBool("RI", false);
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        anim.SetTrigger("RR");
                        anim.SetBool("RI", false);
                    }
                    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
                    {
                        v = 0;
                    }
                    if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                    {
                        h = 0;
                    }
                    if (moveDir == new Vector2(0f, 0f))
                    {
                        anim.SetBool("RI", true);
                    }
                }

                // �� �Ѹ��� �ڵ�
                if (Input.GetKeyDown(KeyCode.F) && bucketCount > 0)
                {
                    auSrc.PlayOneShot(water, 1f);

                    h = 0;
                    v = 0;

                    isAttackDelayed = true;
                    Invoke("AttackDelayEnd", 0.5f);

                    bucketCount--;
                    if (isLeft)
                    {
                        Instantiate(waterLeft, firePos.position, waterLeft.transform.rotation);
                    }
                    else if (isRight)
                    {
                        Instantiate(waterRight, firePos.position, waterRight.transform.rotation);
                    }
                    else if (isUp)
                    {
                        Instantiate(waterUp, firePos.position, firePos.rotation);
                    }
                    else if (isDown)
                    {
                        Instantiate(waterDown, firePos.position, firePos.rotation);
                    }
                }

                // Į �ֵθ��� �ڵ�
                if (Input.GetKeyDown(KeyCode.E))
                {
                    auSrc.PlayOneShot(blade, 1f);

                    h = 0;
                    v = 0;

                    isAttackDelayed = true;
                    Invoke("AttackDelayEnd", 0.5f);

                    if(isKnifeUpgraded)
                    {
                        Instantiate(upgradeKnife, firePos.transform.position, firePos.transform.rotation);
                    }
                    else
                    {
                        Instantiate(Knife, firePos.transform.position, firePos.transform.rotation);
                    }
                    

                    if (isLeft)
                    {
                        anim.SetTrigger("RAL");
                    }
                    else if (isRight)
                    {
                        anim.SetTrigger("RAR");
                    }
                    else if (isUp)
                    {
                        anim.SetTrigger("RAU");
                    }
                    else if (isDown)
                    {
                        anim.SetTrigger("RAD");
                    }
                }

                // �������� ��ġ �ڵ�
                if (Input.GetKeyDown(KeyCode.Q) && bucketCount > 0)
                {
                    auSrc.PlayOneShot(block, 1f);

                    bucketCount--;
                    if (!Stack)
                    {
                        Instantiate(iceBlock, firePos.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(HardBlock, firePos.transform.position, Quaternion.identity);
                    }
                }

                // �ٶ󺸴� ���� üũ �� firePos ��ġ �缳��
                {
                    if ((Input.GetKeyDown(KeyCode.W)))
                    {
                        isUp = true;
                        isLeft = false;
                        isRight = false;
                        isDown = false;

                        firePos.transform.localPosition = new Vector2(0f, 1.1f);
                        firePos.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.A)))
                    {
                        isUp = false;
                        isLeft = true;
                        isRight = false;
                        isDown = false;

                        firePos.transform.localPosition = new Vector2(-1.1f, 0f);
                        firePos.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.S)))
                    {
                        isUp = false;
                        isLeft = false;
                        isRight = false;
                        isDown = true;

                        firePos.transform.localPosition = new Vector2(0f, -1.1f);
                        firePos.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.D)))
                    {
                        isUp = false;
                        isLeft = false;
                        isRight = true;
                        isDown = false;

                        firePos.transform.localPosition = new Vector2(1.1f, 0f);
                        firePos.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                    }
                }
            }

            // player 2
            if (isPlayer2)
            {
                // �̵� �ڵ�
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    v = 1;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    v = -1;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    h = -1;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    h = 1;
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    anim.SetTrigger("GU");
                    anim.SetBool("GI", false);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    anim.SetTrigger("GD");
                    anim.SetBool("GI", false);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    anim.SetTrigger("GL");
                    anim.SetBool("GI", false);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    anim.SetTrigger("GR");
                    anim.SetBool("GI", false);
                }
                if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
                {
                    v = 0;
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    h = 0;
                }
                if (moveDir == new Vector2(0f, 0f))
                {
                    anim.SetBool("GI", true);
                }


                // �� �Ѹ��� �ڵ�
                if (Input.GetKeyDown(KeyCode.Comma) && bucketCount > 0)
                {
                    auSrc.PlayOneShot(water, 1f);

                    h = 0;
                    v = 0;

                    isAttackDelayed = true;
                    Invoke("AttackDelayEnd", 0.5f);

                    bucketCount--;
                    if (isLeft)
                    {
                        Instantiate(waterLeft, firePos.position, waterLeft.transform.rotation);
                    }
                    else if (isRight)
                    {
                        Instantiate(waterRight, firePos.position, waterRight.transform.rotation);
                    }
                    else if (isUp)
                    {
                        Instantiate(waterUp, firePos.position, firePos.rotation);
                    }
                    else if (isDown)
                    {
                        Instantiate(waterDown, firePos.position, firePos.rotation);
                    }
                }

                // Į �ֵθ��� �ڵ�
                if (Input.GetKeyDown(KeyCode.Slash))
                {
                    auSrc.PlayOneShot(blade, 1f);

                    h = 0;
                    v = 0;

                    isAttackDelayed = true;
                    Invoke("AttackDelayEnd", 0.5f);

                    if (isKnifeUpgraded)
                    {
                        Instantiate(upgradeKnife, firePos.transform.position, firePos.transform.rotation);
                    }
                    else
                    {
                        Instantiate(Knife, firePos.transform.position, firePos.transform.rotation);
                    }

                    if (isLeft)
                    {
                        anim.SetTrigger("GAL");
                    }
                    else if (isRight)
                    {
                        anim.SetTrigger("GAR");
                    }
                    else if (isUp)
                    {
                        anim.SetTrigger("GAU");
                    }
                    else if (isDown)
                    {
                        anim.SetTrigger("GAD");
                    }
                }


                // �������� ��ġ �ڵ�
                if (Input.GetKeyDown(KeyCode.RightShift) && bucketCount > 0)
                {
                    auSrc.PlayOneShot(block, 1f);

                    bucketCount--;
                    if (!Stack)
                    {
                        Instantiate(iceBlock, firePos.transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(HardBlock, firePos.transform.position, Quaternion.identity);
                    }
                }


                // �ٶ󺸴� ���� üũ �� firePos ��ġ �缳��
                {
                    if ((Input.GetKeyDown(KeyCode.UpArrow)))
                    {
                        isUp = true;
                        isLeft = false;
                        isRight = false;
                        isDown = false;

                        firePos.transform.localPosition = new Vector2(0f, 1.1f);
                        firePos.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.LeftArrow)))
                    {
                        isUp = false;
                        isLeft = true;
                        isRight = false;
                        isDown = false;

                        firePos.transform.localPosition = new Vector2(-1.1f, 0f);
                        firePos.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.DownArrow)))
                    {
                        isUp = false;
                        isLeft = false;
                        isRight = false;
                        isDown = true;

                        firePos.transform.localPosition = new Vector2(0f, -1.1f);
                        firePos.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                    }
                    else if ((Input.GetKeyDown(KeyCode.RightArrow)))
                    {
                        isUp = false;
                        isLeft = false;
                        isRight = true;
                        isDown = false;

                        firePos.transform.localPosition = new Vector2(1.1f, 0f);
                        firePos.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                    }
                }
            }

            // �̵� ���� �Ǻ� �ڵ�
            {
                moveDir = (Vector2.up * v) + (Vector2.right * h);

                selfTr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
            }
        }
    }

    void AttackDelayEnd()
    {
        isAttackDelayed = false;
    }

    void Hit1()
    {
        Invoke("Hit12", 0.2f);
        e1.SetActive(true);
        auSrc.PlayOneShot(frozen, 1f);
        frozen1.SetActive(true);
        moveSpeed = 2.5f;
        Invoke("Hit2", 3.0f);
    }

    void Hit12()
    {
        e1.SetActive(false);
        e2.SetActive(true);
        Invoke("Hit14", 0.2f);
    }

    void Hit14()
    {
        e2.SetActive(false);
    }

    void Hit2()
    {
        frozen1.SetActive(false);
        frozen2.SetActive(true);
        moveSpeed = 1f;
        Invoke("Hit3", 2.0f);
    }

    void Hit3()
    {
        frozen2.SetActive(false);
        frozen3.SetActive(true);
        moveSpeed = 0f;
        isIced = true;
        Invoke("Hit4", 1.0f);
    }

    void Hit4()
    {
        frozen3.SetActive(false);
        frozen4.SetActive(true);
        Invoke("Hit5", 1.0f);
    }

    void Hit5()
    {
        frozen4.SetActive(false);
        frozen5.SetActive(true);
        moveSpeed = 1f;
        Invoke("HitEnd", 1.0f);
    }

    void HitEnd()
    {
        frozen5.SetActive(false);
        isIced = false;
        moveSpeed = 5f;
    }

    void GameFin()
    {
        gameFin = true;
    }
}