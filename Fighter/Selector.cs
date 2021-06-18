using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Selector : MonoBehaviour
{
    public GameObject[] selections;

    public GameObject p1_selector;
    public GameObject p2_selector;

    public Animator p1_model;
    public Animator p2_model;

    private Animator P1_anim;
    private Animator P2_anim;

    private TextMeshProUGUI P1_Text;
    private TextMeshProUGUI P2_Text;


    private int p1 = -1;
    private int p2 = -1;

    private Color32 p1_c= new Color32(0, 118, 225, 255); //0076FF blue
    private Color32 p2_c = new Color32(168, 26, 26, 255); //A81A1A red

    private GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < selections.Length; i++)
        {
            selections[i].SetActive(false);
        }

        P1_anim = p1_selector.GetComponent<Animator>();
        P2_anim = p2_selector.GetComponent<Animator>();

        P1_Text = p1_selector.GetComponentInChildren<TextMeshProUGUI>();
        P2_Text = p2_selector.GetComponentInChildren<TextMeshProUGUI>();

        p1_model.Play("Static");
        p2_model.Play("Static2");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup >= 4)
        {
            if(p1 == -1)
            {
                p1 = 0;
                p2 = 2;
                selections[p1].SetActive(true);
                selections[p2].SetActive(true);

                selections[p1].GetComponent<Image>().color = p1_c;
                selections[p2].GetComponent<Image>().color = p2_c;

                P1_anim.Play("P1_Select");
                P2_anim.Play("P2_Select");

                P1_Text.text = characterText(p1);
                P2_Text.text = characterText(p2);

                p1_model.Play("Select");
                p2_model.Play("Select2");
            }

            int change = p1;
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (p1 == 0 || p1 == 1 || p1 == 2)
                    p1 = (p1 + 6) % 9;
                else
                    p1 = p1 - 3;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (p1 == 6 || p1 == 7 || p1 == 8)
                    p1 = (p1 + 3) % 9;
                else
                    p1 = p1 + 3;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (p1 == 0 || p1 == 3 || p1 == 6)
                    p1 = (p1 + 2);
                else
                    p1 = p1 - 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (p1 == 2 || p1 == 5 || p1 == 8)
                    p1 = (p1 - 2);
                else
                    p1 = p1 + 1;
            }

            if (change != p1)
                setP1(change);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SceneControl.control.loadNextScene();
            }
        }
    }

    private void setP1(int change)
    {
        selections[change].SetActive(false);
        if (p1 == p2)
        {
            selections[p1].GetComponent<Image>().fillAmount = 0.5f;
            clone = Instantiate(selections[p1], selections[p1].transform.position, Quaternion.identity);
            clone.transform.parent = gameObject.transform;
            clone.GetComponent<Image>().fillAmount = 0.5f;
            clone.GetComponent<Image>().fillOrigin = 1;
            clone.GetComponent<Image>().color = p2_c;
        }
        else
        {
            Destroy(clone);
            selections[p2].SetActive(true);
            selections[p2].GetComponent<Image>().color = p2_c;
            selections[p2].GetComponent<Image>().fillAmount = 1f;

            selections[p1].GetComponent<Image>().fillAmount = 1f;
        }
        selections[p1].SetActive(true);
        selections[p1].GetComponent<Image>().color = p1_c;

        P1_anim.Play("P1_Select", 0, 0);
        P1_Text.text = characterText(p1);
    }

    private string characterText(int i)
    {
        string temp = "";
        switch(i)
        {
            case 0:
                temp = "Yasha   	Difficulty 2/5\nType: Grappler";
                break;
            case 1:
                temp = "Nott    	Difficulty 5/5\nType: Stance";
                break;
            case 2:
                temp = "MollyMauk   Difficulty 3/5\nType: Rush";
                break;
            case 3:
                temp = "Fjord   	Difficulty 1/5\nType: Shoto";
                break;
            case 4:
                temp = "Caleb   	Difficulty 4/5\nType: Range";
                break;
            case 5:
                temp = "Jester   	Difficulty 1/5\nType: Shoto";
                break;
            case 6:
                temp = "Beau   	    Difficulty 3/5\nType: Rush";
                break;
            case 7:
                temp = "Random   	Difficulty ?/5\nType: ???";
                break;
            case 8:
                temp = "Caduceus   	Difficulty 2/5\nType: Heavy";
                break;
        }

        return temp;
            
    }
}
