using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public static move Instance;

    public GameObject[] fruits;
    public Transform defaultPosition;

    public GameObject nowFruit;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Createfruit();
    }

    void Createfruit()
    {
        int index = Random.Range(0, 4);
        nowFruit = Instantiate(fruits[index]);
        nowFruit.transform.position = defaultPosition.position;
        nowFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (!nowFruit)
            return;
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!(mousePos.x + nowFruit.GetComponent<CircleCollider2D>().radius > 2.8f) &&
                !(mousePos.x - nowFruit.GetComponent<CircleCollider2D>().radius < -2.8f))
                nowFruit.transform.position = new Vector3(mousePos.x, nowFruit.transform.position.y, 0);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            nowFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
            nowFruit = null;
            Invoke("Createfruit", 1.2f);
        }


    }
}
