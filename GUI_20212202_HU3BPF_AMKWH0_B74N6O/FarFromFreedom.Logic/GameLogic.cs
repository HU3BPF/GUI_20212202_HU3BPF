using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FarFromFreedom.Logic
{
    public class GameLogic : IGameLogic
    {
        public IGameModel gameModel;

        public void EnemyMove(MainCharacter character)
        {

            List<Enemy> enemies = gameModel.Enemies;
            foreach (Enemy enemy in enemies)
            {
                double x = character.Area.Rect.X - enemy.Area.Rect.X;
                double y = character.Area.Rect.Y - enemy.Area.Rect.Y;
                if (x > 0 && y > 0)
                {
                    enemy.MoveUpRight();
                }
                else if (x > 0 && y == 0)
                {
                    enemy.MoveRight();
                }
                else if (x == 0 && y > 0)
                {
                    enemy.MoveUp();
                }
                else if (x < 0 && y > 0)
                {
                    enemy.MoveUpLeft();
                }
                else if (x < 0 && y == 0)
                {
                    enemy.MoveLeft();
                }
                else if (x < 0 && y < 0)
                {
                    enemy.MoveDownLeft();
                }
                else if (x == 0 && y < 0)
                {
                    enemy.MoveDown();
                }
                else if (x > 0 && y < 0)
                {
                    enemy.MoveDownRight();
                }
            }
        }

        public void EnemyHit(MainCharacter character)
        {
            List<Enemy> enemies = gameModel.Enemies;
            foreach (Enemy enemy in enemies)
            {
                bool isCollision = enemy.IsCollision(character);
                if (isCollision)
                {
                    character.CurrentHealthDown(enemy.Power);
                }
            }
        }

        public bool GameEnd(MainCharacter character)
        {
            bool gameEnded = false;
            if (character.CurrentHealth == 0)
            {
                gameEnded = true;
            }
            return gameEnded;
        }

        public void ItemPicked(MainCharacter character)
        {
            IItem removeableItem;
            List<IItem> enemies = gameModel.Items;
            foreach (IItem item in enemies)
            {
                bool isCollision = item.IsCollision(character);
                if (isCollision)
                {
                    character.CoinUp(1);
                }
            }
        }

        public void PLayerMove(MainCharacter player)
        {
            throw new NotImplementedException();
        }

        public void PlayerShoot(MainCharacter PlayerShoot)
        {
            throw new NotImplementedException();
        }
    }
}
