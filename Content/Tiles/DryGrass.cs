using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;
using CatharsisReborn.Content.Tiles.Plants;

namespace CatharsisReborn.Content.Tiles
{
    public class DryGrass : ModTile
    {
        public override string Texture => "Terraria/Images/Tiles_2_Beach";
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Grass"]);

            TileID.Sets.Grass[Type] = true;
            TileID.Sets.CanBeDugByShovel[Type] = true;
            TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            DustType = ModContent.DustType<Dusts.DryGrassDust>();
            RegisterItemDrop(ItemID.DirtBlock);
            AddMapEntry(new Color(176, 204, 40));
        }

        int animationFrameWidth = 288;

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            Tile up = Main.tile[i, j - 1];
            Tile up2 = Main.tile[i, j - 2];

            if (WorldGen.genRand.NextBool(10) && !up.HasTile && !up2.HasTile && !(up.LiquidAmount > 0 && up2.LiquidAmount > 0) && !tile.LeftSlope && !tile.RightSlope && !tile.IsHalfBlock)
            {
                up.TileType = (ushort)ModContent.TileType<DryGrassTallPlants>();
                up.HasTile = true;
                up.TileFrameY = 0;

                //11 different frames, choose a random one
                up.TileFrameX = (short)(WorldGen.genRand.Next(11) * 18);
                WorldGen.SquareTileFrame(i, j - 1, true);

                if (Main.dedServ)
                {
                    NetMessage.SendTileSquare(-1, i, j - 1, 3, TileChangeType.None);
                }
            }
            //place Astral Short Grass
            if (WorldGen.genRand.NextBool(10) && !up.HasTile && !up2.HasTile && !(up.LiquidAmount > 0 && up2.LiquidAmount > 0) && !tile.LeftSlope && !tile.RightSlope && !tile.IsHalfBlock)
            {
                up.TileType = (ushort)ModContent.TileType<DryGrassShortPlants>();
                up.HasTile = true;
                up.TileFrameY = 0;

                //11 different frames, choose a random one
                up.TileFrameX = (short)(WorldGen.genRand.Next(11) * 18);
                WorldGen.SquareTileFrame(i, j - 1, true);

                if (Main.dedServ)
                {
                    NetMessage.SendTileSquare(-1, i, j - 1, 3, TileChangeType.None);
                }
            }
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].TileType = (ushort)TileID.Dirt;
            }
        }
    }
}