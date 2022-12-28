using UnityEngine;
using UnityEngine.UI;


public class manabar : MonoBehaviour
{    
    player player;
    public float add_mana = 20;
    public float mana;
    public float maxmana;
    public bool noMana = false;

    public Slider manawheel;
    public Slider manausagewheel;
    void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
       mana = maxmana;
       
    }

    // Update is called once per frame
    void Update()
    {
        manacost();
    }

    void manacost()
    {
        if (player.isMana)
        {
            if (mana > 0 && player.isManablock || player.isManafire)
            {
                mana -= 10 * Time.deltaTime; 
            }

            manausagewheel.value = mana / maxmana + 0.05f;
        }
        else
        {
            // stop mana incrementing
            //if (mana < maxmana)
            //{   
            //    mana += 30 * Time.deltaTime;
            //}
            if (mana >= 100)
            {
                noMana = false;
            }
            manausagewheel.value = mana / maxmana;
        }

        manawheel.value = mana / maxmana;

        if (mana <= 0)
        {
            player.isManafire = false;
            player.anim.SetBool("isfireball", false);
            player.flamethrower.SetActive(false);

            player.isManablock = false;
            player.anim.SetBool("bblocking", false);
            player.blockparticle.SetActive(false);       
        }
    }

      public void updatemana()
    {   
        mana += add_mana;
        if (mana >= 100)
        {
            mana = maxmana;
        }
        //Debug.Log("mana up");
    }
}

