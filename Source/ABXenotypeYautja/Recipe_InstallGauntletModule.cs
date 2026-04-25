using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace ABXenotypeYautja
{
    public class Recipe_InstallGauntletModule : Recipe_Surgery
    {
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            Pawn pawn = (Pawn)null;
            if (thing is Pawn)
                pawn = (Pawn)thing;
            if (pawn == null)
                return false;
            foreach (Hediff hediff in pawn.health.hediffSet.hediffs)
            {
                if ((!((RecipeWorker)this).recipe.targetsBodyPart || hediff.Part != null) && hediff.Visible)
                    return true;
            }
            return false;
        }

        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn1, RecipeDef recipe)
        {
            List<Hediff> allHediffs = pawn1.health.hediffSet.hediffs;
            IEnumerable<Hediff> ValidHediffs = ((IEnumerable<Hediff>)allHediffs).Where<Hediff>((Func<Hediff, bool>)(x => x.Part != null && x.Visible && ((Def)x.def).GetModExtension<DefExtension_GauntletModuleHediff>() != null));
            IEnumerable<Hediff> hediffsOnPawn = ((IEnumerable<Hediff>)allHediffs).Where<Hediff>((Func<Hediff, bool>)(x => x.Part != null && x.Visible));
            foreach (Hediff validHediff in ValidHediffs)
            {
                bool partRejected = false;
                if (((RecipeWorker)this).recipe.appliedOnFixedBodyParts.Contains(validHediff.Part.def))
                {
                    foreach (Hediff hediffOnPawn in hediffsOnPawn)
                    {
                        if (hediffOnPawn.Part == validHediff.Part)
                        {
                            if (hediffOnPawn.def == ((RecipeWorker)this).recipe.addsHediff)
                            {
                                partRejected = true;
                                break;
                            }
                            if (((RecipeWorker)this).recipe.incompatibleWithHediffTags != null && hediffOnPawn.def.tags != null)
                            {
                                List<string> matchingTags = ((RecipeWorker)this).recipe.incompatibleWithHediffTags.Intersect<string>((IEnumerable<string>)hediffOnPawn.def.tags).ToList<string>();
                                if (matchingTags != null && GenCollection.Any<string>(matchingTags))
                                    partRejected = true;
                                matchingTags = (List<string>)null;
                            }
                        }
                    }
                    if (!partRejected)
                        yield return validHediff.Part;
                }
            }
        }

        public override void ApplyOnPawn(
          Pawn pawn,
          BodyPartRecord part,
          Pawn billDoer,
          List<Thing> ingredients,
          Bill bill)
        {
            if (billDoer != null)
            {
                if (this.CheckSurgeryFail(billDoer, pawn, ingredients, part, bill))
                    return;
                TaleRecorder.RecordTale(TaleDefOf.DidSurgery, new object[2]
                {
          (object) billDoer,
          (object) pawn
                });
            }
            pawn.health.AddHediff(((RecipeWorker)this).recipe.addsHediff, part, new DamageInfo?(), (DamageWorker.DamageResult)null);
        }
    }
}
