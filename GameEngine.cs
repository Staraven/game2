using System;
using ConsoleGameEngine.Library.Concrete.Game;
using ConsoleGameEngine.Library.Interface.Game;

namespace ConsoleGameEngine.Library.Concrete.Engine
{
    public class GameEngine
    {
        public const int AnimationMillisecondInterval = 50;
        public ValidationService ValidationService { get; private set; }
        public UIEngine UIEngine { get; private set; }
        public Map CurrentMap { get; private set; }

        public bool Paused => !ValidationService.ValidateConsoleSize();

        public void Initialize(ValidationService validationService, UIEngine uiEngine)
        {
            this.ValidationService = validationService;
            this.UIEngine = uiEngine;
        }

        public void SetCurrentMap(Map map)
        {
            this.CurrentMap = map;
        }

        public void TriggerUpdate()
        {
            if (this.CurrentMap == null)
            {
                return;
            }

            List<IGameObject> gameObjects = (List<IGameObject>)this.CurrentMap.GameObjects;
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = (GameObject)gameObjects[i];

                if (gameObject.IsDisposed)
                {
                    gameObjects.RemoveAt(i);
                    i--;
                    continue;
                }

                if (gameObject is IGravity)
                {
                    IGravity gravity = (IGravity)gameObject;
                    if (!gravity.GravityDisabled)
                    {
                        if (gameObject.IsFalling)
                        {
                            if ((DateTime.UtcNow - gravity.FallingSetOn).TotalMilliseconds > AnimationMillisecondInterval)
                            {
                                gameObject.Move(0, -1);
                                gravity.FallingSetOn = DateTime.UtcNow;
                            }
                        }
                    }
                }
            }


            this.CurrentMap.TriggerUpdate();
        }

        public void TriggerKeyPressed(ConsoleKey key)
        {
            if (this.CurrentMap == null)
            {
                return;
            }

            IGameObject[] gameObjects = this.CurrentMap.GameObjects.ToArray();
            foreach (IGameObject gameObject in gameObjects)
            {
                gameObject.OnKeyPressed(key);
            }
        }

        public void Log(string text)
        {
            string prev = File.Exists("log.txt") ? File.ReadAllText("log.txt") : "";
            File.WriteAllText("log.txt", text + Environment.NewLine + prev);
        }
    }
}