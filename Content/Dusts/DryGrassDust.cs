using Terraria;
using Terraria.ModLoader;

namespace CatharsisReborn.Content.Dusts
{
    public class DryGrassDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.scale = Main.rand.NextFloat(0.9f, 1f);
        }
    }
}