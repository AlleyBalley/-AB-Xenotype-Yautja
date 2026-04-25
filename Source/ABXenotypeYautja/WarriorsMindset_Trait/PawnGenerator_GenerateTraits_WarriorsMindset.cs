using HarmonyLib;
using RimWorld;
using Verse;

namespace ABWarriorsMindset_Code
{
    [HarmonyPatch(typeof(PawnGenerator), "GenerateTraits", null)]
    public static class PawnGenerator_GenerateTraits_WarriorsMindset
    {
        public static void Postfix(Pawn pawn)
        {
            Trait trait = (Trait)null;
            foreach (Trait allTrait in pawn.story.traits.allTraits)
            {
                trait = allTrait;
                if (!trait.Label.Equals("ABYautjaWarriorsMindset"))
                    trait = (Trait)null;
                else
                    break;
            }
            if (trait != null)
            {
                pawn.story.traits.allTraits.Remove(trait);
                pawn.skills?.Notify_SkillDisablesChanged();
                if (!pawn.Dead && pawn.RaceProps.Humanlike)
                    pawn.needs.mood.thoughts.situational.Notify_SituationalThoughtsDirty();
                if (!pawn.story.traits.HasTrait(TraitDefOf.Nudist))
                    pawn.story.traits.GainTrait(new Trait(TraitDefOf.Nudist, 0, false), false);
                else if (!pawn.story.traits.HasTrait(TraitDefOf.Psychopath))
                    pawn.story.traits.GainTrait(new Trait(TraitDefOf.Psychopath, 0, false), false);
                else
                    pawn.story.traits.GainTrait(new Trait(TraitDefOf.Kind, 0, false), false);
            }
            if (pawn.story.traits.HasTrait(TraitDefOf_WarriorsMindset.ABYautjaWarriorsMindset))
                return;
            ExtraTraits_WarriorsMindset.ABXYWarriorMindsetTrait(pawn);
        }
    }
}