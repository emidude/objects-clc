using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour {

    public GameObject sphere;

    public List<Vector3> locatons;

    public int numberOfSpheres = 3;

    public List<GameObject> spheres;

    public List<Vector4> all4Dcoords;

    public float wSlice;

    //
    public KeyCode createKey = KeyCode.C;
	
    void Awake(){
        spheres = new List<GameObject>();
        wSlice = 0f;
        all4Dcoords = new List<Vector4>();
        CalculateCoordinates();

        locatons = new List<Vector3> { Vector3.one, Vector3.one * 2f, Vector3.one * 3f };

    }

    // Use this for initialization
	void Start () {
        for (int i = 0; i < numberOfSpheres;i++){
            CreateSpheres(locatons[i],i);  
        }

        for (int i = 0; i < numberOfSpheres;i++){
            Debug.Log("sphere " + i + spheres[i].GetComponent<Info>().Get4DCoords());
        }


	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(createKey))
        {
            //Instantiate(prefab);
            IncrementSlice(); //only worked once at best, dont know why
        }
	}

    void CreateSpheres(Vector3 where, int re){
        GameObject s = Instantiate(sphere);
        s.transform.parent = this.transform;
        s.transform.localPosition = where;
        s.transform.localScale = Vector3.one;
        Info sphereInfo = s.GetComponent<Info>();
        sphereInfo.setCoords4D(all4Dcoords[re]);
        spheres.Add(s);
    }

    void CalculateCoordinates(){
        List<float> numbers = new List<float>();
        float[] options = {1f, -1f};
        for (int i = 0; i < 2;i++){
            for (int j = 0; j < 2;j++){
                for (int k = 0; k < 2;k++){
                    for (int l = 0; l < 2; l ++){
                        numbers.Add(options[i]); 
                        numbers.Add(options[j]);
                        numbers.Add(options[k]);
                        numbers.Add(options[l]);
                    }
                }
            }
        }
        //for (int i = 0; i < numbers.Count; i+=4){
        //    Debug.Log(numbers[i] + " " + numbers[i + 1] + " " + numbers[i + 2] + " " + numbers[i + 3]); 
        //}

        for (int i = 0; i < numbers.Count; i+=4){
            Vector4 v = new Vector4(numbers[i], numbers[i + 1],numbers[i + 2],numbers[i + 3]);
            all4Dcoords.Add(v);
        }

        for (int i = 0; i < all4Dcoords.Count; i++){
            Debug.Log(all4Dcoords[i]);
        }
        Debug.Log("count = " + all4Dcoords.Count);
    }

    void IncrementSlice(){
        wSlice += 1f;
        Debug.Log("wSlice = " + wSlice);
    }



}
