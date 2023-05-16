using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Node : MonoBehaviour
{
    [SerializeField] Color hoverColor;
    private Renderer rend;
    private Color startColor;

    public Vector3 position;
    public Vector3 offset;


    public Text text;


    public Color poorColor;
    public GameObject turret;
    public TurretBlueprint _turretBlueprint;
    public bool isUpgraded = false;




    Builder build;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        build = Builder.instance;

        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offset;
    }

    
    void OnMouseDown() 
    {
        

        if(turret != null)
        {
            build.selectNode(this);
            return;
        }

        if(!build.CanBuild)
            return;

        
        Buildturret(build.GetTurrettoBuild());
        

    }

    void OnMouseEnter()
    {
        if(!build.CanBuild)
            return;
        if(build.HasEnoughMoney)
        {
            rend.material.color = hoverColor;
        }else{
            rend.material.color = poorColor;
        }
        
        
        
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
        
    }

    void Buildturret(TurretBlueprint turretBlueprint)
    {
        if(GameStats.Money < turretBlueprint.cost)
        {   
            DisplayText("YOU DONT HAVE ENOUGH MONEY!!!",Color.red);
            
            return;
        }
        GameStats.Money -= turretBlueprint.cost;
        GameObject TURRET = (GameObject)Instantiate(turretBlueprint.prefab, transform.position + position, Quaternion.identity);
        turret = TURRET;

        _turretBlueprint = turretBlueprint;

        DisplayText("Turret Built!",Color.red);
        
    }

    public void UpgradeTower()
    {
        if(GameStats.Money < _turretBlueprint.upgradecost)
        {
            
            DisplayText("YOU DONT HAVE ENOUGH MONEY TO UPGRADE!",Color.red);
            return;
        }
        if(isUpgraded)
        {
            
            DisplayText("This tower is already upgraded!!!",Color.red);
            return;
        }
        GameStats.Money -= _turretBlueprint.upgradecost;
        //Get rid of old turret
        Destroy(turret);
        //new turret
        GameObject TURRET = (GameObject)Instantiate(_turretBlueprint.upgradedprefab, transform.position + position, Quaternion.identity);
        turret = TURRET;

        isUpgraded = true;

        DisplayText("TURRET UPGRADED", Color.green);
    }

    public void SellTower()
    {
        GameStats.Money += _turretBlueprint.sellAmount();

        Destroy(turret);
        _turretBlueprint = null;
    }

    public void DisplayText(string mess, Color color)
    {
        text.text = mess;
        text.color = color;
        Invoke("removeText",3f);
    }

    private void removeText()
    {
        text.text = "";
    }

    
    

    


}
