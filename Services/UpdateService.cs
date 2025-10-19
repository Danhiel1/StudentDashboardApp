using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace StudentDashboardApp.Services
{
    public class UpdateInfo
    {
        public string version { get; set; }
        public string changelog { get; set; }
        public string download_url { get; set; }
    }

    public class UpdateService
    {
        private readonly string _urlVersionJson;

        public UpdateService(string urlVersionJson)
        {
            _urlVersionJson = urlVersionJson;
        }

        public async Task<UpdateInfo> GetRemoteUpdateInfoAsync()
        {
            using (var http = new HttpClient())
            {
                http.Timeout = TimeSpan.FromSeconds(10);
                var resp = await http.GetAsync(_urlVersionJson);
                resp.EnsureSuccessStatusCode();

                var json = await resp.Content.ReadAsStringAsync();
                var info = JsonSerializer.Deserialize<UpdateInfo>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return info;
            }
        }

        /// <summary>
        /// So sánh version hiện tại và version mới. Nếu mới > hiện tại, trả về true.
        /// Giả sử version theo dạng “major.minor.patch”.
        /// </summary>
        public bool IsNewVersion(string currentVersion, string remoteVersion)
        {
            try
            {
                var vCur = Version.Parse(currentVersion);
                var vRem = Version.Parse(remoteVersion);
                return vRem > vCur;
            }
            catch
            {
                // Nếu parse lỗi, ta mặc định không cập nhật
                return false;
            }
        }
    }
}
