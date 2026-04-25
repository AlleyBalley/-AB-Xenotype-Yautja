using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace ABXenotypeYautja
{
    internal class Recipe_RemoveGauntletModule : Recipe_Surgery
    {
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            bool flag;
            if (!(thing is Pawn pawn))
            {
                flag = false;
            }
            else
            {
                List<Hediff> hediffs = pawn.health.hediffSet.hediffs;
                for (int index = 0; index < hediffs.Count; ++index)
                {
                    if ((!((RecipeWorker)this).recipe.targetsBodyPart || hediffs[index].Part != null) && hediffs[index].Visible)
                        return true;
                }
                flag = false;
            }
            return flag;
        }

        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn1, RecipeDef recipe)
        {
            List<Hediff> allHediffs = pawn1.health.hediffSet.hediffs;
            IEnumerable<Hediff> ValidHediffs = ((IEnumerable<Hediff>)allHediffs).Where<Hediff>((Func<Hediff, bool>)(x => x.Part != null && x.Visible));
            foreach (Hediff validHediff in ValidHediffs)
            {
                DefExtension_GauntletModuleHediff modExtension = ((Def)validHediff.def).GetModExtension<DefExtension_GauntletModuleHediff>();
                bool flag = modExtension == null || !modExtension.isModule;
                if (modExtension != null && modExtension.isModule)
                {
                    foreach (Hediff hediffOnPawn in pawn1.health.hediffSet.hediffs)
                    {
                        if (hediffOnPawn.def == ((RecipeWorker)this).recipe.removesHediff && hediffOnPawn.Part == validHediff.Part)
                            yield return validHediff.Part;
                    }
                    modExtension = (DefExtension_GauntletModuleHediff)null;
                    modExtension = (DefExtension_GauntletModuleHediff)null;
                }
                modExtension = (DefExtension_GauntletModuleHediff)null;
            }
        }

        public override void ApplyOnPawn(
          Pawn pawn,
          BodyPartRecord part,
          Pawn billDoer,
          List<Thing> ingredients,
          Bill bill)
        {
            MedicalRecipesUtility.IsClean(pawn, part);
            if (billDoer != null)
            {
                if (this.CheckSurgeryFail(billDoer, pawn, ingredients, part, bill))
                    return;
                TaleRecorder.RecordTale(TaleDefOf.DidSurgery, new object[2]
                {
          (object) billDoer,
          (object) pawn
                });
                if (!pawn.health.hediffSet.GetNotMissingParts((BodyPartHeight)0, (BodyPartDepth)0, (BodyPartTagDef)null, (BodyPartRecord)null).Contains<BodyPartRecord>(part))
                    return;
                Hediff hediff = GenCollection.FirstOrDefault<Hediff>(pawn.health.hediffSet.hediffs, (Predicate<Hediff>)(x => x.def == ((RecipeWorker)this).recipe.removesHediff));
                if (hediff != null)
                {
                    if (hediff.def.spawnThingOnRemoved != null)
                        GenSpawn.Spawn(hediff.def.spawnThingOnRemoved, ((Thing)billDoer).Position, ((Thing)billDoer).Map, (WipeMode)0);
                    pawn.health.RemoveHediff(hediff);
                }
            }

            if (!((Recipe_RemoveGauntletModule)this).IsViolationOnPawn(pawn, part, Faction.OfPlayer))
                return;
            ((Recipe_RemoveGauntletModule)this).ReportViolation(pawn, billDoer, pawn.HomeFaction, -70, (HistoryEventDef)null);
        }
    }
}
