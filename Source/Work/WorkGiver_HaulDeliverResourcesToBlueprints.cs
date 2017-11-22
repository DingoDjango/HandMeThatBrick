using RimWorld;
using Verse;
using Verse.AI;

namespace HMTB
{
	public class WorkGiver_HaulDeliverResourcesToBlueprints : WorkGiver_ConstructDeliverResourcesToBlueprints
	{
		public override bool ShouldSkip(Pawn pawn)
		{
			return !Controller.EnableMod;
		}

		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			Blueprint blueprint = t as Blueprint;

			if (blueprint == null)
			{
#if DEBUG
				Log.Error($"HMTB :: Tried to pass blueprint of type {t.GetType()}");
#endif

				return false;
			}

			bool materialsAllowed = blueprint is Blueprint_Install ? true : !blueprint.MaterialsNeeded().NullOrEmpty();

			return materialsAllowed && Utilities.AllowedHaulDistance(pawn, blueprint) && this.JobOnThing(pawn, blueprint, forced) != null;
		}

		//Tweaked Job to return only Haul-related results
		public override Job JobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			if (t.Faction != pawn.Faction)
			{
				return null;
			}

			Blueprint blueprint = t as Blueprint;

			Thing firstBlockingThing = GenConstruct.FirstBlockingThing(blueprint, pawn);

			if (firstBlockingThing != null && firstBlockingThing.def.category == ThingCategory.Item && firstBlockingThing.def.EverHaulable)
			{
				return HaulAIUtility.HaulAsideJobFor(pawn, firstBlockingThing);
			}

			if (!Utilities.CanDeliverResources(blueprint, pawn, firstBlockingThing, forced))
			{
				return null;
			}

			if (base.RemoveExistingFloorJob(pawn, blueprint) != null)
			{
				return null;
			}

			Job resourceDeliveryJob = base.ResourceDeliverJobFor(pawn, blueprint, true);

			if (resourceDeliveryJob != null)
			{
				return resourceDeliveryJob;
			}

			return null;
		}
	}
}
