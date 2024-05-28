using FlowerClient.model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

internal static class TokenParameters
{
    public static DateTime? Lifetime() // находим время истечения жизни токена
    {
        string token = Header.headers.AccessToken; // access token

        // Создаем объект JwtSecurityTokenHandler для чтения токена
        var tokenHandler = new JwtSecurityTokenHandler();

        // Проверяем, является ли токен валидным JWT токеном
        if (tokenHandler.CanReadToken(token))
        {
            // Читаем токен
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Извлекаем дату истечения срока действия (exp) токена
            var expirationDateUnix = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "exp")?.Value;
            if (expirationDateUnix != null)
            {
                // Преобразуем Unix время в DateTime
                var expirationDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(expirationDateUnix)).UtcDateTime;
                Console.WriteLine(expirationDate);
                return expirationDate;
            }
            else
            {
                Console.WriteLine("Срок действия токена не найден.");
                return null;
            }
        }
        else
        {
            Console.WriteLine("Некорректный JWT токен.");
            return null;
        }
    }

    public static string GetRoleFromToken() // Метод для получения роли пользователя из токена
    {
        // Получаем токен доступа из заголовка
        string token = Header.headers.AccessToken;

        try
        {
            // Создаем обработчик для работы с JWT токенами
            var handler = new JwtSecurityTokenHandler();

            // Читаем токен как JWT токен
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            // Проверяем, удалось ли прочитать токен
            if (jsonToken == null)
            {
                // Если токен не является действительным JWT токеном, выбрасываем исключение
                throw new ArgumentException("Invalid JWT token");
            }

            // Ищем в токене claim с типом 'role'
            var roleClaim = jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            // Возвращаем значение claim 'role', если он найден; иначе возвращаем null
            return roleClaim?.Value;
        }
        catch (Exception ex)
        {
            // Обрабатываем исключения или логируем ошибки
            throw new InvalidOperationException("Error extracting role from token", ex);
        }
    }
}