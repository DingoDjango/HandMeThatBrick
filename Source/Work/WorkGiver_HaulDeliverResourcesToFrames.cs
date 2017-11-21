using RimWorld;
using Verse;

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
				return false;
			}

			return !frame.MaterialsNeeded().NullOrEmpty() && Utilities.AllowedHaulDistance(pawn, frame) && base.HasJobOnThing(pawn, t, forced);
		}
	}
}
