using System;
using System.IO;
using System.Text.Json;

namespace The590Box
{
    internal class UserConfig
    {
        private static readonly string ConfigPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "The590Box",
            "user.config");

        private static UserConfig? _default;
        public static UserConfig Default => _default ??= Load();

        public string LastPort        { get; set; } = "";
        public int    WindowLeft      { get; set; } = -1;
        public int    WindowTop       { get; set; } = -1;
        public int    WindowWidth     { get; set; } = -1;
        public int    WindowHeight    { get; set; } = -1;
        public bool   IsPositionSaved { get; set; } = false;
        public int    StepIndexA      { get; set; } = 2;
        public int    StepIndexB      { get; set; } = 2;

        private static UserConfig Load()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    string json = File.ReadAllText(ConfigPath);
                    return JsonSerializer.Deserialize<UserConfig>(json) ?? new UserConfig();
                }
            }
            catch { }
            return new UserConfig();
        }

        public void Save()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath)!);
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigPath, json);
            }
            catch { }
        }
    }
}
