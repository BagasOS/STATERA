using UnityEngine;
using System.Collections;

public class csDemoScenceControl : MonoBehaviour {

    public GameObject[] AllEffect;
    int i;
    public GUIText Text;
    public Transform mg;
    GameObject MakedObject;
    public bool isIngredientScene;
    csColorChangerinSampleScene cs;
    void Start()
    {
        i = 1;
        MakedObject = Instantiate(AllEffect[i - 1], AllEffect[i - 1].transform.position, Quaternion.identity) as GameObject;
        Text.text = "("+(i)+"/"+AllEffect.Length+") "+AllEffect[i-1].name;
    }

    void Update()
    {
        if (mg)
            cs = mg.GetComponent<csColorChangerinSampleScene>();
        

        if (Input.GetKeyDown(KeyCode.X))
        {
            if ((i - 1) <= AllEffect.Length-2)
                i++;
            else
                i = 1;
            Destroy(MakedObject);
            MakedObject = Instantiate(AllEffect[i - 1], AllEffect[i - 1].transform.position, AllEffect[i-1].transform.rotation) as GameObject;
            Text.text = "(" + i + "/" + AllEffect.Length + ") " + AllEffect[i-1].name;
            if (isIngredientScene)
            {
                if (cs.Saved)
                    cs.ChangeColor(cs.SaveColor);
            }

        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if ((i - 1) > 0)
                i--;
            else
                i = AllEffect.Length;
            Destroy(MakedObject);
            MakedObject = Instantiate(AllEffect[i - 1], AllEffect[i - 1].transform.position, AllEffect[i - 1].transform.rotation) as GameObject;
            Text.text = "(" + i + "/" + AllEffect.Length + ") " + AllEffect[i-1].name;
            if (isIngredientScene)
            {
                if (cs.Saved)
                    cs.ChangeColor(cs.SaveColor);
            }
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(MakedObject);
            MakedObject = Instantiate(AllEffect[i - 1], AllEffect[i - 1].transform.position, AllEffect[i - 1].transform.rotation) as GameObject;
            Text.text = "(" + i + "/" + AllEffect.Length + ") " + AllEffect[i-1].name;
            if (isIngredientScene)
            {
                if (cs.Saved)
                    cs.ChangeColor(cs.SaveColor);
            }
        }
    }

}