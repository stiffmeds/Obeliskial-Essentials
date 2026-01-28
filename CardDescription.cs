using HarmonyLib;
using System.Text;
using static Obeliskial_Essentials.CardDescriptionNew;

namespace Obeliskial_Essentials
{
  [HarmonyPatch]
  public class CardDescriptionUpdated
  {
    [HarmonyPrefix]
    [HarmonyPatch(typeof(CardData), "AddFormattedDescription")]
    public static void AddFormattedDescriptionPrefix(ref CardData __instance,
                                               StringBuilder builder, string descriptionId, string[] descriptionArgs)
    {
      // BinbinCustomText(TextLocation.Beginning, ref builder, __instance.Id);

    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(CardData), "AddFormattedDescription")]
    public static void AddFormattedDescriptionPostfix(ref CardData __instance,
                                               StringBuilder builder, string descriptionId, string[] descriptionArgs)
    {
      // BinbinCustomText(TextLocation.End, ref builder, __instance.Id);
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(CardData), "AppendCardDescription")]
    public static void AppendCardDescriptionPrefix(ref CardData __instance,
                                               Character character, StringBuilder builder, StringBuilder aux, string grColor, string endColor, string br1, string goldColor)
    {
      BinbinCustomText(TextLocation.Beginning, ref builder, __instance.Id);
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(CardData), "AppendCardDescription")]
    public static void AppendCardDescriptionPostfix(ref CardData __instance,
                                               Character character, StringBuilder builder, StringBuilder aux, string grColor, string endColor, string br1, string goldColor)
    {
      BinbinCustomText(TextLocation.End, ref builder, __instance.Id);
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(CardData), "AppendItemDescription")]
    public static void AppendItemDescriptionPrefix(ref CardData __instance,
                                               Character character, StringBuilder builder, StringBuilder aux, string grColor, string endColor, string goldColor)
    {
      BinbinCustomText(TextLocation.ItemBeginning, ref builder, __instance.Id);
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(CardData), "AppendItemDescription")]
    public static void AppendItemDescriptionPostfix(ref CardData __instance,
                                               Character character, StringBuilder builder, StringBuilder aux, string grColor, string endColor, string goldColor)
    {
      BinbinCustomText(TextLocation.End, ref builder, __instance.Id);
    }

  }
}