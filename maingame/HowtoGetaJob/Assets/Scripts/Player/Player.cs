using UnityEngine;

public enum MoveRule
{
    Walk,
    Fly,
}
public class Player : MonoBehaviour
{
    public static Player Instance;

    private MoveRule rule;
    private Transform root;

    public MoveRule Rule
    {
        get { return rule; }
        set
        {
            if (rule != value)
                rule = value;
        }
    }

    private Animator animator;

    private bool lastIsLeft;   //用于保存人物的上一次朝向，问题起源于速度为0时不方便判断朝向，则用该朝向

    public Joystick joystick;
    public float basicSpeed;

    
    void Start()
    {
        Instance = this;
        root = this.transform.GetChild(0);
        Rule = MoveRule.Walk;
        lastIsLeft = false;
        animator = this.transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal;
        float vertical;
        if (joystick.IsDrag)
        {
            horizontal = joystick.Horizontal;
            vertical = joystick.Vertical;
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Horizontal");
        }

        if (Rule.Equals(MoveRule.Fly))
        {
            this.transform.Translate(basicSpeed * horizontal, basicSpeed * vertical, 0);
            SetAnimatorSpeed(horizontal, vertical);
        }
        else if(Rule.Equals(MoveRule.Walk))
        {
            this.transform.Translate(basicSpeed * horizontal, 0, 0);
            SetAnimatorSpeed(horizontal);
        }
    }

    private void SetAnimatorSpeed(float horiontalSpeed, float verticalSpeed = 0)
    {
        float speed = Mathf.Sqrt(horiontalSpeed * horiontalSpeed + verticalSpeed * verticalSpeed) * 4;
        bool isLeft = horiontalSpeed < 0;
        if (horiontalSpeed == 0)
        {
            isLeft = lastIsLeft;
        }
        animator.SetFloat("speed", speed);
        animator.SetBool("isLeft", isLeft);
        lastIsLeft = isLeft;
    }

    public void DressItem(GameObject go)
    {
        Transform rightHand = this.root.Find("right_arm/right_hand");
        GameObject item = GameObject.Instantiate(go, rightHand);
        item.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
        item.gameObject.GetComponent<RectTransform>().sizeDelta = go.gameObject.GetComponent<RectTransform>().sizeDelta;
        item.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.02f, 0.02f, 0.02f);
        GameObject.Destroy(go);
    }
}
