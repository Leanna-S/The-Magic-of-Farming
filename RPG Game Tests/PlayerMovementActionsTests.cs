using RPG_Game_Classes;
using RPG_Game_Classes.MapSquares;
using RPG_Game_Classes.MoveActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Tests
{
    public class PlayerMovementActionsTests
    {
        private RPGGame _game = new("Leanna");

        [Fact]
        public void MoveRight_CorrectlyMovesRight()
        {
            new MoveRight(_game.Player, _game).MovePlayer();
            Assert.Equal(1, _game.Player.X);
            Assert.Equal(0, _game.Player.Y);
            Assert.True(_game.Map[_game.Player.Y, _game.Player.X] is PlayerMapSquare);
        }

        [Fact]
        public void MoveLeft_CorrectlyMovesLeft()
        {
            new MoveRight(_game.Player, _game).MovePlayer();
            new MoveLeft(_game.Player, _game).MovePlayer();

            Assert.Equal(0, _game.Player.X);
            Assert.Equal(0, _game.Player.Y);
            Assert.True(_game.Map[_game.Player.Y, _game.Player.X] is PlayerMapSquare);
        }

        [Fact]
        public void MoveUp_CorrectlyMovesUp()
        {
            new MoveDown(_game.Player, _game).MovePlayer();
            new MoveUp(_game.Player, _game).MovePlayer();
            Assert.Equal(0, _game.Player.X);
            Assert.Equal(0, _game.Player.Y);
            Assert.True(_game.Map[_game.Player.Y, _game.Player.X] is PlayerMapSquare);
        }

        [Fact]
        public void MoveDown_CorrectlyMovesDown()
        {
            new MoveDown(_game.Player, _game).MovePlayer();
            Assert.Equal(0, _game.Player.X);
            Assert.Equal(1, _game.Player.Y);
            Assert.True(_game.Map[_game.Player.Y, _game.Player.X] is PlayerMapSquare);
        }

        [Fact]
        public void MoveRight_OutOfBounds_ThrowInvalidOperationException()
        {
            _game.Map = _game.CreateMap(10, 2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                new MoveRight(_game.Player, _game).MovePlayer();
                new MoveRight(_game.Player, _game).MovePlayer();
                new MoveRight(_game.Player, _game).MovePlayer();
            });
            Assert.Equal(1, _game.Player.X);
            Assert.Equal(0, _game.Player.Y);
        }

        [Fact]
        public void MoveLeft_OutOfBounds_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                new MoveLeft(_game.Player, _game).MovePlayer();
            });
            Assert.Equal(0, _game.Player.X);
            Assert.Equal(0, _game.Player.Y);
        }

        [Fact]
        public void MoveUp_OutOfBounds_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                new MoveUp(_game.Player, _game).MovePlayer();
            });
            Assert.Equal(0, _game.Player.X);
            Assert.Equal(0, _game.Player.Y);
        }

        [Fact]
        public void MoveDown_OutOfBounds_ThrowInvalidOperationException()
        {
            _game.Map = _game.CreateMap(2, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                new MoveDown(_game.Player, _game).MovePlayer();
                new MoveDown(_game.Player, _game).MovePlayer();
                new MoveDown(_game.Player, _game).MovePlayer();
            });
            Assert.Equal(0, _game.Player.X);
            Assert.Equal(1, _game.Player.Y);
        }
    }
}