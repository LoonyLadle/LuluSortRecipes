using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Verse;

#pragma warning disable IDE1006 // Naming Styles

namespace LoonyLadle.SortRecipes
{
    [StaticConstructorOnStartup]
    public static class SortRecipes
    {
        static SortRecipes()
        {
            List<RecipeDef> sortedList = DefDatabase<RecipeDef>.AllDefs.OrderBy(d => d.label).ToList();
            typeof(DefDatabase<RecipeDef>).GetField("defsList", BindingFlags.NonPublic | BindingFlags.Static).SetValue(new object(), sortedList);
            Log.Message("[Lulu's Sort Recipes] The def database has been sorted.");
        }
    }
}
