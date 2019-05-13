using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class SavePosition : MonoBehaviour
{
    string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/" + gameObject.name + "myData.dat";
        Debug.Log(savePath);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

       
    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if(!File.Exists(savePath))
        {
            file = File.Create(savePath);
        }
        else
        {
            file = File.Open(savePath, FileMode.Open);
        }
        DataObject data = new DataObject(transform.position);
        bf.Serialize(file, data);
        file.Close();
    }
    void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(savePath))
        {
            FileStream file = File.Open(savePath, FileMode.Open);
            DataObject data = (DataObject)bf.Deserialize(file);
            transform.position = data.GetVector3();
                       
        }
    }
}
[System.Serializable]
public class DataObject
{
    public float x;
    public float y;
    public float z;

    public DataObject(Vector3 position)
    {
        x = position.x;
        y = position.y;
        z = position.z;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(x, y, z);
    }
}
