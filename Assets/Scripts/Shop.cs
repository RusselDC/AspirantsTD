
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{   
    Builder build;
    public TurretBlueprint turret1;
    public TurretBlueprint turret2;

    public Text text;

    

    public TurretBlueprint turret3;
    void Start()
    {
        build = Builder.instance;
    }
    public void selectturret1()
    {
        
        text.text = "Standard Turret SELECTED";
        text.color = Color.green;
        build.selecturretotbuild(turret1);
        Invoke("RemoveText",3f);   
    }
    public void selectturret2()
    {
        
        text.text = "Missile Turret SELECTED";
        text.color = Color.green;
        build.selecturretotbuild(turret2);
        Invoke("RemoveText",3f);   
    }
    public void selectturret3()
    {
        text.text = "Laser Turret SELECTED";
        text.color = Color.green;
        build.selecturretotbuild(turret3);
        Invoke("RemoveText",3f);   
    }
    private void RemoveText()
    {
        text.text = "";
    }


}
