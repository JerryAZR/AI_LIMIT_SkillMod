# ActionGroupMod

**ActionGroupMod** is a MelonLoader mod that allows you to override sync-rate (a.k.a. Confidence) costs for specific skills in the game by editing a simple JSON config file.

---

## 🔧 Installation

1. **Install MelonLoader** for your game.
   [https://melonwiki.xyz](https://melonwiki.xyz)

2. **Download and place the following files:**
   - `ActionGroupMod.dll` -> into your game's `Mods` folder
     *(e.g. `GameFolder/Mods/`)*
   - `ActionGroupOverrides.json` -> into your game's `UserData` folder
     *(e.g. `GameFolder/UserData/`)*

3. **Launch the game** - the mod will automatically apply any defined overrides during config loading.

---

## 📄 Configuration Format

The config file uses the following format:

```json
{
  "ActionTypeName1": {
    "ConfidenceCosts": [ int, int, ... ]
  },
  "ActionTypeName2": {
    "ConfidenceCosts": [ int, int, ... ]
  }
}
```
* The key is the ActionType enum as a string (e.g. "P_Tachi_SkillAttack4_2").

* ConfidenceCosts is a list of integers that replaces the skill's original sync-rate costs.

## ✅ Example

```json
{
  "P_Tachi_SkillAttack4_2": {
    "ConfidenceCosts": [0, -5, -5, -5]
  }
}
```

This example modifies the skill "Eureka" of tachi "Materialism" such that on a successful parry,
the first slash costs 0 and the next 3 hits (if not cancelled) restore 5 sync-rate each (-5);

## 📝 Notes

* The override is applied based on the skill's ActionType value.

* Only the ConfidenceCosts field is currently supported.

* Invalid or missing ActionType names will be ignored.

* If no override is found, the original game values are used.
