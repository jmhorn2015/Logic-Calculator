using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReaderScript : MonoBehaviour {
    public float speed;
    char current;
    bool currChange;
    Vector2 pos;
    float endpoint;
    int index;
    int degree;
    Stack<Variable> vars;
    Stack<char> cons;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        currChange = false;
        index = 0;
        degree = 0;
        pos.x = -8.29f;
        pos.y = 1.68f;
        transform.position = pos;
        endpoint = 2.3f;
        vars = new Stack<Variable>();
        cons = new Stack<char>();
    }
	
	// Update is called once per frame
	void Update () {
        pos.x += speed * Time.deltaTime;
        if (currChange)
        {
            currChange = false;
            if (current.GetHashCode() >= 65 & current.GetHashCode() <= 90)
            {
                vars.Push(new Variable(current));
            }
            else if (current.GetHashCode() != 40 & current.GetHashCode() != 41)
            {
                cons.Push(current);
            }
            else if(current.GetHashCode() == 40)
            {
                degree++;
            }
            else if(current.GetHashCode() == 41)
            {
                degree--;
                Variable b = vars.Pop();
                Variable a = vars.Pop();
                char c = cons.Pop();
                vars.Push(new Variable(new Connective(a, b, c)));
            }
        }
        if (pos.x > endpoint)
        {
            if (degree <= 1 & cons.Count > 0)
            {
                degree = 0;
                Variable b = vars.Pop();
                Variable a = vars.Pop();
                char c = cons.Pop();
                vars.Push(new Variable(new Connective(a, b, c)));
            }
            else if (degree > 0)
            {
                Debug.Log("Read Error in line: " + (index+1));
                Debug.Log(degree + "\n" + cons.Count);
            }
            if(index < 3 & vars.Count == 1)
            {
                TextRender.assumptions[index] = vars.Pop();
            }
            else if (index < 3 & vars.Count == 0)
            {
                TextRender.assumptions[index] = new Variable(' ');
            }
            else if (index == 3 & vars.Count == 1)
            {
                TextRender.conclusion = vars.Pop();
            }
            else if(index == 3 & vars.Count == 0)
            {
                Debug.Log("Error: No Conclusion");
            }
            else
            {
                Debug.Log("Error: Multiple Variables left in line: " + (index + 1));
                Debug.Log(index + "\n" + vars.Count);
            }
            pos.y -= 1.24f;
            pos.x = -8.29f;
            index++;
            if (index == 3)
            {
                pos.y -= 2.06f;
            }
            if(index >= 4)
            {
                SceneManager.LoadScene("Results Screen");
            }
            vars = new Stack<Variable>();
            cons = new Stack<char>();
        }
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        if (colliderInfo.gameObject.GetComponent<Identity>() != null)
        {
            current = colliderInfo.gameObject.GetComponent<Identity>().ID;
            currChange = true;
        }
    }
}
