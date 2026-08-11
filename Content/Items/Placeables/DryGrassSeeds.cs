using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CatharsisReborn.Content.Items.Placeables
{
    public class DryGrassSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.DryGrass>());
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useAnimation = 15;
            Item.maxStack = Item.CommonMaxStack;

            Item.value = Item.buyPrice(copper: 50);
        }
    }
}