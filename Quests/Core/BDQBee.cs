﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Core
{
	class BDQBee : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Royal Beeatdown";
			SetNPCHead(NPCID.Guide, false);
			expedition.difficulty = 3;
			expedition.ctgSlay = true;
			expedition.ctgImportant = true;

			expedition.conditionDescription1 = "Face the hive guardian";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardMoney(Item.buyPrice(0, 2, 0, 0));
			AddRewardItem(ItemID.HoneyChest);
		}
		public override string Description(bool complete)
		{
			return "The giant bee hives of the jungle each contain a delicate larva. Slaying it will anger the dangerous queen of the hive, so make sure to prepare yourself before diving in. Should you be up for the challenge, the queen carries some very interesting potential rewards if you favor allies in combat. ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (cond1)
			{ expedition.conditionDescription2 = "Defeat the Queen Bee"; }
			else
			{ expedition.conditionDescription2 = ""; }

			// Only appears until hardmode, or is done already
			if (!expedition.completed && Main.hardMode) return false;

			// Appears once the second main boss is defeated or turned in
			return API.FindExpedition<BCBoss2>(mod).completed || NPC.downedBoss2;
		}

		public override void OnCombatWithNPC(NPC npc, bool playerGotHit, Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!expedition.condition1Met)
				expedition.condition1Met = npc.type == NPCID.QueenBee;
		}

		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (cond1 && !cond2)
			{
				cond2 = NPC.downedQueenBee;
			}
			return cond1 && cond2;
		}
	}
}
