using FarFromFreedom.Model;
using FarFromFreedom.Model.Characters;
using FarFromFreedom.Model.Items;
using FarFromFreedom.Renderer;
using FarFromFreedom.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace FarFromFreedom.Logic
{
    public class GameLogic : IGameLogic
    {
        public int CurrentRoom => currentRoom;
        public int CurrentLevel => currentLevel;

        private IGameModel gameModel;
        private IFarFromFreedomRepository farFromFreedomRepository;
        private int currentRoom = -1;
        private int currentLevel = 0;

        public GameLogic(IGameModel gameModel)
        {
            this.gameModel = gameModel;
        }
        public GameLogic(int levels, string fileName)
        {
            farFromFreedomRepository = new FarFromFreedomRepository(levels, fileName);
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

        public bool EnemyIsCollision(Queue<Enemy> queue, Enemy enemy)
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
                gameModel.Character.HighscoreUp(removableEnemy.Highscore);
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

        public void GameSave(string fileName)
        {
            this.farFromFreedomRepository.SaveGame(gameModel, fileName);
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
                    ItemPickerHelper(item);
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
            if (key == Key.Up)
            {
                gameModel.Character.MoveUp();
                DirectionChangerHelper(Direction.Up);
            }
            else if (key == Key.Left)
            {
                gameModel.Character.MoveLeft();
                DirectionChangerHelper(Direction.Left);
            }
            else if (key == Key.Right)
            {
                gameModel.Character.MoveRight();
                DirectionChangerHelper(Direction.Right);
            }
            else if (key == Key.Down)
            {
                gameModel.Character.MoveDown();
                DirectionChangerHelper(Direction.Down);
            }
            gameModel.Character.CharacterMoved = true;
        }

        public int PlayerShoot(Key key, int counter)
        {
            if (Key.W == key)
            {
                Bullet bullet = new Bullet(this.gameModel.Character.Area.Rect, Direction.Up);
                gameModel.Character.DirectionHelper.DirectionChanger(Direction.Up);
                gameModel.bullets.Add(bullet);
                return 0;
            }
            else if (Key.S == key)
            {
                Bullet bullet = new Bullet(this.gameModel.Character.Area.Rect, Direction.Down);
                gameModel.Character.DirectionHelper.DirectionChanger(Direction.Down);
                gameModel.bullets.Add(bullet);
                return 0;
            }
            else if (Key.A == key)
            {
                Bullet bullet = new Bullet(this.gameModel.Character.Area.Rect, Direction.Left);
                gameModel.Character.DirectionHelper.DirectionChanger(Direction.Left);
                gameModel.bullets.Add(bullet);
                return 0;
            }
            else if (Key.D == key)
            {
                Bullet bullet = new Bullet(this.gameModel.Character.Area.Rect, Direction.Right);
                gameModel.Character.DirectionHelper.DirectionChanger(Direction.Right);
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
                else if (bullet.Direction == Direction.Down)
                {
                    bullet.MoveDown();
                }
                else if (bullet.Direction == Direction.Left)
                {
                    bullet.MoveLeft();
                }
                else if (bullet.Direction == Direction.Right)
                {
                    bullet.MoveRight();
                }
            }
        }

        public void HighscoreUp(double highscore)
        {
            this.gameModel.Character.HighscoreUp(highscore);
        }

        public IGameModel GameLoad(string fileName)
        {
            return farFromFreedomRepository.LoadGame(fileName);
        }

        public void levelUp()
        {
            this.currentLevel++;
        }

        public void RoomUp()
        {
            ++this.currentRoom;
            this.RoomLooder();
        }

        public void RoomDown()
        {
            --this.currentRoom;
            this.RoomLooder();
        }

        private void DirectionChangerHelper(Direction direction)
        {
            if (direction != gameModel.Character.DirectionHelper.Direction)
            {
                gameModel.Character.DirectionHelper.DirectionChanger(direction);
            }
        }

        private void ItemPickerHelper(IItem item)
        {
            if (item.GetType() == typeof(Hearth))
            {
                Hearth hearth = (Hearth)item;
                gameModel.Character.CurrentHealthUp(hearth.Health);
            }
            else if (item.GetType() == typeof(Bomb))
            {
                Bomb bomb = (Bomb)item;
            }
            else if (item.GetType() == typeof(Bootle))
            {
                Bootle bootle = (Bootle)item;
                gameModel.Character.PowerUp(bootle.Power);
            }
            else if (item.GetType() == typeof(Coin))
            {
                Coin coin = (Coin)item;
                gameModel.Character.CoinUp(coin.Value);
            }
            else if (item.GetType() == typeof(Money))
            {
                Money money = (Money)item;
                gameModel.Character.CoinUp(money.Value);
            }
            else if (item.GetType() == typeof(Hearth))
            {
                Shield shield = (Shield)item;
                gameModel.Character.HealthUp(shield.Armor);
            }
            else if (item.GetType() == typeof(Star))
            {
                Star star = (Star)item;
                gameModel.Character.PowerUp(star.Power);
            }
        }

        private void RoomLooder() => gameModel = farFromFreedomRepository.GameModelMap[currentLevel][currentRoom];
    }
}
