using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurretUI : MonoBehaviour
{   
     public GameObject ui;
     public Text UcostText;
     public Text sText;
     public Button upgradeBtn;
   private Node TargetNode;
   public void setTarget(Node target)
   {
        TargetNode = target;

        sText.text = target._turretBlueprint.sellAmount().ToString() + "G";

        transform.position = target.GetBuildPosition();
        if(!target.isUpgraded)
        {
          UcostText.text = target._turretBlueprint.upgradecost.ToString() + "G";
          upgradeBtn.interactable = true;
        }else{
          UcostText.text = "Max Upgrade";
          upgradeBtn.interactable = false;
        }
        
        
        ui.SetActive(true);
   }

   public void Hide()
   {
    ui.SetActive(false);
   } 


     public void Upgrade()
     {
          TargetNode.UpgradeTower();
          Builder.instance.DeselectNode();
     }
   public void Sell()
   {
     TargetNode.SellTower();
     Builder.instance.DeselectNode();
   }
}
