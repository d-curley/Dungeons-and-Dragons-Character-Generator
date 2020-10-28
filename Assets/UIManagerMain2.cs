using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class UIManagerMain2 : MonoBehaviour
{
    public GameObject Name;
    public GameObject Race;
    public GameObject Garb;
    public GameObject Voice;
    public GameObject Secret;
    public GameObject Quirk;
    public GameObject Fight;

    public List<string> Names = new List<string>();
    public List<string> Races = new List<string>();
    public List<string> Garbs = new List<string>();
    public List<string> Voices = new List<string>();
    public List<string> Secrets = new List<string>();
    public List<string> Quirks = new List<string>();
    public List<string> Fights = new List<string>();
   
    public InputField NameInput;
    public InputField RaceInput;
    public InputField GarbInput;
    public InputField VoiceInput;
    public InputField SecretInput;
    public InputField QuirkInput;
    public InputField FightInput;

    void Awake()
    {
        Load();
    }


    public void AddNPC() //page
    {
        SceneManager.LoadScene("AddNPC");
    }

    public void Upload()
    {
        TextCheck(NameInput.text, Names);
        TextCheck(RaceInput.text, Races);
        TextCheck(GarbInput.text, Garbs);
        TextCheck(VoiceInput.text, Voices);
        TextCheck(SecretInput.text, Secrets);
        TextCheck(QuirkInput.text, Quirks);
        TextCheck(FightInput.text, Fights);


        NameInput.text="";
        RaceInput.text = "";
        GarbInput.text = "";
        VoiceInput.text = "";
        SecretInput.text = "";
        QuirkInput.text = "";
        FightInput.text = "";

}

    public void TextCheck(string text, List<string> List) //Won't add text if field is empty
    {//need to add check for if it's in the system
        if (text == "")
        {
            Debug.Log("No text");
        }
        else
        {
            List.Add(text);
            Debug.Log("Added it");
        }
    }

    public void Generate()
    {
        int Namelength = Names.Count;
        int Racelength = Races.Count;
        int Garblength = Garbs.Count;
        int Voicelength = Voices.Count;
        int Secretlength = Secrets.Count;
        int Quirklength = Quirks.Count;
        int Fightlength = Fights.Count;

        Name.GetComponent<Text>().text = Names[Random.Range(0, Namelength)];
        Race.GetComponent<Text>().text = Races[Random.Range(0, Racelength)];
        Garb.GetComponent<Text>().text = Garbs[Random.Range(0, Garblength)];
        Voice.GetComponent<Text>().text = Voices[Random.Range(0, Voicelength)];
        Secret.GetComponent<Text>().text = Secrets[Random.Range(0, Secretlength)];
        Quirk.GetComponent<Text>().text = Quirks[Random.Range(0, Quirklength)];
        Fight.GetComponent<Text>().text = Fights[Random.Range(0, Fightlength)];
    }

    public void Home() //page
    {
        SceneManager.LoadScene("Generate");
    }
   

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath +
            "/NPCsave.save");

        NPCData data = new NPCData();
        data.Names = Names;
        data.Races = Races;
        data.Garbs = Garbs;
        data.Voices = Voices;
        data.Secrets = Secrets;
        data.Quirks = Quirks;
        data.Fights = Fights;
 
        bf.Serialize(file, data);
        file.Close();

        Debug.Log(Names);
        Debug.Log("Game Saved");
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath +
            "/NPCsave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath +
            "/NPCsave.save", FileMode.Open);
            NPCData data = (NPCData)bf.Deserialize(file);
            file.Close();

            Names = data.Names;
            Races = data.Races;
            Garbs  = data.Garbs;
            Voices = data.Voices;
            Secrets = data.Secrets;
            Quirks = data.Quirks;
            Fights = data.Fights;

        }
    }
}

[Serializable]
class NPCData
{
    public List<string> Names = new List<string>();
    public List<string> Races = new List<string>();
    public List<string> Garbs = new List<string>();
    public List<string> Voices = new List<string>();
    public List<string> Secrets = new List<string>();
    public List<string> Quirks = new List<string>();
    public List<string> Fights = new List<string>();
}