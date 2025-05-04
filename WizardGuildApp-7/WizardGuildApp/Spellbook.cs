using System.Collections.Generic;
using System.Linq;

namespace WizardsGuild
{
    public class Spellbook : List<MagicSpell>
    {
        public override string ToString()
        {
            if (this.Count == 0)
                return "No spells in this spellbook";

            return $"Spells:\n{string.Join("\n", this.Select(spell => spell.ToString()))}";
        }
    }
}