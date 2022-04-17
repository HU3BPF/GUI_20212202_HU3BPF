﻿using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Items;
using FarFromFreedom.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace FarFromFreedom.Logic
{
    public class GameLogic : FarFromFreedomRepository
    {
        private IGameModel gameModel;

        public GameLogic(IGameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public GameLogic()
        {

        }
        public void EnemyMove()
        {
            MainCharacter character = gameModel.Character;
            Enemy enemy;
            Queue<Enemy> queue = new Queue<Enemy>();
            foreach (Enemy enemyAdd in gameModel.Enemies)
            {
                queue.Enqueue(enemyAdd);
            }

            while (queue.Count > 0)
            {
                enemy = queue.Dequeue();

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

        public bool EnemyIsCollision(Queue<Enemy> queue,Enemy enemy)
        {
            for (int i = 0; i < queue.Count; i++)
            {
                Enemy enemyCollision = queue.Dequeue();
                if (enemyCollision.IsCollision(enemy))
                {
                    enemyCollision.MoveUpLeft();
                    enemy.MoveDownRight();
                    return true;
                }
                else
                {
                    queue.Enqueue(enemyCollision);
                }
            }
            return false;
        }

        public void EnemyDestroy()
        {
            Enemy removableEnemy = null;
            foreach (Enemy enemy in gameModel.Enemies)
            {
                if (enemy.CurrentHealth <= 0)
                {
                    removableEnemy = enemy;
                }
            }
            if (removableEnemy != null)
            {
                gameModel.Enemies.Remove(removableEnemy);
            }
        }

        public void EnemyDamaged()
        {
            Bullet removeableBullet = null;
            List<int> indexes = new List<int>();

            foreach (var enemy in gameModel.Enemies)
            {
                foreach (var bullet in gameModel.bullets)
                {
                    bool isCollision = bullet.IsCollision(enemy);
                    if (isCollision)
                    {
                        enemy.CurrentHealthDown(gameModel.Character.Power);
                        removeableBullet = bullet;
                    }
                }
                if (removeableBullet != null)
                {
                    gameModel.bullets.Remove(removeableBullet);
                    removeableBullet = null;
                }
            }
        }

        public void EnemyHit()
        {
            foreach (Enemy enemy in gameModel.Enemies)
            {
                bool isCollision = enemy.IsCollision(gameModel.Character);
                if (isCollision)
                {
                    gameModel.Character.CurrentHealthDown(enemy.Power);
                }
            }
        }

        public bool GameEnd()
        {
            MainCharacter character = gameModel.Character;
            bool gameEnded = false;
            if (character.CurrentHealth <= 0)
            {
                gameEnded = true;
            }
            return gameEnded;
        }

        public void ItemPicked()
        {
            IItem itemPicked = null;
            foreach (IItem item in gameModel.Items)
            {
                bool isCollision = item.IsCollision(gameModel.Character);
                if (isCollision)
                {
                    gameModel.Character.CoinUp(1);
                    itemPicked = item;
                }
            }
            if (itemPicked != null)
            {
                gameModel.Items.Remove(itemPicked);
            }
        }

        public void PLayerMove(Key key)
        {
            if (key == Key.W)
            {
                gameModel.Character.MoveUp();
                DirectionChangerHelper(Direction.Up);
            }
            else if (key == Key.A)
            {
                gameModel.Character.MoveLeft();
                DirectionChangerHelper(Direction.Left);
            }
            else if (key == Key.D)
            {
                gameModel.Character.MoveRight();
                DirectionChangerHelper(Direction.Right);
            }
            else if (key == Key.S)
            {
                gameModel.Character.MoveDown();
                DirectionChangerHelper(Direction.Down);
            }
        }

        public int PlayerShoot(Key key, int counter)
        {
            if (Key.Space == key)
            {
                Bullet bullet = new Bullet(this.gameModel.Character.Area.Rect, Direction.Up);
                gameModel.bullets.Add(bullet);
                return 0;
            }
            return counter;
        }

        public void BulletMove()
        {
            List<Bullet> bullets = gameModel.bullets;

            foreach (var bullet in bullets)
            {
                if (bullet.Direction == Direction.Up)
                {
                    bullet.MoveUp();
                }
                else if(bullet.Direction == Direction.Down)
                {
                    bullet.MoveDown();
                }
                else if(bullet.Direction == Direction.Left)
                {
                    bullet.MoveLeft();
                }
                else if (bullet.Direction == Direction.Right)
                {
                    bullet.MoveRight();
                }
            }
        }

        public void PlayerShoot(MainCharacter PlayerShoot)
        {
            throw new NotImplementedException();
        }

        private void DirectionChangerHelper(Direction direction)
        {
            if (direction != gameModel.Character.DirectionHelper.Direction)
            {
                gameModel.Character.DirectionHelper.DirectionChanger(direction);
            }  
        }

        public void GameLoader()
        {
            gameModel = this.LoadGame("dobby_2022.4.17_23H46M");
        }
    }
}
