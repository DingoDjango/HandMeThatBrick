using RimWorld;
using Verse;
using Verse.AI;

namespace HMTB
{
	public class WorkGiver_HaulDeliverResourcesToFrames : WorkGiver_ConstructDeliverResourcesToFrames
	{
		public override bool ShouldSkip(Pawn pawn)
		{
			return !Controller.EnableMod;
		}

		public override bool HasJobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			Frame frame = t as Frame;

			if (frame == null)
			{
#if DEBUG
				Log.Error($"HMTB :: Tried to pass frame of type {t.GetType()}");
#endif

				return false;
			}

			return !frame.MaterialsNeeded().NullOrEmpty() && Utilities.AllowedHaulDistance(pawn, frame) && this.JobOnThing(pawn, frame, forced) != null;
		}

		public override Job JobOnThing(Pawn pawn, Thing t, bool forced = false)
		{
			if (t.Faction != pawn.Faction)
			{
				return null;
			}

			Frame frame = t as Frame;

			Thing firstBlockingThing = GenConstruct.FirstBlockingThing(frame, pawn);

			if (firstBlockingThing != null && firstBlockingThing.def.category == ThingCategory.Item && firstBlockingThing.def.EverHaulable)
			{
				return HaulAIUtility.HaulAsideJobFor(pawn, firstBlockingThing);
			}

			if (!Utilities.CanDeliverResources(frame, pawn, firstBlockingThing, forced))
			{
				return null;
			}

			Job resourceDeliveryJob = base.ResourceDeliverJobFor(pawn, frame, true);

			if (resourceDeliveryJob != null)
			{
				return resourceDeliveryJob;
			}

			return null;
		}
	}
}
