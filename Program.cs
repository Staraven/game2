using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ConsoleGameEngine.Library.Concrete.Engine;
using ConsoleGameEngine.Library.Concrete.Game;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleGameEngine.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JToken configJson = JsonConvert.DeserializeObject<JToken>(
                                    File.ReadAllText(
                                        Path.Combine("Config.json")));
            int FPS = configJson.Value<int>("FPS");
            int UIWidth = configJson.Value<int>("UIWidth");
            int UIHeight = configJson.Value<int>("UIHeight");
            int UIBorderSize = configJson.Value<int>("UIBorderSize");

            // Services
            ValidationService validationService = new ValidationService();
            GameEngine gameEngine = new GameEngine();
            RenderService renderService = new RenderService()
            {
                FPS = FPS
            };

            // Game
            UIEngine ui = new UIEngine()
            {
                Width = UIWidth,
                Height = UIHeight,
                BorderSize = UIBorderSize,
            };

            // Initialize
            validationService.Initialize(ui);
            gameEngine.Initialize(validationService, ui);
            renderService.Initialize(validationService, ui, gameEngine);

            Map map = new Map(gameEngine, ui.Width, ui.Height);
            gameEngine.SetCurrentMap(map);

            var services = new ServiceCollection();

            services.AddSingleton(map);
            services.AddSingleton(validationService);
            services.AddSingleton(gameEngine);
            services.AddSingleton(renderService);
            services.AddSingleton(ui);

            ConsoleGameEngine.Main.Register(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            ConsoleGameEngine.Main.Initialize(serviceProvider);

            // // Player player = new Player(map);

            // // map.InitializeGameObject(new Message(map, 0, map.Height - 3)
            // // {
            // //     Text = () => $" Score: {player.Score}  {Environment.NewLine} FPS:{renderService.RenderedFPS}  {Environment.NewLine} X: {player.X}, Y:{player.Y}  "
            // // });
            // // map.InitializeGameObject(new Message(map, map.Width / 2 - 8, map.Height / 2 - 1)
            // // {
            // //     Text = () => player.IsDead ? ("_______________" + Environment.NewLine + 
            // //                  ">| GAME OVER |<" + Environment.NewLine + 
            // //                  "---------------") : "\0"
            // // });
            // // map.InitializeGameObject(player);

            // Start Rendering...
            renderService.Start();

            while (true)
            {
                ConsoleKey pressedKey = Console.ReadKey(true).Key;
                gameEngine.TriggerKeyPressed(pressedKey);
            }
        }
    }
}