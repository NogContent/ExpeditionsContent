﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Core
{
	class DAMechaWorm : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Mechanical Mayhem";
			SetNPCHead(NPCID.Guide, false);
			expedition.difficulty = 6;
			expedition.ctgSlay = true;
			expedition.ctgImportant = true;

			expedition.conditionDescription1 = "Face the burrowing war machine";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardMoney(Item.buyPrice(0, 4, 0, 0));
		}
		public override string Description(bool complete)
		{
			return "Deep beneath the earth lies a humongous war machine that draws closer every night. Despite its size it is quite lumbersome, you may find piercing weapons advantageous against it. ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!cond1)
			{ expedition.conditionDescription2 = ""; }
			else
			{ expedition.conditionDescription2 = "Defeat The Destroyer"; }

			// When tracing steps is cleared, or fighting the boss
			return API.FindExpedition<CBTracingSteps>(mod).completed || cond1 ||
				NPC.FindFirstNPC(NPCID.TheDestroyer) >= 0 ||
				NPC.FindFirstNPC(NPCID.TheDestroyerBody) >= 0 ||
				NPC.FindFirstNPC(NPCID.TheDestroyerTail) >= 0;
		}

		public override void OnCombatWithNPC(NPC npc, bool playerGotHit, Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!expedition.condition1Met)
			{
				expedition.condition1Met =
					npc.type == NPCID.TheDestroyer ||
					npc.type == NPCID.TheDestroyerBody ||
					npc.type == NPCID.TheDestroyerTail ||
					npc.type == NPCID.Probe;
			}
		}

		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{

			if (cond1 && !cond2) cond2 = NPC.downedMechBoss1;
			return cond1 && cond2;
		}
	}
}
