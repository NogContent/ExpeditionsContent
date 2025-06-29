﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Core
{
	class CBLivingLoot : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Living Loot";
			SetNPCHead(NPCID.Guide, false);
			expedition.difficulty = 4;
			expedition.ctgSlay = true;

			expedition.partyShare = true;

			expedition.conditionDescription1 = "Defeat a Mimic";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardMoney(Item.buyPrice(0, 2, 0, 0));
		}
		public override string Description(bool complete)
		{
			return "Be cautious when approaching a chest that may not have been there before. A dangerous beast resembling a chest can rarely be found lying in wait, and if dealt with carefully will reward you with powerful items. A neat trick to tell a real chest from a fake is to examine it on your map screen. ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			// Only appears until plantera is defeated, or is done already
			if (!expedition.completed && NPC.downedPlantBoss) return false;

			// Appears once hardmode quest chain starts
			return API.FindExpedition<CAHardMode>(mod).completed;
		}

		public override void OnKillNPC(NPC npc, Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!expedition.condition1Met) expedition.condition1Met = npc.type == NPCID.Mimic;
		}

		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			return cond1;
		}
	}
}
