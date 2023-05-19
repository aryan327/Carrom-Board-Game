using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class striker2 : MonoBehaviour
{

    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    CircleCollider2D coll;
    Transform selftrans;
    Vector2 startpos;
    public Slider myslider;
    Vector2 direction;
    Vector3 mousepos;
    Vector3 mouspos2;
    Transform arrowtransorm;
    public GameObject arrowdir;
    public LineRenderer line;
    bool hasStriked = false;
    bool positionset = false;
    public GameObject bord;
    bool no = true;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        selftrans = transform;
        startpos = transform.position;
        arrowtransorm = arrowdir.transform;
        coll = GetComponent<CircleCollider2D>();
    }

    public void shootstriker()
    {
        float x = 0;
        if (positionset && rigidbody.velocity.magnitude == 0)
        {
            x = Vector2.Distance(transform.position, mousepos);
        }
        direction = (Vector2)(mouspos2 - transform.position);
        direction.Normalize();
        rigidbody.AddForce(direction * x * 300);
        hasStriked = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            no = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            no = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        line.enabled = false;
        arrowdir.SetActive(false);

        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 inverseMouPos = new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, Input.mousePosition.z);
        mouspos2 = Camera.main.ScreenToWorldPoint(inverseMouPos);
        mouspos2.y = mouspos2.y + 3;

        if (selftrans.position.x != 0)
        {
            mouspos2.x = mouspos2.x + (selftrans.position.x * 2);
        }
        if (mouspos2.y > 2.66f)
        {
            mouspos2.y = 2.66f;
        }
        if (mouspos2.y < -0.507f)
        {
            mouspos2.y = -0.507f;
        }
        if (mouspos2.x < -2.45f)
        {
            mouspos2.y = -2.45f;
        }
        if (mouspos2.x > 2.61f)
        {
            mouspos2.x = 2.61f;
        }
        if (!hasStriked && !positionset)
        {
            coll.isTrigger = true;
            selftrans.position = new Vector2(myslider.value, startpos.y);
        }
        if (Input.GetMouseButtonUp(0) && rigidbody.velocity.magnitude == 0 && positionset)
        {
            shootstriker();
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && no)
            {
                if (!positionset)
                {
                    positionset = true;
                    coll.isTrigger = false;
                }
            }
        }
        if (positionset && rigidbody.velocity.magnitude == 0)
        {
            arrowdir.SetActive(true);
            line.enabled = true;
            line.SetPosition(0, selftrans.position);
            line.SetPosition(1, mouspos2);
            float angle = AngleBetweenTwoPoints(arrowtransorm.position, mouspos2);
            arrowtransorm.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));
        }
        if (rigidbody.velocity.magnitude < 0.1f && rigidbody.velocity.magnitude != 0)
        {
            strikerreset();
            bord.GetComponent<gameman>().count++;
        }
    }
    public void strikerreset()
    {
        rigidbody.velocity = Vector2.zero;
        hasStriked = false;
        positionset = false;
        line.enabled = true;
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}