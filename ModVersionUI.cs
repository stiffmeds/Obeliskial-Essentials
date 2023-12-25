﻿using UnityEngine.UI;
using UnityEngine;
using UniverseLib.UI;
using UniverseLib.UI.Models;
using static Obeliskial_Essentials.Essentials;
using System;

namespace Obeliskial_Essentials
{

    public class ObeliskialUI : MonoBehaviour
    {
        private static UIBase uiBase;
        private static GameObject uiRoot;
        private static GameObject showAtStartGO;
        private static Toggle showAtStartToggle;
        internal static Text modVersions;
        /*private static GameObject uiVert;
        private static RectTransform uiRect;
        private static GameObject lockAtOGO;
        internal static Toggle lockAtOToggle;

        internal static ButtonRef settingsBtn;
        internal static ButtonRef userToolsBtn;
        internal static ButtonRef devToolsBtn;
        internal static ButtonRef hideBtn;
        internal static Text labelMouseX;
        internal static Text labelMouseY;*/
        internal static bool ShowUI
        {
            get => uiBase != null && uiBase.Enabled;
            set
            {
                if (uiBase == null || !uiBase.RootObject || uiBase.Enabled == value)
                    return;

                UniversalUI.SetUIActive(PluginInfo.PLUGIN_GUID + ".versionUI", value);
            }
        }
        internal static void InitUI()
        {
            uiBase = UniversalUI.RegisterUI(PluginInfo.PLUGIN_GUID + ".versionUI", UpdateUI);
            //MedsUI MedsPanel = new MedsUI(uiBase);
            uiRoot = UIFactory.CreateUIObject("medsVersionWindow", uiBase.RootObject);
            uiRoot.AddComponent<Image>().color = new Color(0.03f, 0.008f, 0.05f, 0.9f);
            UIFactory.SetLayoutGroup<VerticalLayoutGroup>(uiRoot, false, false, true, true, 5, 8, 8, 8, 8);
            //uiVert = UIFactory.CreateVerticalGroup(uiNav, "medsNavVert", true, false, true, true, 5, new Vector4(4, 4, 4, 4), new Color(0.03f, 0.008f, 0.05f, 0.9f), TextAnchor.UpperLeft);

            RectTransform uiRect = uiRoot.GetComponent<RectTransform>();
            uiRect.pivot = new Vector2(0.5f, 0.5f);
            uiRect.anchorMin = new Vector2(0.5f, 0.5f);
            uiRect.anchorMax = new Vector2(0.5f, 0.5f);
            uiRect.anchoredPosition = new Vector2(uiRect.anchoredPosition.x, uiRect.anchoredPosition.y);
            uiRect.sizeDelta = new(350f, 350f);
            Text title = UIFactory.CreateLabel(uiRoot, "Title", "Registered Mods", TextAnchor.UpperLeft, fontSize: 25);
            title.fontStyle = FontStyle.Bold;
            //title.gameObject.AddComponent<Image>().color = new Color(0.3f, 0.3f, 0.3f, 0.9f);
            UIFactory.SetLayoutElement(title.gameObject, minWidth: 100, minHeight: 20, flexibleHeight: 0); //, flexibleWidth: 100);

            modVersions = UIFactory.CreateLabel(uiRoot, "Mod Versions", "Obeliskial Essentials v" + PluginInfo.PLUGIN_VERSION, TextAnchor.UpperLeft);
            UIFactory.SetLayoutElement(modVersions.gameObject, flexibleHeight: 100);

            GameObject uiHorizontal = UIFactory.CreateUIObject("medsTogglesHorizontal", uiRoot);
            UIFactory.SetLayoutElement(uiHorizontal, flexibleHeight: 0, flexibleWidth: 100);
            UIFactory.SetLayoutGroup<HorizontalLayoutGroup>(uiHorizontal, false, false, true, true, 20, 0, 0, 30, 10, TextAnchor.LowerCenter);
            //GameObject togglesHorizontal = UIFactory.CreateHorizontalGroup(uiVert, "medsTogglesHorizontal", true, true, true, true, 5, new Vector4(4, 4, 4, 4), new Color(), TextAnchor.UpperCenter);

            ButtonRef closeBtn = UIFactory.CreateButton(uiHorizontal, "closeBtn", "Close");
            UIFactory.SetLayoutElement(closeBtn.Component.gameObject, minWidth: 100, minHeight: 30);
            closeBtn.Component.onClick.AddListener(delegate
            {
                ShowUI = false;
            });

            showAtStartGO = UIFactory.CreateToggle(uiHorizontal, "showAtStartToggle", out showAtStartToggle, out Text showAtStartText, checkWidth: 20, checkHeight: 20);
            showAtStartText.text = "Do Not Show Again";
            showAtStartToggle.isOn = !medsShowAtStart.Value;
            UIFactory.SetLayoutElement(showAtStartGO, minWidth: 85, minHeight: 30);
            showAtStartToggle.onValueChanged.AddListener(delegate
            {
                medsShowAtStart.Value = !showAtStartToggle.isOn;
            });

            // ButtonRef tempBtn = UIFactory.CreateButton(medsNav, "tempButton", "TEST");
            // UIFactory.SetLayoutElement(tempBtn.Component.gameObject, minWidth: 80, minHeight: 30, flexibleWidth: 0);
            // RuntimeHelper.SetColorBlock(tempBtn.Component, new Color(0.22f, 0.54f, 0.22f), new Color(0.15f, 0.71f, 0.1f), new Color(0.08f, 0.5f, 0.06f));


            /*labelMouseX = UIFactory.CreateLabel(uiNav, "labelMouseX", "x:", TextAnchor.UpperLeft);
            UIFactory.SetLayoutElement(labelMouseX.gameObject, minWidth: 100);

            labelMouseY = UIFactory.CreateLabel(uiNav, "labelMouseY", "y:", TextAnchor.UpperLeft);
            UIFactory.SetLayoutElement(labelMouseY.gameObject, minWidth: 100);*/

            /*lockAtOGO = UIFactory.CreateToggle(togglesHorizontal, "disableButtonsToggle", out lockAtOToggle, out Text lockAtOText);
            lockAtOText.text = "Lock AtO";
            lockAtOToggle.isOn = false;
            UIFactory.SetLayoutElement(lockAtOGO, minWidth: 85, minHeight: 20);*/
            //settingsBtn = UIFactory.CreateButton(medsNav, "settingsButton", "Settings");
            //UIFactory.SetLayoutElement(settingsBtn.Component.gameObject, minWidth: 85, minHeight: 30, flexibleWidth: 0);


            //userToolsBtn = UIFactory.CreateButton(medsNav, "userToolsBtn", "User Tools");
            //UIFactory.SetLayoutElement(userToolsBtn.Component.gameObject, minWidth: 85, minHeight: 30, flexibleWidth: 0);

            //devToolsBtn = UIFactory.CreateButton(medsNav, "devToolsBtn", "Dev Tools");
            //UIFactory.SetLayoutElement(devToolsBtn.Component.gameObject, minWidth: 85, minHeight: 30, flexibleWidth: 0);


            //hideBtn = UIFactory.CreateButton(medsNav, "hideBtn", "Hide (F1)");
            //UIFactory.SetLayoutElement(hideBtn.Component.gameObject, minWidth: 85, minHeight: 30, flexibleWidth: 0);


            Canvas.ForceUpdateCanvases();
            if (medsShowAtStart.Value)
            {
                ShowUI = true;
                UniversalUI.SetUIActive(PluginInfo.PLUGIN_GUID + ".versionUI", true);
            }
            else
            {
                ShowUI = false;
            }
            LogInfo($"UI... created?!");
        }
        private static void UpdateUI()
        {
            modVersions.text = medsVersionText;
            /*Vector3 newPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            labelMouseX.text = "x:" + newPos.x.ToString();
            labelMouseY.text = "y:" + newPos.y.ToString();*/
        }
    }
    public class DevTools: UniverseLib.UI.Panels.PanelBase
    {
        public static DevTools Instance { get; internal set; }
        public DevTools(UIBase owner) : base(owner)
        {
            Instance = this;
        }
        internal static UIBase uiBase;
        public override string Name => "Developer Tools (F2 to hide)";
        public override int MinWidth => 300;
        public override int MinHeight => 300;
        public override Vector2 DefaultAnchorMin => new(0f, 1f);
        public override Vector2 DefaultAnchorMax => new(0f, 1f);
        public override bool CanDragAndResize => true;
        internal static Text labelMouseXY;
        public static GameObject lockAtOGO;
        public static Toggle lockAtOToggle;
        internal static InputFieldRef inputStartingNode;
        internal static bool ShowUI
        {
            get => uiBase != null && uiBase.Enabled;
            set
            {
                if (uiBase == null || !uiBase.RootObject || uiBase.Enabled == value)
                    return;

                UniversalUI.SetUIActive(PluginInfo.PLUGIN_GUID + ".devToolsUI", value);
                Instance.SetActive(value);
            }
        }
        protected override void ConstructPanelContent()
        {
            GameObject medsDevToolsGO = UIFactory.CreateUIObject("medsDevTools", ContentRoot);
            UIFactory.SetLayoutGroup<VerticalLayoutGroup>(medsDevToolsGO, false, false, true, true, 5, 4, 4, 4, 4, TextAnchor.UpperLeft);
            //medsDevToolsGO.AddComponent<Image>().color = new Color(0.03f, 0.008f, 0.05f, 0.1f);

            labelMouseXY = UIFactory.CreateLabel(medsDevToolsGO, "labelMouseX", "Mouse x: ", TextAnchor.UpperLeft);
            UIFactory.SetLayoutElement(labelMouseXY.gameObject, minWidth: 100);

            ButtonRef btnPartyXP = UIFactory.CreateButton(medsDevToolsGO, "btnPartyXP", "+150 party xp");
            UIFactory.SetLayoutElement(btnPartyXP.Component.gameObject, minWidth: 100, minHeight: 30);
            btnPartyXP.Component.onClick.AddListener(delegate
            {
                for (int i = 0; i < 4; i++)
                {
                    try { AtOManager.Instance.GetHero(i).GrantExperience(150); }
                    catch (Exception e) { LogDebug("Failed to add 150 xp to hero " + i.ToString() + ": " + e.Message); };
                }
            });

            ButtonRef btn1HPEnemies = UIFactory.CreateButton(medsDevToolsGO, "btn1HPEnemies", "Set Enemy HP to 1");
            UIFactory.SetLayoutElement(btn1HPEnemies.Component.gameObject, minWidth: 100, minHeight: 30);
            btn1HPEnemies.Component.onClick.AddListener(delegate
            {
                try
                {
                    NPC[] teamNPC = MatchManager.Instance.GetTeamNPC();
                    foreach (NPC npc in teamNPC)
                    {
                        if (npc != null && npc.Alive)
                            npc.HpCurrent = 1;
                    }
                }
                catch (Exception e) { LogDebug("Failed to set enemy HP to 1: " + e.Message); };
            });
            inputStartingNode = UIFactory.CreateInputField(medsDevToolsGO, "inputStartingNode", "starting node");
            UIFactory.SetLayoutElement(inputStartingNode.Component.gameObject, minWidth: 100, minHeight: 30);
            lockAtOGO = UIFactory.CreateToggle(medsDevToolsGO, "disableButtonsToggle", out lockAtOToggle, out Text lockAtOText);
            lockAtOText.text = "Disable AtO Buttons";
            lockAtOToggle.isOn = false;
            UIFactory.SetLayoutElement(lockAtOGO, minWidth: 85, minHeight: 20);

            Canvas.ForceUpdateCanvases();
        }
        internal static void Init()
        {
            uiBase = UniversalUI.RegisterUI(PluginInfo.PLUGIN_GUID + ".devToolsUI", UpdateUI);
            DevTools devTools = new(uiBase);
            ShowUI = false;
            UniversalUI.SetUIActive(PluginInfo.PLUGIN_GUID + ".devToolsUI", false);
        }
        private static void UpdateUI()
        {
            try
            {
                Vector3 newPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                labelMouseXY.text = "x: " + newPos.x.ToString("0.0000") + " | y: " + newPos.y.ToString("0.0000");
            }
            catch { }
        }

        // override other methods as desired
    }
    /*public class ModVersionUI : MonoBehaviour
    {
        internal static UIBase uiBase { get; private set; }
        //internal static Text modVersions;
        internal static VersionPanel myVersionPanel;
        internal static GameObject lockAtOGO;
        internal static Toggle lockAtOToggle;
        internal static GameObject showAtStartGO;
        internal static Toggle showAtStartToggle;
        public static bool ShowUI
        {
            get => uiBase != null && uiBase.Enabled;
            set
            {
                if (uiBase == null || !uiBase.RootObject || uiBase.Enabled == value)
                    return;

                UniversalUI.SetUIActive(PluginInfo.PLUGIN_GUID, value);
            }
        }
        internal static void InitUI()
        {

            /*uiBase = UniversalUI.RegisterUI(PluginInfo.PLUGIN_GUID, UpdateUI);
            myVersionPanel = new(uiBase);
            myVersionPanel.Rect.pivot = new Vector2(0.5f, 0.3f);
            myVersionPanel.Rect.anchorMin = new Vector2(0.5f, 0.3f);
            myVersionPanel.Rect.anchorMax = new Vector2(0.5f, 0.3f);

            Canvas.ForceUpdateCanvases();
            ShowUI = medsShowAtStart.Value;
            UniversalUI.SetUIActive(PluginInfo.PLUGIN_GUID, Essentials.medsShowAtStart.Value);
            /*myVersionPanel.Rect.anchorMin = new Vector2(1f, 1f);
            myVersionPanel.Rect.anchorMax = new Vector2(1f, 1f);
            myVersionPanel.Dragger.OnEndResize();
        }
        internal static void UpdateUI()
        {
            //modVersions.text = Essentials.medsVersionText;
        }

    }
    */
}