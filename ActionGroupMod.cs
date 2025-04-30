using MelonLoader;
using HarmonyLib;
using Il2CppGameDef;
using Il2Cpptabtoy;
using static ActionGroupMod.ActionGroupOverrideLoader;

[assembly: MelonInfo(typeof(ActionGroupMod.ActionGroupMod), "ActionGroupMod", "1.0.0", "Jerry", null)]
[assembly: MelonGame("SenseGames", "AILIMIT")]

namespace ActionGroupMod {
    public class ActionGroupMod : MelonMod {

        protected static Dictionary<ActionType, OverrideEntry> Overrides;

        public override void OnInitializeMelon() {
            Overrides = ActionGroupOverrideLoader.Load("UserData/ActionGroupOverrides.json");
        }

        [HarmonyPatch(typeof(Config), "Deserialize", new System.Type[] { typeof(ActionGroupDefine), typeof(DataReader) })]
        static class ActionGroupPatch {
            static void Postfix(ref ActionGroupDefine ins) {
                if (Overrides.TryGetValue(ins.Type, out OverrideEntry entry)) {
                    int numIters = Math.Min(entry.ConfidenceCosts.Count, ins.ConfidenceCostInfos.Count);
                    for (int i = 0; i < numIters; i++) {
                        ins.ConfidenceCostInfos[i].ConfidenceCost = entry.ConfidenceCosts[i];
                    }
                    Melon<ActionGroupMod>.Logger.Msg($"Patched {numIters} ConfidenceConst(s) of {ins.Type}");
                }
            }
        }
    }
}