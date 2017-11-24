using RimWorld;
using Verse;
using Verse.AI;

namespace HMTB
{
	[StaticConstructorOnStartup]
	public static class Utilities
	{
		private static WorkTypeDef PlantCutting = DefDatabase<WorkTypeDef>.GetNamed("PlantCutting");

		public static bool AllowedHaulDistance(Pawn pawn, Thing t)
		{
			OpportunityDistance distance = Controller.OpportunisticMode.Value;

			if (distance == OpportunityDistance.HMTB_Unrestricted)
			{
				return true;
			}

			float maxSearchDistance;

			switch (distance)
			{
				case OpportunityDistance.HMTB_Close:
					maxSearchDistance = 15f; //Close
					break;
				case OpportunityDistance.HMTB_Medium:
					maxSearchDistance = 45f; //Medium
					break;
				default:
					maxSearchDistance = 100f; //Long
					break;
			}

			return t.Position.DistanceTo(pawn.Position) <= maxSearchDistance;
		}

		/* RimWorld.GenConstruct.HandleBlockingThingJob
		 * Tweaked vanilla code to disregard construction and only cut plants if the hauler is a PlantCutter */
		public static Job HandleBlockingThingJob(Thing firstBlocking, Pawn p, bool forced = false)
		{
			if (firstBlocking.def.category == ThingCategory.Plant)
			{
				if (p.workSettings.GetPriority(PlantCutting) > 0)
				{
					if (p.CanReserveAndReach(new LocalTargetInfo(firstBlocking), PathEndMode.ClosestTouch, p.NormalMaxDanger(), 1, -1, null, forced))
					{
						return new Job(JobDefOf.CutPlant, firstBlocking);
					}
				}
			}

			else if (firstBlocking.def.category == ThingCategory.Item && firstBlocking.def.EverHaulable)
			{
				return HaulAIUtility.HaulAsideJobFor(p, firstBlocking);
			}

			return null;
		}

		/* RimWorld.GenConstruct.CanConstruct
		 * Tweaked vanilla code to disregard pawn skill */
		public static bool CanDeliverResources(Thing t, Pawn p, bool forced = false)
		{
			Danger maxDanger = !forced ? p.NormalMaxDanger() : Danger.Deadly;

			return !t.IsBurning() && p.CanReserveAndReach(new LocalTargetInfo(t), PathEndMode.Touch, maxDanger, 1, -1, null, forced);
		}
	}
}
