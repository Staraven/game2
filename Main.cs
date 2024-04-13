using System;
using ConsoleGameEngine.Concrete;
using ConsoleGameEngine.Interface;
using ConsoleGameEngine.Library.Concrete.Game;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleGameEngine
{
    public static class Main
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IPlayer>((serviceProvider) => new Player(serviceProvider.GetService<Map>()));
            services.AddTransient<IXBlock>((serviceProvider) => new XBlock(serviceProvider.GetService<Map>()));
            services.AddTransient<IYBlock>((serviceProvider) => new YBlock(serviceProvider.GetService<Map>()));
            services.AddTransient<IStar>((serviceProvider) => new Star(serviceProvider.GetService<Map>()));
            services.AddTransient<IDoor>((serviceProvider) => new Door(serviceProvider.GetService<Map>()));
            services.AddTransient<IDoor2>((serviceProvider) => new Door2(serviceProvider.GetService<Map>()));



        }

        public static void AddXBlock(IServiceProvider serviceProvider, Map map, int startX, int y, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                IXBlock xblockTop = serviceProvider.GetService<IXBlock>();
                xblockTop.X = startX + i * xblockTop.Width;
                xblockTop.Y = y;
                xblockTop.BlockType = i % 2;
                map.InitializeGameObject(xblockTop);
            }
        }

        public static void AddYBlock(IServiceProvider serviceProvider, Map map, int x, int startY, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                IYBlock yblockTop = serviceProvider.GetService<IYBlock>();
                yblockTop.X = x;
                yblockTop.Y = startY + i * yblockTop.Height;
                yblockTop.BlockType = i % 2;
                map.InitializeGameObject(yblockTop);
            }
        }

        public static void Initialize(IServiceProvider serviceProvider)
        {
            Map map = serviceProvider.GetService<Map>();

            IPlayer player = serviceProvider.GetService<IPlayer>();
            map.InitializeGameObject(player);

            for (int i = 0; i < 100; i++)
            {
                IXBlock xblockTop = serviceProvider.GetService<IXBlock>();
                xblockTop.X = i * xblockTop.Width;
                xblockTop.Y = map.Height - xblockTop.Height;
                xblockTop.BlockType = i % 2;
                map.InitializeGameObject(xblockTop);
            }

            AddXBlock(serviceProvider, map, 0, map.Height - 1, 100);
            AddXBlock(serviceProvider, map, 0, 0, 100);
            AddYBlock(serviceProvider, map, 3, 1, 5);
            AddXBlock(serviceProvider, map, 4, 15, 7);
            AddYBlock(serviceProvider, map, 29, 4, 5);
            AddYBlock(serviceProvider, map, 25, 4, 4);
            AddXBlock(serviceProvider, map, 29, 4, 5);
            AddXBlock(serviceProvider, map, 8, 4, 6);
            AddYBlock(serviceProvider, map, 8, 4, 3);  
            AddXBlock(serviceProvider, map, 10, 12, 3);
            AddYBlock(serviceProvider, map, 43, 4, 4);  
            AddYBlock(serviceProvider, map, 51, 1, 5);  
            AddXBlock(serviceProvider, map, 33, 15, 3);
            AddXBlock(serviceProvider, map, 57, 3, 4); ;
            AddXBlock(serviceProvider, map, 57, 4, 4); ;




            IDoor door1 = serviceProvider.GetService<IDoor>();
            door1.X = 29;
            door1.Y = 1;
            door1.Height = 3;
            map.InitializeGameObject(door1);

            IStar star1 = serviceProvider.GetService<IStar>();
            star1.X = 16;
            star1.Y = 7;
            star1.Door = door1;
            map.InitializeGameObject(star1);

            IDoor door2 = serviceProvider.GetService<IDoor>();
            door2.X = 51;
            door2.Y = 16;
            door2.Height = 3;
            map.InitializeGameObject(door2);

            IStar star2 = serviceProvider.GetService<IStar>();
            star2.X = 33;
            star2.Y = 6;
            star2.Door = door2;
            map.InitializeGameObject(star2);

            IDoor door3 = serviceProvider.GetService<IDoor>();
            door3.X = 54;
            door3.Y = 5;
            door3.Height = 10;
            map.InitializeGameObject(door3);

            IDoor door5 = serviceProvider.GetService<IDoor>();
            door5.X = 58;
            door5.Y = 5;
            door5.Height = 10;
            map.InitializeGameObject(door5);

            
            IDoor door4 = serviceProvider.GetService<IDoor>();
            door4.X = 57;
            door4.Y = 5;
            door4.Height = 10;
            map.InitializeGameObject(door4);

            IStar star3 =serviceProvider.GetService<IStar>();
            star3.X=68;
            star3.Y=17;
            star3.Door=door3;
            
            map.InitializeGameObject(star3);

             IDoor door6 = serviceProvider.GetService<IDoor>();
            door6.X = 59;
            door6.Y = 5;
            door6.Height = 10;
            map.InitializeGameObject(door6);

            IDoor door7 = serviceProvider.GetService<IDoor>();
            door7.X = 64;
            door7.Y = 5;
            door7.Height = 10;
            map.InitializeGameObject(door7);

            IDoor door8 = serviceProvider.GetService<IDoor>();
            door8.X = 63;
            door8.Y = 5;
            door8.Height = 10;
            map.InitializeGameObject(door8);

             IDoor door9 = serviceProvider.GetService<IDoor>();
            door9.X = 60;
            door9.Y = 5;
            door9.Height = 10;
            map.InitializeGameObject(door9);

            IDoor door10 = serviceProvider.GetService<IDoor>();
            door10.X = 61;
            door10.Y = 5;
            door10.Height = 10;
            map.InitializeGameObject(door10);

            IDoor door11 = serviceProvider.GetService<IDoor>();
            door11.X = 62;
            door11.Y = 5;
            door11.Height = 10;
            map.InitializeGameObject(door11);

            IDoor door12 = serviceProvider.GetService<IDoor>();
            door12.X = 65;
            door12.Y = 5;
            door12.Height = 10;
            map.InitializeGameObject(door12);

            IDoor door13 = serviceProvider.GetService<IDoor>();
            door13.X = 66;
            door13.Y = 5;
            door13.Height = 10;
            map.InitializeGameObject(door13);

             IDoor door14 = serviceProvider.GetService<IDoor>();
            door14.X = 67;
            door14.Y = 5;
            door14.Height = 10;
            map.InitializeGameObject(door14);

             IDoor door15 = serviceProvider.GetService<IDoor>();
            door15.X = 68;
            door15.Y = 5;
            door15.Height = 10;
            map.InitializeGameObject(door15);

            IDoor door16 = serviceProvider.GetService<IDoor>();
            door16.X = 69;
            door16.Y = 5;
            door16.Height = 10;
            map.InitializeGameObject(door16);

            IDoor2 door17 = serviceProvider.GetService<IDoor2>();
            door17.X = 68;
            door17.Y = 1;
            door17.Height = 2;
            map.InitializeGameObject(door17);


            






            


          

            

            
           

            

            

            
        }
    }
}