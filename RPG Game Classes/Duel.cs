using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_Game_Classes.Abilities;
using RPG_Game_Classes.FarmFields;

namespace RPG_Game_Classes
{
    public class Duel
    {
        // Duel needs player and npc
        public Player Player { get; init; }

        public NPC NPC { get; init; }

        // uses a bool to determine turn
        public bool IsPlayerTurn { get; set; }

        public RPGGame Game { get; init; }

        //event to handle when a round is played
        public event EventHandler? RoundStarted;

        // basic stat constants - basically just makes it easier if i want to change rewards
        public static readonly int DuelExperienceBaseAmount = 250;

        public static readonly int DuelMoneyBaseAmount = 10;

        // this is what triggers the event so that the Ui can detect it
        public void OnRoundStarted(EventArgs e)
        {
            if (RoundStarted != null)
            {
                RoundStarted(this, e);
            }
        }

        public Duel(Player player, NPC npc, RPGGame game)
        {
            Player = player;
            NPC = npc;
            // randomly determines whos turn it is
            IsPlayerTurn = new Random().Next(2) == 0 ? true : false;

            Game = game;
        }

        public void InvokeAbility(IAbility ability)
        {
            IPerson attacker = (IsPlayerTurn ? Player : NPC);
            IPerson defender = (IsPlayerTurn ? NPC : Player);
            // if a player can affor the ability, then perfrom abilty and reduce mana
            if (ability.CanAfford(attacker))
            {
                attacker.DecreaseMana(ability.ManaCost);
                Output.AddDialogs($"{attacker.Name} has chosen to use {ability.Name}.");

                ability.PerformAbility(attacker, defender);
            }
            else
            {
                // otherwise just print a message
                Output.AddDialogs($"{attacker.Name} cannot afford {ability.Name}. Mana too low! Skipping turn.");
            }
            //Start another duel round
            StartNextRound();
        }

        // skips turn of whoevers turn it is
        public void SkipTurn()
        {
            IPerson attacker = (IsPlayerTurn ? Player : NPC);
            Output.AddDialogs($"{attacker.Name} skipped turn!");
            StartNextRound();
        }

        private void StartNextRound()
        {
            // changes turn and runs round
            ChangeTurn();
            RunRound();
        }

        private void ChangeTurn()
        {
            IsPlayerTurn = (IsPlayerTurn ? false : true);
        }

        private void FinishDuel()
        {
            //determines if NPC or player is dead
            bool playerAlive = Player.Fields.Any((field) => !field.IsDead);
            bool npcAlive = NPC.Fields.Any((field) => !field.IsDead);

            Output.AddDialogs($"Duel Ended. {(playerAlive ? Player.Name : NPC.Name)} has won!");

            // gives rewards depending if you won or not
            if (playerAlive)
            {
                PlayerWonDuel();
            }
            else
            {
                NPCWonDuel();
            }

            // sets all fields back to non-duel mode so you can once again farm them
            foreach (IFarmField field in Player.Fields)
            {
                ((PlayerFarmField)field).NotInDuel();
            }

            // let game know to end duel
            Game.EndDuel();
        }

        private void NPCWonDuel()
        {
            Output.AddDialogs($"You lost the duel. +{DuelExperienceBaseAmount}exp, +{DuelMoneyBaseAmount} coins");
            Player.AddExperience(DuelExperienceBaseAmount);
            Player.Money += DuelMoneyBaseAmount;
        }

        private void PlayerWonDuel()
        {
            Output.AddDialogs($"You won the duel! + {NPC.Level * DuelExperienceBaseAmount}exp, + {NPC.Level * DuelMoneyBaseAmount} coins");
            Player.AddExperience(NPC.Level * DuelExperienceBaseAmount);
            Player.Money += NPC.Level * DuelMoneyBaseAmount;

            // if the npc has never been defeated
            if (!NPC.HasBeenDefeated)
            {
                NPC.HasBeenDefeated = true;
                Output.AddDialogs($"You won {NPC.Name}'s equipment!", $"{NPC.EquippedItem}");
                Player.Equipment.Add(NPC.EquippedItem);
            }
        }

        public void RunRound()
        {
            bool playerAlive = Player.Fields.Any((field) => !field.IsDead);
            bool npcAlive = NPC.Fields.Any((field) => !field.IsDead);

            // if NPC or player has all dead fields, end duel
            if (!playerAlive || !npcAlive)
            {
                FinishDuel();
                return;
            }

            // otherwise, send out event
            OnRoundStarted(new EventArgs());
            // run round, NPC's get a delay for more 'realisticness'
            if (!IsPlayerTurn)
            {
                Thread.Sleep(2000);
                RegenerateMana(NPC);
                InvokeAbility(NPC.GetAbility());
            }
            else
            {
                // for the player, the next round wont trigger unless an abily has been chosen or the round has been skipped
                // in any case, regen mana
                RegenerateMana(Player);
            }
        }

        private void RegenerateMana(IPerson person)
        {
            person.IncreaseMana(person.Level + person.EquippedItem.ManaRegeneration);
        }

        private void ResetField(IFarmField field)
        {
            // resets a field for duel start
            field.IsDead = false;
            field.Health = field.MaxHealth;
            field.SetColorByHealth();
        }

        public void StartDuel()
        {
            IPerson attacker = (IsPlayerTurn ? Player : NPC);

            // sets up fields for duel
            foreach (IFarmField field in Player.Fields)
            {
                ((PlayerFarmField)field).InDuel();
                ResetField(field);
            }

            foreach (IFarmField field in NPC.Fields)
            {
                ResetField(field);
            }

            //resets mana
            Player.CurrentMana = Player.MaximumMana;
            NPC.CurrentMana = NPC.MaximumMana;

            // starts duel
            Output.AddDialogs($"The duel has begun! {attacker.Name} has the first turn!");
            RunRound();
        }
    }
}