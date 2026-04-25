using RimWorld;
using Verse;

namespace ABWarriorsMindset_Code
{
    public static class ExtraTraits_WarriorsMindset
    {
        public static void ABXYWarriorMindsetTrait(Pawn pawn)
        {
            pawn.story.traits.GainTrait(new Trait(TraitDefOf_WarriorsMindset.ABYautjaWarriorsMindset, 0, false), false);
        }
    }
}