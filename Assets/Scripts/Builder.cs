
using UnityEngine;

public class Builder : MonoBehaviour
{
    public static Builder instance;

    public GameObject turret1;
    public GameObject turret2;
    private TurretBlueprint turretchosen;

    private Node selectedNode;
    public TurretUI turretui;

    void Awake()
    {   
        if(instance != null)
        {
            Debug.LogError("More than one buildmanager in scene");
            return;
        }
        instance = this;
        
    }
 
    

    public bool CanBuild{get{ return turretchosen != null;}}
    public bool HasEnoughMoney{get{ return GameStats.Money>= turretchosen.cost;}}


    public void selecturretotbuild(TurretBlueprint turret)
    {   
        turretchosen = turret;
        DeselectNode();
    }

    public void selectNode(Node node)
    {   
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretchosen = null;
        
        turretui.setTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        turretui.Hide();
    }

    public TurretBlueprint GetTurrettoBuild()
    {
        return turretchosen;
    }


    
}
