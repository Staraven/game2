using System;
using System.ComponentModel;
using ConsoleGameEngine.Library.Concrete.Engine;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Library.Concrete.Game
{
    public class Map
    {
        private List<IGameObject> gameObjects = new List<IGameObject>();
        public IEnumerable<IGameObject> GameObjects => this.gameObjects;
        public IEnumerable<Sprite> GameObjectSprites => gameObjects.SelectMany(o => o.Sprites).ToArray();
        public int CameraX { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public GameEngine GameEngine { get; private set; }

        public Map(GameEngine gameEngine, int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.GameEngine = gameEngine;
        }

        public void TriggerUpdate()
        {
            foreach (IGameObject gameObject in this.gameObjects)
            {
                gameObject.OnUpdated();
            }
        }

        public void InitializeGameObject(IGameObject gameObject)
        {
            this.gameObjects.Add(gameObject);

            gameObject.OnInitialized();
        }

        public void DisposeGameObject(IGameObject gameObject)
        {
            gameObject.IsDisposed = true;

            gameObject.OnDisposed();

            this.gameObjects.Remove(gameObject);
        }
    }
}