using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public Transform prefab;
    public KeyCode createKey = KeyCode.C;
    public KeyCode newGameKey = KeyCode.N;

    List<Transform> objects;

    void Awake()
    {
        //IMPORTANT - INITIALIS IN AWAKE
        objects = new List<Transform>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(createKey))
        {
            //Instantiate(prefab);
            CreateObject();
        }
        else if (Input.GetKey(newGameKey))
        {
            BeginNewGame();
        }
	}

    void CreateObject(){
        Transform t = Instantiate(prefab);
        t.localPosition = Random.insideUnitSphere * 5f;
        t.localRotation = Random.rotation;
        //LOOK UP HOW TO SET T AS GLOBAL POSITION
        t.localScale = Vector3.one * Random.Range(0.1f, 1f);
        objects.Add(t);
    }

    void BeginNewGame(){
        for (int i = 0; i < objects.Count; i++)
        {
            Destroy(objects[i].gameObject);
            objects.Clear();
        }
    }
}
