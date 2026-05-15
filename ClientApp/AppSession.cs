namespace ClientApp
{
    public static class AppSession
    {
        // 🌟 เปลี่ยนจาก { get; } เป็น { get; private set; } เพื่อให้เขียนค่าใหม่ได้จากภายในคลาส
        public static string SessionId { get; private set; } = System.Guid.NewGuid().ToString();

        // 🌟 เพิ่มฟังก์ชันสำหรับสุ่มรหัสใหม่
        public static void ResetSession()
        {
            SessionId = System.Guid.NewGuid().ToString();
        }
    }
}