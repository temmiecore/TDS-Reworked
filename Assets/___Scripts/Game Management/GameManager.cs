using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public SaveState saveState;
    private string filePath;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        filePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "/save.data";

        SceneManager.sceneLoaded += OnLoadScene;
        SceneManager.sceneLoaded += LoadData;

        /// ADD DontDestroyOnLoad FOR EVERY NON-DESTRUCTABLE OBJECTS
    }

    [Header("Player class")]
    public PlayerClass playerClass;

    [Header("References assigned on Start()")]
    public Player player;
    public PlayerMover playerMover;
    public Inventory inventory;
    public ItemUseController itemUseController;
    public ClassManager classManager;
    public SpellController spellController;

    [Header("References assigned in inspector")]
    public Health playerHealthComponent;
    public WeaponController playerWeaponController;
    public Animator playerAnimator;

    [Header("BTM has to be assigned in the inspector")]
    public BehaviourTreeManager behaviourTreeManager;

    [Header("Floating text prefab")]
    public FloatingText floatingTextObject;

    [Header("Items prefabs lists. Index of the item = index of the enum value")]
    public List<GameObject> consumablePrefabs;
    public List<GameObject> artefactPrefabs;

    [Header("Player XP to Level table")]
    public List<int> xpToLevelTable;

    void Start()
    {
        player = FindObjectOfType<Player>();
        inventory = FindObjectOfType<Inventory>();
        playerMover = FindObjectOfType<PlayerMover>();
        itemUseController = FindObjectOfType<ItemUseController>();
        classManager = GetComponent<ClassManager>();
        spellController = FindObjectOfType<SpellController>();

        classManager.ApplyClassParameters(playerClass);
    }

    public void SaveData()
    {
        if (saveState == null)
            saveState = new SaveState();

        FileStream dataStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveState);

        dataStream.Close();

        Debug.Log("Game saved");
    }

    public void LoadData(Scene s, LoadSceneMode mode)
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            SaveState data = (SaveState)bf.Deserialize(file);
            file.Close();

            /// Here SaveState values are assigned to GameManager values, sprites are changed, etc etc

            Debug.Log("Game loaded");
        }
        else
            return;
    }

    public void OnLoadScene(Scene s, LoadSceneMode mode)
    {
        /// If anything needs to happen on scene loads, it can happen here
    }

    public void InstantiateFloatingText(string text, Color color, float liveTime, int animId, Transform target)
    {
        FloatingText floatingTextInstance = Instantiate(floatingTextObject, new Vector3(target.position.x, target.position.y + 0.1f, 0), target.rotation);

        floatingTextInstance.text = text;
        floatingTextInstance.color = color;
        floatingTextInstance.liveTime = liveTime;
        floatingTextInstance.animId = animId;

        floatingTextInstance.InstantiateText();
    }


    public int CalculateHPFromVitality(int vitality) /// 5-40, 10-50, 20-70, 30-90
    {
        return (2 * vitality + 30);
    }

    public int CalculateManaFromWisdom(int wisdom) /// 5-30, 10-50, 20-90, 30-130
    {
        return (4 * wisdom + 10);
    }

    public void PlayerAddXP(int xp)
    {
        player.xp += xp;
        /// SAVESTATE

        InstantiateFloatingText("+ " + xp + "XP", Color.yellow, 1f, 1, player.transform);

        if (player.xp >= xpToLevelTable[player.level])
        {
            PlayerLevelUp();
        }
    }

    public void PlayerLevelUp()
    {
        player.level += 1;
        player.xp -= xpToLevelTable[player.level - 1];
        InstantiateFloatingText("Level up!", Color.yellow, 1f, 1, player.transform);

        PlayerAddXP(0);
    }
}
