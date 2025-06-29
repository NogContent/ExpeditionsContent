﻿using System;
using Terraria;
using Terraria.ID;
using Expeditions144;

namespace ExpeditionsContent144.Quests.Core
{
	class ACHouseHome : ModExpedition
	{
		public override void SetDefaults()
		{
			expedition.name = "A Place To Call Home";
			SetNPCHead(NPCID.Guide, false);
			expedition.difficulty = 0;
			expedition.ctgExplore = true;

			expedition.conditionDescription1 = "Use a bed to set your spawn point";
		}
		public override void AddItemsOnLoad()
		{
			AddRewardItem(ItemID.RecallPotion, 3);
		}
		public override string Description(bool complete)
		{
			return "Did you know you can change your spawn point using a bed? You can craft them out of wood and silk at a sawmill, the silk itself crafted from cobwebs at a loom. Both require wood, and the sawmill also requires iron and chains. ";
		}

		public override bool CheckPrerequisites(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCount)
		{
			return API.FindExpedition<ABStartTown>(mod).completed;
		}

		public override bool CheckConditions(Player player, ref bool cond1, ref bool cond2, ref bool cond3, bool condCont)
		{
			if (!cond1)
			{
				if (Main.time % 60 == 0)
				{
					// Code from FindSpawn() in player.cs
					for (int i = 0; i < 200; i++)
					{
						if (player.spN[i] == null)
						{
							// Reached the end of array
							cond1 = false;
							break;
						}
						if (player.spN[i] == Main.worldName && player.spI[i] == Main.worldID)
						{
							cond1 = true;
							break;
						}
					}
				}
			}
			return cond1;
		}
	}
}
