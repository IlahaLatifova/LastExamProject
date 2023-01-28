namespace ExamProject.Extensions.FileManagmentExtensions
{
    public static class FileManagement
    {
        public static bool IsTrueContent(this IFormFile formFile)
        {
            if (formFile.ContentType.Contains("image"))
            {
                return true;
            }
            return false;
        }
        public static bool IsValidLength(this IFormFile formFile)
        {
            if (formFile.Length <= 2 * 1024 * 1024)
            {
                return true;
            }
            return false;
        }
        public static string CreateUrl(this IFormFile formFile,string env,string folderPath)
        {
            string fileUrl = $"{Guid.NewGuid().ToString()}{formFile.FileName}";
            string filePath = Path.Combine(env,folderPath,fileUrl);
            using(FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return fileUrl;
        }
        public static void DeleteFile(this string fileUrl,string env, string folderPath)
        {
            string filePath = Path.Combine(env, folderPath, fileUrl);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
