﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Core
{
	class DAMechaEyes : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Hard Stare";
			SetNPCHead(NPCID.Guide, false);
			expedition.difficulty = 6;
			expedition.ctgSlay = true;
			expedition.ctgImportant = true;

			expedition.conditionDescription1 = "Face the hallowed defilers";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardMoney(Item.buyPrice(0, 6, 0, 0));
		}
		public override string Description(bool complete)
		{
			return "You will soon face another challenge, not unlike the Eye of Cthulu. This particular fight favors weapons with long reach, so be sure to gear up appropriately. ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!cond1)
			{ expedition.conditionDescription2 = ""; }
			else
			{ expedition.conditionDescription2 = "Defeat The Twins"; }

			// When tracing steps is cleared, or fighting the boss
			return API.FindExpedition<CBTracingSteps>(mod).completed || cond1 ||
				NPC.FindFirstNPC(NPCID.Retinazer) >= 0 ||
				NPC.FindFirstNPC(NPCID.Spazmatism) >= 0;
		}

		public override void OnCombatWithNPC(NPC npc, bool playerGotHit, Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!expedition.condition1Met)
			{
				expedition.condition1Met =
					npc.type == NPCID.Retinazer ||
					npc.type == NPCID.Spazmatism;
			}
		}

		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{

			if (cond1 && !cond2) cond2 = NPC.downedMechBoss2;
			return cond1 && cond2;
		}
	}
}
