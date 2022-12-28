using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Linq;

public class SavingSystem : MonoBehaviour
{
    /*public static SavingSystem system { get; private set; }
    PlayerData playerData;

    void Start()
    {
        //check if system already exits, if it doesn't, make a new one
        if (system!= null)
        {
            Debug.Log("There is already a saving system initialized");




        }
        system = this;
    }
    public static void Saving(movement move)
    {
        ///Saves current game
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/play.bee";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(move);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData Load()
    {
        ///Loads a saved game
        string path = Application.persistentDataPath + "/play.bee";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else { return null; }
    }
    */
}
