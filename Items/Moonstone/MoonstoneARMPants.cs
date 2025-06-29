﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpeditionsContent144.Items.Moonstone
{
	[AutoloadEquip(EquipType.Legs)]
	public class MoonstoneARMPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			/****DisplayName.SetDefault("Yutu Pants");
            Tooltip.SetDefault("5% increased movement speed\n"
                + "40% increased rocket flight duration");*/
		}
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.defense = 7;
			Item.rare = 3;
			Item.value = Item.sellPrice(0, 2, 40, 0);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Moonstone>(), 10);
			recipe.AddIngredient(ItemID.Silk, 4);
			recipe.AddTile(TileID.Anvils);

			recipe.Register();
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.05f;

			// Add rocket jump from pulley, grapping, or the others in the Main loop
			if (player.pulley || player.grappling[0] >= 0 ||
				player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped))
			{
				player.rocketTime += 3; // Add 3 rocket bursts (total 10)
			}
		}
	}
}
