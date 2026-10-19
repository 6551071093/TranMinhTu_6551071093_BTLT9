using App_QuanLyChiTieu;
using App_QuanLyChiTieu.Configurations;
using Microsoft.Extensions.Configuration;
using Serilog;
using App_QuanLyChiTieu.Configurations;
using System;
using System.IO;
using System.Windows.Forms;

namespace SoChiTieu_App
{
    internal static class Program
    {
        // Biến toàn cục lưu cấu hình đã đọc để toàn bộ App sử dụng
        public static AppSettings ConfigurationSettings { get; private set; } = new();

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. CẤU HÌNH SERILOG GHI THEO NGÀY VÀO THƯ MỤC Logs
            string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    path: Path.Combine(logFolder, "log-.txt"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            try
            {
                // 2. ĐỌC FILE CẤU HÌNH APPSETTINGS (Hỗ trợ ghi đè bằng Development)
                var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                    .Build();

                // Bind dữ liệu vào class Strongly-Typed
                ConfigurationSettings = config.Get<AppSettings>() ?? new AppSettings();

                Log.Information("=== Ứng dụng Sổ Chi Tiêu khởi động thành công ===");

                Application.Run(new FormChiTieu());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Lỗi nghiêm trọng khi khởi động ứng dụng!");
                MessageBox.Show("Không thể khởi động ứng dụng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.CloseAndFlush(); // Giải phóng và ghi hết log trước khi đóng ứng dụng
            }
        }
    }
}