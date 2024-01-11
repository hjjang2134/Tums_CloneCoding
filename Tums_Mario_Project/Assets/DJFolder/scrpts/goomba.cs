using UnityEngine;

public class goomba : MonoBehaviour
{
    public float movementSpeed = 2f; // ������ �̵� �ӵ�
    public float detectionRadius = 5f; // �������� ������ �ݰ�, ���� ���� �ʿ�

    private Rigidbody rb;
    private GameObject player; // ������ ��ü

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        animator.Play("Wait");
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Mario"); // "Mario" �±׷� ������ ������Ʈ ã��, hierachy���� �������� �±� ����

    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= detectionRadius)
            {
                MoveTowardsMario(); // �������� ���� �̵�
            }
        }
    }

    void MoveTowardsMario()
    {
        // �������� ���� ���ٸ� �̵���Ű�� ���� ���
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 movement = direction * movementSpeed * Time.deltaTime;

        // ���� �̵�
        animator.Play("Noesis Frames");
        rb.MovePosition(transform.position + movement);
    }

    // �÷��̾�� �浹���� �� ȣ��Ǵ� �Լ�
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ���� �������� ���� ���� �ְ�, �Ʒ� �������� �����´ٸ�
            if (collision.contacts[0].normal.y > 0.5f)
            {
                Destroy(gameObject); // ���� ����
            }
            else
            {
                //�������� ���ٰ� �浹���� ��
            }
        }
    }
}