using UnityEngine;

namespace Assets.Scripts.Conservation
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private GameObject[] buldings;

        private Storage storage;
        private GameData gameData;

        private void Start()
        {
            storage = new Storage();
            Load();
        }

        public void Save()
        {
            for (int i= 0; i < buldings.Length; i++)
            {
                gameData.position = buldings[i].transform.position;
                gameData.rotation = buldings[i].transform.rotation;
                storage.Save(gameData);
            }
        }

        private void Load()
        {
            gameData = (GameData)storage.Load(new GameData());
            for (int i= 0;i < buldings.Length; i++)
            {
                gameData = (GameData)storage.Load(new GameData());
                buldings[i].transform.position = gameData.position;
                buldings[i].transform.rotation = gameData.rotation;
            }
        }
    }
}
