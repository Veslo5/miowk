// See https://aka.ms/new-console-template for more information
using System.Numerics;
using miow;
using Raylib_cs;

Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_TRANSPARENT | ConfigFlags.FLAG_WINDOW_UNDECORATED | ConfigFlags.FLAG_WINDOW_MOUSE_PASSTHROUGH | ConfigFlags.FLAG_WINDOW_TOPMOST);

Raylib.InitWindow(800, 600, "miow");
Raylib.SetTargetFPS(30);

Raylib.SetWindowSize(Raylib.GetMonitorWidth(0) - 1, Raylib.GetMonitorHeight(0) - 1);
Raylib.SetWindowPosition(0, 0);

WinAPI.InitWinAPI();
WinAPI.HideRaylibIcon();

var catTexture = Raylib.LoadTexture("cat/cat_running.png");
var catMob = new Mob("cat", new Animation(32, 32, catTexture));

while (Raylib.WindowShouldClose() == false)
{

    // Console.WriteLine(WinAPI.GetCursorPosition().X);


    catMob.Update(Raylib.GetFrameTime());

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.BLANK);

    catMob.Draw();

    // Raylib.DrawText("Hello world", 12, 12, 20, Color.WHITE);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();