using UnityEngine;
using System.Collections;

public class MyDraw : MonoBehaviour {

    public Vector3 position;

    public Vector3 oldposition;

    public int num;

    public int LineNum;

    public GameObject prefab;
    // Use this for initialization
    void Start () {
        position = Vector3.zero;
        oldposition = Vector3.zero;
        num = 0;
        LineNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            position.z = 0.0f;
            num++;
            if(num > 1)
            {
                float length = getlength(position, oldposition);
                GameObject gobj = Instantiate(prefab) as GameObject;
                gobj.transform.position = (position + oldposition) * 0.5f;
                gobj.transform.localScale = new Vector3(length, 0.05f, 1.0f);
                float angle = Vector3.Angle(Vector3.right, position - oldposition);
                if ((position - oldposition).y < 0)
                {
                    angle = -angle;
                }
                gobj.transform.Rotate(0.0f,0.0f,angle);
                GameObject go = GameObject.Find("Line" + LineNum.ToString());
                gobj.transform.SetParent(go.transform);
            }
            else
            {
                GameObject gobj = new GameObject();
                gobj.name = "Line" + LineNum.ToString();
            }
            Debug.Log(position);
            Debug.Log(oldposition);
            Debug.Log(position-oldposition);
            Debug.Log(Vector3.Angle(Vector3.right, position - oldposition));
            oldposition = position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            LineNum++;
            num = 0;
        }
	}

    float getlength(Vector3 v1,Vector3 v2)
    {
        return Mathf.Sqrt((v1.x - v2.x) * (v1.x - v2.x) + (v1.y - v2.y) * (v1.y - v2.y));
    }
}
