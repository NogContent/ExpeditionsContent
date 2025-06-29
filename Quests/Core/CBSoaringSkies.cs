﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Core
{
	class CBSoaringSkies : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "Power of Flight";
			SetNPCHead(NPCID.Guide, false);
			expedition.difficulty = 5;
			expedition.ctgSlay = true;
			expedition.ctgImportant = true;

			expedition.conditionDescription1 = "Encounter a Wyvern";
			expedition.conditionDescription2 = "Gain the ability to fly";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardMoney(Item.buyPrice(0, 2, 0, 0));
		}
		public override string Description(bool complete)
		{
			string message = "The flying wyverns soaring above can be defeated to harvest their souls. These souls in particular contain power capable of granting flight. ";
			if (!API.FindExpedition<CBTracingSteps>(mod).condition1Met)
			{
				message += "However, you might not have the facilities to craft this kind of equipment yet. Try exploring some more first. ";
			}
			else
			{
				message += "You can combine these souls with a variety of items at an anvil to craft flying apparatus of varying power and maneuverability. ";
			}
			return message;
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			// Appears once hardmode quest chain starts
			return API.FindExpedition<CAHardMode>(mod).completed;
		}

		public override void OnCombatWithNPC(NPC npc, bool playerGotHit, Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{

			if (!expedition.condition1Met)
			{
				expedition.condition1Met =
				  npc.type == NPCID.WyvernHead ||
				  npc.type == NPCID.WyvernBody ||
				  npc.type == NPCID.WyvernBody2 ||
				  npc.type == NPCID.WyvernBody3 ||
				  npc.type == NPCID.WyvernLegs ||
				  npc.type == NPCID.WyvernTail;
			}
		}

		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			if (!cond2)
			{
				cond2 = (player.wingTimeMax > 0);
			}
			return cond2;
		}
	}
}
