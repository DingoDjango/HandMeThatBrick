using System.Collections.Generic;
using System.Linq;
using Verse;

namespace HMTB
{
	[StaticConstructorOnStartup]
	public static class Utilities
	{
		public static IEnumerable<Thing> WorkThingsOpportunistic(Pawn pawn, ThingRequest request)
		{
			IEnumerable<Thing> allMatchingThings = pawn.Map.listerThings.ThingsMatching(request);

			if (Controller.OpportunisticMode.Value == OpportunityDistance.HMTB_Unrestricted)
			{
				return allMatchingThings;
			}

			else
			{
				float maxSearchDistance;

				switch (Controller.OpportunisticMode.Value)
				{
					case OpportunityDistance.HMTB_Close:
						maxSearchDistance = 15f;
						break;
					case OpportunityDistance.HMTB_Medium:
						maxSearchDistance = 45f;
						break;
					default:
						maxSearchDistance = 100f; //(Long)
						break;
				}

				return allMatchingThings.Where(t => t.Position.DistanceTo(pawn.Position) < maxSearchDistance);
			}
		}
	}
}
