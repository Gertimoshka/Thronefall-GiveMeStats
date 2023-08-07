using I2.Loc;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BetterDescriptions.Patches
{
    public static class PerkSelectionTooltipHelperPatch
    {
        public static void Apply()
        {
            On.PerkSelectionTooltipHelper.UpdateTooltip += UpdateTooltip;

        }

        private static void UpdateTooltip(On.PerkSelectionTooltipHelper.orig_UpdateTooltip orig, PerkSelectionTooltipHelper self)
        {
            TFUIEquippable x = self.targetFrame.CurrentFocus as TFUIEquippable;
            if (x == null)
            {
                return;
            }
            else if (x.Locked)
            {
                orig(self);
            }
            else
            {
                Equippable Data = x.Data;
                string Info = "";

                switch (Data.displayName)
                {
                    case "Royal Mint":
                        Info = "Starting Gold Income: 1 \nIncome Increase For Upgrades: +1";
                        break;
                    case "Arcane Towers":
                        Info = "Tower Base Attack Damage: +2.5\nTower Balista Attack Damage: +40\nTower Attack/Heal Range: +33%";
                        break;
                    case "Heavy Armor":
                        Info = "King Health: +300%\nKing Movement Speed: -20% (During Night Only)";
                        break;
                    case "Caslte Fortifications":
                        Info = "Castle Health : +150%\nCastle Attack Range: +50%\nCastle Attack Per Second: +200%";
                        break;
                    case "Pumpkin Fields":
                        Info = "Fields Health: +50\nFields Income: +1\nFields Cost: +1";
                        break;
                    case "Gods Lotion":
                        Info = "Delay Until Life Regen: -50%\nLife Regen Rate: +100%";
                        break;
                    case "Castle Blueprints":
                        Info = "Walls and Towers Health: +100%";
                        break;
                    case "Gladiator School":
                        Info = "Barracks/Archery Range Cost: +1\nUnit Respawn Speed: +50%";
                        break;
                    case "War Horse":
                        Info = "King Movement Speed: +20%\nRamming Weapon Enabled\nRamming Weapon Damage: 2.5";
                        break;
                    case "Glass Canon":
                        Info = "King Health: -80%\nKing Damage: +100%";
                        break;
                    case "Big Harbours":
                        Info = "Harbours Max Ships: +2\nHarbours Health: +200%";
                        break;
                    case "Elite Warriors":
                        Info = "Unit Health: +100%\nUnit Respawn Speed: -60%";
                        break;
                    case "Archery Skills":
                        Info = "Ranged Unit Range: +60%";
                        break;
                    case "Fortified Houses":
                        Info = "Bugged!\nHouse Health: =50\nHouse Weapon Enabled\nHouse Weapon Damage: 8";
                        break;
                    case "Commander Mode":
                        Info = "King Damage: -50%\nStructure/Unit Damage: +45%";
                        break;
                    case "Healing Spirits":
                        Info = "Undetermined";
                        break;
                    case "Ice Magic":
                        Info = "Undetermined";
                        break;
                    case "Melee Resistence":
                        Info = "Melee Damage Taken: -33%";
                        break;
                    case "Power Tower":
                        Info = "Nearest Tower Attack Speed: +100%";
                        break;
                    case "Ranged Resistence":
                        Info = "Ranged Damage Taken: -33%";
                        break;
                    case "Warrior Mode":
                        Info = "King Damage: +(100%/Night Count) * Night (Max: +100%)\nStructure/Unit Damage: -50%";
                        break;
                    default:
                        //Debug.Log(Data.displayName);
                        orig(self);
                        return;
                }

                string translation = LocalizationManager.GetTranslation(Data.LOCIDENTIFIER_NAME, true, 0, true, false, null, null, true);
                string translation2 = LocalizationManager.GetTranslation(Data.LOCIDENTIFIER_DESCRIPTION, true, 0, true, false, null, null, true);
                translation2 += "\n" + Info;
                self.selectionIcon.sprite = Data.icon;
                self.selectionTitle.text = translation;
                self.selectionDescription.text = translation2;
                self.background.color = x.GetBackgroundColor;
                self.selectionIcon.color = x.GetIconColor;
                self.sizer.Trigger();
            }
        }
    }
}
