using HarmonyLib;
using System.Collections.Generic;

namespace CupAPI.Util {
    public static class CustomData {

        public static void PutForSlot(int slot, string key, object value) {
            List<string> list = GetDataForSlot(slot);
            bool keyExists = false;
            foreach (var str in list) {
                string[] split = str.Split(':');
                if (split.Length == 2)
                    if (split[0] == key) {
                        keyExists = true;
                        list.Remove(str);
                        list.Add($"{key}:{value}");
                        break;
                    }
            }
            if (!keyExists)
                list.Add($"{key}:{value}");
        }

        public static string GetForSlot(int slot, string key) {
            List<string> list = GetDataForSlot(slot);
            foreach (var str in list) {
                string[] split = str.Split(':');
                if (split.Length == 2)
                    if (split[0] == key)
                        return split[1];
            }
            return string.Empty;
        }

        private static List<string> GetDataForSlot(int slot) {
            return Traverse.Create(PlayerData.GetDataForSlot(slot)).Field("customData").GetValue<List<string>>();
        }

        internal static void Initialize() {
            for (int i = 0; i < 3; i++) {
                Traverse.Create(PlayerData.GetDataForSlot(i)).Field("customData").SetValue(new List<string>());
            }
        }
    }
}