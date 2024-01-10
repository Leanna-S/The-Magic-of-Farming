using System.ComponentModel;
using System.Data;
using System.Timers;
using System.Xml.Linq;
using RPG_Game_Classes.Abilities;
using RPG_Game_Classes.MapSquares;
using RPG_Game_Classes.MoveActions;
using RPG_Game_Classes.ShopItems;

namespace RPG_Game_Classes
{
    public class RPGGame
    {
        public Player Player { get; init; }
        public List<NPC> NPCs { get; init; }

        public BindingList<IShopItem> Shop { get; init; }

        public IMapSquare[,] Map { get; set; }

        // easy to access dimentions
        public readonly (int height, int width) FarmFieldDimentions = (9, 13);

        public readonly (int height, int width) MapDimentions = (12, 18);

        private Duel? _currentDuel;

        public Duel? CurrentDuel
        {
            get { return _currentDuel; }
            set
            {
                if (value != _currentDuel)
                {
                    _currentDuel = value;
                    OnDuelChange(new EventArgs());
                }
            }
        }

        // when teh current duel changes
        public event EventHandler? DuelChange;

        public event EventHandler? GameEnded;

        private void OnGameEnded(EventArgs e)
        {
            if (GameEnded != null)
            {
                GameEnded(this, e);
            }
        }

        private void OnDuelChange(EventArgs e)
        {
            if (DuelChange != null)
            {
                DuelChange(this, e);
            }
        }

        public RPGGame(string playerName)
        {
            Player = new(playerName);

            NPCs =
            [
                new NPC("Whitty Whimbleton", 4, 4, new("Gnarly 'Staff'", 3, "This 'tool' certainly has knots and looks 'gnarly' but not in the cool way. Made by Whitty Whimbleton who was clearly not a particularly good staff maker.", 3), new([new ThrowHands(true), new HolyCornyWheatpire(true), new AttackOfTheCrows(true)]), ["Hi!!! Welcome to Small Townville!!!!", $"You must be {Player.Name}!!!!! It's wonderful to meet you!!!!!!", "My name? Oh... I'm Whitty Whimbleton!!!", "You need to win farm compititions? Why?!?!?", "Oh? You're from the wizarding school?!? Me too!!! Eh well... not anymore... I was kicked out...", "You were kicked out too?!?!?! We can become great friends!!!", "No? You don't wanna be friends??!? Why?!?!", "You-you need to be the Small Town Farm Champion to rejoin the school?", "Aww shucks... Well, I guess I'll duel you", "Do... do you accept?"], ["You beat me! I knew you could!", "Do you want to be friends now?", "...yes? Yes? YES!?!?!? OMG best day ever!!!!", "You may want to duel for fun? I'd love to duel some more my great friends!"]),
                new NPC("Ferne Plantar", 7, 7, new("Ole' Reliable", 5, "A true hillbillies tool. Made from the finest scrap you've ever seen. Is that a set of garden trimmers, pitchfork, and garden hoe in one?", 2), new([new AttackOfTheCrows(true), new BeesKnees(true), new Every17Years(true), new BarberShop(true), new ThrowHands(true)]), ["Oh, uh, howdy there... I'm Ferne Plantar.", "Well, you see, I reckon plants are just a mite easier to talk to than folks.", "Plants don't judge, and they sure don't mind my awkward ramblings.", "You... you need to battle me?", "Are... are you sure?", "Oh... oh okay if... if you want...", "You sure you want to battle?"], ["Uh... you beat me... congrats", "I'm just... I'll go back to my plants...", "You want... you want to practice?", "Um... alright... I'll do it even though you beat me already.."]),
                new NPC("Horrace The Eighty-Eighth", 10, 10, new("Shucker 2000", 8, "Passed down through 88 generations of Horrace's, this tool is nothing to sneeze at. It is not only good at shucking corn, that's for sure.", 4), new([new Cornnado(true), new BeesKnees(true), new BarberShop(true), new PumpkinPatchUp(true), new Every17Years(true)]), ["Who're you?", $"Ah, {Player.Name}. Ye're the new on aren't cha?", "Me? Well my family has been tilling this land since the cows learned to moo and the chickens learned to cluck.", "Farming's in my blood, deeper than the roots of the oldest oak tree on this side of the county.", "Ye need to battle me? Ah, well I'm sure ya could learn from an old man like me!", "I'll give you some pointers. You up for the challenge?"], ["You've got some skill, kid. You really can go at it.", "Ya beat me already, but I think ya could do better.", "Get yourself some shiny new spells and remember the importance of debuffing.", "If ya do that, you'll be one mighty farmer, I'll tell ya that much.", "I'm always open if you want to try out your skills."]),
                new NPC("Raylyne Rylayday", 15, 15, new("Oblyveyan", 9, "Oblyvyan is a deadly weapon. It would be more dangerous if it didn't have some many damn Y's...", 5), new([new AttackOfTheCrows(true), new WannabeVampire(true), new Every17Years(true), new CombineAtion(true), new DragonSummoning(true)]), ["My crops and I, we have this mystical connection, like the deep darkness of the night embracing the moonlit fields, y'know?", "My yaks and ravens are like my companions in this shadowy symphony.", "We bond over mysterious moonlit evenings and, like, share secrets whispered by the restless winds.", "Not interested? How... boring.", "You could use a little dark in your life.", "You need to duel me? How... fun.", "I enjoy a little bit of bloodshed.", "Don't worry doll, I'm joking.", "You ready to face the queen of darkness?"], ["Oh, like, you totally bested me in that duel, didn't you? It's, um, fine.", "Dark forces can't win every time, I guess.", "My crops might be withering in disappointment, but, like, I'll survive, you know?", "I'll rise again like the undead, if you wanna duel again, yeah?"]),
                new NPC("Bartholemew", 22, 22, new("The White Staff of Destiny", 12, "Nobody knows much about Bartholemew. Why? Well he's very rude. He's a bit too posh for farming community which makes him an outcast. Supposedly from an ancient line of wizards (not supposedly, he annouces it at every moment), this... beautiful staff is a work of art that packs a punch.", 6), new([new Cornnado(true), new BurningDay(true), new PumpkinPatchUp(true), new CombineAtion(true), new DragonSummoning(true)]), ["Get out of my sight, scrub.", "You wanna duel?", "You know who I am? My lineage is practically royalty. You should get lost.", "You are beneath me. I should not be talking to such dirt.", "You'll get crushed by I, the greatest farmer of all time.", "You got kicked out of MITT? Pah, you're worthless. An you still believe you are worthy of my attention?", "Very well, you may earn my attention if you duel me and win.", "Just know that if you wish to fight I'll make you beg for mercy. You brought this upon yourself"], ["I can't believe you beat me! A nobody dropout like you beat me!", "I suppose you're... alright.", "I think it was luck. If you duel me again, we'll see who the true winner is."]),
                new NPC("⋪⋆⌃⍟⋇⋔⍐⋆", 30, 30, new("⸢Ω ʘ∑∂⍋⋔ 〤⍀ ", 15, "⊆⊣⋫⋠⊘ ⋉⋎⊸⋡⋉⊹⋁ ⊤⋦⊊⋕⋀⌶⍎⍈⋗⊂⌤⋋ ⊈⍍⋪⋚⋉⋖ ⊦⋆⊚⌠", 8), new([new GNOs(true), new DragonSummoning(true), new BurningDay(true), new CombineAtion(true), new WannabeVampire(true)]), ["⋙⋣⋠ ⋂⋋⊕⋚ ⋖⊲⊧⋓⋌⊃⋚⊙⋂⋇⋕⋅ ⊣⋢⋊⋘⋂⊀⋋⊚⋏⊢⋎ ⊬⋔⊄⋎⊳⊜⋍⋛⋈⊌ ⊕⋢⊞", "⋈⋐⋆⋙⋒⋠⋐⊛⋄⋄⊸⋙⊇⋛⋍⋗⋕⋉⋃⋌⋇⋃⋔⋇⋌⊆⋃⊓⋕⋅⊬⊟⋚⊛⋒⊤⋏⋃⋢⊂⋓⊑⋐⊤⋈⋔⋀⋑⋉⋌⊹", "⋡⋑⊺⋔⋣⋛⋉⋅⊰⋉ ⋌⋋⋖⊏⊡⋉⋄⋖⋓⋕⋛⋋⋅⋌⋊⊯⋓⋊⋎⋓ ⋀⊌⊸ ⊛⋋⊆⊠⋢⊉ ⋌⋂⊹⋓⋀⋇⋚⊰⋗ ⋠⊋⋋", "⊦⌣⋃⊉⋎⋎⋍⊏ ⋙⊸⋏⊙⋛⊪⊂⊸⋦⋚⊭⋜⊉", "⊤⋖⊧⋇⋛⋦⋉⋊⋧⋉⊴⊞⋍⋇⋉⋀⊹ ⊷⋑⊺⊙ ⋤⋄⋂⋑⋁⊇⋆⋉⊭⋍⊳⋊ ⊒⋤⊋⊄⊂ ⋛⊸⊓⋙⊌⊔⋆⋦⋂⋦⋖⋏⋇⋂⋊⋋⊹ ⋇⊺ ⋑⊍⋠⋦⋠⋢ ⊰⋂⋎⋇⋊⊙⊰⋇⋠ ⋄⋏⋢⋇⋅⋢⋉⊓⋘⋛"], ["⋆⊃⋅⋂⋡⋛⊉⊴⋠⋃⋗⊛⋂⊸⋗⋇⋖ ...I... ⋖⋍⋠⊅⋅⋋⋍", "⋏⋎⋊⋋⋔ ⊗⋉⋊⊬⊋⊓⋢⋗ ...will... ⋠⊷⋔⋋ ⋏⋈⋇⊐⊰⊕⋇⋌", "⋇⋉⋇⋎⋖⋆⊢⋏⊨⋄ ⋏⋊⋕⋆⋃⊳⋃⋑⋇⊯⊞⋆⋕⊔⋍⊊⋖⋑⋋⋓⋑⋍⋆⋆⋎ ...win... ⊹⊖⋆⊘ ⋆⋙⋑⋛⊱⋇⋏⋍⋄⋋⋑", "⋔⊗⋉⋊⊬⊋⊓⋢⋗ ...this... ⋠⊷⋔⋋⋏⋈⋇⊐⊰", "⋑⋋⋓⋑⋍⋆⋆...time... ⋎⊹⊖⋆⊘⋆⋙⋑", $"⋠⋉⊓⊋⋎⋋⋉⋗⋏⋅⊰⋋⋂ ...{Player.Name}... ⊙⋛⋉⋏⋖⊣⋏⋌⊊⊇⋅⊃⋑⊃"]),
            ];
            Map = CreateMap(MapDimentions.height, MapDimentions.width);

            Shop =
            [
                new EquipmentShopItem(this, 50, new("Piano", 4, "You may have disappointed your parents for getting kicked out of MITT, but at least you can try to impress them with your piano abilities.", 3)),
                new EquipmentShopItem(this, 150, new("The Wand 'Weedwhacker'", 8, "For those magical moments when your garden is more unruly than your spellbook.", 5)),
                new EquipmentShopItem(this, 450, new("Hocus Plow-cus", 14, "A wand that magically turns fields from 'meh' to 'marvelous.'", 7)),
                new AbilityShopItem(this, 25, new HolyCornyWheatpire(false)),
                new AbilityShopItem(this, 50, new AttackOfTheCrows(false)),
                new AbilityShopItem(this, 100, new Every17Years(false)),
                new AbilityShopItem(this, 100, new BeesKnees(false)),
                new AbilityShopItem(this, 125, new BarberShop(false)),
                new AbilityShopItem(this, 200, new Cornnado(false)),
                new AbilityShopItem(this, 200, new PumpkinPatchUp(false)),
                new AbilityShopItem(this, 225, new CombineAtion(false)),
                new AbilityShopItem(this, 300, new WannabeVampire(false)),
                new AbilityShopItem(this, 325, new GNOs(false)),
                new AbilityShopItem(this, 350, new BurningDay(false)),
                new AbilityShopItem(this, 400, new DragonSummoning(false)),
            ];
        }

        public void PrintStats()
        {
            //prints stats
            List<string> output = [$"Player: {Player.Name}", $"Level: {Player.Level}", $"Maximum Mana: {Player.MaximumMana}", $"Strength: {Player.Strength}"];

            output.Add($"Selected Equipment: {Player.EquippedItem}");
            foreach (IAbility ability in Player.Abilities.Where(ability => ability.Selected))
            {
                output.Add("Ability: " + ability.ToString() ?? "");
            }
            Output.AddDialogs(output.ToArray());
        }

        public void RequestDuel(NPC npc)
        {
            // creates new duel
            CurrentDuel = new(Player, npc, this);
        }

        public void EndDuel()
        {
            // sets current duel to null
            CurrentDuel = null;
            // also check for a win
            if (NPCs.All((npc) => npc.HasBeenDefeated))
            {
                OnGameEnded(new EventArgs());
            }
        }

        public void MovePlayer(IPlayerMovement moveAction)
        {
            // move player! log errors to output so user is aware
            try
            {
                moveAction.MovePlayer();
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }

        public void StartGame()
        {
            // literally just start up dialog
            Output.AddDialogs("(You can scroll down to read more!)", " Welcome! You went to the greatest wizarding school on the planet, Magicka, Institute of Talents and Trickery (MITT for short).", "Trouble is that you weren't very good - you blew up an entire wing of the castle!!", "You were kicked out, (and you honestly deserved it) and are now hoping to become the best farmer Small Townville has ever seen.", "If you beat everyone here, maybe you'll be able to reclaim your postion at MITT.", $"Small Townville has some tough compitition that you'll need to beat. I hope you're up for the challenge, {Player.Name}.");

            Output.AddDialogs("Basic Instructions:", "Your goal is to defeat all the other farmers around.", "Use the arrow buttons to move around the map!", "Make sure to harvest your farm! Click on a field when it is gold to harvest it!", "Harvesting plants will gain you experience and money to make you stronger!!!", "All abilities have interesting effects - make sure to check out your abilities and pick up to 5 abilities that fit you best.", "Check out the shop! There are lots of interesting spells to be found!", "Equipment can be bought in the shop, won from duels, or found when exploring!!");
        }

        public IMapSquare[,] CreateMap(int height, int width)
        {
            // create hidden items
            List<Equipment> hiddenEquipment =
            [
                new Equipment("Crystal of Focus", 3, "May just be one of those 'crystal girl' stones, but it's pretty and hums with your magic", 3),
                new Equipment("Scythe", 4, "You don't look quite like the grim reaper, but you sure can cut some grass", 2),
                new Equipment("1989 Best Farm Award Pin", 2, "This rusty pin gives you the confidence boost of a lifetime. You got this!", 1),
            ];

            // throw error if not enough space
            if (height < 1 || width < 1 || height * width < NPCs.Count + 1 + hiddenEquipment.Count)
            {
                throw new ArgumentException("Map too small");
            }
            Random rng = new();
            IMapSquare[,] map = new IMapSquare[height, width];

            // create player at 0,0
            map[Player.X, Player.Y] = new PlayerMapSquare(Player, new EmptyMapSquare(this, Player.X, Player.Y), this, Player.X, Player.Y);

            // generate empty map squares at empty map spots
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (map[i, j] == null)
                    {
                        map[i, j] = new EmptyMapSquare(this, j, i);
                    }
                }
            }

            // add NPC's on empty spots
            foreach (NPC npc in NPCs)
            {
                int npcX;
                int npcY;
                do
                {
                    npcX = rng.Next(width);
                    npcY = rng.Next(height);
                } while (map[npcY, npcX] is not EmptyMapSquare);
                map[npcY, npcX] = new NPCMapSquare(npc, this, npcX, npcY);
            }

            // add equipment on empty spots
            foreach (Equipment equipment in hiddenEquipment)
            {
                int equipmentX;
                int equipmentY;
                do
                {
                    equipmentX = rng.Next(width);
                    equipmentY = rng.Next(height);
                } while (map[equipmentY, equipmentX] is not EmptyMapSquare);
                map[equipmentY, equipmentX] = new HiddenItemMapSquare(this, equipmentX, equipmentY, equipment);
            }

            return map;
        }

        public void PurchaseFromShop(IShopItem item)
        {
            try
            {
                // checks if you can buy items
                if (Player.Money < item.Price)
                {
                    throw new InvalidOperationException("Money too low! Cannot make purchase.");
                }
                //buys item and removes it from shop
                Player.Money -= item.Price;
                item.Purchase();
                Shop.Remove(item);
            }
            catch (Exception ex)
            {
                Output.AddDialogs(ex.Message);
            }
        }
    }
}